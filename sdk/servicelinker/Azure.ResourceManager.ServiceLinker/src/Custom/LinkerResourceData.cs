// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ServiceLinker.Models;

namespace Azure.ResourceManager.ServiceLinker
{
    // Add the properties back due to the breaking change of models: `VnetSolution` & `SecretStore` have more properties in version 2024-07-01-preview.
    public partial class LinkerResourceData
    {
        /// <summary> Type of VNet solution. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VnetSolutionType? SolutionType
        {
            get => VnetSolution is null ? default : VnetSolution.SolutionType;
            set
            {
                if (VnetSolution is null)
                    VnetSolution = new VnetSolution();
                VnetSolution.SolutionType = value;
            }
        }

        /// <summary> The key vault id to store secret. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier SecretStoreKeyVaultId
        {
            get => SecretStore is null ? default : SecretStore.KeyVaultId;
            set
            {
                if (SecretStore is null)
                    SecretStore = new LinkerSecretStore();
                SecretStore.KeyVaultId = value;
            }
        }
    }
}
