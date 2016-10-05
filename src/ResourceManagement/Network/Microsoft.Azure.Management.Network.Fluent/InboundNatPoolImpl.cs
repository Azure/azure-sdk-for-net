// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Management.Network.Fluent.Models;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.ChildResourceActions;
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
            : base(inner, parent)
        {
        }

        public override string Name()
        {
            return Inner.Name;
        }

        internal string Protocol()
        {
            return Inner.Protocol;
        }

        internal int BackendPort()
        {
            return Inner.BackendPort;
        }

        internal IFrontend Frontend ()
        {
            IFrontend frontend;
            string name = ResourceUtils.NameFromResourceId(Inner.FrontendIPConfiguration.Id);
            Parent.Frontends().TryGetValue(name, out frontend);
            return frontend;
        }

        internal int FrontendPortRangeStart()
        {
            return Inner.FrontendPortRangeStart;
        }

        internal int FrontendPortRangeEnd()
        {
            return Inner.FrontendPortRangeEnd;
        }

        internal InboundNatPoolImpl WithBackendPort (int port)
        {
            Inner.BackendPort = port;
            return this;
        }

        internal InboundNatPoolImpl WithProtocol (string protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }

        internal InboundNatPoolImpl WithFrontend (string frontendName)
        {
            SubResource frontendRef = new SubResource(Parent.FutureResourceId() + "/frontendIPConfigurations/" + frontendName);
            Inner.FrontendIPConfiguration = frontendRef;
            return this;
        }

        internal InboundNatPoolImpl WithFrontendPortRange (int from, int to)
        {
            Inner.FrontendPortRangeStart = from;
            Inner.FrontendPortRangeEnd = to;
            return this;
        }

        internal LoadBalancerImpl Attach ()
        {
            return Parent.WithInboundNatPool(this);
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}