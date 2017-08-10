// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update
{
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of a load balancing rule update allowing to enable the floating IP functionality.
    /// </summary>
    public interface IWithFloatingIP  :
        Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.Update.IWithFloatingIP<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule update allowing to modify the backend port.
    /// </summary>
    public interface IWithBackendPort  :
        Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule update allowing to modify the frontend reference.
    /// </summary>
    public interface IWithFrontend  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontend.Update.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule update allowing to modify the load distribution.
    /// </summary>
    public interface IWithLoadDistribution 
    {
        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">A supported load distribution mode.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate WithLoadDistribution(LoadDistribution loadDistribution);
    }

    /// <summary>
    /// The stage of a load balancing rule update allowing to modify the transport protocol the rule applies to.
    /// </summary>
    public interface IWithProtocol  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate,Microsoft.Azure.Management.Network.Fluent.Models.TransportProtocol>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule update allowing to specify the probe to associate with the rule.
    /// </summary>
    public interface IWithProbe 
    {
        /// <summary>
        /// Associates the specified existing HTTP or TCP probe of this load balancer with the load balancing rule.
        /// </summary>
        /// <param name="name">The name of an existing HTTP or TCP probe.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate WithProbe(string name);

        /// <summary>
        /// Removes any association with a probe and falls back to Azure's default probing mechanism.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate WithoutProbe();
    }

    /// <summary>
    /// The stage of a load balancing rule update allowing to modify the frontend port.
    /// </summary>
    public interface IWithFrontendPort  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.Update.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate>
    {
    }

    /// <summary>
    /// The entirety of a load balancing rule update as part of a load balancer update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IWithFrontendPort,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IWithFrontend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IWithProtocol,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IWithBackendPort,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IWithFloatingIP,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IWithIdleTimeoutInMinutes,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IWithLoadDistribution,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IWithProbe
    {
    }

    /// <summary>
    /// The stage of a load balancing rule update allowing to modify the connection timeout for idle connections.
    /// </summary>
    public interface IWithIdleTimeoutInMinutes 
    {
        /// <summary>
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">The desired number of minutes.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate WithIdleTimeoutInMinutes(int minutes);
    }
}