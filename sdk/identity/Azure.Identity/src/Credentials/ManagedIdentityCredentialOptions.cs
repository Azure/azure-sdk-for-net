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
        /// Creates an instance of <see cref="ManagedIdentityCredentialOptions"/>.
        /// </summary>
        /// <param name="managedIdentityId">The <see cref="ManagedIdentityId"/> to configure the type of managed identity to be used by the <see cref="ManagedIdentityCredential"/>.</param>
        public ManagedIdentityCredentialOptions(ManagedIdentityId managedIdentityId)
        {
            ManagedIdentityId = managedIdentityId;
        }

        /// <summary>
        /// Specifies the configuration for the managed identity.
        /// </summary>
        public ManagedIdentityId ManagedIdentityId { get; set; }
    }
}
