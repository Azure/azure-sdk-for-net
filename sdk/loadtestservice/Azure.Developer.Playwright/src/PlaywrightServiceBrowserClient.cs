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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Developer.Playwright;

/// <summary>
/// Sets up and manages the Playwright service browser client.
/// </summary>
public class PlaywrightServiceBrowserClient : IDisposable
{
    internal readonly IEntraLifecycle _entraLifecycle;
    internal readonly IEnvironment _environment;
    internal readonly JsonWebTokenHandler _jsonWebTokenHandler;
    internal readonly PlaywrightServiceBrowserClientOptions _options;
    internal readonly ClientUtilities _clientUtility;
    internal readonly ILogger? _logger;
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
        options: options,
        tokenCredential: credential
    )
    {
        // No-op
    }

    internal PlaywrightServiceBrowserClient(IEnvironment? environment = null, IEntraLifecycle? entraLifecycle = null, JsonWebTokenHandler? jsonWebTokenHandler = null, ILogger? logger = null, ClientUtilities? clientUtility = null, PlaywrightServiceBrowserClientOptions? options = null, TokenCredential? tokenCredential = null)
    {
        _environment = environment ?? new EnvironmentHandler();
        _clientUtility = clientUtility ?? new ClientUtilities(_environment);
        _options = options ?? new PlaywrightServiceBrowserClientOptions(PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_07_01_Preview, environment: _environment, clientUtility: _clientUtility);
        _logger = logger ?? _options.Logger;
        _jsonWebTokenHandler = jsonWebTokenHandler ?? new JsonWebTokenHandler();
        _entraLifecycle = entraLifecycle ?? new EntraLifecycle(jsonWebTokenHandler: _jsonWebTokenHandler, logger: _logger, environment: _environment, tokenCredential: tokenCredential);

        // Call getters to set default environment variables if not already set before
        _ = _options.OS;
        _ = _options.RunId;
        _ = _options.ExposeNetwork;
        _ = _options.ServiceAuth;
        _ = _options.UseCloudHostedBrowsers;
    }

    /// <summary>
    /// Gets the connect options for connecting to Playwright Service's cloud hosted browsers.
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
        var environmentValueForUseCloudHostedBrowsers = _environment.GetEnvironmentVariable(Constants.s_playwright_service_use_cloud_hosted_browsers_environment_variable);
        if (bool.TryParse(environmentValueForUseCloudHostedBrowsers, out var useCloudHostedBrowsers) && !useCloudHostedBrowsers)
        {
            if (!useCloudHostedBrowsers)
            {
                throw new Exception(Constants.s_service_endpoint_removed_since_scalable_execution_disabled_error_message);
            }
        }
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
    /// Gets the connect options for connecting to Playwright Service's cloud hosted browsers.
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
        var environmentValueForUseCloudHostedBrowsers = _environment.GetEnvironmentVariable(Constants.s_playwright_service_use_cloud_hosted_browsers_environment_variable);
        if (bool.TryParse(environmentValueForUseCloudHostedBrowsers, out var useCloudHostedBrowsers) && !useCloudHostedBrowsers)
        {
            if (!useCloudHostedBrowsers)
            {
                throw new Exception(Constants.s_service_endpoint_removed_since_scalable_execution_disabled_error_message);
            }
        }
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
        if (!_options.UseCloudHostedBrowsers)
        {
            // Since playwright-dotnet checks PLAYWRIGHT_SERVICE_ACCESS_TOKEN and PLAYWRIGHT_SERVICE_URL to be set, remove PLAYWRIGHT_SERVICE_URL so that tests are run locally.
            // If customers use GetConnectOptionsAsync, after setting disableScalableExecution, an error will be thrown.
            _logger?.LogInformation("Disabling scalable execution since UseCloudHostedBrowsers is set to false.");
            _environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), null);
            return;
        }
        // If default auth mechanism is Access token and token is available in the environment variable, no need to setup rotation handler
        if (_options.ServiceAuth == ServiceAuthType.AccessToken)
        {
            _logger?.LogInformation("Auth mechanism is Access Token.");
            _clientUtility.ValidateMptPAT(_options.AuthToken, _options.ServiceEndpoint!);
            return;
        }
        _logger?.LogInformation("Auth mechanism is Entra Id.");
        await _entraLifecycle!.FetchEntraIdAccessTokenAsync(cancellationToken).ConfigureAwait(false);
        RotationTimer = new Timer(RotationHandlerAsync, null, TimeSpan.FromMinutes(Constants.s_entra_access_token_rotation_interval_period_in_minutes), TimeSpan.FromMinutes(Constants.s_entra_access_token_rotation_interval_period_in_minutes));
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
        if (!_options.UseCloudHostedBrowsers)
        {
            // Since playwright-dotnet checks PLAYWRIGHT_SERVICE_ACCESS_TOKEN and PLAYWRIGHT_SERVICE_URL to be set, remove PLAYWRIGHT_SERVICE_URL so that tests are run locally.
            // If customers use GetConnectOptionsAsync, after setting disableScalableExecution, an error will be thrown.
            _logger?.LogInformation("Disabling scalable execution since UseCloudHostedBrowsers is set to false.");
            _environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), null);
            return;
        }
        // If default auth mechanism is Access token and token is available in the environment variable, no need to setup rotation handler
        if (_options.ServiceAuth == ServiceAuthType.AccessToken)
        {
            _logger?.LogInformation("Auth mechanism is Access Token.");
            _clientUtility.ValidateMptPAT(_options.AuthToken, _options.ServiceEndpoint!);
            return;
        }
        _logger?.LogInformation("Auth mechanism is Entra Id.");
        _entraLifecycle!.FetchEntraIdAccessToken(cancellationToken);
        RotationTimer = new Timer(RotationHandlerAsync, null, TimeSpan.FromMinutes(Constants.s_entra_access_token_rotation_interval_period_in_minutes), TimeSpan.FromMinutes(Constants.s_entra_access_token_rotation_interval_period_in_minutes));
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
        _logger?.LogInformation("Cleaning up Playwright service resources.");
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
}
