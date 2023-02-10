// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Models;

[assembly: CodeGenSuppressType("DevTestLabManagedIdentity")]
namespace Azure.ResourceManager.DevTestLabs.Models
{
    /// <summary>
    /// Properties of a managed identity
    /// </summary>
    public partial class DevTestLabManagedIdentity
    {
        /// <summary> Initializes a new instance of DevTestLabManagedIdentity. </summary>
        public DevTestLabManagedIdentity()
        {
        }

        /// <summary> Initializes a new instance of DevTestLabManagedIdentity. </summary>
        /// <param name="managedIdentityType">
        /// Managed identity.
        /// Serialized Name: IdentityProperties.type
        /// </param>
        /// <param name="principalId">
        /// The principal id of resource identity.
        /// Serialized Name: IdentityProperties.principalId
        /// </param>
        /// <param name="tenantId">
        /// The tenant identifier of resource.
        /// Serialized Name: IdentityProperties.tenantId
        /// </param>
        /// <param name="clientSecretUri">
        /// The client secret URL of the identity.
        /// Serialized Name: IdentityProperties.clientSecretUrl
        /// </param>
        internal DevTestLabManagedIdentity(ManagedServiceIdentityType managedIdentityType, Guid? principalId, Guid? tenantId, Uri clientSecretUri)
        {
            ManagedIdentityType = managedIdentityType;
            PrincipalId = principalId;
            TenantId = tenantId;
            ClientSecretUri = clientSecretUri;
        }

        /// <summary>
        /// Managed identity.
        /// Serialized Name: IdentityProperties.type
        /// </summary>
        public Azure.ResourceManager.Models.ManagedServiceIdentityType ManagedIdentityType { get; set; }
        /// <summary>
        /// The principal id of resource identity.
        /// Serialized Name: IdentityProperties.principalId
        /// </summary>
        public Guid? PrincipalId { get; set; }
        /// <summary>
        /// The tenant identifier of resource.
        /// Serialized Name: IdentityProperties.tenantId
        /// </summary>
        public Guid? TenantId { get; set; }
        /// <summary>
        /// The client secret URL of the identity.
        /// Serialized Name: IdentityProperties.clientSecretUrl
        /// </summary>
        public Uri ClientSecretUri { get; set; }
    }
}
