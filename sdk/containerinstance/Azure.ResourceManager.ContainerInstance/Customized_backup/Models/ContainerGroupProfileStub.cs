// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupProfileStub
    {
        /// <summary> A reference to the container group profile ARM resource hosted in ACI RP. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ResourceId
        {
            get => Resource?.Id != null ? new ResourceIdentifier(Resource.Id) : null;
            set
            {
                if (Resource is null)
                {
                    Resource = new ApiEntityReference();
                }
                Resource.Id = value?.ToString();
            }
        }

        /// <summary> A network profile for network settings of a ContainerGroupProfile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupNetworkProfile NetworkProfile
        {
            get => _networkProfile as ContainerGroupNetworkProfile;
            set => _networkProfile = value;
        }

        /// <summary> The list of file shares for the container group profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ContainerGroupFileShare> StorageFileShares
        {
            get
            {
                if (StorageProfile is null)
                {
                    StorageProfile = new StorageProfile();
                }
                return new Azure.ResourceManager.ContainerInstance.UpCastList<ContainerGroupFileShare, FileShare>(StorageProfile.FileShares);
            }
        }
    }
}
