// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="AzureApplicationCredential"/> authentication flow and requests made to Azure Identity services.
    /// </summary>
    internal class AzureApplicationCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// Specifies the client id of the azure ManagedIdentity in the case of user assigned identity.
        /// </summary>
        public string ManagedIdentityClientId { get; set; } = GetNonEmptyStringOrNull(EnvironmentVariables.ClientId);

        /// <summary>
        /// Specifies whether a token request will include an x5c header in it client claims to enable subject name / issuer based
        /// authentication in the case of client certificate authentication.
        /// </summary>
        public bool SendCertificateChain { get; set; }

        private static string GetNonEmptyStringOrNull(string str)
        {
            return !string.IsNullOrEmpty(str) ? str : null;
        }
    }
}
