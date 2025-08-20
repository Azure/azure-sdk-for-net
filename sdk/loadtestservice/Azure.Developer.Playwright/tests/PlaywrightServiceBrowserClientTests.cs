// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Developer.Playwright.Implementation;
using Azure.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace Azure.Developer.Playwright.Tests;

[TestFixture]
public class PlaywrightServiceBrowserClientTests
{
    [Test]
    public void Constructor_NoConstructorParams_SetsEntraAuthMechanismAsDefault()
    {
        var environment = new TestEnvironment();
        PlaywrightServiceBrowserClient client = new(environment);
        Assert.That(client._options.ServiceAuth, Is.EqualTo(ServiceAuthType.EntraId));
    }

    [Test]
    public void Constructor_NoServiceParams_SetsDefaultValues()
    {
        var environment = new TestEnvironment();
        PlaywrightServiceBrowserClient client = new(environment);
        Assert.Multiple(() =>
        {
            Assert.That(client._options.ServiceAuth, Is.EqualTo(ServiceAuthType.EntraId));
            Assert.That(client._options.UseCloudHostedBrowsers, Is.True);
            Assert.AreEqual(client._options.OS, OSPlatform.Linux);
            Assert.AreEqual(client._options.ExposeNetwork, Constants.s_default_expose_network);
            Assert.That(Guid.TryParse(client._options.RunId, out _), Is.True);

            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_os_environment_variable.ToString()), Is.EqualTo(Constants.s_default_os));
            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable.ToString()), Is.EqualTo(Constants.s_default_expose_network));
            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable.ToString().ToString()), Is.Not.Null);
        });
    }

    [Test]
    public void InitializeAsync_WhenServiceEnpointIsNotSet_NoOP()
    {
        var environment = new TestEnvironment();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        client.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public void InitializeAsync_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsSet_FetchesEntraIdAccessToken()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "access_token");
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        client.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        client.RotationTimer!.Dispose();

        Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString()), Is.Not.Null);
    }

    [Test]
    public void InitializeAsync_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsSetAndCredentialsArePassed_FetchesEntraIdAccessTokenUsedPassedCredentials()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var tokenCredential = new Mock<TokenCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        tokenCredential
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "access_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(tokenCredential.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        client.InitializeAsync().Wait();
        tokenCredential.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        client.RotationTimer!.Dispose();

        Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString()), Is.Not.Null);
    }

    [Test]
    public void InitializeAsync_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsSetButScalableExecutionIsDisabled_DeletesServiceUrlEnvVariable()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "access_token");
        var clientOptions = new PlaywrightServiceBrowserClientOptions(environment: environment, serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview)
        {
            UseCloudHostedBrowsers = false
        };
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, options: clientOptions);

        Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString()), Is.Not.Null);

        client.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);

        Assert.That(client.RotationTimer, Is.Null);
        Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString()), Is.Null);
    }

    [Test]
    public void InitializeAsync_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsNotSet_FetchesEntraIdAccessToken()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        client.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        client.RotationTimer!.Dispose();
    }

    [Test]
    public void InitializeAsync_WhenFetchesEntraIdAccessToken_SetsUpRotationHandler()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        client.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
        Assert.That(client.RotationTimer, Is.Not.Null);

        client.RotationTimer!.Dispose();
    }

    [Test]
    public void InitializeAsync_WhenFailsToFetchEntraIdAccessToken_ThrowsException()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        Exception? ex = Assert.ThrowsAsync<Exception>(async () => await client.InitializeAsync());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void InitializeAsync_WhenEntraIdAccessTokenFailsAndMptPatIsSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"aid", "account-id-guid"},
        });
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        Exception? ex = Assert.ThrowsAsync<Exception>(async () => await client.InitializeAsync());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void InitializeAsync_WhenEntraIdAccessTokenFailsAndMptPatIsNotSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"aid", "account-id-guid"},
        });
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        Exception? ex = Assert.ThrowsAsync<Exception>(async () => await client.InitializeAsync());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void InitializeAsync_WhenEntraIdAccessTokenFailsAndMptPatIsNotValid_ThrowsError()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var token = "sample token";
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        Assert.That(() => client.InitializeAsync().Wait(), Throws.Exception);
    }

    [Test]
    public void InitializeAsync_WhenEntraIdAccessTokenFailsAndMptPatTokenParsingReturnsNull_ThrowsError()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var token = "sample token";
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        jsonWebTokenHandlerMock
            .Setup(x => x.ReadJsonWebToken(It.IsAny<string>()))
            .Returns(value: null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment: environment, entraLifecycle: entraLifecycleMock.Object, jsonWebTokenHandler: jsonWebTokenHandlerMock.Object);
        Assert.That(() => client.InitializeAsync().Wait(), Throws.Exception);
    }

    [Test]
    public void InitializeAsync_WhenEntraIdAccessTokenFailsAndMptPatIsExpired_ThrowsError()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"aid", "account-id-guid"},
        }, DateTime.UtcNow.AddMinutes(-1));
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);

        Assert.That(() => client.InitializeAsync().Wait(), Throws.Exception);
    }

    [Test]
    public void InitializeAsync_WhenDefaultAuthIsMptPATAndPATIsSet_DoesNotSetUpRotationHandler()
    {
        var environment = new TestEnvironment();
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"aid", "eastus_bd830e63-6120-40cb-8cd7-f0739502d888"},
        });
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var testRubric = new Dictionary<string, string>
        {
            { "url", "wss://eastus.api.playwright.microsoft.com/accounts/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers" },
            { "workspaceId", "eastus_bd830e63-6120-40cb-8cd7-f0739502d888" },
            { "region", "eastus" },
            { "domain", "playwright.microsoft.com" }
        };
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), $"{testRubric["url"]}");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        var clientOptions = new PlaywrightServiceBrowserClientOptions(environment: environment, serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview)
        {
            ServiceAuth = ServiceAuthType.AccessToken
        };
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, options: clientOptions);
        client.InitializeAsync().Wait();
        Assert.That(client.RotationTimer, Is.Null);
    }

    [Test]
    public void Initialize_WhenServiceEnpointIsNotSet_NoOP()
    {
        var environment = new TestEnvironment();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        client.Initialize();
        defaultAzureCredentialMock.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsSet_FetchesEntraIdAccessToken()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "access_token");
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        client.Initialize();
        defaultAzureCredentialMock.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        client.RotationTimer!.Dispose();

        Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString()), Is.Not.Null);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsSetAndCredentialsArePassed_FetchesEntraIdAccessTokenUsedPassedCredentials()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var tokenCredential = new Mock<TokenCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        tokenCredential
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "access_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(tokenCredential.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        client.Initialize();
        tokenCredential.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        client.RotationTimer!.Dispose();

        Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString()), Is.Not.Null);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsSetButScalableExecutionIsDisabled_DeletesServiceUrlEnvVariable()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "access_token");
        var clientOptions = new PlaywrightServiceBrowserClientOptions(environment: environment, serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview)
        {
            UseCloudHostedBrowsers = false
        };
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, options: clientOptions);

        Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString()), Is.Not.Null);

        client.Initialize();
        defaultAzureCredentialMock.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);

        Assert.That(client.RotationTimer, Is.Null);
        Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString()), Is.Null);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsNotSet_FetchesEntraIdAccessToken()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        client.Initialize();
        defaultAzureCredentialMock.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        client.RotationTimer!.Dispose();
    }

    [Test]
    public void Initialize_WhenFetchesEntraIdAccessToken_SetsUpRotationHandler()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        client.Initialize();
        defaultAzureCredentialMock.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
        Assert.That(client.RotationTimer, Is.Not.Null);

        client.RotationTimer!.Dispose();
    }

    [Test]
    public void Initialize_WhenFailsToFetchEntraIdAccessToken_ThrowsException()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Throws(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        Exception? ex = Assert.Throws<Exception>(() => client.Initialize());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatIsSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"aid", "account-id-guid"},
        });
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Throws(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        Exception? ex = Assert.Throws<Exception>(() => client.Initialize());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatIsNotSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"aid", "account-id-guid"},
        });
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Throws(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        Exception? ex = Assert.Throws<Exception>(() => client.Initialize());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatIsNotValid_ThrowsError()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var token = "sample token";
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Throws(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        Assert.That(() => client.Initialize(), Throws.Exception);
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatTokenParsingReturnsNull_ThrowsError()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var token = "sample token";
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        jsonWebTokenHandlerMock
            .Setup(x => x.ReadJsonWebToken(It.IsAny<string>()))
            .Returns(value: null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Throws(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment: environment, entraLifecycle: entraLifecycleMock.Object, jsonWebTokenHandler: jsonWebTokenHandlerMock.Object);
        Assert.That(() => client.Initialize(), Throws.Exception);
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatIsExpired_ThrowsError()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"aid", "account-id-guid"},
        }, DateTime.UtcNow.AddMinutes(-1));
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Throws(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);

        Assert.That(() => client.Initialize(), Throws.Exception);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsMptPATAndPATIsSet_DoesNotSetUpRotationHandler()
    {
        var environment = new TestEnvironment();
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"aid", "eastus_bd830e63-6120-40cb-8cd7-f0739502d888"},
        });
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var testRubric = new Dictionary<string, string>
        {
            { "url", "wss://eastus.api.playwright.microsoft.com/accounts/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers" },
            { "workspaceId", "eastus_bd830e63-6120-40cb-8cd7-f0739502d888" },
            { "region", "eastus" },
            { "domain", "playwright.microsoft.com" }
        };
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), $"{testRubric["url"]}");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        var clientOptions = new PlaywrightServiceBrowserClientOptions(environment: environment, serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview)
        {
            ServiceAuth = ServiceAuthType.AccessToken
        };
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, options: clientOptions);
        client.Initialize();
        Assert.That(client.RotationTimer, Is.Null);
    }

    [Test]
    public void RotationHandler_WhenEntraIdAccessTokenRequiresRotation_FetchesEntraIdAccessToken()
    {
        var environment = new TestEnvironment();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(5)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);

        client.RotationHandlerAsync(null);
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public void RotationHandler_WhenEntraIdAccessTokenDoesNotRequireRotation_NoOp()
    {
        var environment = new TestEnvironment();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);

        client.RotationHandlerAsync(null);
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public void GetConnectOptionsAsync_WhenServiceEndpointIsNotSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        PlaywrightServiceBrowserClient client = new(environment);
        Exception? ex = Assert.ThrowsAsync<Exception>(() => client.GetConnectOptionsAsync<BrowserConnectOptions>());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_service_endpoint_error_message));
    }

    [Test]
    public void GetConnectOptionsAsync_WhenUseCloudHostedBrowsersEnvironmentIsFalse_ThrowsException()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var clientOptions = new PlaywrightServiceBrowserClientOptions(environment: environment, serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview)
        {
            UseCloudHostedBrowsers = false
        };
        PlaywrightServiceBrowserClient client = new(environment, options: clientOptions);
        Exception? ex = Assert.ThrowsAsync<Exception>(() => client.GetConnectOptionsAsync<BrowserConnectOptions>());
        Assert.Multiple(() =>
        {
            Assert.That(client._options.UseCloudHostedBrowsers, Is.False);
            Assert.That(ex!.Message, Is.EqualTo(Constants.s_service_endpoint_removed_since_scalable_execution_disabled_error_message));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenServiceEndpointIsSet_ReturnsConnectOptions()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        ConnectOptions<BrowserConnectOptions> connectOptions = await client.GetConnectOptionsAsync<BrowserConnectOptions>(runId: runId);
        var authorizationHeader = connectOptions.Options!.Headers!.Where(x => x.Key == "Authorization").FirstOrDefault().Value!;
        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={Constants.s_default_os}&runId={runId}&api-version=2025-07-01-preview"));
            Assert.That(connectOptions.Options!.Timeout, Is.EqualTo(3 * 60 * 1000));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo(Constants.s_default_expose_network));
            Assert.That(authorizationHeader, Is.EqualTo("Bearer valid_token"));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenTokenRequiresRotation_RotatesEntraToken()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken("valid_token", DateTimeOffset.UtcNow.AddMinutes(5)));
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(-1).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        _ = await client.GetConnectOptionsAsync<BrowserConnectOptions>();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenTokenDoesNotRequireRotation_DoesNotRotateEntraToken()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken("valid_token", DateTimeOffset.UtcNow.AddMinutes(5)));
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        _ = await client.GetConnectOptionsAsync<BrowserConnectOptions>();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenDefaultParametersAreProvided_SetsServiceParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        ConnectOptions<BrowserConnectOptions> connectOptions = await client.GetConnectOptionsAsync<BrowserConnectOptions>(runId: runId, os: OSPlatform.Windows, exposeNetwork: "localhost");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os=windows&runId={runId}&api-version=2025-07-01-preview"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("localhost"));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenDefaultParametersAreNotProvided_SetsDefaultServiceParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        ConnectOptions<BrowserConnectOptions> connectOptions = await client.GetConnectOptionsAsync<BrowserConnectOptions>(runId: runId);

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={Constants.s_default_os}&runId={runId}&api-version=2025-07-01-preview"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo(Constants.s_default_expose_network));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenParametersAreSetInTheObjectButAlsoPassedInMethod_UsesMethodParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        var newRunId = "new-run-id";

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        ConnectOptions<BrowserConnectOptions> connectOptions = await client.GetConnectOptionsAsync<BrowserConnectOptions>(os: OSPlatform.Windows, runId: newRunId, exposeNetwork: "expose-network");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={OSConstants.s_wINDOWS}&runId={newRunId}&api-version=2025-07-01-preview"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("expose-network"));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenParametersAreSetViaEnvironmentButAlsoPassedInMethod_UsesMethodParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        var newRunId = "new-run-id";

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        environment.SetEnvironmentVariable(Constants.s_playwright_service_os_environment_variable.ToString(), OSConstants.s_lINUX);
        environment.SetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable.ToString(), "expose");
        ConnectOptions<BrowserConnectOptions> connectOptions = await client.GetConnectOptionsAsync<BrowserConnectOptions>(os: OSPlatform.Windows, runId: newRunId, exposeNetwork: "expose-network");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={OSConstants.s_wINDOWS}&runId={newRunId}&api-version=2025-07-01-preview"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("expose-network"));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenServiceParametersAreSetViaEnvironment_SetsServiceParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);

        environment.SetEnvironmentVariable(Constants.s_playwright_service_os_environment_variable.ToString(), OSConstants.s_wINDOWS);
        environment.SetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable.ToString(), "localhost");

        ConnectOptions<BrowserConnectOptions> connectOptions = await client.GetConnectOptionsAsync<BrowserConnectOptions>();
        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={OSConstants.s_wINDOWS}&runId={runId}&api-version=2025-07-01-preview"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("localhost"));
        });
    }

    [Test]
    public void GetConnectOptionsAsync_WhenNoAuthTokenIsSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);

        Exception? ex = Assert.ThrowsAsync<Exception>(() => client.GetConnectOptionsAsync<BrowserConnectOptions>());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void GetConnectOptions_WhenUseCloudHostedBrowsersEnvironmentIsFalse_ThrowsException()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var clientOptions = new PlaywrightServiceBrowserClientOptions(environment: environment, serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview)
        {
            UseCloudHostedBrowsers = false
        };
        PlaywrightServiceBrowserClient client = new(environment, options: clientOptions);
        Exception? ex = Assert.Throws<Exception>(() => client.GetConnectOptions<BrowserConnectOptions>());
        Assert.Multiple(() =>
        {
            Assert.That(client._options.UseCloudHostedBrowsers, Is.False);
            Assert.That(ex!.Message, Is.EqualTo(Constants.s_service_endpoint_removed_since_scalable_execution_disabled_error_message));
        });
    }

    [Test]
    public void GetConnectOptions_WhenServiceEndpointIsSet_ReturnsConnectOptions()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        ConnectOptions<BrowserConnectOptions> connectOptions = client.GetConnectOptions<BrowserConnectOptions>(runId: runId);
        var authorizationHeader = connectOptions.Options!.Headers!.Where(x => x.Key == "Authorization").FirstOrDefault().Value!;
        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={Constants.s_default_os}&runId={runId}&api-version=2025-07-01-preview"));
            Assert.That(connectOptions.Options!.Timeout, Is.EqualTo(3 * 60 * 1000));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo(Constants.s_default_expose_network));
            Assert.That(authorizationHeader, Is.EqualTo("Bearer valid_token"));
        });
    }

    [Test]
    public void GetConnectOptions_WhenTokenRequiresRotation_RotatesEntraToken()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken("valid_token", DateTimeOffset.UtcNow.AddMinutes(5)));
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(-1).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        _ = client.GetConnectOptions<BrowserConnectOptions>();
        defaultAzureCredentialMock.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public void GetConnectOptions_WhenTokenDoesNotRequireRotation_DoesNotRotateEntraToken()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://region.api.playwright.microsoft.com/");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken("valid_token", DateTimeOffset.UtcNow.AddMinutes(5)));
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        _ = client.GetConnectOptions<BrowserConnectOptions>();
        defaultAzureCredentialMock.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public void GetConnectOptions_WhenDefaultParametersAreProvided_SetsServiceParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        ConnectOptions<BrowserConnectOptions> connectOptions = client.GetConnectOptions<BrowserConnectOptions>(runId: runId, os: OSPlatform.Windows, exposeNetwork: "localhost");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os=windows&runId={runId}&api-version=2025-07-01-preview"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("localhost"));
        });
    }

    [Test]
    public void GetConnectOptions_WhenDefaultParametersAreNotProvided_SetsDefaultServiceParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        ConnectOptions<BrowserConnectOptions> connectOptions = client.GetConnectOptions<BrowserConnectOptions>(runId: runId);

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={Constants.s_default_os}&runId={runId}&api-version=2025-07-01-preview"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo(Constants.s_default_expose_network));
        });
    }

    [Test]
    public void GetConnectOptions_WhenParametersAreSetInTheObjectButAlsoPassedInMethod_UsesMethodParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        var newRunId = "new-run-id";

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        ConnectOptions<BrowserConnectOptions> connectOptions = client.GetConnectOptions<BrowserConnectOptions>(os: OSPlatform.Windows, runId: newRunId, exposeNetwork: "expose-network");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={OSConstants.s_wINDOWS}&runId={newRunId}&api-version=2025-07-01-preview"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("expose-network"));
        });
    }

    [Test]
    public void GetConnectOptions_WhenParametersAreSetViaEnvironmentButAlsoPassedInMethod_UsesMethodParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        var newRunId = "new-run-id";

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);
        environment.SetEnvironmentVariable(Constants.s_playwright_service_os_environment_variable.ToString(), OSConstants.s_lINUX);
        environment.SetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable.ToString(), "expose");
        ConnectOptions<BrowserConnectOptions> connectOptions = client.GetConnectOptions<BrowserConnectOptions>(os: OSPlatform.Windows, runId: newRunId, exposeNetwork: "expose-network");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={OSConstants.s_wINDOWS}&runId={newRunId}&api-version=2025-07-01-preview"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("expose-network"));
        });
    }

    [Test]
    public void GetConnectOptions_WhenServiceParametersAreSetViaEnvironment_SetsServiceParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);

        environment.SetEnvironmentVariable(Constants.s_playwright_service_os_environment_variable.ToString(), OSConstants.s_wINDOWS);
        environment.SetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable.ToString(), "localhost");

        ConnectOptions<BrowserConnectOptions> connectOptions = client.GetConnectOptions<BrowserConnectOptions>();
        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={OSConstants.s_wINDOWS}&runId={runId}&api-version=2025-07-01-preview"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("localhost"));
        });
    }

    [Test]
    public void GetConnectOptions_WhenNoAuthTokenIsSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object);

        Exception? ex = Assert.Throws<Exception>(() => client.GetConnectOptions<BrowserConnectOptions>());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }
}
