// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Definition;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Update;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Network.HasFrontend.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasFrontend.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasProtocol.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasProtocol.Update;
    using Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update;
    public partial class InboundNatPoolImpl 
    {
        /// <returns>the protocol</returns>
        string Microsoft.Azure.Management.Fluent.Network.IHasProtocol<string>.Protocol
        {
            get
            { 
            return this.Protocol() as string;
            }
        }
        /// <returns>the associated frontend</returns>
        Microsoft.Azure.Management.Fluent.Network.IFrontend Microsoft.Azure.Management.Fluent.Network.IHasFrontend.Frontend
        {
            get
            { 
            return this.Frontend() as Microsoft.Azure.Management.Fluent.Network.IFrontend;
            }
        }
        /// <returns>the backend port number the network traffic is sent to</returns>
        int Microsoft.Azure.Management.Fluent.Network.IHasBackendPort.BackendPort
        {
            get
            { 
            return this.BackendPort();
            }
        }
        /// <summary>
        /// Specifies the frontend port range.
        /// </summary>
        /// <param name="from">from the starting port number, between 1 and 65534</param>
        /// <param name="to">to the ending port number, greater than the starting port number and no more than 65534</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IWithFrontendPortRange.WithFrontendPortRange(int from, int to) { 
            return this.WithFrontendPortRange( from,  to) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool> Microsoft.Azure.Management.Fluent.Network.HasProtocol.Definition.IWithProtocol<Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool>,string>.WithProtocol(string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasProtocol.Update.IWithProtocol<Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IUpdate,string>.WithProtocol(string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasProtocol.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>,string>.WithProtocol(string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name on this load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IWithFrontendPortRange<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool> Microsoft.Azure.Management.Fluent.Network.HasFrontend.Definition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IWithFrontendPortRange<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.WithFrontend(string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IWithFrontendPortRange<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies the frontend.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name from this load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasFrontend.Update.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IUpdate>.WithFrontend(string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name on this load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasFrontend.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>.WithFrontend(string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <returns>the starting frontend port number</returns>
        int Microsoft.Azure.Management.Fluent.Network.IInboundNatPool.FrontendPortRangeStart
        {
            get
            { 
            return this.FrontendPortRangeStart();
            }
        }
        /// <returns>the ending frontend port number</returns>
        int Microsoft.Azure.Management.Fluent.Network.IInboundNatPool.FrontendPortRangeEnd
        {
            get
            { 
            return this.FrontendPortRangeEnd();
            }
        }
        /// <summary>
        /// Specifies the backend port.
        /// <p>
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool> Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Definition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool>>.WithBackendPort(int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specifies the backend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Update.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IUpdate>.WithBackendPort(int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the backend port.
        /// <p>
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasBackendPort.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>.WithBackendPort(int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend port range.
        /// </summary>
        /// <param name="from">from the starting port number, between 1 and 65534</param>
        /// <param name="to">to the ending port number, greater than the starting port number and no more than 65534</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool> Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IWithFrontendPortRange<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool>.WithFrontendPortRange(int from, int to) { 
            return this.WithFrontendPortRange( from,  to) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Specified the frontend port range.
        /// </summary>
        /// <param name="from">from the starting port number, between 1 and 65534</param>
        /// <param name="to">to the ending port number, greater than the starting port number and no more than 65534</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IWithFrontendPortRange<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithFrontendPortRange(int from, int to) { 
            return this.WithFrontendPortRange( from,  to) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <returns>the name of this child object</returns>
        string Microsoft.Azure.Management.Fluent.Resource.Core.IChildResource<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>.Name
        {
            get
            { 
            return this.Name() as string;
            }
        }
    }
}