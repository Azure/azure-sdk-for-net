// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.ContainerInstance;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupProfileStub
    {
        // backward-compat shim: old property returned ContainerGroupNetworkProfile, new returns NetworkProfile
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupNetworkProfile NetworkProfile
        {
            get => _networkProfile as ContainerGroupNetworkProfile;
            set => _networkProfile = value;
        }

        // backward-compat shim: old property was ResourceIdentifier, new is string
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.Core.ResourceIdentifier ResourceId
        {
            get => Resource?.Id != null ? new Azure.Core.ResourceIdentifier(Resource.Id) : null;
            set
            {
                if (Resource is null)
                    Resource = new ApiEntityReference();
                Resource.Id = value?.ToString();
            }
        }

        // backward-compat shim: old property returned IList<ContainerGroupFileShare>, new returns IList<FileShare>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ContainerGroupFileShare> StorageFileShares
        {
            get
            {
                if (StorageProfile is null)
                    StorageProfile = new StorageProfile();
                return StorageProfile.FileShares != null ? new UpCastList<ContainerGroupFileShare, FileShare>(StorageProfile.FileShares) : null;
            }
        }
    }
}
