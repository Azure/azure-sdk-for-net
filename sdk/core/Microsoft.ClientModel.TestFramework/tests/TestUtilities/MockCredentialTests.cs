// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Microsoft.ClientModel.TestFramework.Tests;
[TestFixture]
public class MockCredentialTests
{
    [Test]
    public void DefaultConstructor_CreatesCredentialWithDefaultValues()
    {
        var credential = new MockCredential();
        Assert.That(credential, Is.Not.Null);
    }
    [Test]
    public void Constructor_WithTokenAndExpiration_SetsPropertiesCorrectly()
    {
        var token = "test-token";
        var expiresOn = DateTimeOffset.UtcNow.AddMinutes(30);
        var credential = new MockCredential(token, expiresOn);
        Assert.That(credential, Is.Not.Null);
        // Token and expiration will be validated in GetToken tests
    }
    [Test]
    public void Constructor_WithNullToken_ThrowsArgumentNullException()
    {
        var expiresOn = DateTimeOffset.UtcNow.AddMinutes(30);
        Assert.Throws<ArgumentNullException>(() => new MockCredential(null!, expiresOn));
    }
    [Test]
    public void CreateTokenOptions_ReturnsNull()
    {
        var credential = new MockCredential();
        var properties = new Dictionary<string, object>
        {
            { "scope", "test-scope" },
            { "tenant", "test-tenant" }
        };
        var tokenOptions = credential.CreateTokenOptions(properties);
        Assert.That(tokenOptions, Is.Null);
    }
    [Test]
    public void GetToken_ReturnsCorrectToken()
    {
        var expectedToken = "mock-test-token";
        var expectedExpiration = DateTimeOffset.UtcNow.AddHours(2);
        var credential = new MockCredential(expectedToken, expectedExpiration);
        var options = new GetTokenOptions(new Dictionary<string, object>());
        var authToken = credential.GetToken(options, CancellationToken.None);
        Assert.That(authToken, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(authToken.TokenValue, Is.EqualTo(expectedToken));
            Assert.That(authToken.TokenType, Is.EqualTo("Bearer"));
            Assert.That(authToken.ExpiresOn, Is.EqualTo(expectedExpiration));
            Assert.That(authToken.RefreshOn, Is.Null);
        }
    }
    [Test]
    public void GetToken_WithCancellationToken_ReturnsCorrectToken()
    {
        var expectedToken = "cancellation-test-token";
        var expectedExpiration = DateTimeOffset.UtcNow.AddMinutes(45);
        var credential = new MockCredential(expectedToken, expectedExpiration);
        var options = new GetTokenOptions(new Dictionary<string, object>());
        using var cts = new CancellationTokenSource();
        var authToken = credential.GetToken(options, cts.Token);
        Assert.That(authToken, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(authToken.TokenValue, Is.EqualTo(expectedToken));
            Assert.That(authToken.TokenType, Is.EqualTo("Bearer"));
            Assert.That(authToken.ExpiresOn, Is.EqualTo(expectedExpiration));
        }
    }
    [Test]
    public async Task GetTokenAsync_ReturnsCorrectToken()
    {
        var expectedToken = "async-test-token";
        var expectedExpiration = DateTimeOffset.UtcNow.AddHours(3);
        var credential = new MockCredential(expectedToken, expectedExpiration);
        var options = new GetTokenOptions(new Dictionary<string, object>());
        var authToken = await credential.GetTokenAsync(options, CancellationToken.None);
        Assert.That(authToken, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(authToken.TokenValue, Is.EqualTo(expectedToken));
            Assert.That(authToken.TokenType, Is.EqualTo("Bearer"));
            Assert.That(authToken.ExpiresOn, Is.EqualTo(expectedExpiration));
            Assert.That(authToken.RefreshOn, Is.Null);
        }
    }
    [Test]
    public async Task GetTokenAsync_WithCancellationToken_ReturnsCorrectToken()
    {
        var expectedToken = "async-cancellation-test-token";
        var expectedExpiration = DateTimeOffset.UtcNow.AddMinutes(15);
        var credential = new MockCredential(expectedToken, expectedExpiration);
        var options = new GetTokenOptions(new Dictionary<string, object>());
        using var cts = new CancellationTokenSource();
        var authToken = await credential.GetTokenAsync(options, cts.Token);
        Assert.That(authToken, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(authToken.TokenValue, Is.EqualTo(expectedToken));
            Assert.That(authToken.TokenType, Is.EqualTo("Bearer"));
            Assert.That(authToken.ExpiresOn, Is.EqualTo(expectedExpiration));
        }
    }
    [Test]
    public void GetToken_DefaultCredential_ReturnsDefaultValues()
    {
        var credential = new MockCredential();
        var options = new GetTokenOptions(new Dictionary<string, object>());
        var authToken = credential.GetToken(options, CancellationToken.None);
        Assert.That(authToken, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(authToken.TokenValue, Is.EqualTo("mock-token"));
            Assert.That(authToken.TokenType, Is.EqualTo("Bearer"));
            Assert.That(authToken.ExpiresOn > DateTimeOffset.UtcNow, Is.True);
            Assert.That(authToken.ExpiresOn < DateTimeOffset.UtcNow.AddHours(2), Is.True);
        }
    }
    [Test]
    public async Task GetTokenAsync_DefaultCredential_ReturnsDefaultValues()
    {
        var credential = new MockCredential();
        var options = new GetTokenOptions(new Dictionary<string, object>());
        var authToken = await credential.GetTokenAsync(options, CancellationToken.None);
        Assert.That(authToken, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(authToken.TokenValue, Is.EqualTo("mock-token"));
            Assert.That(authToken.TokenType, Is.EqualTo("Bearer"));
            Assert.That(authToken.ExpiresOn > DateTimeOffset.UtcNow, Is.True);
            Assert.That(authToken.ExpiresOn < DateTimeOffset.UtcNow.AddHours(2), Is.True);
        }
    }
    [Test]
    public void GetToken_WithNullOptions_ReturnsToken()
    {
        var credential = new MockCredential();
        var authToken = credential.GetToken(null!, CancellationToken.None);
        Assert.That(authToken, Is.Not.Null);
        Assert.That(authToken.TokenValue, Is.EqualTo("mock-token"));
    }
    [Test]
    public async Task GetTokenAsync_WithNullOptions_ReturnsToken()
    {
        var credential = new MockCredential();
        var authToken = await credential.GetTokenAsync(null!, CancellationToken.None);
        Assert.That(authToken, Is.Not.Null);
        Assert.That(authToken.TokenValue, Is.EqualTo("mock-token"));
    }
    [Test]
    public void GetToken_WithExpiredToken_StillReturnsToken()
    {
        var expiredTime = DateTimeOffset.UtcNow.AddHours(-1);
        var credential = new MockCredential("expired-token", expiredTime);
        var options = new GetTokenOptions(new Dictionary<string, object>());
        var authToken = credential.GetToken(options, CancellationToken.None);
        Assert.That(authToken, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(authToken.TokenValue, Is.EqualTo("expired-token"));
            Assert.That(authToken.ExpiresOn, Is.EqualTo(expiredTime));
        }
    }
    [Test]
    public void GetToken_MultipleCalls_ReturnsSameToken()
    {
        // Arrange
        var credential = new MockCredential("consistent-token", DateTimeOffset.UtcNow.AddHours(1));
        var options = new GetTokenOptions(new Dictionary<string, object>());
        // Act
        var token1 = credential.GetToken(options, CancellationToken.None);
        var token2 = credential.GetToken(options, CancellationToken.None);
        using (Assert.EnterMultipleScope())
        {
            // Assert
            Assert.That(token2.TokenValue, Is.EqualTo(token1.TokenValue));
            Assert.That(token2.ExpiresOn, Is.EqualTo(token1.ExpiresOn));
            Assert.That(token2.TokenType, Is.EqualTo(token1.TokenType));
        }
    }
}
