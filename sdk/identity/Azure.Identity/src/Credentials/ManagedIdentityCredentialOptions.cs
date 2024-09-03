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
        /// Specifies the configuration for the managed identity.
        /// </summary>
        public ManagedIdentityId ManagedIdentityId { get; set; } = ManagedIdentityId.SystemAssigned;
    }
}
