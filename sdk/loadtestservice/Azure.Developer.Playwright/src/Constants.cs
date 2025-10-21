// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Developer.Playwright;

/// <summary>
/// Contains environment variable names used by the Playwright Workspaces.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ServiceEnvironmentVariable"/> structure.
/// </remarks>
/// <param name="value">The string value of the instance.</param>
public readonly struct ServiceEnvironmentVariable(string value) : IEquatable<ServiceEnvironmentVariable>
{
    private const string PlaywrightServiceAccessTokenValue = "PLAYWRIGHT_SERVICE_ACCESS_TOKEN";
    private const string PlaywrightServiceUriValue = "PLAYWRIGHT_SERVICE_URL";

    private readonly string _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary>
    /// The environment variable for the Playwright Workspaces access token.
    /// </summary>
    public static ServiceEnvironmentVariable PlaywrightServiceAccessToken { get; } = new ServiceEnvironmentVariable(PlaywrightServiceAccessTokenValue);

    /// <summary>
    /// The environment variable for the Playwright Workspaces URL.
    /// </summary>
    public static ServiceEnvironmentVariable PlaywrightServiceUri { get; } = new ServiceEnvironmentVariable(PlaywrightServiceUriValue);

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

internal class Constants
{
    // Default constants
    internal static readonly string s_default_os = OSConstants.s_lINUX;
    internal static readonly string s_default_expose_network = "<loopback>";
    internal static readonly string s_pLAYWRIGHT_SERVICE_DEBUG = "Logging__LogLevel__AzurePlaywright";
    internal static readonly string s_minimumSupportedPlaywrightVersion = "1.50.0";

    // Entra id access token constants
    internal static readonly int s_entra_access_token_lifetime_left_threshold_in_minutes_for_rotation = 15;
    internal static readonly string[] s_entra_access_token_scopes = ["https://management.core.windows.net/.default"];
    internal static readonly int s_entra_access_token_rotation_interval_period_in_minutes = 4;

    // Error messages
    internal static readonly string s_no_service_endpoint_error_message = "Please set PLAYWRIGHT_SERVICE_URL in your environment variables.";
    internal static readonly string s_no_auth_error = "Could not authenticate with the service. Please refer to https://aka.ms/pww/docs/authentication for more information.";
    internal static readonly string s_entra_no_cred_error = "Azure credentials not found when using Entra ID authentication. Please refer to https://aka.ms/pww/docs/authentication for more information.";
    internal static readonly string s_invalid_mpt_pat_error = "The Access Token provided in the environment variable is invalid.";
    internal static readonly string s_expired_mpt_pat_error = "The Access Token you are using is expired. Create a new token.";
    internal static readonly string s_invalid_os_error = "Invalid operating system, supported values are 'linux' and 'windows'.";
    internal static readonly string s_workspace_mismatch_error = "The provided access token does not match the specified workspace URL. Please verify that both values are correct.";
    internal static readonly string s_invalid_service_endpoint_error_message = "The service endpoint provided is invalid. Please verify the endpoint URL and try again.";
    internal static readonly string s_playwright_service_runId_not_guid_error_message = "Error: The Run ID must be a valid GUID format. Please provide a valid GUID for the Run ID.";
    internal static readonly string s_playwright_service_runName_truncated_warning = "WARNING: Run name exceeds the maximum limit of 200 characters and will be truncated.";
    internal static readonly string s_playwright_Version_not_supported_error_message = "The Playwright version you are using does not support playwright workspaces. Please update to Playwright version 1.50.0 or higher.";
    internal static readonly string s_playwright_Invalid_version = "The Playwright version you are using is not supported. See the list of supported versions at https://aka.ms/pww/docs/supported-versions.";
    internal static readonly string s_playwright_service_create_test_run_error = "Failed to create the test run in the Playwright Workspaces. Please refer to https://aka.ms/pww/docs/troubleshooting for more information.";

    // Internal environment variables
    internal static readonly string s_playwright_service_use_cloud_hosted_browsers_environment_variable = "_MPT_USE_CLOUD_HOSTED_BROWSERS";
    internal static readonly string s_playwright_service_auth_type_environment_variable = "_MPT_AUTH_TYPE";
    internal static readonly string s_playwright_service_expose_network_environment_variable = "PLAYWRIGHT_SERVICE_EXPOSE_NETWORK";
    internal static readonly string s_playwright_service_os_environment_variable = "PLAYWRIGHT_SERVICE_OS";
    internal static readonly string s_playwright_service_run_id_environment_variable = "PLAYWRIGHT_SERVICE_RUN_ID";
    internal static readonly string s_playwright_service_run_name_environment_variable = "PLAYWRIGHT_SERVICE_RUN_NAME";
}

internal class OSConstants
{
    internal static readonly string s_lINUX = "linux";
    internal static readonly string s_wINDOWS = "windows";
}

internal class CIConstants
{
    internal static readonly string s_gITHUB_ACTIONS = "GITHUB";
    internal static readonly string s_aZURE_DEVOPS = "ADO";
    internal static readonly string s_dEFAULT = "DEFAULT";
}

internal class TimeoutConstants
{
    internal const int Http_call_timeout_ms = 10000;
}

internal class SDKLanguageConstants
{
    internal static readonly string s_jAVASCRIPT = "JAVASCRIPT";
    internal static readonly string s_tYPESCRIPT = "TYPESCRIPT";
    internal static readonly string s_cSHARP = "CSHARP";
}

internal class RunConfigConstants
{
    internal static readonly string s_tEST_FRAMEWORK_NAME = "PLAYWRIGHT";
    internal static readonly string s_tEST_SDK_LANGUAGE = SDKLanguageConstants.s_cSHARP;
    internal static readonly string s_tEST_FRAMEWORK_RUNNERNAME = "PLAYWRIGHT";
}

internal class ServiceClientConstants
{
    internal static readonly int s_mAX_RETRIES = 3;
    internal static readonly int s_iNITIAL_DELAY_MS = 1000;
    internal static readonly int s_mAX_DELAY_MS = 64000;
}

internal class ApiVersionConstants
{
    internal static readonly string s_latestApiVersion = "2025-09-01";
}
