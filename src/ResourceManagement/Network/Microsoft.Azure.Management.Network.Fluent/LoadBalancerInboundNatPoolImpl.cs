// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Resource.Fluent;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for LoadBalancerInboundNatPool.
    /// </summary>
    public partial class LoadBalancerInboundNatPoolImpl  :
        ChildResource<InboundNatPoolInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancerInboundNatPool,
        ILoadBalancerInboundNatPool.Definition.IDefinition<LoadBalancer.Definition.IWithCreateAndInboundNatPool>,
        ILoadBalancerInboundNatPool.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        ILoadBalancerInboundNatPool.Update.IUpdate
    {
        internal LoadBalancerInboundNatPoolImpl (InboundNatPoolInner inner, LoadBalancerImpl parent) 
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

        internal ILoadBalancerFrontend Frontend ()
        {
            ILoadBalancerFrontend frontend;
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

        internal LoadBalancerInboundNatPoolImpl WithBackendPort (int port)
        {
            Inner.BackendPort = port;
            return this;
        }

        internal LoadBalancerInboundNatPoolImpl WithProtocol (string protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }

        internal LoadBalancerInboundNatPoolImpl WithFrontend (string frontendName)
        {
            SubResource frontendRef = new SubResource(Parent.FutureResourceId() + "/frontendIPConfigurations/" + frontendName);
            Inner.FrontendIPConfiguration = frontendRef;
            return this;
        }

        internal LoadBalancerInboundNatPoolImpl WithFrontendPortRange (int from, int to)
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