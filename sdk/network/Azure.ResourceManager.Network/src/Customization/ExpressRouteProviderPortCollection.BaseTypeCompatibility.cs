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
    /// <summary> Compatibility declaration for the ExpressRouteProviderPortCollection type. </summary>
    public partial class ExpressRouteProviderPortCollection : IEnumerable<ExpressRouteProviderPortResource>, IAsyncEnumerable<ExpressRouteProviderPortResource>
    {
        IEnumerator<ExpressRouteProviderPortResource> IEnumerable<ExpressRouteProviderPortResource>.GetEnumerator() => ((IEnumerable<ExpressRouteProviderPortResource>)Array.Empty<ExpressRouteProviderPortResource>()).GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => Array.Empty<ExpressRouteProviderPortResource>().GetEnumerator();
        IAsyncEnumerator<ExpressRouteProviderPortResource> IAsyncEnumerable<ExpressRouteProviderPortResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => new EmptyAsyncEnumerator<ExpressRouteProviderPortResource>();
    }
}
