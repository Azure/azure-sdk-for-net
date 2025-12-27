// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    /// <summary> Specifies set of certificates that should be installed onto the virtual machines. </summary>
    public partial class NodeTypeVaultSecretGroup
    {
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier SourceVaultId
        {
            get => SourceVault is null ? default : SourceVault.Id;
            set
            {
                if (SourceVault is null)
                    SourceVault = new WritableSubResource();
                SourceVault.Id = value;
            }
        }
    }
}
