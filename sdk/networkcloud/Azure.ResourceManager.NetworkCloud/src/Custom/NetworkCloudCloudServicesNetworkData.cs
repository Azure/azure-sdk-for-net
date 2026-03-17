// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudCloudServicesNetworkData
    {
        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation
        {
            get => ExtendedLocationInternal is Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation custom
                ? custom
                : (ExtendedLocationInternal != null ? new Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation(ExtendedLocationInternal.Name, ExtendedLocationInternal.ExtendedLocationType?.ToString()) : null);
            set => ExtendedLocationInternal = value;
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloudCloudServicesNetworkData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudCloudServicesNetworkData(AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation)
            : this(location, (Azure.ResourceManager.Resources.Models.ExtendedLocation)extendedLocation)
        {
        }
    }
}
