// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition;

    /// <summary>
    /// The first stage of the load balancing rule definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithProtocol<ReturnT>
    {
    }

    /// <summary>
    /// The entirety of a load balancing rule definition as part of a load balancer update.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IBlank<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithProtocol<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontendPort<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontend<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackend<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackendPort<ReturnT>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to select a set of virtual machines to load balance
    /// the network traffic among.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithVirtualMachine<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithVirtualMachineBeta<ReturnT>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the backend port to send the load-balanced traffic to.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithBackendPort<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<ReturnT>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the connection timeout for idle connections.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithIdleTimeoutInMinutes<ReturnT> 
    {
        /// <summary>
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">The desired number of minutes.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<ReturnT> WithIdleTimeoutInMinutes(int minutes);
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the load distribution.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithLoadDistribution<ReturnT> 
    {
        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">A supported load distribution mode.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<ReturnT> WithLoadDistribution(LoadDistribution loadDistribution);
    }

    /// <summary>
    /// The final stage of the load balancing rule definition.
    /// At this stage, any remaining optional settings can be specified, or the load balancing rule definition
    /// can be attached to the parent load balancer definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ReturnT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFloatingIP<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithIdleTimeoutInMinutes<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithLoadDistribution<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithProbe<ReturnT>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the backend to associate the rule with.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithBackend<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithVirtualMachine<ReturnT>
    {
        /// <summary>
        /// Specifies a backend on this load balancer to send network traffic to.
        /// If a backend with the specified name does not yet exist, it will be created automatically.
        /// </summary>
        /// <param name="backendName">The name of an existing backend.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackendPort<ReturnT> ToBackend(string backendName);
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the frontend port to load balance.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFrontendPort<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the probe to associate with the rule.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithProbe<ReturnT> 
    {
        /// <summary>
        /// Associates the specified existing HTTP or TCP probe of this load balancer with the load balancing rule.
        /// </summary>
        /// <param name="name">The name of an existing HTTP or TCP probe.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<ReturnT> WithProbe(string name);
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the frontend to associate with the rule.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFrontend<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to enable the floating IP functionality.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFloatingIP<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.UpdateDefinition.IWithFloatingIP<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the transport protocol to apply the rule to.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithProtocol<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,Microsoft.Azure.Management.Network.Fluent.Models.TransportProtocol>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to select a set of virtual machines to load balance
    /// the network traffic among.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithVirtualMachineBeta<ReturnT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to a new back end address pool to be associated with this load balancing rule.
        /// This will add references to the primary IP configurations of the primary network interfaces of
        /// the provided set of virtual machines.
        /// If the virtual machines are not in the same availability set, they will not be associated with the backend.
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">Existing virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackendPort<ReturnT> ToExistingVirtualMachines(params IHasNetworkInterfaces[] vms);

        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to a new back end address pool to be associated with this load balancing rule.
        /// This will add references to the primary IP configurations of the primary network interfaces of
        /// the provided set of virtual machines.
        /// If the virtual machines are not in the same availability set, they will not be associated with the backend.
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">Existing virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackendPort<ReturnT> ToExistingVirtualMachines(ICollection<Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces> vms);
    }
}