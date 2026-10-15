// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class KeyVaultKeyReference
    {
        // Preserve the non-virtual flattened properties shipped in Compute 1.18.0 while
        // keeping the underlying ComputeWriteableSubResourceData.Id virtual for GA compatibility.
        // Remove these forwarding compatibility members when the next major version permits it.
        /// <summary> Resource Id. </summary>
        public ResourceIdentifier SourceVaultId
        {
            get
            {
                return SourceVault is null ? default : SourceVault.Id;
            }
            set
            {
                SourceVault = new ComputeWriteableSubResourceData(value);
            }
        }
    }
}
