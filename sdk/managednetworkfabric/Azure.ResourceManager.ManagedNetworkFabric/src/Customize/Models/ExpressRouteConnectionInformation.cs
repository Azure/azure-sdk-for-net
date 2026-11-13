// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shim for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version added expressRouteAuthorizationKey as a required constructor parameter.
    // This preserves the old constructor signature from v1.1.2 that only required expressRouteCircuitId.
    public partial class ExpressRouteConnectionInformation
    {
        /// <summary> Initializes a new instance of <see cref="ExpressRouteConnectionInformation"/>. </summary>
        /// <param name="expressRouteCircuitId"> The express route circuit resource identifier. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ExpressRouteConnectionInformation(ResourceIdentifier expressRouteCircuitId) : this(expressRouteCircuitId, default)
        {
        }
    }
}
