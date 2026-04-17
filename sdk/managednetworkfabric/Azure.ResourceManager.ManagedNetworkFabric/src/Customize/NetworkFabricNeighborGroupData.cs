// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shim for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version added a required constructor parameter (destination).
    // This preserves the old constructor signature from v1.1.2 that only required location.
    public partial class NetworkFabricNeighborGroupData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricNeighborGroupData"/>. </summary>
        /// <param name="location"> The location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version.")]
        public NetworkFabricNeighborGroupData(AzureLocation location) : this(location, default)
        {
        }
    }
}
