// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a load balancer backend address pool.
    /// </summary>
    public interface ILoadBalancerBackend  :
        IWrapper<Models.BackendAddressPoolInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        IHasLoadBalancingRules,
        IHasBackendNics
    {
        /// <return>A list of the resource IDs of the virtual machines associated with this backend.</return>
        System.Collections.Generic.ISet<string> GetVirtualMachineIds();
    }
}