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
        Assert.IsNotNull(credential);
    }

    [Test]
    public void Constructor_WithTokenAndExpiration_SetsPropertiesCorrectly()
    {
        var token = "test-token";
        var expiresOn = DateTimeOffset.UtcNow.AddMinutes(30);

        var credential = new MockCredential(token, expiresOn);

        Assert.IsNotNull(credential);
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

        Assert.IsNull(tokenOptions);
    }

    [Test]
    public void GetToken_ReturnsCorrectToken()
    {
        var expectedToken = "mock-test-token";
        var expectedExpiration = DateTimeOffset.UtcNow.AddHours(2);
        var credential = new MockCredential(expectedToken, expectedExpiration);
        var options = new GetTokenOptions(new Dictionary<string, object>());

        var authToken = credential.GetToken(options, CancellationToken.None);

        Assert.IsNotNull(authToken);
        Assert.AreEqual(expectedToken, authToken.TokenValue);
        Assert.AreEqual("Bearer", authToken.TokenType);
        Assert.AreEqual(expectedExpiration, authToken.ExpiresOn);
        Assert.IsNull(authToken.RefreshOn);
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

        Assert.IsNotNull(authToken);
        Assert.AreEqual(expectedToken, authToken.TokenValue);
        Assert.AreEqual("Bearer", authToken.TokenType);
        Assert.AreEqual(expectedExpiration, authToken.ExpiresOn);
    }

    [Test]
    public async Task GetTokenAsync_ReturnsCorrectToken()
    {
        var expectedToken = "async-test-token";
        var expectedExpiration = DateTimeOffset.UtcNow.AddHours(3);
        var credential = new MockCredential(expectedToken, expectedExpiration);
        var options = new GetTokenOptions(new Dictionary<string, object>());

        var authToken = await credential.GetTokenAsync(options, CancellationToken.None);

        Assert.IsNotNull(authToken);
        Assert.AreEqual(expectedToken, authToken.TokenValue);
        Assert.AreEqual("Bearer", authToken.TokenType);
        Assert.AreEqual(expectedExpiration, authToken.ExpiresOn);
        Assert.IsNull(authToken.RefreshOn);
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

        Assert.IsNotNull(authToken);
        Assert.AreEqual(expectedToken, authToken.TokenValue);
        Assert.AreEqual("Bearer", authToken.TokenType);
        Assert.AreEqual(expectedExpiration, authToken.ExpiresOn);
    }

    [Test]
    public void GetToken_DefaultCredential_ReturnsDefaultValues()
    {
        var credential = new MockCredential();
        var options = new GetTokenOptions(new Dictionary<string, object>());

        var authToken = credential.GetToken(options, CancellationToken.None);

        Assert.IsNotNull(authToken);
        Assert.AreEqual("mock-token", authToken.TokenValue);
        Assert.AreEqual("Bearer", authToken.TokenType);
        Assert.IsTrue(authToken.ExpiresOn > DateTimeOffset.UtcNow);
        Assert.IsTrue(authToken.ExpiresOn < DateTimeOffset.UtcNow.AddHours(2));
    }

    [Test]
    public async Task GetTokenAsync_DefaultCredential_ReturnsDefaultValues()
    {
        var credential = new MockCredential();
        var options = new GetTokenOptions(new Dictionary<string, object>());
        var authToken = await credential.GetTokenAsync(options, CancellationToken.None);

        Assert.IsNotNull(authToken);
        Assert.AreEqual("mock-token", authToken.TokenValue);
        Assert.AreEqual("Bearer", authToken.TokenType);
        Assert.IsTrue(authToken.ExpiresOn > DateTimeOffset.UtcNow);
        Assert.IsTrue(authToken.ExpiresOn < DateTimeOffset.UtcNow.AddHours(2));
    }

    [Test]
    public void GetToken_WithNullOptions_ReturnsToken()
    {
        var credential = new MockCredential();

        var authToken = credential.GetToken(null!, CancellationToken.None);

        Assert.IsNotNull(authToken);
        Assert.AreEqual("mock-token", authToken.TokenValue);
    }

    [Test]
    public async Task GetTokenAsync_WithNullOptions_ReturnsToken()
    {
        var credential = new MockCredential();
        var authToken = await credential.GetTokenAsync(null!, CancellationToken.None);
        Assert.IsNotNull(authToken);
        Assert.AreEqual("mock-token", authToken.TokenValue);
    }

    [Test]
    public void GetToken_WithExpiredToken_StillReturnsToken()
    {
        var expiredTime = DateTimeOffset.UtcNow.AddHours(-1);
        var credential = new MockCredential("expired-token", expiredTime);
        var options = new GetTokenOptions(new Dictionary<string, object>());
        var authToken = credential.GetToken(options, CancellationToken.None);

        Assert.IsNotNull(authToken);
        Assert.AreEqual("expired-token", authToken.TokenValue);
        Assert.AreEqual(expiredTime, authToken.ExpiresOn);
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

        // Assert
        Assert.AreEqual(token1.TokenValue, token2.TokenValue);
        Assert.AreEqual(token1.ExpiresOn, token2.ExpiresOn);
        Assert.AreEqual(token1.TokenType, token2.TokenType);
    }
}
