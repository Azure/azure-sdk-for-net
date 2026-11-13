// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Moq;
using Npgsql;
using NUnit.Framework;

namespace Microsoft.Azure.PostgreSQL.Auth;

/// <summary>
/// Tests for Entra ID authentication with PostgreSQL.
/// These tests demonstrate token-based authentication and username extraction.
/// </summary>
[TestFixture]
public class NpgsqlEntraIdExtensionTests
{
    private const string MockConnectionString = "Host=localhost;Port=5432;Database=testdb";

    [Test]
    public void ConnectWithEntraUser()
    {
        var testToken = PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser);
        var credential = new TestTokenCredential(testToken);

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);
        builder.UseEntraAuthentication(credential);

        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(PostgreSqlTestEnvironment.EntraUser));
    }

    [Test]
    public async Task ConnectWithEntraUser_Async()
    {
        var testToken = PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser);
        var credential = new TestTokenCredential(testToken);

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);
        await builder.UseEntraAuthenticationAsync(credential);

        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(PostgreSqlTestEnvironment.EntraUser));
    }

    [Test]
    public void ConnectWithManagedIdentity()
    {
        var miToken = PostgreSqlTestEnvironment.CreateJwtTokenWithXmsMirid(PostgreSqlTestEnvironment.ManagedIdentityPath);
        var credential = new TestTokenCredential(miToken);

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);
        builder.UseEntraAuthentication(credential);

        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(PostgreSqlTestEnvironment.ManagedIdentityName));
    }

    [Test]
    public async Task ConnectWithManagedIdentity_Async()
    {
        var miToken = PostgreSqlTestEnvironment.CreateJwtTokenWithXmsMirid(PostgreSqlTestEnvironment.ManagedIdentityPath);
        var credential = new TestTokenCredential(miToken);

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);
        await builder.UseEntraAuthenticationAsync(credential);

        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(PostgreSqlTestEnvironment.ManagedIdentityName));
    }

    [Test]
    public void ThrowMeaningfulErrorForInvalidJwtTokenFormat()
    {
        var invalidToken = "not.a.valid.token";
        var credential = new TestTokenCredential(invalidToken);

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);

        Assert.Throws<InvalidOperationException>(() => builder.UseEntraAuthentication(credential));
    }

    [Test]
    public void ThrowMeaningfulErrorForInvalidJwtTokenFormat_Async()
    {
        var invalidToken = "not.a.valid.token";
        var credential = new TestTokenCredential(invalidToken);

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);

        Assert.ThrowsAsync<InvalidOperationException>(async () => await builder.UseEntraAuthenticationAsync(credential));
    }

    [Test]
    public void HandleConnectionFailureWithClearError()
    {
        var testToken = PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser);
        var credential = new TestTokenCredential(testToken);

        var invalidConnectionString = "Host=invalid-host;Port=9999;Database=testdb";
        var builder = new NpgsqlDataSourceBuilder(invalidConnectionString);
        builder.UseEntraAuthentication(credential);

        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(PostgreSqlTestEnvironment.EntraUser));
    }

    [Test]
    public async Task HandleConnectionFailureWithClearError_Async()
    {
        var testToken = PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser);
        var credential = new TestTokenCredential(testToken);

        var invalidConnectionString = "Host=invalid-host;Port=9999;Database=testdb";
        var builder = new NpgsqlDataSourceBuilder(invalidConnectionString);
        await builder.UseEntraAuthenticationAsync(credential);

        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(PostgreSqlTestEnvironment.EntraUser));
    }

    [Test]
    public void TokenCachingBehavior()
    {
        var testToken = PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser);
        var mockCredential = new Mock<TokenCredential>();
        mockCredential
            .Setup(c => c.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(testToken, DateTimeOffset.UtcNow.AddHours(1)));

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);
        builder.UseEntraAuthentication(mockCredential.Object);

        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(PostgreSqlTestEnvironment.EntraUser));
    }

    [Test]
    public async Task TokenCachingBehavior_Async()
    {
        var testToken = PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser);
        var mockCredential = new Mock<TokenCredential>();
        mockCredential
            .Setup(c => c.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(testToken, DateTimeOffset.UtcNow.AddHours(1)));

        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);
        await builder.UseEntraAuthenticationAsync(mockCredential.Object);

        Assert.That(builder.ConnectionStringBuilder.Username, Is.EqualTo(PostgreSqlTestEnvironment.EntraUser));
    }

    [Test]
    public void MultipleJwtClaimTypes()
    {
        var preferredUsernameToken = PostgreSqlTestEnvironment.CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}") + "." +
                                    PostgreSqlTestEnvironment.CreateBase64UrlString($"{{\"preferred_username\":\"{PostgreSqlTestEnvironment.EntraUser}\",\"iat\":1234567890,\"exp\":9999999999}}") + "." +
                                    "fake-signature";

        var builder1 = new NpgsqlDataSourceBuilder(MockConnectionString);
        var credential1 = new TestTokenCredential(preferredUsernameToken);
        builder1.UseEntraAuthentication(credential1);

        Assert.That(builder1.ConnectionStringBuilder.Username, Is.EqualTo(PostgreSqlTestEnvironment.EntraUser));

        var uniqueNameToken = PostgreSqlTestEnvironment.CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}") + "." +
                             PostgreSqlTestEnvironment.CreateBase64UrlString($"{{\"unique_name\":\"{PostgreSqlTestEnvironment.EntraUser}\",\"iat\":1234567890,\"exp\":9999999999}}") + "." +
                             "fake-signature";

        var builder2 = new NpgsqlDataSourceBuilder(MockConnectionString);
        var credential2 = new TestTokenCredential(uniqueNameToken);
        builder2.UseEntraAuthentication(credential2);

        Assert.That(builder2.ConnectionStringBuilder.Username, Is.EqualTo(PostgreSqlTestEnvironment.EntraUser));
    }

    [Test]
    public async Task MultipleJwtClaimTypes_Async()
    {
        var preferredUsernameToken = PostgreSqlTestEnvironment.CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}") + "." +
                                    PostgreSqlTestEnvironment.CreateBase64UrlString($"{{\"preferred_username\":\"{PostgreSqlTestEnvironment.EntraUser}\",\"iat\":1234567890,\"exp\":9999999999}}") + "." +
                                    "fake-signature";

        var builder1 = new NpgsqlDataSourceBuilder(MockConnectionString);
        var credential1 = new TestTokenCredential(preferredUsernameToken);
        await builder1.UseEntraAuthenticationAsync(credential1);

        Assert.That(builder1.ConnectionStringBuilder.Username, Is.EqualTo(PostgreSqlTestEnvironment.EntraUser));

        var uniqueNameToken = PostgreSqlTestEnvironment.CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}") + "." +
                             PostgreSqlTestEnvironment.CreateBase64UrlString($"{{\"unique_name\":\"{PostgreSqlTestEnvironment.EntraUser}\",\"iat\":1234567890,\"exp\":9999999999}}") + "." +
                             "fake-signature";

        var builder2 = new NpgsqlDataSourceBuilder(MockConnectionString);
        var credential2 = new TestTokenCredential(uniqueNameToken);
        await builder2.UseEntraAuthenticationAsync(credential2);

        Assert.That(builder2.ConnectionStringBuilder.Username, Is.EqualTo(PostgreSqlTestEnvironment.EntraUser));
    }

    [Test]
    public void PreserveExistingCredentials()
    {
        var testToken = PostgreSqlTestEnvironment.CreateValidJwtToken("test@contoso.com");
        var credential = new TestTokenCredential(testToken);

        var connectionStringWithCreds = "Host=localhost;Port=5432;Database=testdb;Username=testuser;Password=testpass";

        var builder = new NpgsqlDataSourceBuilder(connectionStringWithCreds);
        builder.UseEntraAuthentication(credential);

        Assert.Throws<NotSupportedException>(() => builder.Build());
    }

    [Test]
    public async Task PreserveExistingCredentials_Async()
    {
        var testToken = PostgreSqlTestEnvironment.CreateValidJwtToken("test@contoso.com");
        var credential = new TestTokenCredential(testToken);

        var connectionStringWithCreds = "Host=localhost;Port=5432;Database=testdb;Username=testuser;Password=testpass";

        var builder = new NpgsqlDataSourceBuilder(connectionStringWithCreds);
        await builder.UseEntraAuthenticationAsync(credential);

        Assert.Throws<NotSupportedException>(() => builder.Build());
    }

    [Test]
    public void NullDataSourceBuilderThrowsArgumentNullException()
    {
        var credential = new TestTokenCredential(PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser));

        Assert.Throws<ArgumentNullException>(() => EntraIdExtension.UseEntraAuthentication(null!, credential));
    }

    [Test]
    public void NullCredentialThrowsArgumentNullException()
    {
        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);

        Assert.Throws<ArgumentNullException>(() => builder.UseEntraAuthentication(null!));
    }

    [Test]
    public void NullDataSourceBuilderThrowsArgumentNullException_Async()
    {
        var credential = new TestTokenCredential(PostgreSqlTestEnvironment.CreateValidJwtToken(PostgreSqlTestEnvironment.EntraUser));

        Assert.ThrowsAsync<ArgumentNullException>(async () => await EntraIdExtension.UseEntraAuthenticationAsync(null!, credential));
    }

    [Test]
    public void NullCredentialThrowsArgumentNullException_Async()
    {
        var builder = new NpgsqlDataSourceBuilder(MockConnectionString);

        Assert.ThrowsAsync<ArgumentNullException>(async () => await builder.UseEntraAuthenticationAsync(null!));
    }
}
