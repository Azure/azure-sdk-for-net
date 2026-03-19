// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="ManagedIdentityCredential"/>.
    /// </summary>
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    public class ManagedIdentityCredentialOptions : TokenCredentialOptions
    {
        internal ManagedIdentityCredentialOptions() : this(null)
        { }

        /// <summary>
        /// Creates an instance of <see cref="ManagedIdentityCredentialOptions"/>.
        /// </summary>
        /// <param name="managedIdentityId">The <see cref="ManagedIdentityId"/> specifying which managed identity will be configured. By default, <see cref="ManagedIdentityId.SystemAssigned"/> will be configured.</param>
        public ManagedIdentityCredentialOptions(ManagedIdentityId managedIdentityId = null)
        {
            ManagedIdentityId = managedIdentityId ?? ManagedIdentityId.SystemAssigned;
        }
        /// <summary>
        /// Specifies the configuration for the managed identity.
        /// </summary>
        internal ManagedIdentityId ManagedIdentityId { get; }
    }
#pragma warning restore AZC0034
}
