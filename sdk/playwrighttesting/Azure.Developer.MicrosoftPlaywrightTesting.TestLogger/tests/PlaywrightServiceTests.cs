// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests;

[TestFixture]
public class PlaywrightServiceTests
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

    [SetUp]
    public void Setup()
    {
        // Temporary - Switch to IEnvironment
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, "https://playwright.microsoft.com");
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, null);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs, null);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, null);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork, null);
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_disable_scalable_execution_environment_variable, null);
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable, null);
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_workspace_id_environment_variable, null);
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_disable_scalable_execution_environment_variable, null);
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable, null);
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_one_time_operation_flag_environment_variable, null);
    }
    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, null);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, null);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs, null);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, null);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork, null);
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_disable_scalable_execution_environment_variable, null);
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable, null);
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_workspace_id_environment_variable, null);
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_disable_scalable_execution_environment_variable, null);
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable, null);
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_one_time_operation_flag_environment_variable, null);
    }

    [Test]
    public void Constructor_NoConstructorParams_SetsEntraAuthMechanismAsDefault()
    {
        PlaywrightService service = new(entraLifecycle: null);
        Assert.That(service.ServiceAuth, Is.EqualTo(ServiceAuthType.EntraId));
    }

    [Test]
    public void Constructor_NoServiceParams_SetsDefaultValues()
    {
        var playwrightService = new PlaywrightService(entraLifecycle: null);
        Assert.Multiple(() =>
        {
            Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs), Is.EqualTo(Constants.s_default_os));
            Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork), Is.EqualTo(Constants.s_default_expose_network));
            Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId), Is.Not.Null);
            Assert.That(playwrightService.ServiceAuth, Is.EqualTo(ServiceAuthType.EntraId));
            Assert.That(playwrightService.UseCloudHostedBrowsers, Is.True);
            Assert.AreEqual(playwrightService.Os!, OSPlatform.Linux);
            Assert.AreEqual(playwrightService.ExposeNetwork!, Constants.s_default_expose_network);
            Assert.That(playwrightService.RunId, Is.Not.Null);
        });
    }

    [Test]
    public void Constructor_PassServiceOS_SetsServiceOS()
    {
        var playwrightService = new PlaywrightService(os: OSPlatform.Windows, entraLifecycle: null);
        Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs), Is.EqualTo(ServiceOs.Windows));
        Assert.That(playwrightService.Os, Is.EqualTo(OSPlatform.Windows));
    }

    [Test]
    public void Constructor_PassExposeNetwork_SetsExposeNetwork()
    {
        var playwrightService = new PlaywrightService(exposeNetwork: "new-expose", entraLifecycle: null);
        Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork), Is.EqualTo("new-expose"));
        Assert.That(playwrightService.ExposeNetwork, Is.EqualTo("new-expose"));
    }

    [Test]
    public void Constructor_PassRunId_SetsRunId()
    {
        var playwrightService = new PlaywrightService(runId: "new-run-id", entraLifecycle: null);
        Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId), Is.EqualTo("new-run-id"));
        Assert.That(playwrightService.RunId, Is.EqualTo("new-run-id"));
    }

    [Test]
    public void Constructor_PassDefaultAuthMechanism_SetsDefaultAuthMechanism()
    {
        var playwrightService = new PlaywrightService(entraLifecycle: null, serviceAuth: ServiceAuthType.AccessToken);
        Assert.That(playwrightService.ServiceAuth, Is.EqualTo(ServiceAuthType.AccessToken));
    }

    [Test]
    public void Constructor_PassUseCloudHostedBrowsersAsFalse_SetsDisableScalableExecutionAndEnvVariable()
    {
        var playwrightService = new PlaywrightService(entraLifecycle: null, useCloudHostedBrowsers: false);
        Assert.Multiple(() =>
        {
            Assert.That(playwrightService.UseCloudHostedBrowsers, Is.False);
            Assert.That(Environment.GetEnvironmentVariable(Constants.s_playwright_service_disable_scalable_execution_environment_variable), Is.EqualTo("true"));
        });
    }

    [Test]
    public void Constructor_PassUseCloudHostedBrowsersAsTrue_SetsDisableScalableExecutionButNotEnvVariable()
    {
        var playwrightService = new PlaywrightService(entraLifecycle: null, useCloudHostedBrowsers: true);
        Assert.Multiple(() =>
        {
            Assert.That(playwrightService.UseCloudHostedBrowsers, Is.True);
            Assert.That(Environment.GetEnvironmentVariable(Constants.s_playwright_service_disable_scalable_execution_environment_variable), Is.Null);
        });
    }

    [Test]
    public void Constructor_PlaywrightServiceOSEnvironmentVariableIsSet_DoesNotUpdateTheEnvironmentVariableWithDefault()
    {
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs, ServiceOs.Windows);
        _ = new PlaywrightService(entraLifecycle: null);
        Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs), Is.EqualTo(ServiceOs.Windows));
    }

    [Test]
    public void Constructor_PlaywrightServiceExposeNetworkEnvironmentVariableIsSet_DoesNotUpdateTheEnvironmentVariableWithDefault()
    {
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork, "new-expose");
        _ = new PlaywrightService(entraLifecycle: null);
        Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork), Is.EqualTo("new-expose"));
    }

    [Test]
    public void Constructor_MultipleInitialization_DoesNotUpdateTheEnvironmentVariablesOnceSet()
    {
        _ = new PlaywrightService(entraLifecycle: null, os: OSPlatform.Linux, exposeNetwork: "old-expose", runId: "old-run-id", useCloudHostedBrowsers: false, serviceAuth: ServiceAuthType.EntraId);
        var newPlaywrightService = new PlaywrightService(entraLifecycle: null, os: OSPlatform.Windows, exposeNetwork: "new-expose", runId: "new-run-id", useCloudHostedBrowsers: true, serviceAuth: ServiceAuthType.AccessToken);
        Assert.Multiple(() =>
        {
            Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs), Is.EqualTo(ServiceOs.Linux));
            Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork), Is.EqualTo("old-expose"));
            Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId), Is.EqualTo("old-run-id"));
            Assert.That(Environment.GetEnvironmentVariable(Constants.s_playwright_service_disable_scalable_execution_environment_variable), Is.EqualTo("true"));
            Assert.That(Environment.GetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable), Is.EqualTo(ServiceAuthType.EntraId));
            Assert.That(newPlaywrightService.Os, Is.EqualTo(OSPlatform.Windows));
            Assert.That(newPlaywrightService.ExposeNetwork, Is.EqualTo("new-expose"));
            Assert.That(newPlaywrightService.RunId, Is.EqualTo("new-run-id"));
            Assert.That(newPlaywrightService.UseCloudHostedBrowsers, Is.True);
            Assert.That(newPlaywrightService.ServiceAuth, Is.EqualTo(ServiceAuthType.AccessToken));
        });
    }

    [Test]
    public void Constructor_MultipleInitialization_ReadsOlderEnvironmentVariables()
    {
        _ = new PlaywrightService(entraLifecycle: null, os: OSPlatform.Linux, exposeNetwork: "old-expose", runId: "old-run-id", useCloudHostedBrowsers: false, serviceAuth: ServiceAuthType.EntraId);
        var newPlaywrightService = new PlaywrightService(entraLifecycle: null);
        Assert.Multiple(() =>
        {
            Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs), Is.EqualTo(ServiceOs.Linux));
            Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork), Is.EqualTo("old-expose"));
            Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId), Is.EqualTo("old-run-id"));
            Assert.That(Environment.GetEnvironmentVariable(Constants.s_playwright_service_disable_scalable_execution_environment_variable), Is.EqualTo("true"));
            Assert.That(Environment.GetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable), Is.EqualTo(ServiceAuthType.EntraId));
            Assert.That(newPlaywrightService.Os, Is.EqualTo(OSPlatform.Linux));
            Assert.That(newPlaywrightService.ExposeNetwork, Is.EqualTo("old-expose"));
            Assert.That(newPlaywrightService.RunId, Is.EqualTo("old-run-id"));
            Assert.That(newPlaywrightService.UseCloudHostedBrowsers, Is.False);
            Assert.That(newPlaywrightService.ServiceAuth, Is.EqualTo(ServiceAuthType.EntraId));
        });
    }

    [Test]
    public void Initialize_WhenServiceEnpointIsNotSet_NoOP()
    {
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, null);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object);
        service.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsSet_FetchesEntraIdAccessToken()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "access_token");
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object);
        service.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        service.RotationTimer!.Dispose();

        Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri), Is.Not.Null);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsSetAndCredentialsArePassed_FetchesEntraIdAccessTokenUsedPassedCredentials()
    {
        var tokenCredential = new Mock<TokenCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        tokenCredential
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "access_token");
        PlaywrightService service = new(new PlaywrightServiceOptions(), credential: tokenCredential.Object);
        service.InitializeAsync().Wait();
        tokenCredential.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        service.RotationTimer!.Dispose();

        Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri), Is.Not.Null);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsSetButScalableExecutionIsDisabled_DeletesServiceUrlEnvVariable()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "access_token");
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object, useCloudHostedBrowsers: false);

        Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri), Is.Not.Null);

        service.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);

        Assert.That(service.RotationTimer, Is.Null);

        Assert.That(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri), Is.Null);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsNotSet_FetchesEntraIdAccessToken()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object);
        service.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        service.RotationTimer!.Dispose();
    }

    [Test]
    public void Initialize_WhenFetchesEntraIdAccessToken_SetsUpRotationHandler()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object);
        service.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
        Assert.That(service.RotationTimer, Is.Not.Null);

        service.RotationTimer!.Dispose();
    }

    [Test]
    public void Initialize_WhenFailsToFetchEntraIdAccessToken_ThrowsException()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object);
        Exception? ex = Assert.ThrowsAsync<Exception>(async () => await service.InitializeAsync());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatIsSet_ThrowsException()
    {
        var token = GetToken(new Dictionary<string, object>
        {
            {"aid", "account-id-guid"},
        });
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, token);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null);
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object, jsonWebTokenHandler: new JsonWebTokenHandler());
        Exception? ex = Assert.ThrowsAsync<Exception>(async () => await service.InitializeAsync());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatIsNotSet_ThrowsException()
    {
        var token = GetToken(new Dictionary<string, object>
        {
            {"aid", "account-id-guid"},
        });
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null);
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object, jsonWebTokenHandler: new JsonWebTokenHandler());
        Exception? ex = Assert.ThrowsAsync<Exception>(async () => await service.InitializeAsync());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatIsNotValid_ThrowsError()
    {
        var token = "sample token";
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, token);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null);
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object, jsonWebTokenHandler: new JsonWebTokenHandler());
        Assert.That(() => service.InitializeAsync().Wait(), Throws.Exception);
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatTokenParsingReturnsNull_ThrowsError()
    {
        var token = "sample token";
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, token);
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
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null);
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object, jsonWebTokenHandler: jsonWebTokenHandlerMock.Object);
        Assert.That(() => service.InitializeAsync().Wait(), Throws.Exception);
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatIsExpired_ThrowsError()
    {
        var token = GetToken(new Dictionary<string, object>
        {
            {"aid", "account-id-guid"},
        }, DateTime.UtcNow.AddMinutes(-1));
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, token);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null);
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object, jsonWebTokenHandler: new JsonWebTokenHandler());

        Assert.That(() => service.InitializeAsync().Wait(), Throws.Exception);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsMptPATAndPATIsSet_DoesNotSetUpRotationHandler()
    {
        var token = GetToken(new Dictionary<string, object>
        {
            {"aid", "eastus_bd830e63-6120-40cb-8cd7-f0739502d888"},
        });
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, token);
        var testRubric = new Dictionary<string, string>
        {
            { "url", "wss://eastus.api.playwright.microsoft.com/accounts/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers" },
            { "workspaceId", "eastus_bd830e63-6120-40cb-8cd7-f0739502d888" },
            { "region", "eastus" },
            { "domain", "playwright.microsoft.com" }
        };
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, $"{testRubric["url"]}");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null);
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object, jsonWebTokenHandler: new JsonWebTokenHandler(), serviceAuth: ServiceAuthType.AccessToken);
        service.InitializeAsync().Wait();
        Assert.That(service.RotationTimer, Is.Null);
    }

    [Test]
    public void RotationHandler_WhenEntraIdAccessTokenRequiresRotation_FetchesEntraIdAccessToken()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(5)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object);

        service.RotationHandlerAsync(null);
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public void RotationHandler_WhenEntraIdAccessTokenDoesNotRequireRotation_NoOp()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object);

        service.RotationHandlerAsync(null);
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public void GetConnectOptionsAsync_WhenServiceEndpointIsNotSet_ThrowsException()
    {
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, null);
        PlaywrightService service = new(entraLifecycle: null);
        Exception? ex = Assert.ThrowsAsync<Exception>(() => service.GetConnectOptionsAsync<BrowserConnectOptions>());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_service_endpoint_error_message));
    }

    [Test]
    public void GetConnectOptionsAsync_WhenUseCloudHostedBrowsersEnvironmentIsFalse_ThrowsException()
    {
        PlaywrightService service = new(entraLifecycle: null, useCloudHostedBrowsers: false);
        Exception? ex = Assert.ThrowsAsync<Exception>(() => service.GetConnectOptionsAsync<BrowserConnectOptions>());
        Assert.Multiple(() =>
        {
            Assert.That(service.UseCloudHostedBrowsers, Is.False);
            Assert.That(ex!.Message, Is.EqualTo(Constants.s_service_endpoint_removed_since_scalable_execution_disabled_error_message));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenServiceEndpointIsSet_ReturnsConnectOptions()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        var runId = "run-id";

        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object);
        ConnectOptions<BrowserConnectOptions> connectOptions = await service.GetConnectOptionsAsync<BrowserConnectOptions>(runId: runId);
        var authorizationHeader = connectOptions.Options!.Headers!.Where(x => x.Key == "Authorization").FirstOrDefault().Value!;
        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={Constants.s_default_os}&runId={runId}&api-version={Constants.s_api_version}"));
            Assert.That(connectOptions.Options!.Timeout, Is.EqualTo(3 * 60 * 1000));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo(Constants.s_default_expose_network));
            Assert.That(authorizationHeader, Is.EqualTo("Bearer valid_token"));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenTokenRequiresRotation_RotatesEntraToken()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken("valid_token", DateTimeOffset.UtcNow.AddMinutes(5)));
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(-1).ToUnixTimeSeconds();

        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object);
        _ = await service.GetConnectOptionsAsync<BrowserConnectOptions>();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenTokenDoesNotRequireRotation_DoesNotRotateEntraToken()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "valid_token");
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken("valid_token", DateTimeOffset.UtcNow.AddMinutes(5)));
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();

        PlaywrightService service = new(entraLifecycle: entraLifecycleMock.Object);
        _ = await service.GetConnectOptionsAsync<BrowserConnectOptions>();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenDefaultParametersAreProvided_SetsServiceParameters()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        var runId = "run-id";

        var service = new PlaywrightService(entraLifecycle: entraLifecycleMock.Object);
        ConnectOptions<BrowserConnectOptions> connectOptions = await service.GetConnectOptionsAsync<BrowserConnectOptions>(runId: runId, os: OSPlatform.Windows, exposeNetwork: "localhost");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={ServiceOs.Windows}&runId={runId}&api-version={Constants.s_api_version}"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("localhost"));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenDefaultParametersAreNotProvided_SetsDefaultServiceParameters()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        var runId = "run-id";

        var service = new PlaywrightService(entraLifecycle: entraLifecycleMock.Object);
        ConnectOptions<BrowserConnectOptions> connectOptions = await service.GetConnectOptionsAsync<BrowserConnectOptions>(runId: runId);

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={Constants.s_default_os}&runId={runId}&api-version={Constants.s_api_version}"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo(Constants.s_default_expose_network));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenParametersAreSetInTheObject_UsesObjectParameters()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        var runId = "run-id";

        var service = new PlaywrightService(os: OSPlatform.Windows, runId: runId, exposeNetwork: "expose-network", entraLifecycle: entraLifecycleMock.Object);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs, ServiceOs.Linux);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork, "expose");
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, "invalid-run-id");
        ConnectOptions<BrowserConnectOptions> connectOptions = await service.GetConnectOptionsAsync<BrowserConnectOptions>();

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={ServiceOs.Windows}&runId={runId}&api-version={Constants.s_api_version}"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("expose-network"));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenParametersAreSetInTheObjectButAlsoPassedInMethod_UsesMethodParameters()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        var runId = "run-id";

        var service = new PlaywrightService(os: OSPlatform.Linux, runId: "invalid-runid", exposeNetwork: "expose", entraLifecycle: entraLifecycleMock.Object);
        ConnectOptions<BrowserConnectOptions> connectOptions = await service.GetConnectOptionsAsync<BrowserConnectOptions>(os: OSPlatform.Windows, runId: runId, exposeNetwork: "expose-network");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={ServiceOs.Windows}&runId={runId}&api-version={Constants.s_api_version}"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("expose-network"));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenParametersAreSetViaEnvironmentButAlsoPassedInMethod_UsesMethodParameters()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        var runId = "run-id";

        var service = new PlaywrightService(entraLifecycle: entraLifecycleMock.Object);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs, ServiceOs.Linux);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork, "expose");
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, "invalid-run-id");
        ConnectOptions<BrowserConnectOptions> connectOptions = await service.GetConnectOptionsAsync<BrowserConnectOptions>(os: OSPlatform.Windows, runId: runId, exposeNetwork: "expose-network");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={ServiceOs.Windows}&runId={runId}&api-version={Constants.s_api_version}"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("expose-network"));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenServiceParametersAreSetViaEnvironment_SetsServiceParameters()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        var runId = "run-id";
        var service = new PlaywrightService(entraLifecycle: entraLifecycleMock.Object);

        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs, ServiceOs.Windows);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork, "localhost");
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, runId);

        ConnectOptions<BrowserConnectOptions> connectOptions = await service.GetConnectOptionsAsync<BrowserConnectOptions>();
        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={ServiceOs.Windows}&runId={runId}&api-version={Constants.s_api_version}"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("localhost"));
        });
    }

    [Test]
    public void GetConnectOptionsAsync_WhenNoAuthTokenIsSet_ThrowsException()
    {
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null);
        var service = new PlaywrightService(entraLifecycle: entraLifecycleMock.Object);

        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, null);

        Exception? ex = Assert.ThrowsAsync<Exception>(() => service.GetConnectOptionsAsync<BrowserConnectOptions>());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void GetDefaultRunId_RunIdSetViaEnvironmentVariable_ReturnsRunId()
    {
        var runId = "run-id";
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, runId);
        Assert.Multiple(() =>
        {
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, null);
            Assert.That(PlaywrightService.GetDefaultRunId(), Is.Not.Null);
        });
    }

    [Test]
    public void GetDefaultRunId_RunIdNotSetViaEnvironmentVariable_ReturnsRandomRunId()
    {
        Assert.Multiple(() =>
        {
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, null);
            Assert.That(PlaywrightService.GetDefaultRunId(), Is.Not.Null);
        });
    }

    [Test]
    public void SetReportingUrlAndWorkspaceId_WhenServiceEndpointIsSet_SetsReportingUrlAndWorkspaceId()
    {
        var testRubricCombinations = new List<Dictionary<string, string>>()
        {
            new()
            {
                { "url", "wss://eastus.api.playwright.microsoft.com/accounts/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers" },
                { "workspaceId", "eastus_bd830e63-6120-40cb-8cd7-f0739502d888" },
                { "region", "eastus" },
                { "domain", "playwright.microsoft.com" }
            },
            new()
            {
                { "url", "wss://eastus.api.playwright.microsoft.com/accounts/77a38aac-4577-43a9-ac72-5720e5459c5a/browsers" },
                { "workspaceId", "77a38aac-4577-43a9-ac72-5720e5459c5a" },
                { "region", "eastus" },
                { "domain", "playwright.microsoft.com" }
            },
            new()
            {
                { "url", "wss://westus3.api.playwright.microsoft.com/accounts/ad3cf59a-43e1-4dbe-af22-49bfe72b4178/browsers" },
                { "workspaceId", "ad3cf59a-43e1-4dbe-af22-49bfe72b4178" },
                { "region", "westus3" },
                { "domain", "playwright.microsoft.com" }
            },
            new()
            {
                { "url", "wss://westus3.api.playwright-int.io/accounts/3c9ae1d4-e856-4ce0-8b56-1f4488676dff/browsers" },
                { "workspaceId", "3c9ae1d4-e856-4ce0-8b56-1f4488676dff" },
                { "region", "westus3" },
                { "domain", "playwright-int.io" }
            },
            new()
            {
                { "url", "wss://eastasia.api.playwright-test.io/accounts/29abee44-a5f4-477e-9ff1-6c6786d09c7c/browsers" },
                { "workspaceId", "29abee44-a5f4-477e-9ff1-6c6786d09c7c" },
                { "region", "eastasia" },
                { "domain", "playwright-test.io" }
            }
        };

        foreach (Dictionary<string, string> testRubric in testRubricCombinations)
        {
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, $"{testRubric["url"]}");
            var service = new PlaywrightService(entraLifecycle: null);
            Assert.Multiple(() =>
            {
                Assert.That(Environment.GetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable), Is.EqualTo($"https://{testRubric["region"]}.reporting.api.{testRubric["domain"]}"));
                Assert.That(Environment.GetEnvironmentVariable(Constants.s_playwright_service_workspace_id_environment_variable), Is.EqualTo(testRubric["workspaceId"]));
            });
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, null);
            Environment.SetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable, null);
            Environment.SetEnvironmentVariable(Constants.s_playwright_service_workspace_id_environment_variable, null);
        }
    }

    [Test]
    public void SetReportingUrlAndWorkspaceId_WhenReportingServiceEndpointIsSet_OnlySetsWorkspaceId()
    {
        var testRubric = new Dictionary<string, string>
        {
            { "url", "wss://eastus.api.playwright.microsoft.com/accounts/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers" },
            { "workspaceId", "eastus_bd830e63-6120-40cb-8cd7-f0739502d888" },
            { "region", "eastus" },
            { "domain", "playwright.microsoft.com" }
        };
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, $"{testRubric["url"]}");
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable, "https://playwright.microsoft.com");
        var service = new PlaywrightService(entraLifecycle: null);
        Assert.Multiple(() =>
        {
            Assert.That(Environment.GetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable), Is.EqualTo("https://playwright.microsoft.com"));
            Assert.That(Environment.GetEnvironmentVariable(Constants.s_playwright_service_workspace_id_environment_variable), Is.EqualTo(testRubric["workspaceId"]));
        });
    }

    [Test]
    public void SetReportingUrlAndWorkspaceId_WhenReportingServiceEndpointAndWorkspaceIdIsSet_NoOp()
    {
        var testRubric = new Dictionary<string, string>
        {
            { "url", "wss://eastus.api.playwright.microsoft.com/accounts/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers" },
            { "workspaceId", "eastus_bd830e63-6120-40cb-8cd7-f0739502d888" },
            { "region", "eastus" },
            { "domain", "playwright.microsoft.com" }
        };
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, $"{testRubric["url"]}");
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable, "https://playwright.microsoft.com");
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_workspace_id_environment_variable, "sample-id");
        var service = new PlaywrightService(entraLifecycle: null);
        Assert.Multiple(() =>
        {
            Assert.That(Environment.GetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable), Is.EqualTo("https://playwright.microsoft.com"));
            Assert.That(Environment.GetEnvironmentVariable(Constants.s_playwright_service_workspace_id_environment_variable), Is.EqualTo("sample-id"));
        });
    }

    [Test]
    public void ShouldNotCallWarnIfAccessTokenCloseToExpiry_WhenOneTimeOperationFlagIsSet_True()
    {
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "access_token");
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable, "https://playwright.microsoft.com");
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_one_time_operation_flag_environment_variable, "true");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null);
        var service = new Mock<PlaywrightService>(new PlaywrightServiceOptions(), null,null);
        service.Object.PerformOneTimeOperation();
        service.Verify(x => x.WarnIfAccessTokenCloseToExpiry(), Times.Never);
    }

    [Test]
    public void ShouldCallWarnIfAccessTokenCloseToExpiry_WhenOneTimeOperationFlagIsSet_True()
    {
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "access_token");
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable, "https://playwright.microsoft.com");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null);
        var serviceMock = new Mock<PlaywrightService>(new PlaywrightServiceOptions(serviceAuth: ServiceAuthType.AccessToken), null, null);
        serviceMock.Object.PerformOneTimeOperation();
        serviceMock.Verify(x => x.WarnIfAccessTokenCloseToExpiry(), Times.Once);
    }

    [Test]
    public void ShouldReturnTrue_IfAccessTokenIs_CloseToExpiry()
    {
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "access_token");
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable, "https://playwright.microsoft.com");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null);
        var serviceMock = new Mock<PlaywrightService>(new PlaywrightServiceOptions(), null, null);
        long currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long expirationTime = DateTimeOffset.UtcNow.AddDays(4).ToUnixTimeMilliseconds();
        bool isExpiringSoon = PlaywrightService.IsTokenExpiringSoon(expirationTime, currentTime);
        Assert.IsTrue(isExpiringSoon);
    }

    [Test]
    public void ShouldReturnFalse_IfAccessTokenIs_NotCloseToExpiry()
    {
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "access_token");
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable, "https://playwright.microsoft.com");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null);
        var serviceMock = new Mock<PlaywrightService>(new PlaywrightServiceOptions(), null, null);
        long currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long expirationTime = DateTimeOffset.UtcNow.AddDays(20).ToUnixTimeMilliseconds();
        bool isExpiringSoon = PlaywrightService.IsTokenExpiringSoon(expirationTime, currentTime);
        Assert.IsFalse(isExpiringSoon);
    }

    [Test]
    public void ShouldLogWarning_IfWarnAboutTokenExpiry_IsCalled()
    {
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, "access_token");
        Environment.SetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable, "https://playwright.microsoft.com");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());

        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null);
        var consoleWriterMock = new Mock<IConsoleWriter>();
        var serviceMock = new Mock<PlaywrightService>(
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            consoleWriterMock.Object
        );
        serviceMock.CallBase = true;
        long currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long expirationTime = DateTimeOffset.UtcNow.AddDays(4).ToUnixTimeMilliseconds();
        int daysToExpiration = (int)Math.Ceiling((expirationTime - currentTime) / (double)Constants.s_oneDayInMs);
        string expirationDate = DateTimeOffset.FromUnixTimeMilliseconds(expirationTime).UtcDateTime.ToString("d");
        string expectedWarning = string.Format(Constants.s_token_expiry_warning_template, daysToExpiration, expirationDate);
        serviceMock.Object.WarnAboutTokenExpiry(expirationTime, currentTime);
        consoleWriterMock.Verify(c => c.WriteLine(expectedWarning), Times.Once);
    }
}
