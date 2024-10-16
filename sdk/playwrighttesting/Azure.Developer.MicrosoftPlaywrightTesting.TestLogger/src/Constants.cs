// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger;

/// <summary>
/// Contains environment variable names used by the Playwright service.
/// </summary>
public class ServiceEnvironmentVariable
{
    /// <summary>
    /// The environment variable for the Playwright service access token.
    /// </summary>
    public static readonly string PlaywrightServiceAccessToken = "PLAYWRIGHT_SERVICE_ACCESS_TOKEN";

    /// <summary>
    /// The environment variable for the Playwright service URL.
    /// </summary>
    public static readonly string PlaywrightServiceUri = "PLAYWRIGHT_SERVICE_URL";

    /// <summary>
    /// The environment variable for exposing the Playwright service network.
    /// </summary>
    public static readonly string PlaywrightServiceExposeNetwork = "PLAYWRIGHT_SERVICE_EXPOSE_NETWORK";

    /// <summary>
    /// The environment variable for the Playwright service operating system.
    /// </summary>
    public static readonly string PlaywrightServiceOs = "PLAYWRIGHT_SERVICE_OS";

    /// <summary>
    /// The environment variable for the Playwright service run ID.
    /// </summary>
    public static readonly string PlaywrightServiceRunId = "PLAYWRIGHT_SERVICE_RUN_ID";
};

/// <summary>
/// Contains constants for supported operating systems on Microsoft Playwright Testing.
/// </summary>
internal class ServiceOs
{
    /// <summary>
    /// Linux operating system.
    /// </summary>
    public static readonly string Linux = "linux";

    /// <summary>
    /// Windows operating system.
    /// </summary>
    public static readonly string Windows = "windows";
};

/// <summary>
/// Contains constants for authentication methods.
/// </summary>
public class ServiceAuthType
{
    /// <summary>
    /// Entra ID authentication method.
    /// </summary>
    public static readonly string EntraId = "EntraId";

    /// <summary>
    /// Access token authentication method.
    /// </summary>
    public static readonly string AccessToken = "AccessToken";
};

/// <summary>
/// Contains constants for Azure token credential types.
/// </summary>
internal class AzureTokenCredentialType
{
    /// <summary>
    /// Environment Credential.
    /// </summary>
    public static readonly string EnvironmentCredential = "EnvironmentCredential";

    /// <summary>
    /// Workload Identity Credential.
    /// </summary>
    public static readonly string WorkloadIdentityCredential = "WorkloadIdentityCredential";

    /// <summary>
    /// Managed Identity Credential.
    /// </summary>
    public static readonly string ManagedIdentityCredential = "ManagedIdentityCredential";

    /// <summary>
    /// Shared Token Cache Credential.
    /// </summary>
    public static readonly string SharedTokenCacheCredential = "SharedTokenCacheCredential";

    /// <summary>
    /// Visual Studio Credential.
    /// </summary>
    public static readonly string VisualStudioCredential = "VisualStudioCredential";

    /// <summary>
    /// Visual Studio Code Credential.
    /// </summary>
    public static readonly string VisualStudioCodeCredential = "VisualStudioCodeCredential";

    /// <summary>
    /// Azure CLI Credential.
    /// </summary>
    public static readonly string AzureCliCredential = "AzureCliCredential";

    /// <summary>
    /// Azure PowerShell Credential.
    /// </summary>
    public static readonly string AzurePowerShellCredential = "AzurePowerShellCredential";

    /// <summary>
    /// Azure Developer CLI Credential.
    /// </summary>
    public static readonly string AzureDeveloperCliCredential = "AzureDeveloperCliCredential";

    /// <summary>
    /// Interactive Browser Credential.
    /// </summary>
    public static readonly string InteractiveBrowserCredential = "InteractiveBrowserCredential";

    /// <summary>
    /// Default Azure Credential.
    /// </summary>
    public static readonly string DefaultAzureCredential = "DefaultAzureCredential";
}

/// <summary>
/// Contains constants for run setting keys.
/// </summary>
public class RunSettingKey
{
    /// <summary>
    /// The operating system setting key.
    /// </summary>
    public static readonly string Os = "Os";

    /// <summary>
    /// The run ID setting key.
    /// </summary>
    public static readonly string RunId = "RunId";

    /// <summary>
    /// The expose network setting key.
    /// </summary>
    public static readonly string ExposeNetwork = "ExposeNetwork";

    /// <summary>
    /// The default authentication setting key.
    /// </summary>
    public static readonly string ServiceAuthType = "ServiceAuthType";

    /// <summary>
    /// The use cloud-hosted browsers setting key.
    /// </summary>
    public static readonly string UseCloudHostedBrowsers = "UseCloudHostedBrowsers";

    /// <summary>
    /// The Azure token credential type setting key.
    /// </summary>
    public static readonly string AzureTokenCredentialType = "AzureTokenCredentialType";

    /// <summary>
    /// The managed identity client ID setting key.
    /// </summary>
    public static readonly string ManagedIdentityClientId = "ManagedIdentityClientId";

    /// <summary>
    /// Enable GitHub summary setting key.
    /// </summary>
    public static readonly string EnableGitHubSummary = "EnableGitHubSummary";

    /// <summary>
    /// Enable Result publish.
    /// </summary>
    public static readonly string EnableResultPublish = "EnableResultPublish";
}

internal class Constants
{
    // Default constants
    internal static readonly string s_default_os = ServiceOs.Linux;
    internal static readonly string s_default_expose_network = "<loopback>";
    internal static readonly string s_pLAYWRIGHT_SERVICE_DEBUG = "PLAYWRIGHT_SERVICE_DEBUG";

    // Entra id access token constants
    internal static readonly int s_entra_access_token_lifetime_left_threshold_in_minutes_for_rotation = 15;
    internal static readonly string[] s_entra_access_token_scopes = new string[] { "https://management.core.windows.net/.default" };
    internal static readonly int s_entra_access_token_rotation_interval_period_in_minutes = 4;

    // Service constants
    internal static readonly string s_api_version = "2023-10-01-preview";

    // Error messages
    internal static readonly string s_no_service_endpoint_error_message = "Please set PLAYWRIGHT_SERVICE_URL in your environment variables.";
    internal static readonly string s_service_endpoint_removed_since_scalable_execution_disabled_error_message = "GetConnectOptionsAsync() method cannot be used when disableScalableExecution is set to true in the setup file.";
    internal static readonly string s_no_auth_error = "Could not authenticate with the service. Please refer to https://aka.ms/mpt/authentication for more information.";
    internal static readonly string s_invalid_mpt_pat_error = "The Access Token provided in the environment variable is invalid.";
    internal static readonly string s_expired_mpt_pat_error = "The Access Token you are using is expired. Create a new token.";
    internal static readonly string s_invalid_os_error = "Invalid operating system, supported values are 'linux' and 'windows'.";

    internal static readonly string s_playwright_service_disable_scalable_execution_environment_variable = "PLAYWRIGHT_SERVICE_DISABLE_SCALABLE_EXECUTION";
    internal static readonly string s_playwright_service_reporting_url_environment_variable = "PLAYWRIGHT_SERVICE_REPORTING_URL";
    internal static readonly string s_playwright_service_workspace_id_environment_variable = "PLAYWRIGHT_SERVICE_WORKSPACE_ID";
}

internal class OSConstants
{
    internal static readonly string s_lINUX = "Linux";
    internal static readonly string s_wINDOWS = "Windows";
    internal static readonly string s_mACOS = "MacOS";
}

internal class ReporterConstants
{
    internal static readonly string s_executionIdPropertyIdentifier = "ExecutionId";
    internal static readonly string s_parentExecutionIdPropertyIdentifier = "ParentExecId";
    internal static readonly string s_testTypePropertyIdentifier = "TestType";
    internal static readonly string s_sASUriSeparator = "?";
    internal static readonly string s_portalBaseUrl = "https://playwright.microsoft.com/workspaces/";
    internal static readonly string s_reportingRoute = "/runs/";
    internal static readonly string s_reportingAPIVersion_2024_04_30_preview = "2024-04-30-preview";
    internal static readonly string s_reportingAPIVersion_2024_05_20_preview = "2024-05-20-preview";
    internal static readonly string s_pLAYWRIGHT_SERVICE_REPORTING_URL = "PLAYWRIGHT_SERVICE_REPORTING_URL";
    internal static readonly string s_pLAYWRIGHT_SERVICE_WORKSPACE_ID = "PLAYWRIGHT_SERVICE_WORKSPACE_ID";
    internal static readonly string s_aPPLICATION_JSON = "application/json";
}

internal class CIConstants
{
    internal static readonly string s_gITHUB_ACTIONS = "GitHub Actions";
    internal static readonly string s_aZURE_DEVOPS = "Azure DevOps";
    internal static readonly string s_dEFAULT = "Default";
}

internal class TestCaseResultStatus
{
    internal static readonly string s_pASSED = "passed";
    internal static readonly string s_fAILED = "failed";
    internal static readonly string s_sKIPPED = "skipped";
    internal static readonly string s_iNCONCLUSIVE = "inconclusive";
}

internal class TestResultError
{
    internal string? Key { get; set; } = string.Empty;
    internal string? Message { get; set; } = string.Empty;
    internal Regex Pattern { get; set; } = new Regex(string.Empty);
    internal TestErrorType Type { get; set; }
}

internal enum TestErrorType
{
    Scalable
}

internal static class TestResultErrorConstants
{
    public static List<TestResultError> ErrorConstants = new()
    {
        new TestResultError
        {
            Key = "401",
            Message = "The authentication token provided is invalid. Please check the token and try again.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*401 Unauthorized)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "NoPermissionOnWorkspace_Scalable",
            Message = @"You do not have the required permissions to run tests. This could be because:

    a. You do not have the required roles on the workspace. Only Owner and Contributor roles can run tests. Contact the service administrator.
    b. The workspace you are trying to run the tests on is in a different Azure tenant than what you are signed into. Check the tenant id from Azure portal and login using the command 'az login --tenant <TENANT_ID>'.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*403 Forbidden)(?=[\s\S]*CheckAccess API call with non successful response)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "InvalidWorkspace_Scalable",
            Message = "The specified workspace does not exist. Please verify your workspace settings.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*403 Forbidden)(?=.*InvalidAccountOrSubscriptionState)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "InvalidAccessToken",
            Message = "The provided access token does not match the specified workspace URL. Please verify that both values are correct.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*403 Forbidden)(?=.*InvalidAccessToken)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "AccessTokenOrUserOrWorkspaceNotFound_Scalable",
            Message = "The data for the user, workspace or access token was not found. Please check the request or create new token and try again.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*404 Not Found)(?=.*NotFound)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "AccessKeyBasedAuthNotSupported_Scalable",
            Message = "Authentication through service access token is disabled for this workspace. Please use Entra ID to authenticate.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*403 Forbidden)(?=.*AccessKeyBasedAuthNotSupported)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "ServiceUnavailable_Scalable",
            Message = "The service is currently unavailable. Please check the service status and try again.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*503 Service Unavailable)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "GatewayTimeout_Scalable",
            Message = "The request to the service timed out. Please try again later.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*504 Gateway Timeout)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "QuotaLimitError_Scalable",
            Message = "It is possible that the maximum number of concurrent sessions allowed for your workspace has been exceeded.",
            Pattern = new Regex(@"(Timeout .* exceeded)(?=[\s\S]*ws connecting)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "BrowserConnectionError_Scalable",
            Message = "The service is currently unavailable. Please try again after some time.",
            Pattern = new Regex(@"Target page, context or browser has been closed", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        }
    };
}
