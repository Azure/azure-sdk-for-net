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
        LoadBalancerInboundNatPool.Update.IUpdate LoadBalancerInboundNatPool.Update.IWithFrontendPortRange.WithFrontendPortRange(int from, int to)
        {
            return this.WithFrontendPortRange(from, to) as LoadBalancerInboundNatPool.Update.IUpdate;
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
        LoadBalancerInboundNatPool.Update.IUpdate HasFrontend.Update.IWithFrontend<LoadBalancerInboundNatPool.Update.IUpdate>.WithFrontend(string frontendName)
        {
            return this.WithFrontend(frontendName) as LoadBalancerInboundNatPool.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">An existing frontend name.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontend<LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFrontend(string frontendName)
        {
            return this.WithFrontend(frontendName) as LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">An existing frontend name on this load balancer.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool> HasFrontend.Definition.IWithFrontend<LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.WithFrontend(string frontendName)
        {
            return this.WithFrontend(frontendName) as LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies the backend port.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerInboundNatPool.Update.IUpdate HasBackendPort.Update.IWithBackendPort<LoadBalancerInboundNatPool.Update.IUpdate>.WithBackendPort(int port)
        {
            return this.WithBackendPort(port) as LoadBalancerInboundNatPool.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the backend port.
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasBackendPort.UpdateDefinition.IWithBackendPort<LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithBackendPort(int port)
        {
            return this.WithBackendPort(port) as LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the backend port.
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatPool> HasBackendPort.Definition.IWithBackendPort<LoadBalancerInboundNatPool.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.WithBackendPort(int port)
        {
            return this.WithBackendPort(port) as LoadBalancerInboundNatPool.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specified the frontend port range.
        /// </summary>
        /// <param name="from">The starting port number, between 1 and 65534.</param>
        /// <param name="to">The ending port number, greater than the starting port number and no more than 65534.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerInboundNatPool.UpdateDefinition.IWithFrontendPortRange<LoadBalancer.Update.IUpdate>.WithFrontendPortRange(int from, int to)
        {
            return this.WithFrontendPortRange(from, to) as LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend port range.
        /// </summary>
        /// <param name="from">The starting port number, between 1 and 65534.</param>
        /// <param name="to">The ending port number, greater than the starting port number and no more than 65534.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatPool.Definition.IWithBackendPort<LoadBalancer.Definition.IWithCreateAndInboundNatPool> LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<LoadBalancer.Definition.IWithCreateAndInboundNatPool>.WithFrontendPortRange(int from, int to)
        {
            return this.WithFrontendPortRange(from, to) as LoadBalancerInboundNatPool.Definition.IWithBackendPort<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }
    }
}