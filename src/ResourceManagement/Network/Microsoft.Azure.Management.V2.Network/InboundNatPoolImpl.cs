// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.InboundNatPool.Definition;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.HasProtocol.Definition;
    using Microsoft.Azure.Management.V2.Network.HasFrontend.Definition;
    using Microsoft.Azure.Management.V2.Network.InboundNatPool.Update;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.V2.Network.HasFrontend.Update;
    using Microsoft.Azure.Management.V2.Network.HasBackendPort.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.V2.Network.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.InboundNatPool.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.HasBackendPort.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.V2.Network.HasProtocol.Update;
    using Microsoft.Azure.Management.V2.Network.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.HasFrontend.UpdateDefinition;
    using Resource.Core.ChildResourceActions;
    using System;

    /// <summary>
    /// Implementation for {@link InboundNatRule}.
    /// </summary>
    public partial class InboundNatPoolImpl  :
        ChildResource<Microsoft.Azure.Management.Network.Models.InboundNatPoolInner,Microsoft.Azure.Management.V2.Network.LoadBalancerImpl,Microsoft.Azure.Management.V2.Network.ILoadBalancer>,
        IInboundNatPool,
        IDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool>,
        IUpdateDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.V2.Network.InboundNatPool.Update.IUpdate
    {
        protected  InboundNatPoolImpl (InboundNatPoolInner inner, LoadBalancerImpl parent) : base(inner.Name, inner, parent)
        {

            //$ super(inner, parent);
            //$ }

        }

        override public string Name
        {
            get
            {
            //$ return this.inner().name();


                return null;
            }
        }
        public string Protocol
        {
            get
            {
            //$ return this.inner().protocol();


                return null;
            }
        }
        public int? BackendPort
        {
            get
            {
            //$ return this.inner().backendPort();


                return null;
            }
        }
        public IFrontend Frontend ()
        {

            //$ return this.parent().frontends().get(
            //$ ResourceUtils.nameFromResourceId(
            //$ this.inner().frontendIPConfiguration().id()));

            return null;
        }

        public int? FrontendPortRangeStart
        {
            get
            {
            //$ return this.inner().frontendPortRangeStart();


                return null;
            }
        }
        public int? FrontendPortRangeEnd
        {
            get
            {
            //$ return this.inner().frontendPortRangeEnd();


                return null;
            }
        }
        public InboundNatPoolImpl WithBackendPort (int port)
        {

            //$ this.inner().withBackendPort(port);
            //$ return this;

            return this;
        }

        public InboundNatPoolImpl WithProtocol (string protocol)
        {

            //$ this.inner().withProtocol(protocol);
            //$ return this;

            return this;
        }

        public InboundNatPoolImpl WithFrontend (string frontendName)
        {

            //$ SubResource frontendRef = new SubResource()
            //$ .withId(this.parent().futureResourceId() + "/frontendIPConfigurations/" + frontendName);
            //$ this.inner().withFrontendIPConfiguration(frontendRef);
            //$ return this;

            return this;
        }

        public InboundNatPoolImpl WithFrontendPortRange (int from, int to)
        {

            //$ this.inner().withFrontendPortRangeStart(from);
            //$ this.inner().withFrontendPortRangeEnd(to);
            //$ return this;

            return this;
        }

        public LoadBalancerImpl Attach ()
        {

            //$ return this.parent().withInboundNatPool(this);

            return null;
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            throw new NotImplementedException();
        }
    }
}