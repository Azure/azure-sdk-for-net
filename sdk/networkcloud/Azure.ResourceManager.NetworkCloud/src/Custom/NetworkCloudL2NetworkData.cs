// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudL2NetworkData
    {
        // Backward compat: old API had ExtendedLocation as 2nd parameter; new API has it last.
        /// <summary> Initializes a new instance of <see cref="NetworkCloudL2NetworkData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudL2NetworkData(AzureLocation location, ExtendedLocation extendedLocation, ResourceIdentifier l2IsolationDomainId)
            : this(location, l2IsolationDomainId, extendedLocation) { }
        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation
        {
            get => ExtendedLocationInternal is Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation custom
                ? custom
                : (ExtendedLocationInternal != null ? new Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation(ExtendedLocationInternal.Name, ExtendedLocationInternal.ExtendedLocationType?.ToString()) : null);
            set => ExtendedLocationInternal = value;
        }
    }
}
