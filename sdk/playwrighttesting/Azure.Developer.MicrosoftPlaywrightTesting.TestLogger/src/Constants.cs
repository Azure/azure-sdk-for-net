// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger;

/// <summary>
/// Contains environment variable names used by the Playwright service.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ServiceOs"/> structure.
/// </remarks>
/// <param name="value">The string value of the instance.</param>
public readonly struct ServiceEnvironmentVariable(string value) : IEquatable<ServiceEnvironmentVariable>
{
    private const string PlaywrightServiceAccessTokenValue = "PLAYWRIGHT_SERVICE_ACCESS_TOKEN";
    private const string PlaywrightServiceUriValue = "PLAYWRIGHT_SERVICE_URL";
    private const string PlaywrightServiceExposeNetworkValue = "PLAYWRIGHT_SERVICE_EXPOSE_NETWORK";
    private const string PlaywrightServiceOsValue = "PLAYWRIGHT_SERVICE_OS";
    private const string PlaywrightServiceRunIdValue = "PLAYWRIGHT_SERVICE_RUN_ID";

    private readonly string _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary>
    /// The environment variable for the Playwright service access token.
    /// </summary>
    public static ServiceEnvironmentVariable PlaywrightServiceAccessToken { get; } = new ServiceEnvironmentVariable(PlaywrightServiceAccessTokenValue);

    /// <summary>
    /// The environment variable for the Playwright service URL.
    /// </summary>
    public static ServiceEnvironmentVariable PlaywrightServiceUri { get; } = new ServiceEnvironmentVariable(PlaywrightServiceUriValue);

    /// <summary>
    /// The environment variable for exposing the Playwright service network.
    /// </summary>
    public static ServiceEnvironmentVariable PlaywrightServiceExposeNetwork { get; } = new ServiceEnvironmentVariable(PlaywrightServiceExposeNetworkValue);

    /// <summary>
    /// The environment variable for the Playwright service operating system.
    /// </summary>
    public static ServiceEnvironmentVariable PlaywrightServiceOs { get; } = new ServiceEnvironmentVariable(PlaywrightServiceOsValue);

    /// <summary>
    /// The environment variable for the Playwright service run ID.
    /// </summary>
    public static ServiceEnvironmentVariable PlaywrightServiceRunId { get; } = new ServiceEnvironmentVariable(PlaywrightServiceRunIdValue);

    /// <summary>
    /// Determines if two <see cref="ServiceEnvironmentVariable"/> values are the same.
    /// </summary>
    /// <param name="left">The first <see cref="ServiceEnvironmentVariable"/> to compare.</param>
    /// <param name="right">The second <see cref="ServiceEnvironmentVariable"/> to compare.</param>
    /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
    public static bool operator ==(ServiceEnvironmentVariable left, ServiceEnvironmentVariable right) => left.Equals(right);

    /// <summary>
    /// Determines if two <see cref="ServiceEnvironmentVariable"/> values are different.
    /// </summary>
    /// <param name="left">The first <see cref="ServiceEnvironmentVariable"/> to compare.</param>
    /// <param name="right">The second <see cref="ServiceEnvironmentVariable"/> to compare.</param>
    /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
    public static bool operator !=(ServiceEnvironmentVariable left, ServiceEnvironmentVariable right) => !left.Equals(right);

    /// <summary>
    /// Converts a string to a <see cref="ServiceEnvironmentVariable"/>.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    public static implicit operator ServiceEnvironmentVariable(string value) => new ServiceEnvironmentVariable(value);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => obj is ServiceEnvironmentVariable other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ServiceEnvironmentVariable other) => string.Equals(_value, other._value, StringComparison.Ordinal);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}

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
/// /// <remarks>
/// Initializes a new instance of the <see cref="ServiceAuthType"/> structure.
/// </remarks>
/// <param name="value">The string value of the instance.</param>
public readonly struct ServiceAuthType(string value) : IEquatable<ServiceAuthType>
{
    private const string EntraIdValue = "EntraId";
    private const string AccessTokenValue = "AccessToken";

    private readonly string _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary>
    /// Entra ID authentication method.
    /// </summary>
    public static ServiceAuthType EntraId { get; } = new ServiceAuthType(EntraIdValue);

    /// <summary>
    /// Access token authentication method.
    /// </summary>
    public static ServiceAuthType AccessToken { get; } = new ServiceAuthType(AccessTokenValue);

    /// <summary>
    /// Determines if two <see cref="ServiceAuthType"/> values are the same.
    /// </summary>
    /// <param name="left">The first <see cref="ServiceAuthType"/> to compare.</param>
    /// <param name="right">The second <see cref="ServiceAuthType"/> to compare.</param>
    /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
    public static bool operator ==(ServiceAuthType left, ServiceAuthType right) => left.Equals(right);

    /// <summary>
    /// Determines if two <see cref="ServiceAuthType"/> values are different.
    /// </summary>
    /// <param name="left">The first <see cref="ServiceAuthType"/> to compare.</param>
    /// <param name="right">The second <see cref="ServiceAuthType"/> to compare.</param>
    /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
    public static bool operator !=(ServiceAuthType left, ServiceAuthType right) => !left.Equals(right);

    /// <summary>
    /// Converts a string to a <see cref="ServiceAuthType"/>.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    public static implicit operator ServiceAuthType(string value) => new ServiceAuthType(value);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => obj is ServiceAuthType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ServiceAuthType other) => string.Equals(_value, other._value, StringComparison.Ordinal);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}

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
/// /// /// <remarks>
/// Initializes a new instance of the <see cref="RunSettingKey"/> structure.
/// </remarks>
/// <param name="value">The string value of the instance.</param>
public readonly struct RunSettingKey(string value) : IEquatable<RunSettingKey>
{
    private const string RunNameValue = "RunName";
    private const string NumberOfTestWorkersValue = "NumberOfTestWorkers";
    private const string EnableResultPublishValue = "EnableResultPublish";
    private const string EnableGitHubSummaryValue = "EnableGitHubSummary";
    private const string ManagedIdentityClientIdValue = "ManagedIdentityClientId";
    private const string AzureTokenCredentialTypeValue = "AzureTokenCredentialType";
    private const string UseCloudHostedBrowsersValue = "UseCloudHostedBrowsers";
    private const string ServiceAuthTypeValue = "ServiceAuthType";
    private const string ExposeNetworkValue = "ExposeNetwork";
    private const string RunIdValue = "RunId";
    private const string OsValue = "Os";

    private readonly string _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary>
    /// The operating system setting key.
    /// </summary>
    public static RunSettingKey OS { get; } = new RunSettingKey(OsValue);

    /// <summary>
    /// The run ID setting key.
    /// </summary>
    public static RunSettingKey RunId { get; } = new RunSettingKey(RunIdValue);

    /// <summary>
    /// The expose network setting key.
    /// </summary>
    public static RunSettingKey ExposeNetwork { get; } = new RunSettingKey(ExposeNetworkValue);

    /// <summary>
    /// The default authentication setting key.
    /// </summary>
    public static RunSettingKey ServiceAuthType { get; } = new RunSettingKey(ServiceAuthTypeValue);

    /// <summary>
    /// The use cloud-hosted browsers setting key.
    /// </summary>
    public static RunSettingKey UseCloudHostedBrowsers { get; } = new RunSettingKey(UseCloudHostedBrowsersValue);

    /// <summary>
    /// The Azure token credential type setting key.
    /// </summary>
    public static RunSettingKey AzureTokenCredentialType { get; } = new RunSettingKey(AzureTokenCredentialTypeValue);

    /// <summary>
    /// The managed identity client ID setting key.
    /// </summary>
    public static RunSettingKey ManagedIdentityClientId { get; } = new RunSettingKey(ManagedIdentityClientIdValue);

    /// <summary>
    /// Enable GitHub summary setting key.
    /// </summary>
    public static RunSettingKey EnableGitHubSummary { get; } = new RunSettingKey(EnableGitHubSummaryValue);

    /// <summary>
    /// Enable Result publish.
    /// </summary>
    public static RunSettingKey EnableResultPublish { get; } = new RunSettingKey(EnableResultPublishValue);

    /// <summary>
    /// Number of NUnit test workers.
    /// </summary>
    public static RunSettingKey NumberOfTestWorkers { get; } = new RunSettingKey(NumberOfTestWorkersValue);

    /// <summary>
    /// The run name setting key.
    /// </summary>
    public static RunSettingKey RunName { get; } = new RunSettingKey(RunNameValue);

    /// <summary>
    /// Determines if two <see cref="RunSettingKey"/> values are the same.
    /// </summary>
    /// <param name="left">The first <see cref="RunSettingKey"/> to compare.</param>
    /// <param name="right">The second <see cref="RunSettingKey"/> to compare.</param>
    /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
    public static bool operator ==(RunSettingKey left, RunSettingKey right) => left.Equals(right);

    /// <summary>
    /// Determines if two <see cref="RunSettingKey"/> values are different.
    /// </summary>
    /// <param name="left">The first <see cref="RunSettingKey"/> to compare.</param>
    /// <param name="right">The second <see cref="RunSettingKey"/> to compare.</param>
    /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
    public static bool operator !=(RunSettingKey left, RunSettingKey right) => !left.Equals(right);

    /// <summary>
    /// Converts a string to a <see cref="RunSettingKey"/>.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    public static implicit operator RunSettingKey(string value) => new RunSettingKey(value);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => obj is RunSettingKey other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(RunSettingKey other) => string.Equals(_value, other._value, StringComparison.Ordinal);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}

internal class Constants
{
    // Default constants
    internal static readonly string s_default_os = ServiceOs.Linux;
    internal static readonly string s_default_expose_network = "<loopback>";
    internal static readonly string s_pLAYWRIGHT_SERVICE_DEBUG = "Logging__LogLevel__MicrosoftPlaywrightTesting";

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
    internal static readonly string s_workspace_mismatch_error = "The provided access token does not match the specified workspace URL. Please verify that both values are correct.";
    internal static readonly string s_invalid_service_endpoint_error_message = "The service endpoint provided is invalid. Please verify the endpoint URL and try again.";
    internal static readonly string s_playwright_service_runId_length_exceeded_error_message = "Error: The Run Id you provided exceeds 200 characters. Please provide a shorter Run ID.";

    internal static readonly string s_playwright_service_disable_scalable_execution_environment_variable = "_MPT_DISABLE_SCALABLE_EXECUTION";
    internal static readonly string s_playwright_service_reporting_url_environment_variable = "_MPT_REPORTING_URL";
    internal static readonly string s_playwright_service_workspace_id_environment_variable = "_MPT_WORKSPACE_ID";
    internal static readonly string s_playwright_service_auth_type_environment_variable = "_MPT_AUTH_TYPE";

    internal static readonly string s_playwright_service_runName_truncated_warning = "WARNING: Run name exceeds the maximum limit of 200 characters and will be truncated.";
}

internal class OSConstants
{
    internal static readonly string s_lINUX = "LINUX";
    internal static readonly string s_wINDOWS = "WINDOWS";
    internal static readonly string s_mACOS = "MACOS";
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
    internal static readonly string s_pLAYWRIGHT_SERVICE_REPORTING_URL = "_MPT_REPORTING_URL";
    internal static readonly string s_pLAYWRIGHT_SERVICE_WORKSPACE_ID = "_MPT_WORKSPACE_ID";
    internal static readonly string s_aPPLICATION_JSON = "application/json";
    internal static readonly string s_cONFLICT_409_ERROR_MESSAGE = "Test run with id {runId} already exists. Provide a unique run id.";
    internal static readonly string s_cONFLICT_409_ERROR_MESSAGE_KEY = "DuplicateRunId";

    internal static readonly string s_fORBIDDEN_403_ERROR_MESSAGE = "Reporting is not enabled for your workspace {workspaceId}. Enable the Reporting feature under Feature management settings using the Playwright portal: https://playwright.microsoft.com/workspaces/{workspaceId}/settings/general";
    internal static readonly string s_fORBIDDEN_403_ERROR_MESSAGE_KEY = "ReportingNotEnabled";
    internal static readonly string s_uNKNOWN_ERROR_MESSAGE = "Unknown error occured.";
}

internal class CIConstants
{
    internal static readonly string s_gITHUB_ACTIONS = "GITHUB";
    internal static readonly string s_aZURE_DEVOPS = "ADO";
    internal static readonly string s_dEFAULT = "DEFAULT";
}

internal class TestCaseResultStatus
{
    internal static readonly string s_pASSED = "PASSED";
    internal static readonly string s_fAILED = "FAILED";
    internal static readonly string s_sKIPPED = "SKIPPED";
    internal static readonly string s_iNCONCLUSIVE = "INCONCLUSIVE";
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

internal class ServiceClientConstants
{
    internal static readonly int s_mAX_RETRIES = 3;
    internal static readonly int s_mAX_RETRY_DELAY_IN_SECONDS = 2000;
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
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*403 Forbidden)(?=[\s\S]*InvalidAccountOrSubscriptionState)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "InvalidAccessToken",
            Message = "The provided access token does not match the specified workspace URL. Please verify that both values are correct.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*403 Forbidden)(?=[\s\S]*InvalidAccessToken)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "AccessTokenOrUserOrWorkspaceNotFound_Scalable",
            Message = "The data for the user, workspace or access token was not found. Please check the request or create new token and try again.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*404 Not Found)(?=[\s\S]*NotFound)", RegexOptions.IgnoreCase),
            Type = TestErrorType.Scalable
        },
        new TestResultError
        {
            Key = "AccessKeyBasedAuthNotSupported_Scalable",
            Message = "Authentication through service access token is disabled for this workspace. Please use Entra ID to authenticate.",
            Pattern = new Regex(@"(?=.*Microsoft\.Playwright\.PlaywrightException)(?=.*403 Forbidden)(?=[\s\S]*AccessKeyBasedAuthNotSupported)", RegexOptions.IgnoreCase),
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

internal static class ApiErrorConstants
{
    private static Dictionary<int, string> PatchTestRun { get; set; } = new Dictionary<int, string>() {
        { 400, "The request made to the server is invalid. Please check the request parameters and try again." },
        { 401, "The authentication token provided is invalid. Please check the token and try again." },
        { 500, "An unexpected error occurred on our server. Our team is working to resolve the issue. Please try again later, or contact support if the problem continues." },
        { 429, "You have exceeded the rate limit for the API. Please wait and try again later." },
        { 504, "The request to the service timed out. Please try again later." },
        { 503, "The service is currently unavailable. Please check the service status and try again." }
    };

    private static Dictionary<int, string> UploadBatchTestResults { get; set; } = new Dictionary<int, string>()
    {
        { 400, "The request made to the server is invalid. Please check the request parameters and try again." },
        { 401, "The authentication token provided is invalid. Please check the token and try again." },
        { 403, "You do not have the required permissions to run tests. Please contact your workspace administrator." },
        { 500, "An unexpected error occurred on our server. Our team is working to resolve the issue. Please try again later, or contact support if the problem continues." },
        { 429, "You have exceeded the rate limit for the API. Please wait and try again later." },
        { 504, "The request to the service timed out. Please try again later." },
        { 503, "The service is currently unavailable. Please check the service status and try again." }
    };
    private static Dictionary<int, string> PostTestRunShardInfo { get; set; } = new Dictionary<int, string>()
    {
        { 400, "The request made to the server is invalid. Please check the request parameters and try again." },
        { 401, "The authentication token provided is invalid. Please check the token and try again." },
        { 403, "You do not have the required permissions to run tests. Please contact your workspace administrator." },
        { 500, "An unexpected error occurred on our server. Our team is working to resolve the issue. Please try again later, or contact support if the problem continues." },
        { 429, "You have exceeded the rate limit for the API. Please wait and try again later." },
        { 504, "The request to the service timed out. Please try again later." },
        { 503, "The service is currently unavailable. Please check the service status and try again." }
    };
    private static Dictionary<int, string> GetTestRunResultsUri { get; set; } = new Dictionary<int, string>()
    {
        { 400, "The request made to the server is invalid. Please check the request parameters and try again." },
        { 401, "The authentication token provided is invalid. Please check the token and try again." },
        { 403, "You do not have the required permissions to run tests. Please contact your workspace administrator." },
        { 500, "An unexpected error occurred on our server. Our team is working to resolve the issue. Please try again later, or contact support if the problem continues." },
        { 429, "You have exceeded the rate limit for the API. Please wait and try again later." },
        { 504, "The request to the service timed out. Please try again later." },
        { 503, "The service is currently unavailable. Please check the service status and try again." }
    };

    internal static readonly Dictionary<string, Dictionary<int, string>> s_errorOperationPair = new()
    {
        { "PatchTestRun", PatchTestRun },
        { "UploadBatchTestResults", UploadBatchTestResults },
        { "PostTestRunShardInfo", PostTestRunShardInfo },
        { "GetTestRunResultsUri", GetTestRunResultsUri }
    };
}
