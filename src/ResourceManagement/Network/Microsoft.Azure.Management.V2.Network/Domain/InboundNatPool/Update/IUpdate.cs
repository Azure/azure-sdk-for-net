// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network.InboundNatPool.Update
{

    using Microsoft.Azure.Management.V2.Network.HasBackendPort.Update;
    using Microsoft.Azure.Management.V2.Network.HasFrontend.Update;
    using Microsoft.Azure.Management.V2.Network.HasProtocol.Update;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions;
    /// <summary>
    /// The stage of an inbound NAT pool update allowing to specify the backend port.
    /// </summary>
    public interface IWithBackendPort  :
        Microsoft.Azure.Management.V2.Network.HasBackendPort.Update.IWithBackendPort<Microsoft.Azure.Management.V2.Network.InboundNatPool.Update.IUpdate>
    {
    }
    /// <summary>
    /// The stage of an inbound NAT pool update allowing to specify the frontend for the inbound NAT rules in the pool to apply to.
    /// </summary>
    public interface IWithFrontend  :
        Microsoft.Azure.Management.V2.Network.HasFrontend.Update.IWithFrontend<Microsoft.Azure.Management.V2.Network.InboundNatPool.Update.IUpdate>
    {
    }
    /// <summary>
    /// The stage of an inbound NAT pool update allowing to specify the transport protocol for the pool to apply to.
    /// </summary>
    public interface IWithProtocol  :
        Microsoft.Azure.Management.V2.Network.HasProtocol.Update.IWithProtocol<Microsoft.Azure.Management.V2.Network.InboundNatPool.Update.IUpdate,string>
    {
    }
    /// <summary>
    /// The entirety of an inbound NAT pool update as part of a load balancer update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.V2.Network.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.V2.Network.InboundNatPool.Update.IWithProtocol,
        Microsoft.Azure.Management.V2.Network.InboundNatPool.Update.IWithFrontend,
        Microsoft.Azure.Management.V2.Network.InboundNatPool.Update.IWithBackendPort,
        IWithFrontendPortRange
    {
    }
    /// <summary>
    /// The stage of an inbound NAT pool update allowing to specify the frontend port range.
    /// </summary>
    public interface IWithFrontendPortRange 
    {
        /// <summary>
        /// Specifies the frontend port range.
        /// </summary>
        /// <param name="from">from the starting port number, between 1 and 65534</param>
        /// <param name="to">to the ending port number, greater than the starting port number and no more than 65534</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Network.InboundNatPool.Update.IUpdate WithFrontendPortRange (int from, int to);

    }
}