// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
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
