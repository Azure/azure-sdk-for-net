// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
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
    private string? _serviceAuth;
    /// <summary>
    /// Gets or sets the default authentication mechanism.
    /// </summary>
    public string ServiceAuth
    {
        // fetch class level variable if set -> fetch environment variable -> default to EntraId
        get
        {
            if (!string.IsNullOrEmpty(_serviceAuth))
                return _serviceAuth!;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable)))
                return Environment.GetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable)!;
            return ServiceAuthType.EntraId;
        }
        set
        {
            _serviceAuth = value;
        }
    }

    /// <summary>
    /// Gets or sets the rotation timer for Playwright service.
    /// </summary>
    public Timer? RotationTimer { get; set; }
    /// <summary>
    /// Gets the service endpoint for Playwright service.
    /// </summary>
    public static string? ServiceEndpoint => Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri);

    private bool? _useCloudHostedBrowsers;
    /// <summary>
    /// Gets or sets a flag indicating whether to use cloud-hosted browsers.
    /// </summary>
    public bool UseCloudHostedBrowsers
    {
        // fetch class level variable if set -> fetch environment variable -> default to true
        get
        {
            if (_useCloudHostedBrowsers != null)
                return (bool)_useCloudHostedBrowsers;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(Constants.s_playwright_service_disable_scalable_execution_environment_variable)))
                return !bool.Parse(Environment.GetEnvironmentVariable(Constants.s_playwright_service_disable_scalable_execution_environment_variable)!); // this is checked in the line above
            return true;
        }
        set
        {
            _useCloudHostedBrowsers = value;
        }
    }

    private OSPlatform? _os;
    /// <summary>
    /// Gets or sets the operating system for Playwright service.
    /// </summary>
    public OSPlatform? Os
    {
        // fetch class level variable if set -> fetch environment variable -> default to null
        get
        {
            if (_os != null)
                return _os;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs)))
                return GetOSPlatform(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs));
            return null;
        }
        set
        {
            _os = value;
        }
    }

    private string? _runId;
    /// <summary>
    /// Gets or sets the run ID.
    /// </summary>
    public string? RunId
    {
        // fetch class level variable if set -> fetch environment variable -> default to null
        get
        {
            if (!string.IsNullOrEmpty(_runId))
                return _runId;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId)))
                return Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId);
            return null;
        }
        set
        {
            _runId = value;
        }
    }

    private string? _exposeNetwork;
    /// <summary>
    /// Gets or sets the expose network field for remote browsers.
    /// </summary>
    public string? ExposeNetwork
    {
        // fetch class level variable if set -> fetch environment variable -> default to null
        get
        {
            if (!string.IsNullOrEmpty(_exposeNetwork))
                return _exposeNetwork;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork)))
                return Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork);
            return null;
        }
        set
        {
            _exposeNetwork = value;
        }
    }

    private readonly EntraLifecycle? _entraLifecycle;
    private readonly JsonWebTokenHandler? _jsonWebTokenHandler;
    private IFrameworkLogger? _frameworkLogger;
    private IConsoleWriter? _consoleWriter;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightService"/> class.
    /// </summary>
    /// <param name="playwrightServiceOptions"></param>
    /// <param name="credential"></param>
    /// <param name="frameworkLogger"></param>
    public PlaywrightService(PlaywrightServiceOptions playwrightServiceOptions, TokenCredential? credential = null, IFrameworkLogger? frameworkLogger = null) : this(
        os: playwrightServiceOptions.Os,
        runId: playwrightServiceOptions.RunId,
        exposeNetwork: playwrightServiceOptions.ExposeNetwork,
        serviceAuth: playwrightServiceOptions.ServiceAuth,
        useCloudHostedBrowsers: playwrightServiceOptions.UseCloudHostedBrowsers,
        credential: credential ?? playwrightServiceOptions.AzureTokenCredential,
        frameworkLogger: frameworkLogger
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
    /// <param name="frameworkLogger">Logger</param>
    public PlaywrightService(OSPlatform? os = null, string? runId = null, string? exposeNetwork = null, string? serviceAuth = null, bool? useCloudHostedBrowsers = null, TokenCredential? credential = null, IFrameworkLogger? frameworkLogger = null)
    {
        if (string.IsNullOrEmpty(ServiceEndpoint))
            return;
        _frameworkLogger = frameworkLogger;
        _entraLifecycle = new EntraLifecycle(tokenCredential: credential, frameworkLogger: _frameworkLogger);
        _jsonWebTokenHandler = new JsonWebTokenHandler();
        _consoleWriter = new ConsoleWriter();
        InitializePlaywrightServiceEnvironmentVariables(GetServiceCompatibleOs(os), runId, exposeNetwork, serviceAuth, useCloudHostedBrowsers);
    }

    internal PlaywrightService(OSPlatform? os = null, string? runId = null, string? exposeNetwork = null, string? serviceAuth = null, bool? useCloudHostedBrowsers = null, EntraLifecycle? entraLifecycle = null, JsonWebTokenHandler? jsonWebTokenHandler = null, TokenCredential? credential = null, IFrameworkLogger? frameworkLogger = null, IConsoleWriter? consoleWriter = null)
    {
        if (string.IsNullOrEmpty(ServiceEndpoint))
            return;
        _frameworkLogger = frameworkLogger;
        _jsonWebTokenHandler = jsonWebTokenHandler ?? new JsonWebTokenHandler();
        _entraLifecycle = entraLifecycle ?? new EntraLifecycle(credential, _jsonWebTokenHandler, _frameworkLogger);
        _frameworkLogger = frameworkLogger;
        _consoleWriter = consoleWriter ?? new ConsoleWriter();
        InitializePlaywrightServiceEnvironmentVariables(GetServiceCompatibleOs(os), runId, exposeNetwork, serviceAuth, useCloudHostedBrowsers);
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
        string _serviceOs = Uri.EscapeDataString(GetServiceCompatibleOs(os) ?? GetServiceCompatibleOs(Os)!);
        string _runId = Uri.EscapeDataString(runId ?? RunId!);
        string _exposeNetwork = exposeNetwork ?? ExposeNetwork!;

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
            _frameworkLogger?.Error("Access token not found when trying to call GetConnectOptionsAsync.");
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
        {
            _frameworkLogger?.Info("Exiting initialization as service endpoint is not set.");
            return;
        }
        if (!UseCloudHostedBrowsers)
        {
            // Since playwright-dotnet checks PLAYWRIGHT_SERVICE_ACCESS_TOKEN and PLAYWRIGHT_SERVICE_URL to be set, remove PLAYWRIGHT_SERVICE_URL so that tests are run locally.
            // If customers use GetConnectOptionsAsync, after setting disableScalableExecution, an error will be thrown.
            _frameworkLogger?.Info("Disabling scalable execution since UseCloudHostedBrowsers is set to false.");
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri, null);
            return;
        }
        PerformOneTimeOperation();
        // If default auth mechanism is Access token and token is available in the environment variable, no need to setup rotation handler
        if (ServiceAuth == ServiceAuthType.AccessToken)
        {
            _frameworkLogger?.Info("Auth mechanism is Access Token.");
            ValidateMptPAT();
            return;
        }
        _frameworkLogger?.Info("Auth mechanism is Entra Id.");
        await _entraLifecycle!.FetchEntraIdAccessTokenAsync(cancellationToken).ConfigureAwait(false);
        RotationTimer = new Timer(RotationHandlerAsync, null, TimeSpan.FromMinutes(Constants.s_entra_access_token_rotation_interval_period_in_minutes), TimeSpan.FromMinutes(Constants.s_entra_access_token_rotation_interval_period_in_minutes));
    }

    /// <summary>
    /// Cleans up the resources used to setup entra id authentication.
    /// </summary>
    public void Cleanup()
    {
        _frameworkLogger?.Info("Cleaning up Playwright service resources.");
        RotationTimer?.Dispose();
    }
    internal void PerformOneTimeOperation()
    {
        var oneTimeOperationFlag = Environment.GetEnvironmentVariable(Constants.s_playwright_service_one_time_operation_flag_environment_variable) == "true";

        if (oneTimeOperationFlag)
            return;

        Environment.SetEnvironmentVariable(Constants.s_playwright_service_one_time_operation_flag_environment_variable, "true");

        if (ServiceAuth == ServiceAuthType.AccessToken)
        {
            WarnIfAccessTokenCloseToExpiry();
        }
    }

    internal async void RotationHandlerAsync(object? _)
    {
        if (_entraLifecycle!.DoesEntraIdAccessTokenRequireRotation())
        {
            _frameworkLogger?.Info("Rotating Entra Id access token.");
            await _entraLifecycle.FetchEntraIdAccessTokenAsync().ConfigureAwait(false);
        }
    }

    private void InitializePlaywrightServiceEnvironmentVariables(string? os = null, string? runId = null, string? exposeNetwork = null, string? serviceAuth = null, bool? useCloudHostedBrowsers = null)
    {
        // environment variables are set only if they are not already set
        // If method parameters are set, environment variables are set to those values only if they are not already set
        if (!string.IsNullOrEmpty(serviceAuth))
        {
            ServiceAuth = serviceAuth!;
        }
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable)))
        {
            Environment.SetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable, ServiceAuth);
        }
        if (useCloudHostedBrowsers != null)
        {
            UseCloudHostedBrowsers = (bool)useCloudHostedBrowsers;
            if (!UseCloudHostedBrowsers)
                Environment.SetEnvironmentVariable(Constants.s_playwright_service_disable_scalable_execution_environment_variable, "true");
        }
        if (!string.IsNullOrEmpty(os))
        {
            Os = GetOSPlatform(os);
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs)))
            {
                Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs, os);
            }
        }
        // If OS is not provided, set it to default
        else if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs)))
        {
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceOs, Constants.s_default_os);
        }
        if (!string.IsNullOrEmpty(runId))
        {
            RunId = runId;
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId)))
            {
                Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceRunId, runId);
            }
        }
        else
        {
            GetDefaultRunId();
        }
        if (!string.IsNullOrEmpty(exposeNetwork))
        {
            ExposeNetwork = exposeNetwork;
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork)))
            {
                Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork, exposeNetwork);
            }
        }
        else if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork)))
        {
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceExposeNetwork, Constants.s_default_expose_network);
        }
        SetReportingUrlAndWorkspaceId();
    }
    internal virtual void WarnIfAccessTokenCloseToExpiry()
    {
        string accessToken =  GetAuthToken()!;
        JsonWebToken jsonWebToken = _jsonWebTokenHandler!.ReadJsonWebToken(accessToken) ?? throw new Exception(Constants.s_invalid_mpt_pat_error);
        long currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long exp = new DateTimeOffset(jsonWebToken.ValidTo).ToUnixTimeMilliseconds();
        if (PlaywrightService.IsTokenExpiringSoon(exp, currentTime))
        {
            WarnAboutTokenExpiry(exp, currentTime);
        }
    }
    internal static bool IsTokenExpiringSoon(long expirationTime, long currentTime)
    {
        return expirationTime - currentTime <= Constants.s_sevenDaysInMs;
    }

    internal virtual void WarnAboutTokenExpiry(long expirationTime, long currentTime)
    {
        int daysToExpiration = (int)Math.Ceiling((expirationTime - currentTime) / (double)Constants.s_oneDayInMs);
        string expirationDate = DateTimeOffset.FromUnixTimeMilliseconds(expirationTime).UtcDateTime.ToString("d");
        string expirationWarning = string.Format(Constants.s_token_expiry_warning_template, daysToExpiration, expirationDate);
        _consoleWriter?.WriteLine(expirationWarning);
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
        if (ServiceEndpoint == null)
        {
            throw new ArgumentNullException(nameof(ServiceEndpoint));
        }
        Match match = Regex.Match(ServiceEndpoint, @"wss://(?<region>[\w-]+)\.api\.(?<domain>playwright(?:-test|-int)?\.io|playwright\.microsoft\.com)/accounts/(?<workspaceId>[\w-]+)/");
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
        if (ServiceEndpoint == null)
        {
            throw new ArgumentNullException(nameof(ServiceEndpoint));
        }
        try
        {
            string authToken = GetAuthToken()!;
            if (string.IsNullOrEmpty(authToken))
                throw new Exception(Constants.s_no_auth_error);
            JsonWebToken jsonWebToken = _jsonWebTokenHandler!.ReadJsonWebToken(authToken) ?? throw new Exception(Constants.s_invalid_mpt_pat_error);
            var tokenWorkspaceId = jsonWebToken.Claims.FirstOrDefault(c => c.Type == "aid")?.Value;
            Match match = Regex.Match(ServiceEndpoint, @"wss://(?<region>[\w-]+)\.api\.(?<domain>playwright(?:-test|-int)?\.io|playwright\.microsoft\.com)/accounts/(?<workspaceId>[\w-]+)/");
            if (!match.Success)
                throw new Exception(Constants.s_invalid_service_endpoint_error_message);
            var serviceEndpointWorkspaceId = match.Groups["workspaceId"].Value;
            if (tokenWorkspaceId != serviceEndpointWorkspaceId)
                throw new Exception(Constants.s_workspace_mismatch_error);
            var expiry = (long)(jsonWebToken.ValidTo - new DateTime(1970, 1, 1)).TotalSeconds;
            if (expiry <= DateTimeOffset.UtcNow.ToUnixTimeSeconds())
                throw new Exception(Constants.s_expired_mpt_pat_error);
        }
        catch (Exception ex)
        {
            _frameworkLogger?.Error(ex.ToString());
            throw;
        }
    }

    internal static string? GetServiceCompatibleOs(OSPlatform? oSPlatform)
    {
        if (oSPlatform == null)
            return null;
        if (oSPlatform.Equals(OSPlatform.Linux))
            return ServiceOs.Linux;
        if (oSPlatform.Equals(OSPlatform.Windows))
            return ServiceOs.Windows;
        throw new ArgumentException(Constants.s_invalid_os_error);
    }

    internal static OSPlatform? GetOSPlatform(string? os)
    {
        if (string.IsNullOrEmpty(os))
            return null;
        if (os == ServiceOs.Linux)
            return OSPlatform.Linux;
        if (os == ServiceOs.Windows)
            return OSPlatform.Windows;
        throw new ArgumentException(Constants.s_invalid_os_error);
    }
}
