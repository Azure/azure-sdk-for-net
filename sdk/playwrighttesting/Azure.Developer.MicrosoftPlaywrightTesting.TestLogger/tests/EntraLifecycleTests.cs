// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests;

[TestFixture]
public class EntraLifecycleTests
{
    private static string GetToken(Dictionary<string, object> claims, DateTime? expires = null)
    {
        var tokenHandler = new JsonWebTokenHandler();
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Claims = claims,
            Expires = expires ?? DateTime.UtcNow.AddMinutes(10),
        });
        return token!;
    }

    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, null);
    }

    [Test]
    public void Constructor_WhenAccessTokenEnvironmentIsNotSet_DoesNotInitializeEntraToken()
    {
        EntraLifecycle entraLifecycle = new();
        Assert.That(entraLifecycle._entraIdAccessToken, Is.Null);
    }

    [Test]
    public void Constructor_WhenAccessTokenEnvironmentIsSetButTokenIsNotValid_DoesNotInitializeEntraToken()
    {
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "valid_token");
        EntraLifecycle entraLifecycle = new();
        Assert.That(entraLifecycle._entraIdAccessToken, Is.Null);
    }

    [Test]
    public void Constructor_WhenAccessTokenEnvironmentIsSetAndTokenIsMPTCustomToken_DoesNotInitializeEntraToken()
    {
        var token = GetToken(new Dictionary<string, object>
        {
            {"aid", "account-id-guid"},
        });
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, token);
        EntraLifecycle entraLifecycle = new();
        Assert.That(entraLifecycle._entraIdAccessToken, Is.Null);
    }

    [Test]
    public void Constructor_WhenAccessTokenEnvironmentIsSetAndTokenIsMPTCustomTokenWithAccountIdClaim_DoesNotInitializeEntraToken()
    {
        var token = GetToken(new Dictionary<string, object>
        {
            {"accountId", "account-id-guid"},
        });
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, token);
        EntraLifecycle entraLifecycle = new();
        Assert.That(entraLifecycle._entraIdAccessToken, Is.Null);
    }

    [Test]
    public void Constructor_WhenJWTValidationThrowsException_DoesNotInitializeEntraToken()
    {
        var token = GetToken(new Dictionary<string, object>());
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, token);
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        jsonWebTokenHandlerMock
            .Setup(x => x.ReadJsonWebToken(token))
            .Throws(new Exception());
        EntraLifecycle entraLifecycle = new(jsonWebTokenHandler: jsonWebTokenHandlerMock.Object);
        Assert.That(entraLifecycle._entraIdAccessToken, Is.Null);
    }

    [Test]
    public void Constructor_WhenAccessTokenEnvironmentIsSetAndValid_InitializeEntraToken()
    {
        DateTime expiry = DateTime.UtcNow.AddMinutes(10);
        var token = GetToken(new Dictionary<string, object>(), expiry);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, token);
        EntraLifecycle entraLifecycle = new();
        Assert.Multiple(() =>
        {
            Assert.That(entraLifecycle._entraIdAccessToken, Is.EqualTo(token));
            Assert.That(entraLifecycle._entraIdAccessTokenExpiry, Is.EqualTo((long)(expiry - new DateTime(1970, 1, 1)).TotalSeconds));
        });
    }

    [Test]
    public async Task FetchEntraIdAccessTokenAsync_WhenTokenIsFetched_SetsEnvironmentVariable()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        EntraLifecycle entraLifecycle = new(defaultAzureCredentialMock.Object);
        await entraLifecycle.FetchEntraIdAccessTokenAsync();
        Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken), Is.EqualTo(token));

        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, null);
    }

    [Test]
    public async Task FetchEntraIdAccessTokenAsync_WhenTokenIsFetched_SetsTokenAndExpiry()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var token = "valid_token";
        DateTimeOffset expiry = DateTimeOffset.UtcNow.AddMinutes(10);
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, expiry));
        EntraLifecycle entraLifecycle = new(defaultAzureCredentialMock.Object);
        await entraLifecycle.FetchEntraIdAccessTokenAsync();
        Assert.That(entraLifecycle._entraIdAccessToken, Is.EqualTo(token));
        Assert.That(entraLifecycle._entraIdAccessTokenExpiry, Is.EqualTo((int)expiry.ToUnixTimeSeconds()));

        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, null);
    }

    [Test]
    public async Task FetchEntraIdAccessTokenAsync_WhenTokenIsFetched_ReturnVoid()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var token = "valid_token";
        DateTimeOffset expiry = DateTimeOffset.UtcNow.AddMinutes(10);
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, expiry));
        EntraLifecycle entraLifecycle = new(defaultAzureCredentialMock.Object);
        await entraLifecycle.FetchEntraIdAccessTokenAsync();

        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, null);
    }

    [Test]
    public void FetchEntraIdAccessTokenAsync_WhenThrowsError()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("sample exception"));
        EntraLifecycle entraLifecycle = new(defaultAzureCredentialMock.Object);
          Exception? ex = Assert.ThrowsAsync<Exception>(async () =>
        await entraLifecycle.FetchEntraIdAccessTokenAsync());

    Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void DoesEntraIdAccessTokenRequireRotation_WhenEntraIdAccessTokenIsEmpty_ReturnsTrue()
    {
        EntraLifecycle entraLifecycle = new()
        {
            _entraIdAccessToken = ""
        };
        Assert.That(entraLifecycle.DoesEntraIdAccessTokenRequireRotation(), Is.True);
    }

    [Test]
    public void DoesEntraIdAccessTokenRequireRotation_WhenEntraIdAccessTokenIsNull_ReturnsTrue()
    {
        EntraLifecycle entraLifecycle = new()
        {
            _entraIdAccessToken = null
        };
        Assert.That(entraLifecycle.DoesEntraIdAccessTokenRequireRotation(), Is.True);
    }

    [Test]
    public void DoesEntraIdAccessTokenRequireRotation_WhenTokenIsNotAboutToExpire_ReturnsFalse()
    {
        EntraLifecycle entraLifecycle = new()
        {
            _entraIdAccessToken = "valid_token",
            _entraIdAccessTokenExpiry = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 1000 // more than threshold of 10 mins
        };
        Assert.That(entraLifecycle.DoesEntraIdAccessTokenRequireRotation(), Is.False);
    }

    [Test]
    public void DoesEntraIdAccessTokenRequireRotation_WhenTokenIsAboutToExpire_ReturnsTrue()
    {
        EntraLifecycle entraLifecycle = new()
        {
            _entraIdAccessToken = "valid_token",
            _entraIdAccessTokenExpiry = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 400 // less than threshold of 10 mins
        };
        Assert.That(entraLifecycle.DoesEntraIdAccessTokenRequireRotation(), Is.True);
    }
}
