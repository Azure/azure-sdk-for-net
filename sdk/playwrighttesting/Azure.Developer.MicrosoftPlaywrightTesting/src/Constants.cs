// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Developer.MicrosoftPlaywrightTesting;

/// <summary>
/// Contains environment variable names used by the Playwright service.
/// </summary>
public class ServiceEnvironmentVariable
{
    /// <summary>
    /// The environment variable for the Playwright service access token.
    /// </summary>
    public static readonly string PLAYWRIGHT_SERVICE_ACCESS_TOKEN_ENVIRONMENT_VARIABLE = "PLAYWRIGHT_SERVICE_ACCESS_TOKEN";

    /// <summary>
    /// The environment variable for the Playwright service URL.
    /// </summary>
    public static readonly string PLAYWRIGHT_SERVICE_URL_ENVIRONMENT_VARIABLE = "PLAYWRIGHT_SERVICE_URL";

    /// <summary>
    /// The environment variable for exposing the Playwright service network.
    /// </summary>
    public static readonly string PLAYWRIGHT_SERVICE_EXPOSE_NETWORK_ENVIRONMENT_VARIABLE = "PLAYWRIGHT_SERVICE_EXPOSE_NETWORK";

    /// <summary>
    /// The environment variable for the Playwright service operating system.
    /// </summary>
    public static readonly string PLAYWRIGHT_SERVICE_OS_ENVIRONMENT_VARIABLE = "PLAYWRIGHT_SERVICE_OS";

    /// <summary>
    /// The environment variable for the Playwright service run ID.
    /// </summary>
    public static readonly string PLAYWRIGHT_SERVICE_RUN_ID_ENVIRONMENT_VARIABLE = "PLAYWRIGHT_SERVICE_RUN_ID";
};

/// <summary>
/// Contains constants for supported operating systems on Microsoft Playwright Testing.
/// </summary>
public class ServiceOs
{
    /// <summary>
    /// Linux operating system.
    /// </summary>
    public static readonly string LINUX = "linux";

    /// <summary>
    /// Windows operating system.
    /// </summary>
    public static readonly string WINDOWS = "windows";
};

/// <summary>
/// Contains constants for authentication methods.
/// </summary>
public class ServiceAuth
{
    /// <summary>
    /// Entra ID authentication method.
    /// </summary>
    public static readonly string ENTRA = "ENTRA";

    /// <summary>
    /// Service token authentication method.
    /// </summary>
    public static readonly string TOKEN = "TOKEN";
};

/// <summary>
/// Contains constants for Azure token credential types.
/// </summary>
public class AzureTokenCredentialType
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
    public static readonly string OS = "Os";

    /// <summary>
    /// The run ID setting key.
    /// </summary>
    public static readonly string RUN_ID = "RunId";

    /// <summary>
    /// The expose network setting key.
    /// </summary>
    public static readonly string EXPOSE_NETWORK = "ExposeNetwork";

    /// <summary>
    /// The default authentication setting key.
    /// </summary>
    public static readonly string DEFAULT_AUTH = "DefaultAuth";

    /// <summary>
    /// The use cloud-hosted browsers setting key.
    /// </summary>
    public static readonly string USE_CLOUD_HOSTED_BROWSERS = "UseCloudHostedBrowsers";

    /// <summary>
    /// The Azure token credential type setting key.
    /// </summary>
    public static readonly string AZURE_TOKEN_CREDENTIAL_TYPE = "AzureTokenCredentialType";

    /// <summary>
    /// The managed identity client ID setting key.
    /// </summary>
    public static readonly string MANAGED_IDENTITY_CLIENT_ID = "ManagedIdentityClientId";

    /// <summary>
    /// Enable GitHub summary setting key.
    /// </summary>
    public static readonly string ENABLE_GITHUB_SUMMARY = "EnableGitHubSummary";

    /// <summary>
    /// Enable Result publish.
    /// </summary>
    public static readonly string ENABLE_RESULT_PUBLISH = "EnableResultPublish";
}

internal class Constants
{
    // Default constants
    internal static readonly string s_default_os = ServiceOs.LINUX;
    internal static readonly string s_default_expose_network = "<loopback>";

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

    internal static readonly string s_playwright_service_disable_scalable_execution_environment_variable = "PLAYWRIGHT_SERVICE_DISABLE_SCALABLE_EXECUTION";
    internal static readonly string s_playwright_service_reporting_url_environment_variable = "PLAYWRIGHT_SERVICE_REPORTING_URL";
    internal static readonly string s_playwright_service_workspace_id_environment_variable = "PLAYWRIGHT_SERVICE_WORKSPACE_ID";
}