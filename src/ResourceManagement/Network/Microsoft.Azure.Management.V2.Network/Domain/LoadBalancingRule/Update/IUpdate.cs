// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update
{

    using Microsoft.Azure.Management.V2.Network.HasFloatingIp.Update;
    using Microsoft.Azure.Management.V2.Network.HasFrontend.Update;
    using Microsoft.Azure.Management.V2.Network.HasProtocol.Update;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions;
    using Microsoft.Azure.Management.V2.Network.HasBackendPort.Update;
    /// <summary>
    /// The stage of a load balancing rule update allowing to enable the floating IP functionality.
    /// </summary>
    public interface IWithFloatingIp  :
        Microsoft.Azure.Management.V2.Network.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update.IUpdate>
    {
    }
    /// <summary>
    /// The stage of a load balancing rule update allowing to modify the frontend port.
    /// </summary>
    public interface IWithFrontendPort 
    {
        /// <summary>
        /// Specifies the frontend port to load balance.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update.IUpdate WithFrontendPort (int port);

    }
    /// <summary>
    /// The stage of a load balancing rule update allowing to modify the frontend reference.
    /// </summary>
    public interface IWithFrontend  :
        Microsoft.Azure.Management.V2.Network.HasFrontend.Update.IWithFrontend<Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update.IUpdate>
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
        /// <param name="minutes">minutes the desired number of minutes</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update.IUpdate WithIdleTimeoutInMinutes (int minutes);

    }
    /// <summary>
    /// The stage of a load balancing rule update allowing to modify the transport protocol the rule applies to.
    /// </summary>
    public interface IWithProtocol  :
        Microsoft.Azure.Management.V2.Network.HasProtocol.Update.IWithProtocol<Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update.IUpdate,string>
    {
    }
    /// <summary>
    /// The entirety of a load balancing rule update as part of a load balancer update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.V2.Network.LoadBalancer.Update.IUpdate>,
        IWithFrontendPort,
        Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update.IWithFrontend,
        Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update.IWithProtocol,
        Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update.IWithBackendPort,
        Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update.IWithFloatingIp,
        IWithIdleTimeoutInMinutes,
        IWithLoadDistribution
    {
    }
    /// <summary>
    /// The stage of a load balancing rule update allowing to modify the backend port.
    /// </summary>
    public interface IWithBackendPort  :
        Microsoft.Azure.Management.V2.Network.HasBackendPort.Update.IWithBackendPort<Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update.IUpdate>
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
        /// <param name="loadDistribution">loadDistribution a supported load distribution mode</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update.IUpdate WithLoadDistribution (string loadDistribution);

    }
}