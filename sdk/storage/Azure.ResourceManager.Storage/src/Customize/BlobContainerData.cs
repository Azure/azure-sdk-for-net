// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden alias properties for renamed generated properties.

using System.ComponentModel;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobContainerData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.deleted")]
        public bool? IsDeleted => ContainerProperties is null ? default : ContainerProperties.IsDeleted;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.denyEncryptionScopeOverride")]
        public bool? PreventEncryptionScopeOverride
        {
            get => ContainerProperties is null ? default : ContainerProperties.PreventEncryptionScopeOverride;
            set
            {
                if (ContainerProperties is null)
                {
                    ContainerProperties = new ContainerProperties();
                }
                ContainerProperties.PreventEncryptionScopeOverride = value;
            }
        }
    }
}
