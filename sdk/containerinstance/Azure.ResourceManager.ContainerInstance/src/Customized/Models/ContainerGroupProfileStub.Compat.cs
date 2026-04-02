// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

// Backward-compat property shims: ResourceId and StorageFileShares delegated to internal properties.

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupProfileStub
    {
        /// <summary> Resource id of the container group profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ResourceId
        {
            get => Resource?.Id != null ? new ResourceIdentifier(Resource.Id) : null;
            set
            {
                if (Resource is null)
                    Resource = new ApiEntityReference();
                Resource.Id = value?.ToString();
            }
        }

        /// <summary> The list of file shares. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ContainerGroupFileShare> StorageFileShares
        {
            get
            {
                if (StorageProfile is null)
                    StorageProfile = new StorageProfile();
                return StorageProfile.FileShares;
            }
        }
    }
}
