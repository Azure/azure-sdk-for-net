// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent
{
    /// <summary>
    /// An immutable client-side representation of an HTTP load balancing probe.
    /// </summary>
    public interface ILoadBalancerHttpProbe  :
        IBeta,
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerProbe
    {
        /// <summary>
        /// Gets the HTTP request path for the HTTP probe to call to check the health status.
        /// </summary>
        string RequestPath { get; }
    }
}