// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shim for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version added routePolicyStatements as a required constructor parameter.
    // This preserves the old constructor signature from v1.1.2 that only required location and networkFabricId.
    public partial class NetworkFabricRoutePolicyData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricRoutePolicyData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="networkFabricId"> Arm Resource ID of Network Fabric. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version.")]
        public NetworkFabricRoutePolicyData(AzureLocation location, ResourceIdentifier networkFabricId) : this(location, Array.Empty<RoutePolicyStatementProperties>(), networkFabricId)
        {
        }
    }
}
