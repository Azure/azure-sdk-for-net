// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using LoadBalancer.Definition;
    using LoadBalancer.Update;
    using LoadBalancerBackend.Definition;
    using LoadBalancerBackend.Update;
    using LoadBalancerBackend.UpdateDefinition;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;

    internal partial class LoadBalancerBackendImpl 
    {
        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<LoadBalancer.Update.IUpdate>.Attach()
        {
            return this.Attach() as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets a map of names of the IP configurations of network interfaces assigned to this backend,
        /// indexed by their NIC's resource id.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.Network.Fluent.IHasBackendNics.BackendNicIpConfigurationNames
        {
            get
            {
                return this.BackendNicIpConfigurationNames() as System.Collections.Generic.IReadOnlyDictionary<string,string>;
            }
        }

        /// <summary>
        /// Gets the associated load balancing rules from this load balancer, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.IHasLoadBalancingRules.LoadBalancingRules
        {
            get
            {
                return this.LoadBalancingRules() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule>;
            }
        }

        /// <return>A list of the resource IDs of the virtual machines associated with this backend.</return>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend.GetVirtualMachineIds()
        {
            return this.GetVirtualMachineIds() as System.Collections.Generic.ISet<string>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Definition.IWithBackendOrProbe Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<LoadBalancer.Definition.IWithBackendOrProbe>.Attach()
        {
            return this.Attach() as LoadBalancer.Definition.IWithBackendOrProbe;
        }
    }
}