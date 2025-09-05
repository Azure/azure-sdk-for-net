// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Developer.Playwright.Implementation;
using Azure.Developer.Playwright.Interface;
using Azure.Developer.Playwright.Utility;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Developer.Playwright;

/// <summary>
/// Sets up and manages the Playwright Workspaces browser client.
/// </summary>
public class PlaywrightServiceBrowserClient : IDisposable
{
    internal readonly IEntraLifecycle _entraLifecycle;
    internal readonly IEnvironment _environment;
    internal readonly JsonWebTokenHandler _jsonWebTokenHandler;
    internal readonly PlaywrightServiceBrowserClientOptions _options;
    internal readonly ClientUtilities _clientUtility;
    internal readonly ILogger? _logger;
    internal readonly IPlaywrightVersion _playwrightVersion;
    internal readonly CIProvider _ciProvider;
    internal TestRunUpdateClient? _testRunUpdateClient;

    internal Timer? RotationTimer { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserClient"/> class.
    /// </summary>
    public PlaywrightServiceBrowserClient() : this(new PlaywrightServiceBrowserClientOptions())
    {
        // No-op
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserClient"/> class.
    /// </summary>
    /// <param name="credential">The token credential.</param>
    public PlaywrightServiceBrowserClient(TokenCredential credential) : this(options: new PlaywrightServiceBrowserClientOptions(), credential: credential)
    {
        // No-op
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserClient"/> class.
    /// </summary>
    /// <param name="options">The client options.</param>
    public PlaywrightServiceBrowserClient(PlaywrightServiceBrowserClientOptions options) : this(
        environment: null,
        entraLifecycle: null,
        jsonWebTokenHandler: null,
        logger: null,
        clientUtility: null,
        ciProvider: null,
        options: options
    )
    {
        // No-op
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserClient"/> class.
    /// </summary>
    /// <param name="options">The client options.</param>
    /// <param name="credential">The token credential.</param>
    public PlaywrightServiceBrowserClient(TokenCredential credential, PlaywrightServiceBrowserClientOptions options) : this(
        environment: null,
        entraLifecycle: null,
        jsonWebTokenHandler: null,
        logger: null,
        clientUtility: null,
        ciProvider: null,
        options: options,
        tokenCredential: credential
    )
    {
        // No-op
    }

    internal PlaywrightServiceBrowserClient(IEnvironment? environment = null, IEntraLifecycle? entraLifecycle = null, JsonWebTokenHandler? jsonWebTokenHandler = null, CIProvider? ciProvider = null, ILogger? logger = null, ClientUtilities? clientUtility = null, PlaywrightServiceBrowserClientOptions? options = null, TokenCredential? tokenCredential = null, IPlaywrightVersion? playwrightVersion = null, TestRunUpdateClient? testRunUpdateClient = null)
    {
        _environment = environment ?? new EnvironmentHandler();
        _playwrightVersion = playwrightVersion ?? new PlaywrightVersion();
        _clientUtility = clientUtility ?? new ClientUtilities(_environment, playwrightVersion: _playwrightVersion);
        _ciProvider = ciProvider ?? new CIProvider(_environment);
        _options = options ?? new PlaywrightServiceBrowserClientOptions(PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_09_01, environment: _environment, clientUtility: _clientUtility);
        _logger = logger ?? _options.Logger;
        _jsonWebTokenHandler = jsonWebTokenHandler ?? new JsonWebTokenHandler();
        _entraLifecycle = entraLifecycle ?? new EntraLifecycle(jsonWebTokenHandler: _jsonWebTokenHandler, logger: _logger, environment: _environment, tokenCredential: tokenCredential);
        _testRunUpdateClient = testRunUpdateClient;
        _playwrightVersion.ValidatePlaywrightVersion();
        // Call getters to set default environment variables if not already set before
        _ = _options.OS;
        _ = _options.RunId;
        _ = _options.RunName;
        _ = _options.ExposeNetwork;
        _ = _options.ServiceAuth;
    }

    /// <summary>
    /// Gets the connect options for connecting to Playwright Workspaces's cloud hosted browsers.
    /// </summary>
    /// <typeparam name="T">The type of the connect options.</typeparam>
    /// <param name="os">The operating system.</param>
    /// <param name="runId">The run ID.</param>
    /// <param name="exposeNetwork">The network exposure.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The connect options.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
    public virtual async Task<ConnectOptions<T>> GetConnectOptionsAsync<T>(OSPlatform? os = null, string? runId = null, string? exposeNetwork = null, CancellationToken cancellationToken = default) where T : class, new()
#pragma warning restore AZC0015 // Unexpected client method return type.
    {
        if (string.IsNullOrEmpty(_options.ServiceEndpoint))
            throw new Exception(Constants.s_no_service_endpoint_error_message);
        string _serviceOs = Uri.EscapeDataString(ClientUtilities.GetServiceCompatibleOs(os) ?? ClientUtilities.GetServiceCompatibleOs(_options.OS)!);
        string _runId = Uri.EscapeDataString(runId ?? _options.RunId);
        string _exposeNetwork = exposeNetwork ?? _options.ExposeNetwork;

        string wsEndpoint = $"{_options.ServiceEndpoint!}?os={_serviceOs}&runId={_runId}&api-version={_options.VersionString}";

        // fetch Entra id access token if required
        // 1. Entra id access token has been fetched once via global functions
        // 2. Not close to expiry
        if (!string.IsNullOrEmpty(_entraLifecycle.GetEntraIdAccessToken()) && _entraLifecycle.DoesEntraIdAccessTokenRequireRotation())
        {
            await _entraLifecycle.FetchEntraIdAccessTokenAsync(cancellationToken).ConfigureAwait(false);
        }
        if (string.IsNullOrEmpty(_options.AuthToken))
        {
            _logger?.LogError("Access token not found when trying to call GetConnectOptionsAsync.");
            throw new Exception(Constants.s_no_auth_error);
        }

        var browserConnectOptions = new BrowserConnectOptions
        {
            Timeout = 3 * 60 * 1000,
            ExposeNetwork = _exposeNetwork,
            Headers = new Dictionary<string, string>
            {
                ["Authorization"] = $"Bearer {_options.AuthToken}"
            }
        };
        return new ConnectOptions<T>(wsEndpoint, BrowserConnectOptionsConverter.Convert<T>(browserConnectOptions));
    }

    /// <summary>
    /// Gets the connect options for connecting to Playwright Workspaces's cloud hosted browsers.
    /// </summary>
    /// <typeparam name="T">The type of the connect options.</typeparam>
    /// <param name="os">The operating system.</param>
    /// <param name="runId">The run ID.</param>
    /// <param name="exposeNetwork">The network exposure.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The connect options.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
    public virtual ConnectOptions<T> GetConnectOptions<T>(OSPlatform? os = null, string? runId = null, string? exposeNetwork = null, CancellationToken cancellationToken = default) where T : class, new()
#pragma warning restore AZC0015 // Unexpected client method return type.
    {
        if (string.IsNullOrEmpty(_options.ServiceEndpoint))
            throw new Exception(Constants.s_no_service_endpoint_error_message);
        string _serviceOs = Uri.EscapeDataString(ClientUtilities.GetServiceCompatibleOs(os) ?? ClientUtilities.GetServiceCompatibleOs(_options.OS)!);
        string _runId = Uri.EscapeDataString(runId ?? _options.RunId);
        string _exposeNetwork = exposeNetwork ?? _options.ExposeNetwork;

        string wsEndpoint = $"{_options.ServiceEndpoint!}?os={_serviceOs}&runId={_runId}&api-version={_options.VersionString}";

        // fetch Entra id access token if required
        // 1. Entra id access token has been fetched once via global functions
        // 2. Not close to expiry
        if (!string.IsNullOrEmpty(_entraLifecycle.GetEntraIdAccessToken()) && _entraLifecycle.DoesEntraIdAccessTokenRequireRotation())
        {
            _entraLifecycle.FetchEntraIdAccessToken(cancellationToken);
        }
        if (string.IsNullOrEmpty(_options.AuthToken))
        {
            _logger?.LogError("Access token not found when trying to call GetConnectOptionsAsync.");
            throw new Exception(Constants.s_no_auth_error);
        }

        var browserConnectOptions = new BrowserConnectOptions
        {
            Timeout = 3 * 60 * 1000,
            ExposeNetwork = _exposeNetwork,
            Headers = new Dictionary<string, string>
            {
                ["Authorization"] = $"Bearer {_options.AuthToken}"
            }
        };
        return new ConnectOptions<T>(wsEndpoint, BrowserConnectOptionsConverter.Convert<T>(browserConnectOptions));
    }

    /// <summary>
    /// Initialises the resources used to setup entra id authentication.
    /// </summary>
#pragma warning disable AZC0015 // Unexpected client method return type.
    public virtual async Task InitializeAsync(CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
    {
        if (string.IsNullOrEmpty(_options.ServiceEndpoint))
        {
            _logger?.LogInformation("Exiting initialization as service endpoint is not set.");
            return;
        }
        // If default auth mechanism is Access token and token is available in the environment variable, no need to setup rotation handler
        if (_options.ServiceAuth == ServiceAuthType.AccessToken)
        {
            _logger?.LogInformation("Auth mechanism is Access Token.");
            _clientUtility.ValidateMptPAT(_options.AuthToken, _options.ServiceEndpoint!);
            await CreateTestRunPatchCallAsync(_options.AuthToken, cancellationToken).ConfigureAwait(false);
            return;
        }
        _logger?.LogInformation("Auth mechanism is Entra Id.");
        await _entraLifecycle!.FetchEntraIdAccessTokenAsync(cancellationToken).ConfigureAwait(false);
        RotationTimer = new Timer(RotationHandlerAsync, null, TimeSpan.FromMinutes(Constants.s_entra_access_token_rotation_interval_period_in_minutes), TimeSpan.FromMinutes(Constants.s_entra_access_token_rotation_interval_period_in_minutes));
        string? entraIdToken = _entraLifecycle.GetEntraIdAccessToken();
        await CreateTestRunPatchCallAsync(entraIdToken, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Initialises the resources used to setup entra id authentication.
    /// </summary>
#pragma warning disable AZC0015 // Unexpected client method return type.
    public virtual void Initialize(CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
    {
        if (string.IsNullOrEmpty(_options.ServiceEndpoint))
        {
            _logger?.LogInformation("Exiting initialization as service endpoint is not set.");
            return;
        }
        // If default auth mechanism is Access token and token is available in the environment variable, no need to setup rotation handler
        if (_options.ServiceAuth == ServiceAuthType.AccessToken)
        {
            _logger?.LogInformation("Auth mechanism is Access Token.");
            _clientUtility.ValidateMptPAT(_options.AuthToken, _options.ServiceEndpoint!);
            if (!string.IsNullOrEmpty(_options.AuthToken))
            {
                CreateTestRunPatchCall(_options.AuthToken);
            }
            else
            {
                _logger?.LogError("Access token is null or empty");
            }
            return;
        }
        _logger?.LogInformation("Auth mechanism is Entra Id.");
        _entraLifecycle!.FetchEntraIdAccessToken(cancellationToken);
        RotationTimer = new Timer(RotationHandlerAsync, null, TimeSpan.FromMinutes(Constants.s_entra_access_token_rotation_interval_period_in_minutes), TimeSpan.FromMinutes(Constants.s_entra_access_token_rotation_interval_period_in_minutes));
        string? entraIdToken = _entraLifecycle.GetEntraIdAccessToken();
        CreateTestRunPatchCall(entraIdToken);
    }

    /// <summary>
    /// Cleans up the resources used to setup entra id authentication.
    /// </summary>
#pragma warning disable AZC0015 // Unexpected client method return type.
    public virtual async Task DisposeAsync()
#pragma warning restore AZC0015 // Unexpected client method return type.
    {
        Dispose();
        await Task.CompletedTask.ConfigureAwait(false);
    }

    /// <summary>
    /// Cleans up the resources used to setup entra id authentication.
    /// </summary>
#pragma warning disable AZC0015 // Unexpected client method return type.
    public virtual void Dispose()
#pragma warning restore AZC0015 // Unexpected client method return type.
    {
        _logger?.LogInformation("Cleaning up Playwright Workspaces resources.");
        RotationTimer?.Dispose();
        GC.SuppressFinalize(this);
    }

    internal async void RotationHandlerAsync(object? _)
    {
        if (_entraLifecycle!.DoesEntraIdAccessTokenRequireRotation())
        {
            _logger?.LogInformation("Rotating Entra Id access token.");
            await _entraLifecycle.FetchEntraIdAccessTokenAsync(default).ConfigureAwait(false);
        }
    }

      /// <summary>
    /// Creates a TestRunUpdateClient with configured retry policy
    /// </summary>
    /// <param name="endpoint">API endpoint URI</param>
    /// <returns>Configured TestRunUpdateClient</returns>
    private static TestRunUpdateClient CreateTestRunUpdateClientWithRetry(Uri endpoint)
    {
        var clientOptions = new TestRunUpdateClientOptions();
        clientOptions.Diagnostics.IsLoggingEnabled = true;
        clientOptions.Diagnostics.IsTelemetryEnabled = true;
        clientOptions.Retry.MaxRetries = ServiceClientConstants.s_mAX_RETRIES;
        clientOptions.Retry.Delay = TimeSpan.FromMilliseconds(ServiceClientConstants.s_iNITIAL_DELAY_MS);
        clientOptions.Retry.MaxDelay = TimeSpan.FromMilliseconds(ServiceClientConstants.s_mAX_DELAY_MS);
        return new TestRunUpdateClient(endpoint, clientOptions);
    }

    /// <summary>
    /// Sets up the TestRunUpdateClient and performs the PATCH operation to create test run
    /// </summary>
    /// <param name="authToken">The authentication token to use</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>A task representing the asynchronous operation</returns>
    private async Task CreateTestRunPatchCallAsync(string? authToken, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(authToken))
        {
            _logger?.LogError("Cannot create test run: Auth token is null or empty");
            return;
        }
        string apiUrl = _clientUtility.GetTestRunApiUrl();
        Uri endpoint = new(apiUrl);
        _testRunUpdateClient ??= CreateTestRunUpdateClientWithRetry(endpoint);
        Model.CIInfo cIInfo = _ciProvider.GetCIInfo();
        Model.RunConfig runConfig = _clientUtility.GetTestRunConfig();
        var patchBody = new
        {
            displayName = _options.RunName,
            ciConfig = cIInfo,
            config = runConfig
        };
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };
        var json = JsonSerializer.Serialize(patchBody, options);
        var content = RequestContent.Create(BinaryData.FromString(json));
        try
        {
            var workspaceId = _clientUtility.ExtractWorkspaceIdFromEndpoint(_options.ServiceEndpoint!);
            var testRunId = _options.RunId;
            Response response = await _testRunUpdateClient.TestRunsAsync(
                 workspaceId: workspaceId,
                testRunId: testRunId,
                content: content,
                authorization: $"Bearer {authToken}",
                xCorrelationId: Guid.NewGuid().ToString()
            ).ConfigureAwait(false);
            _logger?.LogInformation("Test run created successfully.");
        }
        catch (RequestFailedException ex)
        {
            _logger?.LogError($"Failed to create the test run in the Playwright Workspaces: {ex.Message}. Please refer to https://aka.ms/pww/docs/troubleshooting for more information.");
            throw new Exception(Constants.s_playwright_service_create_test_run_error, ex);
        }
    }

    /// <summary>
    /// Sets up the TestRunUpdateClient and performs the PATCH operation to create test run (synchronous version)
    /// </summary>
    /// <param name="authToken">The authentication token to use</param>
    private void CreateTestRunPatchCall(string? authToken)
    {
        if (string.IsNullOrEmpty(authToken))
        {
            _logger?.LogError("Cannot create test run: Auth token is null or empty");
            return;
        }
        string apiUrl = _clientUtility.GetTestRunApiUrl();
        Uri endpoint = new(apiUrl);
        _testRunUpdateClient ??= CreateTestRunUpdateClientWithRetry(endpoint);
        Model.CIInfo cIInfo = _ciProvider.GetCIInfo();
        Model.RunConfig runConfig = _clientUtility.GetTestRunConfig();
        var patchBody = new
        {
            displayName = _options.RunName,
            ciConfig = cIInfo,
            config = runConfig
        };
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };
        var json = JsonSerializer.Serialize(patchBody, options);
        var content = RequestContent.Create(BinaryData.FromString(json));
        try
        {
            var workspaceId = _clientUtility.ExtractWorkspaceIdFromEndpoint(_options.ServiceEndpoint!);
            var testRunId = _options.RunId;
            Response response = _testRunUpdateClient.TestRuns(
                workspaceId: workspaceId,
                testRunId: testRunId,
                content: content,
                authorization: $"Bearer {authToken}",
                xCorrelationId: Guid.NewGuid().ToString()
            );
            _logger?.LogInformation("Test run created successfully.");
        }
        catch (RequestFailedException ex)
        {
            _logger?.LogError($"Failed to create the test run in the Playwright Workspaces: {ex.Message}");
            throw new Exception(Constants.s_playwright_service_create_test_run_error, ex);
        }
    }
}
