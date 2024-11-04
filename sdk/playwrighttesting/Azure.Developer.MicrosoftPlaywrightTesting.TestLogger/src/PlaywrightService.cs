// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger;

/// <summary>
/// Sets up and manages the Playwright service.
/// </summary>
public class PlaywrightService
{
    /// <summary>
    /// Gets or sets the default authentication mechanism.
    /// </summary>
    public string ServiceAuth { get; set; } = ServiceAuthType.EntraId;
    /// <summary>
    /// Gets or sets a flag indicating whether to use cloud-hosted browsers.
    /// </summary>
    public bool UseCloudHostedBrowsers { get; set; } = true;
    /// <summary>
    /// Gets or sets the rotation timer for the Playwright service.
    /// </summary>
    public Timer? RotationTimer { get; set; }
    /// <summary>
    /// Gets the service endpoint for the Playwright service.
    /// </summary>
    public static string? ServiceEndpoint => Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri);

    private readonly EntraLifecycle? _entraLifecycle;
    private readonly JsonWebTokenHandler? _jsonWebTokenHandler;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightService"/> class.
    /// </summary>
    /// <param name="playwrightServiceOptions"></param>
    /// <param name="credential"></param>
    public PlaywrightService(PlaywrightServiceOptions playwrightServiceOptions, TokenCredential? credential = null) : this(
        os: playwrightServiceOptions.Os,
        runId: playwrightServiceOptions.RunId,
        exposeNetwork: playwrightServiceOptions.ExposeNetwork,
        serviceAuth: playwrightServiceOptions.ServiceAuth,
        useCloudHostedBrowsers: playwrightServiceOptions.UseCloudHostedBrowsers,
        credential: credential ?? playwrightServiceOptions.AzureTokenCredential
    )
    {
        // No-op
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightService"/> class.
    /// </summary>
    /// <param name="os">The operating system.</param>
    /// <param name="runId">The run ID.</param>
    /// <param name="exposeNetwork">The network exposure.</param>
    /// <param name="serviceAuth">The service authentication mechanism.</param>
    /// <param name="useCloudHostedBrowsers">Whether to use cloud-hosted browsers.</param>
    /// <param name="credential">The token credential.</param>
    public PlaywrightService(OSPlatform? os = null, string? runId = null, string? exposeNetwork = null, string? serviceAuth = null, bool? useCloudHostedBrowsers = null, TokenCredential? credential = null)
    {
        if (string.IsNullOrEmpty(ServiceEndpoint))
            return;
        _entraLifecycle = new EntraLifecycle(tokenCredential: credential);
        _jsonWebTokenHandler = new JsonWebTokenHandler();
        InitializePlaywrightServiceEnvironmentVariables(getServiceCompatibleOs(os), runId, exposeNetwork, serviceAuth, useCloudHostedBrowsers);
    }

    internal PlaywrightService(OSPlatform? os = null, string? runId = null, string? exposeNetwork = null, string? serviceAuth = null, bool? useCloudHostedBrowsers = null, EntraLifecycle? entraLifecycle = null, JsonWebTokenHandler? jsonWebTokenHandler = null, TokenCredential? credential = null)
    {
        if (string.IsNullOrEmpty(ServiceEndpoint))
            return;
        _entraLifecycle = entraLifecycle ?? new EntraLifecycle(credential);
        _jsonWebTokenHandler = jsonWebTokenHandler ?? new JsonWebTokenHandler();
        InitializePlaywrightServiceEnvironmentVariables(getServiceCompatibleOs(os), runId, exposeNetwork, serviceAuth, useCloudHostedBrowsers);
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
    public async Task<ConnectOptions<T>> GetConnectOptionsAsync<T>(OSPlatform? os = null, string? runId = null, string? exposeNetwork = null, CancellationToken cancellationToken = default) where T : class, new()
    {
        if (Environment.GetEnvironmentVariable(Constants.s_playwright_service_disable_scalable_execution_environment_variable) == "true")
            throw new Exception(Constants.s_service_endpoint_removed_since_scalable_execution_disabled_error_message);
        if (string.IsNullOrEmpty(ServiceEndpoint))
            throw new Exception(Constants.s_no_service_endpoint_error_message);
        string _serviceOs = Uri.EscapeDataString(getServiceCompatibleOs(os) ?? Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs) ?? Constants.s_default_os);
        string _runId = Uri.EscapeDataString(runId ?? Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId) ?? GetDefaultRunId());
        string _exposeNetwork = exposeNetwork ?? Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork) ?? Constants.s_default_expose_network;

        string wsEndpoint = $"{ServiceEndpoint}?os={_serviceOs}&runId={_runId}&api-version={Constants.s_api_version}";

        // fetch Entra id access token if required
        // 1. Entra id access token has been fetched once via global functions
        // 2. Not close to expiry
        if (!string.IsNullOrEmpty(_entraLifecycle!._entraIdAccessToken) && _entraLifecycle!.DoesEntraIdAccessTokenRequireRotation())
        {
            await _entraLifecycle.FetchEntraIdAccessTokenAsync(cancellationToken).ConfigureAwait(false);
        }
        if (string.IsNullOrEmpty(GetAuthToken()))
        {
            throw new Exception(Constants.s_no_auth_error);
        }

        var browserConnectOptions = new BrowserConnectOptions
        {
            Timeout = 3 * 60 * 1000,
            ExposeNetwork = _exposeNetwork,
            Headers = new Dictionary<string, string>
            {
                ["Authorization"] = $"Bearer {GetAuthToken()}"
            }
        };
        return new ConnectOptions<T>
        {
            WsEndpoint = wsEndpoint,
            Options = BrowserConnectOptionsConverter.Convert<T>(browserConnectOptions)
        };
    }

    /// <summary>
    /// Initialises the resources used to setup entra id authentication.
    /// </summary>
    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(ServiceEndpoint))
            return;
        if (!UseCloudHostedBrowsers)
        {
            // Since playwright-dotnet checks PLAYWRIGHT_SERVICE_ACCESS_TOKEN and PLAYWRIGHT_SERVICE_URL to be set, remove PLAYWRIGHT_SERVICE_URL so that tests are run locally.
            // If customers use GetConnectOptionsAsync, after setting disableScalableExecution, an error will be thrown.
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, null);
        }
        // If default auth mechanism is Access token and token is available in the environment variable, no need to setup rotation handler
        if (ServiceAuth == ServiceAuthType.AccessToken)
        {
            ValidateMptPAT();
            return;
        }
            await _entraLifecycle!.FetchEntraIdAccessTokenAsync(cancellationToken).ConfigureAwait(false);
            RotationTimer = new Timer(RotationHandlerAsync, null, TimeSpan.FromMinutes(Constants.s_entra_access_token_rotation_interval_period_in_minutes), TimeSpan.FromMinutes(Constants.s_entra_access_token_rotation_interval_period_in_minutes));
        }

    /// <summary>
    /// Cleans up the resources used to setup entra id authentication.
    /// </summary>
    public void Cleanup()
    {
        RotationTimer?.Dispose();
    }

    internal async void RotationHandlerAsync(object? _)
    {
        if (_entraLifecycle!.DoesEntraIdAccessTokenRequireRotation())
        {
            await _entraLifecycle.FetchEntraIdAccessTokenAsync().ConfigureAwait(false);
        }
    }

    private void InitializePlaywrightServiceEnvironmentVariables(string? os = null, string? runId = null, string? exposeNetwork = null, string? serviceAuth = null, bool? useCloudHostedBrowsers = null)
    {
        if (!string.IsNullOrEmpty(serviceAuth))
        {
            ServiceAuth = serviceAuth!;
        }
        if (useCloudHostedBrowsers != null)
        {
            UseCloudHostedBrowsers = (bool)useCloudHostedBrowsers;
            if (!UseCloudHostedBrowsers)
                Environment.SetEnvironmentVariable(Constants.s_playwright_service_disable_scalable_execution_environment_variable, "true");
        }
        if (!string.IsNullOrEmpty(os))
        {
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs, os);
        }
        else
        {
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs, Constants.s_default_os);
        }
        if (!string.IsNullOrEmpty(runId))
        {
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, runId);
        }
        else
        {
            GetDefaultRunId();
        }
        if (!string.IsNullOrEmpty(exposeNetwork))
        {
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork, exposeNetwork);
        }
        else
        {
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork, Constants.s_default_expose_network);
        }
        SetReportingUrlAndWorkspaceId();
    }

    internal static string GetDefaultRunId()
    {
        var runIdFromEnvironmentVariable = Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId);
        if (!string.IsNullOrEmpty(runIdFromEnvironmentVariable))
            return runIdFromEnvironmentVariable!;
        CIInfo ciInfo = CiInfoProvider.GetCIInfo();
        var runId = ReporterUtils.GetRunId(ciInfo);
        Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, runId);
        return runId;
    }

    internal static void SetReportingUrlAndWorkspaceId()
    {
        // Service Endpoint null check happens prior to this method being called
        Match match = Regex.Match(ServiceEndpoint!, @"wss://(?<region>[\w-]+)\.api\.(?<domain>playwright(?:-test|-int)?\.io|playwright\.microsoft\.com)/accounts/(?<workspaceId>[\w-]+)/");
        if (!match.Success)
            return;
        var region = match.Groups["region"].Value;
        var domain = match.Groups["domain"].Value;
        var workspaceId = match.Groups["workspaceId"].Value;
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable)))
            Environment.SetEnvironmentVariable(Constants.s_playwright_service_reporting_url_environment_variable, $"https://{region}.reporting.api.{domain}");
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(Constants.s_playwright_service_workspace_id_environment_variable)))
            Environment.SetEnvironmentVariable(Constants.s_playwright_service_workspace_id_environment_variable, $"{workspaceId}");
    }

    private static string? GetAuthToken()
    {
        return Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken);
    }

    private void ValidateMptPAT()
    {
        string authToken = GetAuthToken()!;
        if (string.IsNullOrEmpty(authToken))
            throw new Exception(Constants.s_no_auth_error);
        JsonWebToken jsonWebToken = _jsonWebTokenHandler!.ReadJsonWebToken(authToken) ?? throw new Exception(Constants.s_invalid_mpt_pat_error);
        var tokenaWorkspaceId = jsonWebToken.Claims.FirstOrDefault(c => c.Type == "aid")?.Value;
        // Service Endpoint null check happens prior to this method being called
        Match match = Regex.Match(ServiceEndpoint!, @"wss://(?<region>[\w-]+)\.api\.(?<domain>playwright(?:-test|-int)?\.io|playwright\.microsoft\.com)/accounts/(?<workspaceId>[\w-]+)/");
        if (!match.Success)
            throw new Exception(Constants.s_invalid_service_endpoint_error_message);
        var serviceEndpointWorkspaceId = match.Groups["workspaceId"].Value;
        if (tokenaWorkspaceId != serviceEndpointWorkspaceId)
            throw new Exception(Constants.s_workspace_mismatch_error);
        var expiry = (long)(jsonWebToken.ValidTo - new DateTime(1970, 1, 1)).TotalSeconds;
        if (expiry <= DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            throw new Exception(Constants.s_expired_mpt_pat_error);
    }

    private string? getServiceCompatibleOs(OSPlatform? oSPlatform)
    {
        if (oSPlatform == null)
            return null;
        if (oSPlatform.Equals(OSPlatform.Linux))
            return ServiceOs.Linux;
        if (oSPlatform.Equals(OSPlatform.Windows))
            return ServiceOs.Windows;
        throw new ArgumentException(Constants.s_invalid_os_error);
    }
}
