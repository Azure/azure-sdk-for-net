// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation of a load balancer backend address pool.
    /// </summary>
    public interface ILoadBalancerBackend  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.BackendAddressPoolInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        Microsoft.Azure.Management.Network.Fluent.IHasLoadBalancingRules,
        Microsoft.Azure.Management.Network.Fluent.IHasBackendNics
    {
        /// <return>A list of the resource IDs of the virtual machines associated with this backend.</return>
        System.Collections.Generic.ISet<string> GetVirtualMachineIds();
    }
}