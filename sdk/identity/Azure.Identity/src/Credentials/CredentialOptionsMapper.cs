// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Identity.Credentials;

internal class CredentialOptionsMapper
{
    /// <summary>
    /// Attempts to get broker options and returns them if available, along with a flag indicating success.
    /// </summary>
    /// <param name="fileSystem">The file system service to use for reading authentication records.</param>
    /// <param name="isBrokerEnabled">Output parameter indicating whether broker options are available.</param>
    /// <returns>The broker options if available, null otherwise.</returns>
    internal static InteractiveBrowserCredentialOptions TryGetBrokerOptions(out bool isBrokerEnabled, IFileSystemService fileSystem = null)
    {
        isBrokerEnabled = DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out InteractiveBrowserCredentialOptions options);

        if (isBrokerEnabled && options != null)
        {
            if (fileSystem is not null)
                options.AuthenticationRecord = GetAuthenticationRecord(fileSystem);
            return options;
        }

        return null;
    }

    /// <summary>
    /// Get the broker options from the provided credential options.
    /// </summary>
    /// <param name="credentialOptions">The credential options to extract broker options from.</param>
    /// <param name="isBrokerEnabled"> Indicates whether the broker package is present or not.</param>
    /// <param name="fileSystem"> The file system service to use for reading authentication records. </param>
    /// <returns> The broker options extracted from the credential options, or null if the broker package is not enabled.</returns>
    internal static InteractiveBrowserCredentialOptions GetBrokerOptionsWithCredentialOptions(TokenCredentialOptions credentialOptions, out bool isBrokerEnabled, IFileSystemService fileSystem = null)
    {
        isBrokerEnabled = DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out InteractiveBrowserCredentialOptions options);

        if (isBrokerEnabled && options != null)
        {
            if (credentialOptions != null)
            {
                options.TenantId = (credentialOptions as ISupportsTenantId)?.TenantId;
                options.AdditionallyAllowedTenants = (credentialOptions as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants;
                options.AuthorityHost = credentialOptions.AuthorityHost;
                options.IsUnsafeSupportLoggingEnabled = credentialOptions.IsUnsafeSupportLoggingEnabled;
                options.IsChainedCredential = credentialOptions.IsChainedCredential;
            }

            if (fileSystem is not null)
            {
                options.AuthenticationRecord = GetAuthenticationRecord(fileSystem);
            }

            return options;
        }

        return null;
    }

    internal static AuthenticationRecord GetAuthenticationRecord(IFileSystemService _fileSystem)
        {
            var homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            var authRecordPathLowerCase = Path.Combine(homeDir, ".azure", "ms-azuretools.vscode-azureresourcegroups", "authRecord.json");
            var authRecordPathUpperCase = Path.Combine(homeDir, ".Azure", "ms-azuretools.vscode-azureresourcegroups", "authRecord.json");

            var authRecordPath = _fileSystem.FileExists(authRecordPathLowerCase) ? authRecordPathLowerCase :
                                 _fileSystem.FileExists(authRecordPathUpperCase) ? authRecordPathUpperCase : null;

            if (authRecordPath == null)
            {
                return null;
            }

            try
            {
                using var authRecordStream = _fileSystem.GetFileStream(authRecordPath);
                var authRecord = AuthenticationRecord.Deserialize(authRecordStream);
                if (authRecord != null && !string.IsNullOrEmpty(authRecord.TenantId) && !string.IsNullOrEmpty(authRecord.HomeAccountId))
                {
                    return authRecord;
                }
            }
            catch (Exception) { }
            return null;
        }

    /// <summary>
    /// Creates fallback options when broker options are not available.
    /// This prevents the constructor from failing and defers the error to GetToken.
    /// </summary>
    /// <returns>A minimal InteractiveBrowserCredentialOptions instance.</returns>
    internal static InteractiveBrowserCredentialOptions CreateFallbackOptions()
    {
        return new InteractiveBrowserCredentialOptions();
    }

    /// <summary>
    /// Creates fallback options from the provided credential options when broker options are not available.
    /// </summary>
    /// <param name="credentialOptions"> The credential options to copy properties from.</param>
    /// <returns> A minimal InteractiveBrowserCredentialOptions instance with properties copied from the provided credential options.</returns>
    internal static InteractiveBrowserCredentialOptions CreateFallbackOptionsFromCredentialOptions(TokenCredentialOptions credentialOptions)
    {
        var fallbackOptions = new InteractiveBrowserCredentialOptions();

        if (credentialOptions != null)
        {
            fallbackOptions.TenantId = (credentialOptions as ISupportsTenantId)?.TenantId;
            fallbackOptions.AdditionallyAllowedTenants = (credentialOptions as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants;
            fallbackOptions.AuthorityHost = credentialOptions.AuthorityHost;
            fallbackOptions.IsUnsafeSupportLoggingEnabled = credentialOptions.IsUnsafeSupportLoggingEnabled;
            fallbackOptions.IsChainedCredential = credentialOptions.IsChainedCredential;
        }

        return fallbackOptions;
    }
}
