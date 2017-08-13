// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;

    internal partial class LoadBalancerBackendImpl 
    {
        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<LoadBalancer.Update.IUpdate>.Attach()
        {
            return this.Attach() as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
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
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.Network.Fluent.IHasBackendNics.BackendNicIPConfigurationNames
        {
            get
            {
                return this.BackendNicIPConfigurationNames() as System.Collections.Generic.IReadOnlyDictionary<string,string>;
            }
        }

        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to this backend address pool.
        /// This will add references to the primary IP configurations of the primary network interfaces of
        /// the provided set of virtual machines.
        /// If the virtual machines are not in the same availability set, they will not be associated with this back end.
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">Existing virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerBackend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> LoadBalancerBackend.Definition.IWithVirtualMachineBeta<LoadBalancer.Definition.IWithCreate>.WithExistingVirtualMachines(params IHasNetworkInterfaces[] vms)
        {
            return this.WithExistingVirtualMachines(vms) as LoadBalancerBackend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to this backend address pool.
        /// This will add references to the primary IP configurations of the primary network interfaces of
        /// the provided set of virtual machines.
        /// If the virtual machines are not in the same availability set, they will not be associated with this back end.
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">Existing virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerBackend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> LoadBalancerBackend.Definition.IWithVirtualMachineBeta<LoadBalancer.Definition.IWithCreate>.WithExistingVirtualMachines(ICollection<Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces> vms)
        {
            return this.WithExistingVirtualMachines(vms) as LoadBalancerBackend.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to this back end address pool.
        /// This will add references to the primary IP configurations of the primary network interfaces of
        /// the provided set of virtual machines.
        /// If the virtual machines are not in the same availability set, they will not be associated with this back end.
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">Existing virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerBackend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerBackend.UpdateDefinition.IWithVirtualMachineBeta<LoadBalancer.Update.IUpdate>.WithExistingVirtualMachines(params IHasNetworkInterfaces[] vms)
        {
            return this.WithExistingVirtualMachines(vms) as LoadBalancerBackend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to this backend address pool.
        /// This will add references to the primary IP configurations of the primary network interfaces of
        /// the provided set of virtual machines.
        /// If the virtual machines are not in the same availability set, they will not be associated with this back end.
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">Existing virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerBackend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerBackend.UpdateDefinition.IWithVirtualMachineBeta<LoadBalancer.Update.IUpdate>.WithExistingVirtualMachines(ICollection<Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces> vms)
        {
            return this.WithExistingVirtualMachines(vms) as LoadBalancerBackend.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
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
        LoadBalancer.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<LoadBalancer.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as LoadBalancer.Definition.IWithCreate;
        }
    }
}