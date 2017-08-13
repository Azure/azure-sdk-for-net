// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    internal partial class LoadBalancerInboundNatPoolImpl 
    {
        /// <summary>
        /// Gets the protocol.
        /// </summary>
        Models.TransportProtocol Microsoft.Azure.Management.Network.Fluent.IHasProtocol<Models.TransportProtocol>.Protocol
        {
            get
            {
                return this.Protocol() as Models.TransportProtocol;
            }
        }

        /// <summary>
        /// Gets the associated frontend.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend Microsoft.Azure.Management.Network.Fluent.IHasFrontend.Frontend
        {
            get
            {
                return this.Frontend() as Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend;
            }
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
        /// Gets the starting frontend port number.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool.FrontendPortRangeStart
        {
            get
            {
                return this.FrontendPortRangeStart();
            }
        }

        /// <summary>
        /// Gets the ending frontend port number.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool.FrontendPortRangeEnd
        {
            get
            {
                return this.FrontendPortRangeEnd();
            }
        }

        /// <summary>
        /// Gets the backend port number the network traffic is sent to.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IHasBackendPort.BackendPort
        {
            get
            {
                return this.BackendPort();
            }
        }

        /// <summary>
        /// Specifies the frontend port range.
        /// </summary>
        /// <param name="from">The starting port number, between 1 and 65534.</param>
        /// <param name="to">The ending port number, greater than the starting port number and no more than 65534.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Update.IUpdate LoadBalancerInboundNatPool.Update.IWithFrontendPortRange.FromFrontendPortRange(int from, int to)
        {
            return this.FromFrontendPortRange(from, to) as LoadBalancerInboundNatPool.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<LoadBalancer.Update.IUpdate>.Attach()
        {
            return this.Attach() as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Definition.IWithCreateAndInboundNatPool Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<LoadBalancer.Definition.IWithCreateAndInboundNatPool>.Attach()
        {
            return this.Attach() as LoadBalancer.Definition.IWithCreateAndInboundNatPool;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerInboundNatPool.Update.IUpdate HasProtocol.Update.IWithProtocol<LoadBalancerInboundNatPool.Update.IUpdate,Models.TransportProtocol>.WithProtocol(TransportProtocol protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancerInboundNatPool.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasProtocol.UpdateDefinition.IWithProtocol<LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>,Models.TransportProtocol>.WithProtocol(TransportProtocol protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithFrontend<LoadBalancer.Definition.IWithCreateAndInboundNatPool> HasProtocol.Definition.IWithProtocol<LoadBalancerInboundNatPool.Definition.IWithFrontend<LoadBalancer.Definition.IWithCreateAndInboundNatPool>,Models.TransportProtocol>.WithProtocol(TransportProtocol protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancerInboundNatPool.Definition.IWithFrontend<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies the frontend.
        /// </summary>
        /// <param name="frontendName">An existing frontend name from this load balancer.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerInboundNatPool.Update.IUpdate HasFrontend.Update.IWithFrontendBeta<LoadBalancerInboundNatPool.Update.IUpdate>.FromFrontend(string frontendName)
        {
            return this.FromFrontend(frontendName) as LoadBalancerInboundNatPool.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">An existing frontend name.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontendBeta<LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.FromFrontend(string frontendName)
        {
            return this.FromFrontend(frontendName) as LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="networkResourceId">The resource ID of an existing network.</param>
        /// <param name="subnetName">The name of an existing subnet within the specified network.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontendBeta<LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.FromExistingSubnet(string networkResourceId, string subnetName)
        {
            return this.FromExistingSubnet(networkResourceId, subnetName) as LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="network">An existing network.</param>
        /// <param name="subnetName">The name of an existing subnet within the specified network.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontendBeta<LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.FromExistingSubnet(INetwork network, string subnetName)
        {
            return this.FromExistingSubnet(network, subnetName) as LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontendBeta<LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.FromExistingSubnet(ISubnet subnet)
        {
            return this.FromExistingSubnet(subnet) as LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an existing public IP address to receive network traffic from.
        /// If this load balancer already has a frontend referencing this public IP address, that is the frontend that will be used.
        /// Else, an automatically named new public frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontendBeta<LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.FromExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.FromExistingPublicIPAddress(publicIPAddress) as LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an existing public IP address to receive network traffic from.
        /// If this load balancer already has a frontend referencing this public IP address, that is the frontend that will be used.
        /// Else, an automatically named new public frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontendBeta<LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.FromExistingPublicIPAddress(string resourceId)
        {
            return this.FromExistingPublicIPAddress(resourceId) as LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend to receive network traffic from.
        /// </summary>
        /// <param name="frontendName">An existing frontend name on this load balancer.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool> HasFrontend.Definition.IWithFrontendBeta<LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.FromFrontend(string frontendName)
        {
            return this.FromFrontend(frontendName) as LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="networkResourceId">The resource ID of an existing network.</param>
        /// <param name="subnetName">The name of an existing subnet within the specified network.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool> HasFrontend.Definition.IWithFrontendBeta<LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.FromExistingSubnet(string networkResourceId, string subnetName)
        {
            return this.FromExistingSubnet(networkResourceId, subnetName) as LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="network">An existing network.</param>
        /// <param name="subnetName">The name of an existing subnet within the specified network.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool> HasFrontend.Definition.IWithFrontendBeta<LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.FromExistingSubnet(INetwork network, string subnetName)
        {
            return this.FromExistingSubnet(network, subnetName) as LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool> HasFrontend.Definition.IWithFrontendBeta<LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.FromExistingSubnet(ISubnet subnet)
        {
            return this.FromExistingSubnet(subnet) as LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies that network traffic should be received on a new public IP address that is to be created along with the load balancer
        /// in the same region and resource group but under the provided leaf DNS label, assuming it is available.
        /// A new automatically-named public frontend will be implicitly created on this load balancer for each such new public IP address, so make
        /// sure to use a unique DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">A unique leaf DNS label to create the public IP address under.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool> HasFrontend.Definition.IWithFrontendBeta<LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.FromNewPublicIPAddress(string leafDnsLabel)
        {
            return this.FromNewPublicIPAddress(leafDnsLabel) as LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies that network traffic should be received on a new public IP address that is to be created along with the load balancer
        /// based on the provided definition.
        /// A new automatically-named public frontend will be implicitly created on this load balancer for each such new public IP address.
        /// </summary>
        /// <param name="pipDefinition">A definition for the new public IP.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool> HasFrontend.Definition.IWithFrontendBeta<LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.FromNewPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> pipDefinition)
        {
            return this.FromNewPublicIPAddress(pipDefinition) as LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies that network traffic should be received on a new public IP address that is to be automatically created woth default settings
        /// along with the load balancer.
        /// A new automatically-named public frontend will be implicitly created on this load balancer for each such new public IP address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool> HasFrontend.Definition.IWithFrontendBeta<LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.FromNewPublicIPAddress()
        {
            return this.FromNewPublicIPAddress() as LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies an existing public IP address to receive network traffic from.
        /// If this load balancer already has a frontend referencing this public IP address, that is the frontend that will be used.
        /// Else, an automatically named new public frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool> HasFrontend.Definition.IWithFrontendBeta<LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.FromExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.FromExistingPublicIPAddress(publicIPAddress) as LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies an existing public IP address to receive network traffic from.
        /// If this load balancer already has a frontend referencing this public IP address, that is the frontend that will be used.
        /// Else, an automatically named new public frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool> HasFrontend.Definition.IWithFrontendBeta<LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.FromExistingPublicIPAddress(string resourceId)
        {
            return this.FromExistingPublicIPAddress(resourceId) as LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies a backend port to send network traffic to.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerInboundNatPool.Update.IUpdate HasBackendPort.Update.IWithBackendPort<LoadBalancerInboundNatPool.Update.IUpdate>.ToBackendPort(int port)
        {
            return this.ToBackendPort(port) as LoadBalancerInboundNatPool.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a backend port to send network traffic to.
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasBackendPort.UpdateDefinition.IWithBackendPort<LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.ToBackendPort(int port)
        {
            return this.ToBackendPort(port) as LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies a backend port to send network traffic to.
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatPool> HasBackendPort.Definition.IWithBackendPort<LoadBalancerInboundNatPool.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.ToBackendPort(int port)
        {
            return this.ToBackendPort(port) as LoadBalancerInboundNatPool.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specified the frontend port range.
        /// </summary>
        /// <param name="from">The starting port number, between 1 and 65534.</param>
        /// <param name="to">The ending port number, greater than the starting port number and no more than 65534.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerInboundNatPool.UpdateDefinition.IWithFrontendPortRange<LoadBalancer.Update.IUpdate>.FromFrontendPortRange(int from, int to)
        {
            return this.FromFrontendPortRange(from, to) as LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend port range to receive network traffic from.
        /// </summary>
        /// <param name="from">The starting port number, between 1 and 65534.</param>
        /// <param name="to">The ending port number, greater than the starting port number and no more than 65534.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithBackendPort<LoadBalancer.Definition.IWithCreateAndInboundNatPool> LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>.FromFrontendPortRange(int from, int to)
        {
            return this.FromFrontendPortRange(from, to) as LoadBalancerInboundNatPool.Definition.IWithBackendPort<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }
    }
}