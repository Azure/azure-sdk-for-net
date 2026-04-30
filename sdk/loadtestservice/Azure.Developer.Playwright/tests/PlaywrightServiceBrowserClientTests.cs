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
        var playwrightVersion = new PlaywrightVersion();
        PlaywrightServiceBrowserClient client = new(environment, playwrightVersion: playwrightVersion);
        Assert.That(client._options.ServiceAuth, Is.EqualTo(ServiceAuthType.EntraId));
    }

    [Test]
    public void Constructor_NoServiceParams_SetsDefaultValues()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        PlaywrightServiceBrowserClient client = new(environment, playwrightVersion: playwrightVersion);
        Assert.Multiple(() =>
        {
            Assert.That(client._options.ServiceAuth, Is.EqualTo(ServiceAuthType.EntraId));
            Assert.AreEqual(client._options.OS, OSPlatform.Linux);
            Assert.AreEqual(client._options.ExposeNetwork, Constants.s_default_expose_network);
            Assert.That(Guid.TryParse(client._options.RunId, out _), Is.True);
            Assert.That(client._options.RunName, Is.EqualTo(client._options.RunId)); // RunName defaults to RunId

            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_os_environment_variable.ToString()), Is.EqualTo(Constants.s_default_os));
            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable.ToString()), Is.EqualTo(Constants.s_default_expose_network));
            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable.ToString().ToString()), Is.Not.Null);
            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_run_name_environment_variable), Is.EqualTo(client._options.RunId));
        });
    }

    [Test]
    public void Constructor_CustomRunName_SetsCustomRunNameValue()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        var customRunName = "Custom Run Name";
        var clientOptions = new PlaywrightServiceBrowserClientOptions(environment: environment, serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_09_01)
        {
            RunName = customRunName
        };
        PlaywrightServiceBrowserClient client = new(environment, options: clientOptions, playwrightVersion: playwrightVersion);
        Assert.Multiple(() =>
        {
            Assert.That(client._options.RunName, Is.EqualTo(customRunName));
            Assert.That(environment.GetEnvironmentVariable(Constants.s_playwright_service_run_name_environment_variable), Is.EqualTo(customRunName));
        });
    }

    [Test]
    public void Constructor_RunNameExceedsMaxLength_TruncatesRunName()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        var longRunName = new string('a', 250);
        var clientOptions = new PlaywrightServiceBrowserClientOptions(environment: environment, serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_09_01)
        {
            RunName = longRunName
        };
        PlaywrightServiceBrowserClient client = new(environment, options: clientOptions, playwrightVersion: playwrightVersion);
        Assert.Multiple(() =>
        {
            Assert.That(client._options.RunName.Length, Is.EqualTo(200));
            Assert.That(client._options.RunName, Is.EqualTo(longRunName.Substring(0, 200)));
        });
    }

    [Test]
    public void Constructor_RunNameSetFromEnvironment_UsesEnvironmentValue()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        var environmentRunName = "Environment Run Name";
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_name_environment_variable, environmentRunName);
        PlaywrightServiceBrowserClient client = new(environment, playwrightVersion: playwrightVersion);
        Assert.Multiple(() =>
        {
            Assert.That(client._options.RunName, Is.EqualTo(environmentRunName));
        });
    }

    [Test]
    public void InitializeAsync_WhenServiceEnpointIsNotSet_NoOP()
    {
        var environment = new TestEnvironment();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var playwrightVersion = new PlaywrightVersion();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        client.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public void InitializeAsync_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsSet_FetchesEntraIdAccessToken()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var playwrightVersion = new PlaywrightVersion();
        var testRunUpdateClientMock = new Mock<TestRunUpdateClient>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        testRunUpdateClientMock
            .Setup(x => x.TestRunsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContent>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContext>()))
            .ReturnsAsync(Mock.Of<Response>());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "access_token");
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion, testRunUpdateClient: testRunUpdateClientMock.Object);
        client.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        client.RotationTimer!.Dispose();

        Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString()), Is.Not.Null);
    }

    [Test]
    public void InitializeAsync_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsSetAndCredentialsArePassed_FetchesEntraIdAccessTokenUsedPassedCredentials()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var tokenCredential = new Mock<TokenCredential>();
        var playwrightVersion = new PlaywrightVersion();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var testRunUpdateClientMock = new Mock<TestRunUpdateClient>();
        var token = "valid_token";
        tokenCredential
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        testRunUpdateClientMock
            .Setup(x => x.TestRunsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContent>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContext>()))
            .ReturnsAsync(Mock.Of<Response>());
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "access_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(tokenCredential.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion, testRunUpdateClient: testRunUpdateClientMock.Object);
        client.InitializeAsync().Wait();
        tokenCredential.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        client.RotationTimer!.Dispose();

        Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString()), Is.Not.Null);
    }

    [Test]
    public void InitializeAsync_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsNotSet_FetchesEntraIdAccessToken()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var playwrightVersion = new PlaywrightVersion();
        var testRunUpdateClientMock = new Mock<TestRunUpdateClient>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        testRunUpdateClientMock
            .Setup(x => x.TestRunsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContent>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContext>()))
            .ReturnsAsync(Mock.Of<Response>());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion, testRunUpdateClient: testRunUpdateClientMock.Object);
        client.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        client.RotationTimer!.Dispose();
    }

    [Test]
    public void InitializeAsync_WhenFetchesEntraIdAccessToken_SetsUpRotationHandler()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var playwrightVersion = new PlaywrightVersion();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var testRunUpdateClientMock = new Mock<TestRunUpdateClient>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        testRunUpdateClientMock
            .Setup(x => x.TestRunsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContent>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContext>()))
            .ReturnsAsync(Mock.Of<Response>());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion, testRunUpdateClient: testRunUpdateClientMock.Object);
        client.InitializeAsync().Wait();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
        Assert.That(client.RotationTimer, Is.Not.Null);

        client.RotationTimer!.Dispose();
    }

    [Test]
    public void InitializeAsync_WhenFailsToFetchEntraIdAccessToken_ThrowsException()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var playwrightVersion = new PlaywrightVersion();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        Exception? ex = Assert.ThrowsAsync<Exception>(async () => await client.InitializeAsync());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void InitializeAsync_WhenEntraIdAccessTokenFailsAndMptPatIsSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"pwid", "account-id-guid"},
        });
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var playwrightVersion = new PlaywrightVersion();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        Exception? ex = Assert.ThrowsAsync<Exception>(async () => await client.InitializeAsync());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void InitializeAsync_WhenEntraIdAccessTokenFailsAndMptPatIsNotSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"pwid", "account-id-guid"},
        });
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var playwrightVersion = new PlaywrightVersion();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        Exception? ex = Assert.ThrowsAsync<Exception>(async () => await client.InitializeAsync());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void InitializeAsync_WhenEntraIdAccessTokenFailsAndMptPatIsNotValid_ThrowsError()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var token = "sample token";
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var playwrightVersion = new PlaywrightVersion();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        Assert.That(() => client.InitializeAsync().Wait(), Throws.Exception);
    }

    [Test]
    public void InitializeAsync_WhenEntraIdAccessTokenFailsAndMptPatTokenParsingReturnsNull_ThrowsError()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var token = "sample token";
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var playwrightVersion = new PlaywrightVersion();
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
        PlaywrightServiceBrowserClient client = new(environment: environment, entraLifecycle: entraLifecycleMock.Object, jsonWebTokenHandler: jsonWebTokenHandlerMock.Object, playwrightVersion: playwrightVersion);
        Assert.That(() => client.InitializeAsync().Wait(), Throws.Exception);
    }

    [Test]
    public void InitializeAsync_WhenEntraIdAccessTokenFailsAndMptPatIsExpired_ThrowsError()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"pwid", "account-id-guid"},
        }, DateTime.UtcNow.AddMinutes(-1));
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var playwrightVersion = new PlaywrightVersion();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);

        Assert.That(() => client.InitializeAsync().Wait(), Throws.Exception);
    }

    [Test]
    public void InitializeAsync_WhenDefaultAuthIsMptPATAndPATIsSet_DoesNotSetUpRotationHandler()
    {
        var environment = new TestEnvironment();
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"pwid", "eastus_bd830e63-6120-40cb-8cd7-f0739502d888"},
        });
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var playwrightVersion = new PlaywrightVersion();
        var testRubric = new Dictionary<string, string>
        {
            { "url", "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers" },
            { "workspaceId", "eastus_bd830e63-6120-40cb-8cd7-f0739502d888" },
            { "region", "eastus" },
            { "domain", "playwright.microsoft.com" }
        };
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), $"{testRubric["url"]}");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var testRunUpdateClientMock = new Mock<TestRunUpdateClient>();
        testRunUpdateClientMock
            .Setup(x => x.TestRunsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContent>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContext>()))
            .ReturnsAsync(Mock.Of<Response>());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        var clientOptions = new PlaywrightServiceBrowserClientOptions(environment: environment, serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_09_01)
        {
            ServiceAuth = ServiceAuthType.AccessToken
        };
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, options: clientOptions, playwrightVersion: playwrightVersion, testRunUpdateClient: testRunUpdateClientMock.Object);
        client.InitializeAsync().Wait();
        Assert.That(client.RotationTimer, Is.Null);
    }

    [Test]
    public void Initialize_WhenServiceEnpointIsNotSet_NoOP()
    {
        var environment = new TestEnvironment();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var playwrightVersion = new PlaywrightVersion();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        client.Initialize();
        defaultAzureCredentialMock.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsSet_FetchesEntraIdAccessToken()
    {
        var environment = new TestEnvironment();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var playwrightVersion = new PlaywrightVersion();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var testRunUpdateClientMock = new Mock<TestRunUpdateClient>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        testRunUpdateClientMock
            .Setup(x => x.TestRuns(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContent>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContext>()))
            .Returns(Mock.Of<Response>());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "access_token");
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion, testRunUpdateClient: testRunUpdateClientMock.Object);
        client.Initialize();
        defaultAzureCredentialMock.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        client.RotationTimer!.Dispose();

        Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString()), Is.Not.Null);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsSetAndCredentialsArePassed_FetchesEntraIdAccessTokenUsedPassedCredentials()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var tokenCredential = new Mock<TokenCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var testRunUpdateClientMock = new Mock<TestRunUpdateClient>();
        var token = "valid_token";
        tokenCredential
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        testRunUpdateClientMock
            .Setup(x => x.TestRuns(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContent>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContext>()))
            .Returns(Mock.Of<Response>());
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "access_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(tokenCredential.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion, testRunUpdateClient: testRunUpdateClientMock.Object);
        client.Initialize();
        tokenCredential.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        client.RotationTimer!.Dispose();

        Assert.That(environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString()), Is.Not.Null);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsEntraIdAccessTokenAndAccessTokenEnvironmentVariableIsNotSet_FetchesEntraIdAccessToken()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var testRunUpdateClientMock = new Mock<TestRunUpdateClient>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        testRunUpdateClientMock
            .Setup(x => x.TestRuns(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContent>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContext>()))
            .Returns(Mock.Of<Response>());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion, testRunUpdateClient: testRunUpdateClientMock.Object);
        client.Initialize();
        defaultAzureCredentialMock.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);

        client.RotationTimer!.Dispose();
    }

    [Test]
    public void Initialize_WhenFetchesEntraIdAccessToken_SetsUpRotationHandler()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var testRunUpdateClientMock = new Mock<TestRunUpdateClient>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(10)));
        testRunUpdateClientMock
            .Setup(x => x.TestRuns(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContent>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContext>()))
            .Returns(Mock.Of<Response>());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion, testRunUpdateClient: testRunUpdateClientMock.Object);
        client.Initialize();
        defaultAzureCredentialMock.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
        Assert.That(client.RotationTimer, Is.Not.Null);

        client.RotationTimer!.Dispose();
    }

    [Test]
    public void Initialize_WhenFailsToFetchEntraIdAccessToken_ThrowsException()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Throws(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        Exception? ex = Assert.Throws<Exception>(() => client.Initialize());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatIsSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"pwid", "account-id-guid"},
        });
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Throws(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        Exception? ex = Assert.Throws<Exception>(() => client.Initialize());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatIsNotSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"pwid", "account-id-guid"},
        });
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Throws(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        Exception? ex = Assert.Throws<Exception>(() => client.Initialize());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatIsNotValid_ThrowsError()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var token = "sample token";
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Throws(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        Assert.That(() => client.Initialize(), Throws.Exception);
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatTokenParsingReturnsNull_ThrowsError()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
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
        PlaywrightServiceBrowserClient client = new(environment: environment, entraLifecycle: entraLifecycleMock.Object, jsonWebTokenHandler: jsonWebTokenHandlerMock.Object, playwrightVersion: playwrightVersion);
        Assert.That(() => client.Initialize(), Throws.Exception);
    }

    [Test]
    public void Initialize_WhenEntraIdAccessTokenFailsAndMptPatIsExpired_ThrowsError()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"pwid", "account-id-guid"},
        }, DateTime.UtcNow.AddMinutes(-1));
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Throws(new Exception());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);

        Assert.That(() => client.Initialize(), Throws.Exception);
    }

    [Test]
    public void Initialize_WhenDefaultAuthIsMptPATAndPATIsSet_DoesNotSetUpRotationHandler()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        var token = TestUtilities.GetToken(new Dictionary<string, object>
        {
            {"pwid", "eastus_bd830e63-6120-40cb-8cd7-f0739502d888"},
        });
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), token);
        var testRubric = new Dictionary<string, string>
        {
            { "url", "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers" },
            { "workspaceId", "eastus_bd830e63-6120-40cb-8cd7-f0739502d888" },
            { "region", "eastus" },
            { "domain", "playwright.microsoft.com" }
        };
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), $"{testRubric["url"]}");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var testRunUpdateClientMock = new Mock<TestRunUpdateClient>();
        testRunUpdateClientMock
            .Setup(x => x.TestRuns(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContent>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestContext>()))
            .Returns(Mock.Of<Response>());
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, new JsonWebTokenHandler(), null, environment);
        var clientOptions = new PlaywrightServiceBrowserClientOptions(environment: environment, serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_09_01)
        {
            ServiceAuth = ServiceAuthType.AccessToken
        };
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, options: clientOptions, playwrightVersion: playwrightVersion, testRunUpdateClient: testRunUpdateClientMock.Object);
        client.Initialize();
        Assert.That(client.RotationTimer, Is.Null);
    }

    [Test]
    public void RotationHandler_WhenEntraIdAccessTokenRequiresRotation_FetchesEntraIdAccessToken()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var token = "valid_token";
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(5)));
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);

        client.RotationHandlerAsync(null);
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public void RotationHandler_WhenEntraIdAccessTokenDoesNotRequireRotation_NoOp()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);

        client.RotationHandlerAsync(null);
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public void SetOptions_WhenRunIdExceedsMaxLength_ThrowsArgumentException()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        var notGuidRunId = new string('a', 201);
        var clientOptions = new PlaywrightServiceBrowserClientOptions(environment: environment, serviceVersion: PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_09_01);
        ArgumentException? exception = Assert.Throws<ArgumentException>(() => clientOptions.RunId = notGuidRunId);
        Assert.That(exception, Is.Not.Null);
        Assert.That(exception!.Message, Is.EqualTo(Constants.s_playwright_service_runId_not_guid_error_message));
    }

    [Test]
    public void GetConnectOptionsAsync_WhenServiceEndpointIsNotSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        PlaywrightServiceBrowserClient client = new(environment, playwrightVersion: playwrightVersion);
        Exception? ex = Assert.ThrowsAsync<Exception>(() => client.GetConnectOptionsAsync<BrowserConnectOptions>());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_service_endpoint_error_message));
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenServiceEndpointIsSet_ReturnsConnectOptions()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        ConnectOptions<BrowserConnectOptions> connectOptions = await client.GetConnectOptionsAsync<BrowserConnectOptions>(runId: runId);
        var authorizationHeader = connectOptions.Options!.Headers!.Where(x => x.Key == "Authorization").FirstOrDefault().Value!;
        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={Constants.s_default_os}&runId={runId}&api-version=2025-09-01"));
            Assert.That(connectOptions.Options!.Timeout, Is.EqualTo(3 * 60 * 1000));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo(Constants.s_default_expose_network));
            Assert.That(authorizationHeader, Is.EqualTo("Bearer valid_token"));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenTokenRequiresRotation_RotatesEntraToken()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken("valid_token", DateTimeOffset.UtcNow.AddMinutes(5)));
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(-1).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        _ = await client.GetConnectOptionsAsync<BrowserConnectOptions>();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenTokenDoesNotRequireRotation_DoesNotRotateEntraToken()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        defaultAzureCredentialMock
            .Setup(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AccessToken("valid_token", DateTimeOffset.UtcNow.AddMinutes(5)));
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        _ = await client.GetConnectOptionsAsync<BrowserConnectOptions>();
        defaultAzureCredentialMock.Verify(x => x.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenDefaultParametersAreProvided_SetsServiceParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
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

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        ConnectOptions<BrowserConnectOptions> connectOptions = await client.GetConnectOptionsAsync<BrowserConnectOptions>(runId: runId, os: OSPlatform.Windows, exposeNetwork: "localhost");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os=windows&runId={runId}&api-version=2025-09-01"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("localhost"));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenDefaultParametersAreNotProvided_SetsDefaultServiceParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
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

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        ConnectOptions<BrowserConnectOptions> connectOptions = await client.GetConnectOptionsAsync<BrowserConnectOptions>(runId: runId);

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={Constants.s_default_os}&runId={runId}&api-version=2025-09-01"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo(Constants.s_default_expose_network));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenParametersAreSetInTheObjectButAlsoPassedInMethod_UsesMethodParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
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

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        ConnectOptions<BrowserConnectOptions> connectOptions = await client.GetConnectOptionsAsync<BrowserConnectOptions>(os: OSPlatform.Windows, runId: newRunId, exposeNetwork: "expose-network");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={OSConstants.s_wINDOWS}&runId={newRunId}&api-version=2025-09-01"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("expose-network"));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenParametersAreSetViaEnvironmentButAlsoPassedInMethod_UsesMethodParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
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

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        environment.SetEnvironmentVariable(Constants.s_playwright_service_os_environment_variable.ToString(), OSConstants.s_lINUX);
        environment.SetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable.ToString(), "expose");
        ConnectOptions<BrowserConnectOptions> connectOptions = await client.GetConnectOptionsAsync<BrowserConnectOptions>(os: OSPlatform.Windows, runId: newRunId, exposeNetwork: "expose-network");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={OSConstants.s_wINDOWS}&runId={newRunId}&api-version=2025-09-01"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("expose-network"));
        });
    }

    [Test]
    public async Task GetConnectOptionsAsync_WhenServiceParametersAreSetViaEnvironment_SetsServiceParameters()
    {
        var runId = "run-id";
        var runName = "run-name";
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_name_environment_variable, runName);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object
            ._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object
            ._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);

        environment.SetEnvironmentVariable(Constants.s_playwright_service_os_environment_variable.ToString(), OSConstants.s_wINDOWS);
        environment.SetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable.ToString(), "localhost");

        ConnectOptions<BrowserConnectOptions> connectOptions = await client.GetConnectOptionsAsync<BrowserConnectOptions>();
        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={OSConstants.s_wINDOWS}&runId={runId}&api-version=2025-09-01"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("localhost"));
            Assert.That(client._options.RunName, Is.EqualTo(runName));
        });
    }

    [Test]
    public void GetConnectOptionsAsync_WhenNoAuthTokenIsSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);

        Exception? ex = Assert.ThrowsAsync<Exception>(() => client.GetConnectOptionsAsync<BrowserConnectOptions>());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }

    [Test]
    public void GetConnectOptions_WhenServiceEndpointIsSet_ReturnsConnectOptions()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        ConnectOptions<BrowserConnectOptions> connectOptions = client.GetConnectOptions<BrowserConnectOptions>(runId: runId);
        var authorizationHeader = connectOptions.Options!.Headers!.Where(x => x.Key == "Authorization").FirstOrDefault().Value!;
        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={Constants.s_default_os}&runId={runId}&api-version=2025-09-01"));
            Assert.That(connectOptions.Options!.Timeout, Is.EqualTo(3 * 60 * 1000));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo(Constants.s_default_expose_network));
            Assert.That(authorizationHeader, Is.EqualTo("Bearer valid_token"));
        });
    }

    [Test]
    public void GetConnectOptions_WhenTokenRequiresRotation_RotatesEntraToken()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken("valid_token", DateTimeOffset.UtcNow.AddMinutes(5)));
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(-1).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        _ = client.GetConnectOptions<BrowserConnectOptions>();
        defaultAzureCredentialMock.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public void GetConnectOptions_WhenTokenDoesNotRequireRotation_DoesNotRotateEntraToken()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "wss://eastus.api.playwright.microsoft.com/playwrightworkspaces/eastus_bd830e63-6120-40cb-8cd7-f0739502d888/browsers");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), "valid_token");
        defaultAzureCredentialMock
            .Setup(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
            .Returns(new AccessToken("valid_token", DateTimeOffset.UtcNow.AddMinutes(5)));
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        entraLifecycleMock.Object._entraIdAccessToken = "valid_token";
        entraLifecycleMock.Object._entraIdAccessTokenExpiry = (int)DateTimeOffset.UtcNow.AddMinutes(22).ToUnixTimeSeconds();

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        _ = client.GetConnectOptions<BrowserConnectOptions>();
        defaultAzureCredentialMock.Verify(x => x.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public void GetConnectOptions_WhenDefaultParametersAreProvided_SetsServiceParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
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

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        ConnectOptions<BrowserConnectOptions> connectOptions = client.GetConnectOptions<BrowserConnectOptions>(runId: runId, os: OSPlatform.Windows, exposeNetwork: "localhost");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os=windows&runId={runId}&api-version=2025-09-01"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("localhost"));
        });
    }

    [Test]
    public void GetConnectOptions_WhenDefaultParametersAreNotProvided_SetsDefaultServiceParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
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

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        ConnectOptions<BrowserConnectOptions> connectOptions = client.GetConnectOptions<BrowserConnectOptions>(runId: runId);

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={Constants.s_default_os}&runId={runId}&api-version=2025-09-01"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo(Constants.s_default_expose_network));
        });
    }

    [Test]
    public void GetConnectOptions_WhenParametersAreSetInTheObjectButAlsoPassedInMethod_UsesMethodParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
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

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        ConnectOptions<BrowserConnectOptions> connectOptions = client.GetConnectOptions<BrowserConnectOptions>(os: OSPlatform.Windows, runId: newRunId, exposeNetwork: "expose-network");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={OSConstants.s_wINDOWS}&runId={newRunId}&api-version=2025-09-01"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("expose-network"));
        });
    }

    [Test]
    public void GetConnectOptions_WhenParametersAreSetViaEnvironmentButAlsoPassedInMethod_UsesMethodParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
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

        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);
        environment.SetEnvironmentVariable(Constants.s_playwright_service_os_environment_variable.ToString(), OSConstants.s_lINUX);
        environment.SetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable.ToString(), "expose");
        ConnectOptions<BrowserConnectOptions> connectOptions = client.GetConnectOptions<BrowserConnectOptions>(os: OSPlatform.Windows, runId: newRunId, exposeNetwork: "expose-network");

        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={OSConstants.s_wINDOWS}&runId={newRunId}&api-version=2025-09-01"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("expose-network"));
        });
    }

    [Test]
    public void GetConnectOptions_WhenServiceParametersAreSetViaEnvironment_SetsServiceParameters()
    {
        var runId = "run-id";
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
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
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);

        environment.SetEnvironmentVariable(Constants.s_playwright_service_os_environment_variable.ToString(), OSConstants.s_wINDOWS);
        environment.SetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable.ToString(), "localhost");

        ConnectOptions<BrowserConnectOptions> connectOptions = client.GetConnectOptions<BrowserConnectOptions>();
        Assert.Multiple(() =>
        {
            Assert.That(connectOptions.WsEndpoint, Is.EqualTo($"https://playwright.microsoft.com?os={OSConstants.s_wINDOWS}&runId={runId}&api-version=2025-09-01"));
            Assert.That(connectOptions.Options!.ExposeNetwork, Is.EqualTo("localhost"));
        });
    }

    [Test]
    public void GetConnectOptions_WhenNoAuthTokenIsSet_ThrowsException()
    {
        var environment = new TestEnvironment();
        var playwrightVersion = new PlaywrightVersion();
        environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), "https://playwright.microsoft.com");
        var defaultAzureCredentialMock = new Mock<DefaultAzureCredential>();
        var jsonWebTokenHandlerMock = new Mock<JsonWebTokenHandler>();
        var entraLifecycleMock = new Mock<EntraLifecycle>(defaultAzureCredentialMock.Object, jsonWebTokenHandlerMock.Object, null, environment);
        PlaywrightServiceBrowserClient client = new(environment, entraLifecycle: entraLifecycleMock.Object, playwrightVersion: playwrightVersion);

        Exception? ex = Assert.Throws<Exception>(() => client.GetConnectOptions<BrowserConnectOptions>());
        Assert.That(ex!.Message, Is.EqualTo(Constants.s_no_auth_error));
    }
    [Test]
    public void Constructor_WhenPlaywrightVersionValidationFails_ThrowsException()
    {
        var environment = new TestEnvironment();
        var playwrightVersionMock = new Mock<Interface.IPlaywrightVersion>();
        var expectedErrorMessage = "The Playwright version you are using does not support playwright workspaces. Please update to Playwright version 1.50.0 or higher.";
        playwrightVersionMock
            .Setup(x => x.ValidatePlaywrightVersion())
            .Throws(new Exception(expectedErrorMessage));

        var exception = Assert.Throws<Exception>(() =>
            new PlaywrightServiceBrowserClient(environment, playwrightVersion: playwrightVersionMock.Object));
        Assert.That(exception?.Message, Is.EqualTo(expectedErrorMessage));
        playwrightVersionMock.Verify(x => x.ValidatePlaywrightVersion(), Times.Once);
    }
}
