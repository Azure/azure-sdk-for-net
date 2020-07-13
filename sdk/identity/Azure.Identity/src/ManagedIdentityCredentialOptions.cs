// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="ManagedIdentityCredential"/>.
    /// </summary>
    public class ManagedIdentityCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// The client id of the user assigned managed identity to authenticate. If not specified the <see cref="ManagedIdentityCredential"/> will authenticate the system assigned identity.  More information on user assigned managed identities can be found here:
        /// https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview#how-a-user-assigned-managed-identity-works-with-an-azure-vm
        /// </summary>
        public string ClientId { get; set; }

        internal ManagedIdentityClient Client { get; set; }
    }
}
