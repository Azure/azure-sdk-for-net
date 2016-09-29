// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Models;
    /// <summary>
    /// An immutable client-side representation of an load balancer's backend address pool.
    /// </summary>
    public interface IBackend  :
        IWrapper<Microsoft.Azure.Management.Network.Models.BackendAddressPoolInner>,
        IChildResource<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>,
        IHasLoadBalancingRules
    {
        /// <returns>a map of names of the IP configurations of network interfaces assigned to this backend,</returns>
        /// <returns>indexed by their NIC's resource id</returns>
        IDictionary<string,string> BackendNicIpConfigurationNames { get; }

        /// <returns>a list of the resource IDs of the virtual machines associated with this backend</returns>
        ISet<string> GetVirtualMachineIds ();

    }
}