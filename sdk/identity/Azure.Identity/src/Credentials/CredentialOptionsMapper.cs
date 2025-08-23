// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity.Credentials;

internal class CredentialOptionsMapper
{
    /// <summary>
    /// Get the broker options from the provided credential options.
    /// </summary>
    /// <param name="credentialOptions">The credential options to extract broker options from.</param>
    /// <param name="isBrokerEnabled"> Indicates whether the broker package is present or not.</param>
    /// <returns> The broker options extracted from the credential options, or null if the broker package is not enabled.</returns>
    internal static InteractiveBrowserCredentialOptions GetBrokerOptionsWithCredentialOptions(TokenCredentialOptions credentialOptions, out bool isBrokerEnabled)
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

            return options;
        }

        return null;
    }
}
