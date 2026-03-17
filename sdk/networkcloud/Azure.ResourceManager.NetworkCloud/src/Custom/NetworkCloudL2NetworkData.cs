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
    }
}
