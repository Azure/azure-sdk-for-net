// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Identity;

internal class CredentialOptionsMapper
{
    /// <summary>
    /// Creates broker <see cref="InteractiveBrowserCredentialOptions"/> from the provided credential options if the broker package is available.
    /// </summary>
    /// <param name="isBrokerEnabled">Set to <c>true</c> when broker support is available; otherwise <c>false</c>.</param>
    /// <param name="credentialOptions">Optional credential options whose shared properties (tenant id, allowed tenants, authority host, logging flags, chain marker) are copied onto the returned broker options.</param>
    /// <param name="fileSystem">Optional file system service used to attempt loading an <see cref="AuthenticationRecord"/> from the VS Code Azure Resource Groups extension cache (authRecord.json).</param>
    /// <returns>
    /// A fully populated <see cref="InteractiveBrowserCredentialOptions"/> configured for broker authentication when the broker package is enabled; otherwise <c>null</c>.
    /// </returns>
    internal static InteractiveBrowserCredentialOptions GetBrokerOptions(out bool isBrokerEnabled, TokenCredentialOptions credentialOptions = null, IFileSystemService fileSystem = null)
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
                options.AuthenticationRecord = GetAuthenticationRecord(fileSystem);

            return options;
        }

        return null;
    }

    /// <summary>
    /// Attempts to locate and deserialize a persisted <see cref="AuthenticationRecord"/> written by the
    /// VS Code Azure Resource Groups extension. Both lowercase (".azure") and mixed case (".Azure")
    /// user profile directories are probed for the file:
    /// <c>%USERPROFILE%/.azure/ms-azuretools.vscode-azureresourcegroups/authRecord.json</c>.
    /// </summary>
    /// <param name="_fileSystem">File system abstraction used to test for file existence and open the file stream.</param>
    /// <returns>
    /// A valid <see cref="AuthenticationRecord"/> when the file exists and contains the minimum required
    /// identifiers (TenantId and HomeAccountId); otherwise <c>null</c>. Any I/O or deserialization errors are swallowed.
    /// </returns>
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
    /// Creates non-broker (interactive browser) fallback options from the provided credential options when broker options are not available.
    /// </summary>
    /// <param name="credentialOptions">Optional credential options to copy common properties from.</param>
    /// <returns>A minimal <see cref="InteractiveBrowserCredentialOptions"/> instance with shared properties copied; no broker specific configuration or authentication record is attached.</returns>
    internal static InteractiveBrowserCredentialOptions CreateFallbackOptions(TokenCredentialOptions credentialOptions = null)
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
