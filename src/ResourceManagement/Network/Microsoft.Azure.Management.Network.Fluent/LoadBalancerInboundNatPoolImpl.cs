// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2VySW5ib3VuZE5hdFBvb2xJbXBs
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Resource.Fluent;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for LoadBalancerInboundNatPool.
    /// </summary>
    internal partial class LoadBalancerInboundNatPoolImpl  :
        ChildResource<InboundNatPoolInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancerInboundNatPool,
        LoadBalancerInboundNatPool.Definition.IDefinition<LoadBalancer.Definition.IWithCreateAndInboundNatPool>,
        LoadBalancerInboundNatPool.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancerInboundNatPool.Update.IUpdate
    {
        internal LoadBalancerInboundNatPoolImpl (InboundNatPoolInner inner, LoadBalancerImpl parent) 
            : base(inner, parent)
        {
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:D684E7477889A9013C81FAD82F69C54F:BD249A015EF71106387B78281489583A
        internal string Protocol()
        {
            return Inner.Protocol;
        }

        ///GENMHASH:B7056D5E403DF443379DDF57BB0658A2:9C4AAC15022FA26F69A7DFD88E20FB97
        internal int BackendPort()
        {
            return Inner.BackendPort;
        }

        ///GENMHASH:B206A6556439FF2D98365C5283836AD5:7883B26044DD9E80AC6D8A9F847E6900
        internal ILoadBalancerFrontend Frontend ()
        {
            ILoadBalancerFrontend frontend;
            string name = ResourceUtils.NameFromResourceId(Inner.FrontendIPConfiguration.Id);
            Parent.Frontends().TryGetValue(name, out frontend);
            return frontend;
        }

        ///GENMHASH:2102448B6A6EA7F1973CA8DA21C276B3:639C34A4E22D4FA74D996D47ADE0413B
        internal int FrontendPortRangeStart()
        {
            return Inner.FrontendPortRangeStart;
        }

        ///GENMHASH:2878757D0F89ECB374D335D6532EDE05:E4BF9FB756C9A0682E70E8E172A29CD2
        internal int FrontendPortRangeEnd()
        {
            return Inner.FrontendPortRangeEnd;
        }

        ///GENMHASH:5FDFF29CFA414BCAD7FFD0841828BB7A:E66486C2053EF1D55C02E6EF2E4B2E42
        internal LoadBalancerInboundNatPoolImpl WithBackendPort (int port)
        {
            Inner.BackendPort = port;
            return this;
        }

        ///GENMHASH:475A4755B19EB893208FCC08E7664C5B:8E47A7551FAA8958BCB5314D0E665506
        internal LoadBalancerInboundNatPoolImpl WithProtocol (string protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }

        ///GENMHASH:2EC798C5560EA4F2234EFA1478E59C04:ED14BC5AA9F9F6F99EFCC8B58BEBAC1E
        internal LoadBalancerInboundNatPoolImpl WithFrontend (string frontendName)
        {
            SubResource frontendRef = new SubResource(Parent.FutureResourceId() + "/frontendIPConfigurations/" + frontendName);
            Inner.FrontendIPConfiguration = frontendRef;
            return this;
        }

        ///GENMHASH:403B7F42C07B9B8EADE72FC659A8AA2B:1E95E490A3C761C25CE742AF15819E05
        internal LoadBalancerInboundNatPoolImpl WithFrontendPortRange (int from, int to)
        {
            Inner.FrontendPortRangeStart = from;
            Inner.FrontendPortRangeEnd = to;
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:9F2023060E78B2CFF2E9C0B57FE36805
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
