// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    /// <summary>
    /// A client-side representation of a public frontend of an Internet-facing load balancer.
    /// </summary>
    public interface ILoadBalancerPublicFrontend  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend,
        Microsoft.Azure.Management.Network.Fluent.IHasPublicIPAddress
    {
    }
}