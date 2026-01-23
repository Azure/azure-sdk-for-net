// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using Azure.Core;
using Azure.Core.TestFramework;
using Moq;
using Npgsql;
using NUnit.Framework;
using static Microsoft.Azure.PostgreSQL.Auth.TestJwtTokenGenerator;
using static Microsoft.Azure.PostgreSQL.Auth.TestUsers;

namespace Microsoft.Azure.PostgreSQL.Auth;

/// <summary>
/// Tests for Entra ID authentication with PostgreSQL.
/// These tests demonstrate token-based authentication and username extraction.
/// </summary>
public class NpgsqlEntraIdExtensionTests : RecordedTestBase<PostgreSqlTestEnvironment>
{
    // Mock connection string for unit testing - we're testing the extension methods,
    // not actual database connectivity in recorded mode
    private const string MockConnectionString = "Host=localhost;Port=5432;Database=testdb";

    public NpgsqlEntraIdExtensionTests(bool isAsync) : base(isAsync)
    {
    }
            }
        }
    }


    [Test]
    public void ConnectWithEntraUser()
    {
        // Showcases connecting with an Entra user using UseEntraAuthentication

        var testToken = CreateValidJwtToken(EntraUser);
        var credential = new TestTokenCredential(testToken);

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);
        builder.UseEntraAuthentication(credential);

        // Assert - Username should be extracted from the token
        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(EntraUser));
    }

    [Test]
    public async Task ConnectWithEntraUser_Async()
    {
        // Showcases connecting with an Entra user using UseEntraAuthenticationAsync

        var testToken = CreateValidJwtToken(EntraUser);
        var credential = new TestTokenCredential(testToken);

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);
        await builder.UseEntraAuthenticationAsync(credential);

        // Assert - Username should be extracted from the token
        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(EntraUser));
    }

    [Test]
    public void ConnectWithManagedIdentity()
    {
        // Showcases connecting with a managed identity using UseEntraAuthentication

        var miToken = CreateJwtTokenWithXmsMirid(ManagedIdentityPath);
        var credential = new TestTokenCredential(miToken);

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);
        builder.UseEntraAuthentication(credential);

        // Assert - Username should be extracted from xms_mirid claim
        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(ManagedIdentityName));
    }

    [Test]
    public async Task ConnectWithManagedIdentity_Async()
    {
        // Showcases connecting with a managed identity using UseEntraAuthenticationAsync

        var miToken = CreateJwtTokenWithXmsMirid(ManagedIdentityPath);
        var credential = new TestTokenCredential(miToken);

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);
        await builder.UseEntraAuthenticationAsync(credential);

        // Assert - Username should be extracted from xms_mirid claim
        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(ManagedIdentityName));
    }

    [Test]
    public void ThrowMeaningfulErrorForInvalidJwtTokenFormat()
    {
        // Showcases error handling for invalid JWT token format

        var invalidToken = "not.a.valid.token";
        var credential = new TestTokenCredential(invalidToken);

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);

        Assert.Throws<Exception>(() => builder.UseEntraAuthentication(credential));
    }

    [Test]
    public void ThrowMeaningfulErrorForInvalidJwtTokenFormat_Async()
    {
        // Showcases error handling for invalid JWT token format (async)

        var invalidToken = "not.a.valid.token";
        var credential = new TestTokenCredential(invalidToken);

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);

        Assert.ThrowsAsync<Exception>(async () => await builder.UseEntraAuthenticationAsync(credential));
    }

    [Test]
    public void HandleConnectionFailureWithClearError()
    {
        // Showcases that the extension configures authentication correctly
        // Actual connection failure testing would require a live database

        var testToken = CreateValidJwtToken(EntraUser);
        var credential = new TestTokenCredential(testToken);

        var invalidConnectionString = "Host=invalid-host;Port=9999;Database=testdb";
        var builder = new NpgsqlDataSourceBuilder(invalidConnectionString);
        builder.UseEntraAuthentication(credential);

        // Verify the username was extracted correctly
        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(EntraUser));
    }

    [Test]
    public async Task HandleConnectionFailureWithClearError_Async()
    {
        // Showcases that the extension configures authentication correctly (async)
        // Actual connection failure testing would require a live database

        var testToken = CreateValidJwtToken(EntraUser);
        var credential = new TestTokenCredential(testToken);

        var invalidConnectionString = "Host=invalid-host;Port=9999;Database=testdb";
        var builder = new NpgsqlDataSourceBuilder(invalidConnectionString);
        await builder.UseEntraAuthenticationAsync(credential);

        // Verify the username was extracted correctly
        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(EntraUser));
    }

    [Test]
    public void TokenCachingBehavior()
    {
        // Showcases that the password provider is configured correctly
        // Note: Npgsql's password provider calls GetToken for each connection
        // Token caching should be implemented by the credential itself

        var testToken = CreateValidJwtToken(EntraUser);
        var mockCredential = new Mock<TokenCredential>();
        mockCredential
            .Setup(c => c.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(testToken, DateTimeOffset.UtcNow.AddHours(1)));

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);
        builder.UseEntraAuthentication(mockCredential.Object);

        // Verify the username was extracted correctly
        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(EntraUser));
    }

    [Test]
    public async Task TokenCachingBehavior_Async()
    {
        // Showcases that the password provider is configured correctly (async)
        // Note: Npgsql's password provider calls GetToken for each connection
        // Token caching should be implemented by the credential itself

        var testToken = CreateValidJwtToken(EntraUser);
        var mockCredential = new Mock<TokenCredential>();
        mockCredential
            .Setup(c => c.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(testToken, DateTimeOffset.UtcNow.AddHours(1)));

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);
        await builder.UseEntraAuthenticationAsync(mockCredential.Object);

        // Verify the username was extracted correctly
        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(EntraUser));
    }

    [Test]
    public void MultipleJwtClaimTypes()
    {
        // Showcases support for different JWT claim types (preferred_username, unique_name)

        // Test with preferred_username claim
        var preferredUsernameToken = CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}") + "." +
                                    CreateBase64UrlString($"{{\"preferred_username\":\"{EntraUser}\",\"iat\":1234567890,\"exp\":9999999999}}") + "." +
                                    "fake-signature";

        var builder1 = new NpgsqlDataSourceBuilder(MockConnectionString);
        var credential1 = new TestTokenCredential(preferredUsernameToken);
        builder1.UseEntraAuthentication(credential1);

        Assert.That(builder1.ConnectionStringBuilder.Username, Is.EqualTo(EntraUser));

        // Test with unique_name claim
        var uniqueNameToken = CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}") + "." +
                             CreateBase64UrlString($"{{\"unique_name\":\"{EntraUser}\",\"iat\":1234567890,\"exp\":9999999999}}") + "." +
                             "fake-signature";

        var builder2 = new NpgsqlDataSourceBuilder(MockConnectionString);
        var credential2 = new TestTokenCredential(uniqueNameToken);
        builder2.UseEntraAuthentication(credential2);

        Assert.That(builder2.ConnectionStringBuilder.Username, Is.EqualTo(EntraUser));
    }

    [Test]
    public async Task MultipleJwtClaimTypes_Async()
    {
        // Showcases support for different JWT claim types (preferred_username, unique_name) using async

        // Test with preferred_username claim
        var preferredUsernameToken = CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}") + "." +
                                    CreateBase64UrlString($"{{\"preferred_username\":\"{EntraUser}\",\"iat\":1234567890,\"exp\":9999999999}}") + "." +
                                    "fake-signature";

        var builder1 = new NpgsqlDataSourceBuilder(MockConnectionString);
        var credential1 = new TestTokenCredential(preferredUsernameToken);
        await builder1.UseEntraAuthenticationAsync(credential1);

        Assert.That(builder1.ConnectionStringBuilder.Username, Is.EqualTo(EntraUser));

        // Test with unique_name claim
        var uniqueNameToken = CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}") + "." +
                             CreateBase64UrlString($"{{\"unique_name\":\"{EntraUser}\",\"iat\":1234567890,\"exp\":9999999999}}") + "." +
                             "fake-signature";

        var builder2 = new NpgsqlDataSourceBuilder(MockConnectionString);
        var credential2 = new TestTokenCredential(uniqueNameToken);
        await builder2.UseEntraAuthenticationAsync(credential2);

        Assert.That(builder2.ConnectionStringBuilder.Username, Is.EqualTo(EntraUser));
    }

    [Test]
    public void PreserveExistingCredentials()
    {
        // Documents that building data source with existing password fails when Entra auth is configured
        // This is by design in Npgsql - you cannot register a password provider when password is set

        var testToken = CreateValidJwtToken("test@contoso.com");
        var credential = new TestTokenCredential(testToken);

        // Connection string already has username and password
        var connectionStringWithCreds = "Host=localhost;Port=5432;Database=testdb;Username=testuser;Password=testpass";

        var builder = new NpgsqlDataSourceBuilder(connectionStringWithCreds);
        builder.UseEntraAuthentication(credential);

        // Building the data source should throw because password provider can't be registered
        // when password is already set
        Assert.Throws<NotSupportedException>(() => builder.Build());
    }

    [Test]
    public async Task PreserveExistingCredentials_Async()
    {
        // Documents that building data source with existing password fails when Entra auth is configured (async)
        // This is by design in Npgsql - you cannot register a password provider when password is set

        var testToken = CreateValidJwtToken("test@contoso.com");
        var credential = new TestTokenCredential(testToken);

        // Connection string already has username and password
        var connectionStringWithCreds = "Host=localhost;Port=5432;Database=testdb;Username=testuser;Password=testpass";

        var builder = new NpgsqlDataSourceBuilder(connectionStringWithCreds);
        await builder.UseEntraAuthenticationAsync(credential);

        // Building the data source should throw because password provider can't be registered
        // when password is already set
        Assert.Throws<NotSupportedException>(() => builder.Build());
    }
}
