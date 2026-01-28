// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using Azure.Core;
using FluentAssertions;
using Moq;
using Npgsql;
using Testcontainers.PostgreSql;
using Xunit;
using static Microsoft.Azure.PostgreSQL.Auth.TestJwtTokenGenerator;
using static Microsoft.Azure.PostgreSQL.Auth.TestUsers;

namespace Microsoft.Azure.PostgreSQL.Auth;

/// <summary>
/// Integration tests showcasing Entra ID authentication with PostgreSQL Docker instance.
/// These tests demonstrate token-based authentication and username extraction.
/// </summary>
public class NpgsqlEntraIdExtensionTests : IAsyncLifetime
{
    private PostgreSqlContainer _postgresContainer = null!;
    private string _connectionString = null!;

    public async Task InitializeAsync()
    {
        _postgresContainer = new PostgreSqlBuilder()
            .WithImage("postgres:15")
            .WithDatabase("testdb")
            .WithUsername("testuser")
            .WithPassword("testpass")
            .Build();

        await _postgresContainer.StartAsync();
        _connectionString = _postgresContainer.GetConnectionString();

        // Set up test users that simulate Azure Database for PostgreSQL users
        await SetupEntraTestUsersAsync();
    }

    public async Task DisposeAsync()
    {
        await _postgresContainer.DisposeAsync();
    }

    private async Task SetupEntraTestUsersAsync()
    {
        // Create users that match what would be extracted from JWT tokens
        // This simulates how Azure Database for PostgreSQL creates users for Entra ID principals
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        // Generate JWT tokens for each user
        var testUserToken = CreateValidJwtToken(EntraUser);
        var managedIdentityToken = CreateJwtTokenWithXmsMirid(ManagedIdentityPath);
        var fallbackUserToken = CreateValidJwtToken(FallbackUser);

        var setupCommands = new[]
        {
            $@"CREATE USER ""{EntraUser}"" WITH PASSWORD '{testUserToken}';",
            $@"CREATE USER ""{ManagedIdentityName}"" WITH PASSWORD '{managedIdentityToken}';",
            $@"CREATE USER ""{FallbackUser}"" WITH PASSWORD '{fallbackUserToken}';",
            $@"GRANT CONNECT ON DATABASE testdb TO ""{EntraUser}"";",
            $@"GRANT CONNECT ON DATABASE testdb TO ""{ManagedIdentityName}"";",
            $@"GRANT CONNECT ON DATABASE testdb TO ""{FallbackUser}"";",
            $@"GRANT ALL PRIVILEGES ON DATABASE testdb TO ""{EntraUser}"";",
            $@"GRANT ALL PRIVILEGES ON DATABASE testdb TO ""{ManagedIdentityName}"";",
            $@"GRANT ALL PRIVILEGES ON DATABASE testdb TO ""{FallbackUser}"";",
            // Grant schema permissions for creating tables
            $@"GRANT ALL ON SCHEMA public TO ""{EntraUser}"";",
            $@"GRANT ALL ON SCHEMA public TO ""{ManagedIdentityName}"";",
            $@"GRANT ALL ON SCHEMA public TO ""{FallbackUser}"";",
            // Grant permissions on all tables in the schema
            $@"GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO ""{EntraUser}"";",
            $@"GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO ""{ManagedIdentityName}"";",
            $@"GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO ""{FallbackUser}"";",
            // Grant permissions on all sequences in the schema
            $@"GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO ""{EntraUser}"";",
            $@"GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO ""{ManagedIdentityName}"";",
            $@"GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO ""{FallbackUser}"";"
        };

        foreach (var sql in setupCommands)
        {
            try
            {
                using var cmd = new NpgsqlCommand(sql, connection);
                await cmd.ExecuteNonQueryAsync();
            }
            catch (PostgresException ex) when (ex.SqlState == "42710")
            {
                // User already exists, this is expected in test reruns
                continue;
            }
            catch (Exception ex)
            {
                // Log unexpected errors to help debugging
                Console.Error.WriteLine($"Setup command failed: {sql}");
                Console.Error.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }

    /// <summary>
    /// Helper method to test end-to-end connection with Entra authentication.
    /// Verifies username extraction, connection establishment, and database operations.
    /// </summary>
    private async Task TestEntraAuthenticationFlow(string token, string expectedUsername, bool useAsync = false)
    {
        // Arrange - Create base connection string without credentials
        var baseConnectionString = new NpgsqlConnectionStringBuilder(_connectionString)
        {
            Username = null,
            Password = null
        }.ToString();

        var builder = new NpgsqlDataSourceBuilder(baseConnectionString);
        var credential = new TestTokenCredential(token);

        // Act - Configure Entra authentication (sync or async)
        if (useAsync)
        {
            await builder.UseEntraAuthenticationAsync(credential);
        }
        else
        {
            builder.UseEntraAuthentication(credential);
        }

        // Build data source with Entra configuration
        using var dataSource = builder.Build();

        // Assert - Username should be extracted from the token
        builder.ConnectionStringBuilder.Username.Should().Be(expectedUsername);

        // Opens a new connection from the data source
        using var connection = await dataSource.OpenConnectionAsync();
        connection.State.Should().Be(System.Data.ConnectionState.Open);

        // Test basic operations
        using var cmd = new NpgsqlCommand("SELECT current_user, current_database()", connection);
        await using var reader = await cmd.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            var currentUser = reader.GetString(0);
            var currentDb = reader.GetString(1);

            currentUser.Should().Be(expectedUsername);
            currentDb.Should().Be("testdb");
        }
    }

    [Fact]
    public async Task ConnectWithEntraUser()
    {
        // Showcases connecting with an Entra user using UseEntraAuthentication

        var testToken = CreateValidJwtToken(EntraUser);
        await TestEntraAuthenticationFlow(testToken, EntraUser);
    }

    [Fact]
    public async Task ConnectWithEntraUser_Async()
    {
        // Showcases connecting with an Entra user using UseEntraAuthenticationAsync

        var testToken = CreateValidJwtToken(EntraUser);
        await TestEntraAuthenticationFlow(testToken, EntraUser, useAsync: true);
    }

    [Fact]
    public async Task ConnectWithManagedIdentity()
    {
        // Showcases connecting with a managed identity using UseEntraAuthentication

        var miToken = CreateJwtTokenWithXmsMirid(ManagedIdentityPath);
        await TestEntraAuthenticationFlow(miToken, ManagedIdentityName);
    }

    [Fact]
    public async Task ConnectWithManagedIdentity_Async()
    {
        // Showcases connecting with a managed identity using UseEntraAuthenticationAsync

        var miToken = CreateJwtTokenWithXmsMirid(ManagedIdentityPath);
        await TestEntraAuthenticationFlow(miToken, ManagedIdentityName, useAsync: true);
    }

    [Fact]
    public void ThrowMeaningfulErrorForInvalidJwtTokenFormat()
    {
        // Showcases error handling for invalid JWT token format

        var invalidToken = "not.a.valid.token";
        var credential = new TestTokenCredential(invalidToken);

        var baseConnectionString = new NpgsqlConnectionStringBuilder(_connectionString)
        {
            Username = null,
            Password = null
        }.ToString();

        var builder = new NpgsqlDataSourceBuilder(baseConnectionString);

        var act = () => builder.UseEntraAuthentication(credential);

        act.Should().Throw<Exception>();
    }

    [Fact]
    public async Task ThrowMeaningfulErrorForInvalidJwtTokenFormat_Async()
    {
        // Showcases error handling for invalid JWT token format (async)

        var invalidToken = "not.a.valid.token";
        var credential = new TestTokenCredential(invalidToken);

        var baseConnectionString = new NpgsqlConnectionStringBuilder(_connectionString)
        {
            Username = null,
            Password = null
        }.ToString();

        var builder = new NpgsqlDataSourceBuilder(baseConnectionString);

        var act = async () => await builder.UseEntraAuthenticationAsync(credential);

        await act.Should().ThrowAsync<Exception>();
    }

    [Fact]
    public async Task HandleConnectionFailureWithClearError()
    {
        // Showcases error handling for connection failures

        var testToken = CreateValidJwtToken(EntraUser);
        var credential = new TestTokenCredential(testToken);

        var invalidConnectionString = "Host=invalid-host;Port=9999;Database=testdb";
        var builder = new NpgsqlDataSourceBuilder(invalidConnectionString);
        builder.UseEntraAuthentication(credential);

        using var dataSource = builder.Build();

        var act = async () => await dataSource.OpenConnectionAsync();

        await act.Should().ThrowAsync<Exception>();
    }

    [Fact]
    public async Task HandleConnectionFailureWithClearError_Async()
    {
        // Showcases error handling for connection failures (async)

        var testToken = CreateValidJwtToken(EntraUser);
        var credential = new TestTokenCredential(testToken);

        var invalidConnectionString = "Host=invalid-host;Port=9999;Database=testdb";
        var builder = new NpgsqlDataSourceBuilder(invalidConnectionString);
        await builder.UseEntraAuthenticationAsync(credential);

        using var dataSource = builder.Build();

        var act = async () => await dataSource.OpenConnectionAsync();

        await act.Should().ThrowAsync<Exception>();
    }

    [Fact]
    public void TokenCachingBehavior()
    {
        // Showcases that credentials are invoked for each connection using UseEntraAuthentication
        // Note: Npgsql's password provider calls GetToken for each connection
        // Token caching should be implemented by the credential itself

        var testToken = CreateValidJwtToken(EntraUser);
        var mockCredential = new Mock<TokenCredential>();
        mockCredential
            .Setup(c => c.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(testToken, DateTimeOffset.UtcNow.AddHours(1)));

        var baseConnectionString = new NpgsqlConnectionStringBuilder(_connectionString)
        {
            Username = null,
            Password = null
        }.ToString();

        var builder = new NpgsqlDataSourceBuilder(baseConnectionString);
        builder.UseEntraAuthentication(mockCredential.Object);

        using var dataSource = builder.Build();

        // Open multiple connections (using sync method to test sync password provider)
        using (var connection1 = dataSource.OpenConnection())
        {
            connection1.State.Should().Be(System.Data.ConnectionState.Open);
        }

        using (var connection2 = dataSource.OpenConnection())
        {
            connection2.State.Should().Be(System.Data.ConnectionState.Open);
        }

        // Verify token was fetched for each connection
        mockCredential.Verify(
            c => c.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2));
    }

    [Fact]
    public async Task TokenCachingBehavior_Async()
    {
        // Showcases that credentials are invoked for each connection using UseEntraAuthenticationAsync
        // Note: Npgsql's password provider calls GetToken for each connection
        // Token caching should be implemented by the credential itself

        var testToken = CreateValidJwtToken(EntraUser);
        var mockCredential = new Mock<TokenCredential>();
        mockCredential
            .Setup(c => c.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(testToken, DateTimeOffset.UtcNow.AddHours(1)));

        var baseConnectionString = new NpgsqlConnectionStringBuilder(_connectionString)
        {
            Username = null,
            Password = null
        }.ToString();

        var builder = new NpgsqlDataSourceBuilder(baseConnectionString);
        await builder.UseEntraAuthenticationAsync(mockCredential.Object);

        using var dataSource = builder.Build();

        // Open multiple connections
        using (var connection1 = await dataSource.OpenConnectionAsync())
        {
            connection1.State.Should().Be(System.Data.ConnectionState.Open);
        }

        using (var connection2 = await dataSource.OpenConnectionAsync())
        {
            connection2.State.Should().Be(System.Data.ConnectionState.Open);
        }

        // Verify token was fetched for each connection
        mockCredential.Verify(
            c => c.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2));
    }

    [Fact]
    public void MultipleJwtClaimTypes()
    {
        // Showcases support for different JWT claim types (preferred_username, unique_name)

        // Test with preferred_username claim
        var preferredUsernameToken = CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}") + "." +
                                    CreateBase64UrlString($"{{\"preferred_username\":\"{EntraUser}\",\"iat\":1234567890,\"exp\":9999999999}}") + "." +
                                    "fake-signature";

        var baseConnectionString = new NpgsqlConnectionStringBuilder(_connectionString)
        {
            Username = null,
            Password = null
        }.ToString();

        var builder1 = new NpgsqlDataSourceBuilder(baseConnectionString);
        var credential1 = new TestTokenCredential(preferredUsernameToken);
        builder1.UseEntraAuthentication(credential1);

        builder1.ConnectionStringBuilder.Username.Should().Be(EntraUser);

        // Test with unique_name claim
        var uniqueNameToken = CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}") + "." +
                             CreateBase64UrlString($"{{\"unique_name\":\"{EntraUser}\",\"iat\":1234567890,\"exp\":9999999999}}") + "." +
                             "fake-signature";

        var builder2 = new NpgsqlDataSourceBuilder(baseConnectionString);
        var credential2 = new TestTokenCredential(uniqueNameToken);
        builder2.UseEntraAuthentication(credential2);

        builder2.ConnectionStringBuilder.Username.Should().Be(EntraUser);
    }

    [Fact]
    public async Task MultipleJwtClaimTypes_Async()
    {
        // Showcases support for different JWT claim types (preferred_username, unique_name) using async

        // Test with preferred_username claim
        var preferredUsernameToken = CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}") + "." +
                                    CreateBase64UrlString($"{{\"preferred_username\":\"{EntraUser}\",\"iat\":1234567890,\"exp\":9999999999}}") + "." +
                                    "fake-signature";

        var baseConnectionString = new NpgsqlConnectionStringBuilder(_connectionString)
        {
            Username = null,
            Password = null
        }.ToString();

        var builder1 = new NpgsqlDataSourceBuilder(baseConnectionString);
        var credential1 = new TestTokenCredential(preferredUsernameToken);
        await builder1.UseEntraAuthenticationAsync(credential1);

        builder1.ConnectionStringBuilder.Username.Should().Be(EntraUser);

        // Test with unique_name claim
        var uniqueNameToken = CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}") + "." +
                             CreateBase64UrlString($"{{\"unique_name\":\"{EntraUser}\",\"iat\":1234567890,\"exp\":9999999999}}") + "." +
                             "fake-signature";

        var builder2 = new NpgsqlDataSourceBuilder(baseConnectionString);
        var credential2 = new TestTokenCredential(uniqueNameToken);
        await builder2.UseEntraAuthenticationAsync(credential2);

        builder2.ConnectionStringBuilder.Username.Should().Be(EntraUser);
    }

    [Fact]
    public void PreserveExistingCredentials()
    {
        // Documents that building data source with existing password fails when Entra auth is configured
        // This is by design in Npgsql - you cannot register a password provider when password is set

        var testToken = CreateValidJwtToken("test@example.com");
        var credential = new TestTokenCredential(testToken);

        // Connection string already has username and password
        var connectionStringWithCreds = new NpgsqlConnectionStringBuilder(_connectionString)
        {
            Username = "testuser",
            Password = "testpass"
        }.ToString();

        var builder = new NpgsqlDataSourceBuilder(connectionStringWithCreds);
        builder.UseEntraAuthentication(credential);

        // Building the data source should throw because password provider can't be registered
        // when password is already set
        var act = () => builder.Build();

        act.Should().Throw<NotSupportedException>()
            .WithMessage("*password provider*password*");
    }

    [Fact]
    public async Task PreserveExistingCredentials_Async()
    {
        // Documents that building data source with existing password fails when Entra auth is configured (async)
        // This is by design in Npgsql - you cannot register a password provider when password is set

        var testToken = CreateValidJwtToken("test@example.com");
        var credential = new TestTokenCredential(testToken);

        // Connection string already has username and password
        var connectionStringWithCreds = new NpgsqlConnectionStringBuilder(_connectionString)
        {
            Username = "testuser",
            Password = "testpass"
        }.ToString();

        var builder = new NpgsqlDataSourceBuilder(connectionStringWithCreds);
        await builder.UseEntraAuthenticationAsync(credential);

        // Building the data source should throw because password provider can't be registered
        // when password is already set
        var act = () => builder.Build();

        act.Should().Throw<NotSupportedException>()
            .WithMessage("*password provider*password*");
    }
}
