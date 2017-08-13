// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;

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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<ReturnT> WithLoadDistribution(LoadDistribution loadDistribution);
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the backend to associate the rule with.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithBackend<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithVirtualMachine<ReturnT>
    {
        /// <summary>
        /// Specifies a backend on this load balancer to send network traffic to.
        /// If a backend with the specified name does not yet exist on this load balancer, it will be created automatically.
        /// </summary>
        /// <param name="backendName">The name of a backend.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackendPort<ReturnT> ToBackend(string backendName);
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the frontend port to load balance.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFrontendPort<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.Definition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackend<ReturnT>>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to select a set of virtual machines to load balance
    /// the network traffic among.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithVirtualMachine<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithVirtualMachineBeta<ReturnT>
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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<ReturnT> WithProbe(string name);
    }

    /// <summary>
    /// The final stage of the load balancing rule definition.
    /// At this stage, any remaining optional settings can be specified, or the load balancing rule definition
    /// can be attached to the parent load balancer definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ReturnT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFloatingIP<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithIdleTimeoutInMinutes<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithLoadDistribution<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithProbe<ReturnT>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to enable the floating IP functionality.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFloatingIP<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.Definition.IWithFloatingIP<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<ReturnT>>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the backend port to send the load-balanced traffic to.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithBackendPort<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<ReturnT>>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<ReturnT>
    {
    }

    /// <summary>
    /// The entirety of a load balancing rule definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IBlank<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithProtocol<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontendPort<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontend<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackend<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackendPort<ReturnT>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the frontend to associate with the rule.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFrontend<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontendPort<ReturnT>>
    {
    }

    /// <summary>
    /// The first stage of the load balancing rule definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithProtocol<ReturnT>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the transport protocol to apply the rule to.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithProtocol<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontend<ReturnT>,Microsoft.Azure.Management.Network.Fluent.Models.TransportProtocol>
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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<ReturnT> WithIdleTimeoutInMinutes(int minutes);
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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackendPort<ReturnT> ToExistingVirtualMachines(params IHasNetworkInterfaces[] vms);

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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackendPort<ReturnT> ToExistingVirtualMachines(ICollection<Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces> vms);
    }
}