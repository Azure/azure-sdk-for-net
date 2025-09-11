// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Developer.Playwright.Implementation;
using Azure.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Moq;

namespace Azure.Developer.Playwright.Tests.Implementation;

[TestFixture]
public class EntraLifecycleTests
{
    [Test]
    public void Constructor_WhenAccessTokenEnvironmentIsNotSet_DoesNotInitializeEntraToken()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), null);

        EntraLifecycle entraLifecycle = new(environment: environment);
        Assert.That(entraLifecycle._entraIdAccessToken, Is.Null);
    }

    [Test]
    public void Constructor_WhenAccessTokenEnvironmentIsSetButTokenIsNotValid_DoesNotInitializeEntraToken()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "invalid_token");
        EntraLifecycle entraLifecycle = new(environment: environment);
        Assert.That(entraLifecycle._entraIdAccessToken, Is.Null);
    }

    [Test]
    public void Constructor_WhenAccessTokenEnvironmentIsSetAndTokenIsMPTCustomToken_DoesNotInitializeEntraToken()
    {
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"pwid", "account-id-guid"},
        });
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        EntraLifecycle entraLifecycle = new(environment: environment);
        Assert.That(entraLifecycle._entraIdAccessToken, Is.Null);
    }

    [Test]
    public void Constructor_WhenJWTValidationThrowsException_DoesNotInitializeEntraToken()
    {
        var token = TestUtilities.GetToken([]);
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        jsonWebTokenHandlerMock
            .Setup(x => x.ReadJsonWebToken(token))
            .Throws(new Exception());
        EntraLifecycle entraLifecycle = new(jsonWebTokenHandler: jsonWebTokenHandlerMock.Object, environment: environment);
        Assert.That(entraLifecycle._entraIdAccessToken, Is.Null);
    }

    [Test]
    public void Constructor_WhenAccessTokenEnvironmentIsSetAndValid_InitializeEntraToken()
    {
        DateTime expiry = DateTime.UtcNow.AddMinutes(10);
        var token = TestUtilities.GetToken(new Dictionary<string, object>(), expiry);
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        EntraLifecycle entraLifecycle = new(environment: environment);
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
        DateTime expiry = DateTime.UtcNow.AddMinutes(10);
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"pwid", "account-id-guid"},
        });
        var environment = new TestEnvironment();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        EntraLifecycle entraLifecycle = new(tokenCredential: defaultAzureCredentialMock.Object, environment: environment);
        await entraLifecycle.FetchEntraIdAccessTokenAsync();
        Assert.Multiple(() =>
        {
            Assert.That(entraLifecycle._entraIdAccessToken, Is.EqualTo(token));
            Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString()), Is.EqualTo(token));
        });
    }

    [Test]
    public async Task FetchEntraIdAccessTokenAsync_WhenTokenIsFetched_SetsTokenAndExpiry()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var token = "valid_token";
        var environment = new TestEnvironment();
        DateTimeOffset expiry = DateTimeOffset.UtcNow.AddMinutes(10);
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, expiry));
        EntraLifecycle entraLifecycle = new(defaultAzureCredentialMock.Object, environment: environment);
        await entraLifecycle.FetchEntraIdAccessTokenAsync();
        Assert.Multiple(() =>
        {
            Assert.That(entraLifecycle._entraIdAccessToken, Is.EqualTo(token));
            Assert.That(entraLifecycle._entraIdAccessTokenExpiry, Is.EqualTo((int)expiry.ToUnixTimeSeconds()));
        });
    }

    [Test]
    public async Task FetchEntraIdAccessTokenAsync_WhenTokenIsFetched_ReturnVoid()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var token = "valid_token";
        var environment = new TestEnvironment();
        DateTimeOffset expiry = DateTimeOffset.UtcNow.AddMinutes(10);
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, expiry));
        EntraLifecycle entraLifecycle = new(defaultAzureCredentialMock.Object, environment: environment);
        await entraLifecycle.FetchEntraIdAccessTokenAsync();
    }

    [Test]
    public void FetchEntraIdAccessTokenAsync_WhenThrowsError()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("sample exception"));
        var environment = new TestEnvironment();
        EntraLifecycle entraLifecycle = new(defaultAzureCredentialMock.Object, environment: environment);
        Exception? ex = Assert.ThrowsAsync<Exception>(async () =>
        await entraLifecycle.FetchEntraIdAccessTokenAsync());

        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void FetchEntraIdAccessToken_WhenTokenIsFetched_SetsEnvironmentVariable()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var token = "valid_token";
        var environment = new TestEnvironment();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        EntraLifecycle entraLifecycle = new(defaultAzureCredentialMock.Object, environment: environment);
        entraLifecycle.FetchEntraIdAccessToken();
        Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString()), Is.EqualTo(token));
    }

    [Test]
    public void FetchEntraIdAccessToken_WhenTokenIsFetched_SetsTokenAndExpiry()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var token = "valid_token";
        var environment = new TestEnvironment();
        DateTimeOffset expiry = DateTimeOffset.UtcNow.AddMinutes(10);
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(token, expiry));
        EntraLifecycle entraLifecycle = new(defaultAzureCredentialMock.Object, environment: environment);
        entraLifecycle.FetchEntraIdAccessToken();

        Assert.Multiple(() =>
        {
            Assert.That(entraLifecycle._entraIdAccessToken, Is.EqualTo(token));
            Assert.That(entraLifecycle._entraIdAccessTokenExpiry, Is.EqualTo((int)expiry.ToUnixTimeSeconds()));
        });
    }

    [Test]
    public void FetchEntraIdAccessToken_WhenTokenIsFetched_ReturnVoid()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var token = "valid_token";
        var environment = new TestEnvironment();
        DateTimeOffset expiry = DateTimeOffset.UtcNow.AddMinutes(10);
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, expiry));
        EntraLifecycle entraLifecycle = new(defaultAzureCredentialMock.Object, environment: environment);
        entraLifecycle.FetchEntraIdAccessToken();
    }

    [Test]
    public void FetchEntraIdAccessToken_WhenThrowsError()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var environment = new TestEnvironment();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Throws(new Exception("sample exception"));
        EntraLifecycle entraLifecycle = new(defaultAzureCredentialMock.Object, environment: environment);
        Exception? ex = Assert.Throws<Exception>(() => entraLifecycle.FetchEntraIdAccessToken());

        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void DoesEntraIdAccessTokenRequireRotation_WhenEntraIdAccessTokenIsEmpty_ReturnsTrue()
    {
        var environment = new TestEnvironment();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        EntraLifecycle entraLifecycle = new(environment: environment, tokenCredential: defaultAzureCredentialMock.Object)
        {
            _entraIdAccessToken = ""
        };
        Assert.That(entraLifecycle.DoesEntraIdAccessTokenRequireRotation(), Is.True);
    }

    [Test]
    public void DoesEntraIdAccessTokenRequireRotation_WhenEntraIdAccessTokenIsNull_ReturnsTrue()
    {
        var environment = new TestEnvironment();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        EntraLifecycle entraLifecycle = new(environment: environment, tokenCredential: defaultAzureCredentialMock.Object)
        {
            _entraIdAccessToken = null
        };
        Assert.That(entraLifecycle.DoesEntraIdAccessTokenRequireRotation(), Is.True);
    }

    [Test]
    public void DoesEntraIdAccessTokenRequireRotation_WhenTokenIsNotAboutToExpire_ReturnsFalse()
    {
        var environment = new TestEnvironment();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        EntraLifecycle entraLifecycle = new(environment: environment, tokenCredential: defaultAzureCredentialMock.Object)
        {
            _entraIdAccessToken = "valid_token",
            _entraIdAccessTokenExpiry = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 1000 // more than threshold of 10 mins
        };
        Assert.That(entraLifecycle.DoesEntraIdAccessTokenRequireRotation(), Is.False);
    }

    [Test]
    public void DoesEntraIdAccessTokenRequireRotation_WhenTokenIsAboutToExpire_ReturnsTrue()
    {
        var environment = new TestEnvironment();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        EntraLifecycle entraLifecycle = new(environment: environment, tokenCredential: defaultAzureCredentialMock.Object)
        {
            _entraIdAccessToken = "valid_token",
            _entraIdAccessTokenExpiry = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 400 // less than threshold of 10 mins
        };
        Assert.That(entraLifecycle.DoesEntraIdAccessTokenRequireRotation(), Is.True);
    }

    [Test]
    public void FetchEntraIdAccessTokenAsync_WhenAzureCredentialsIsntPassed_ThrowsException()
    {
        var environment = new TestEnvironment();
        EntraLifecycle entraLifecycle = new(environment: environment);
        Exception? ex = Assert.ThrowsAsync<Exception>(async () => await entraLifecycle.FetchEntraIdAccessTokenAsync());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_entra_no_cred_error));
    }

    [Test]
    public void FetchEntraIdAccessToken_WhenAzureCredentialsIsntPassed_ThrowsException()
    {
        var environment = new TestEnvironment();
        EntraLifecycle entraLifecycle = new(environment: environment);
        Exception? ex = Assert.Throws<Exception>(() => entraLifecycle.FetchEntraIdAccessToken());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_entra_no_cred_error));
    }

    [Test]
    public void DoesEntraIdAccessTokenRequireRotation_WhenAzureCredentialsIsntPassed_ThrowsException()
    {
        var environment = new TestEnvironment();
        EntraLifecycle entraLifecycle = new(environment: environment);
        Exception? ex = Assert.Throws<Exception>(() => entraLifecycle.DoesEntraIdAccessTokenRequireRotation());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_entra_no_cred_error));
    }
}
