// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The stage of a load balancer backend definition allowing to select a set of virtual machines to load balance
    /// the network traffic among.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithVirtualMachine<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition.IWithVirtualMachineBeta<ReturnT>
    {
    }

    /// <summary>
    /// The entirety of a load balancer backend definition as part of a load balancer update.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of a load balancer backend definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent load balancer definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition.IWithVirtualMachine<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a load balancer backend definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of a load balancer backend definition allowing to select a set of virtual machines to load balance
    /// the network traffic among.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithVirtualMachineBeta<ReturnT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition.IWithAttach<ReturnT> WithExistingVirtualMachines(params IHasNetworkInterfaces[] vms);

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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition.IWithAttach<ReturnT> WithExistingVirtualMachines(ICollection<Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces> vms);
    }
}