// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{
    using Management.Network.Models;
    using Resource.Core;
    using Resource.Core.ChildResourceActions;
    using Rest.Azure;

    /// <summary>
    /// Implementation for InboundNatRule.
    /// </summary>
    public partial class InboundNatPoolImpl  :
        ChildResource<InboundNatPoolInner, LoadBalancerImpl, ILoadBalancer>,
        IInboundNatPool,
        InboundNatPool.Definition.IDefinition<LoadBalancer.Definition.IWithCreateAndInboundNatPool>,
        InboundNatPool.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        InboundNatPool.Update.IUpdate
    {
        internal InboundNatPoolImpl (InboundNatPoolInner inner, LoadBalancerImpl parent) 
            : base(inner.Name, inner, parent)
        {
        }

        override public string Name()
        {
            return Inner.Name;
        }
        public string Protocol
        {
            get
            {
                return Inner.Protocol;
            }
        }
        public int BackendPort
        {
            get
            {
                return Inner.BackendPort;
            }
        }

        public IFrontend Frontend ()
        {
            IFrontend frontend;
            string name = ResourceUtils.NameFromResourceId(Inner.FrontendIPConfiguration.Id);
            Parent.Frontends().TryGetValue(name, out frontend);
            return frontend;
        }

        public int FrontendPortRangeStart
        {
            get
            {
                return Inner.FrontendPortRangeStart;
            }
        }

        public int FrontendPortRangeEnd
        {
            get
            {
                return Inner.FrontendPortRangeEnd;
            }
        }

        public InboundNatPoolImpl WithBackendPort (int port)
        {
            Inner.BackendPort = port;
            return this;
        }

        public InboundNatPoolImpl WithProtocol (string protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }

        public InboundNatPoolImpl WithFrontend (string frontendName)
        {
            SubResource frontendRef = new SubResource(Parent.FutureResourceId + "/frontendIPConfigurations/" + frontendName);
            Inner.FrontendIPConfiguration = frontendRef;
            return this;
        }

        public InboundNatPoolImpl WithFrontendPortRange (int from, int to)
        {
            Inner.FrontendPortRangeStart = from;
            Inner.FrontendPortRangeEnd = to;
            return this;
        }

        public LoadBalancerImpl Attach ()
        {
            return Parent.WithInboundNatPool(this);
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}