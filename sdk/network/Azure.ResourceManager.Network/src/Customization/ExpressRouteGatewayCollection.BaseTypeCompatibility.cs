// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteGatewayCollection type. </summary>
    public partial class ExpressRouteGatewayCollection : IEnumerable<ExpressRouteGatewayResource>, IAsyncEnumerable<ExpressRouteGatewayResource>
    {
        IEnumerator<ExpressRouteGatewayResource> IEnumerable<ExpressRouteGatewayResource>.GetEnumerator() => ((IEnumerable<ExpressRouteGatewayResource>)Array.Empty<ExpressRouteGatewayResource>()).GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => Array.Empty<ExpressRouteGatewayResource>().GetEnumerator();
        IAsyncEnumerator<ExpressRouteGatewayResource> IAsyncEnumerable<ExpressRouteGatewayResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => new EmptyAsyncEnumerator<ExpressRouteGatewayResource>();
    }
}
