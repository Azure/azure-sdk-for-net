// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent
{
    /// <summary>
    /// An immutable client-side representation of a TCP load balancing probe.
    /// </summary>
    public interface ILoadBalancerTcpProbe  :
        IBeta,
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerProbe
    {
    }
}