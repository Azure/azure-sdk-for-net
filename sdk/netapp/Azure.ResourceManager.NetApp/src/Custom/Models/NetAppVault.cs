// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Vault information. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppVault : ResourceData
    {
        /// <summary> Initializes a new instance of NetAppVault. </summary>
        internal NetAppVault()
        {
        }

        /// <summary> Initializes a new instance of NetAppVault. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="vaultName"> Vault Name. </param>
        internal NetAppVault(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string vaultName) : base(id, name, resourceType, systemData)
        {
            VaultName = vaultName;
        }

        /// <summary> Vault Name. </summary>
        public string VaultName { get; }
    }
}
