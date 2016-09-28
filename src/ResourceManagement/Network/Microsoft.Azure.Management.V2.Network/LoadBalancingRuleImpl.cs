// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.LoadBalancingRule.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update;
    using Microsoft.Azure.Management.V2.Network.HasFloatingIp.Definition;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.HasFrontend.Definition;
    using Microsoft.Azure.Management.V2.Network.HasProtocol.Definition;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition;
    using Microsoft.Azure.Management.V2.Network.HasFrontend.Update;
    using Microsoft.Azure.Management.V2.Network.HasFloatingIp.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.V2.Network.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.HasBackendPort.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Network.HasFloatingIp.Update;
    using Microsoft.Azure.Management.V2.Network.HasProtocol.Update;
    using Microsoft.Azure.Management.V2.Network.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Definition;
    using Microsoft.Azure.Management.V2.Network.HasBackendPort.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Resource.Core.ChildResourceActions;
    using System;

    /// <summary>
    /// Implementation for {@link LoadBalancingRule}.
    /// </summary>
    public partial class LoadBalancingRuleImpl  :
        ChildResource<Microsoft.Azure.Management.Network.Models.LoadBalancingRuleInner,Microsoft.Azure.Management.V2.Network.LoadBalancerImpl,Microsoft.Azure.Management.V2.Network.ILoadBalancer>,
        ILoadBalancingRule,
        IDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>,
        IUpdateDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.V2.Network.LoadBalancingRule.Update.IUpdate
    {
        protected  LoadBalancingRuleImpl (LoadBalancingRuleInner inner, LoadBalancerImpl parent) : base(inner.Name, inner, parent)
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
        public bool? FloatingIpEnabled
        {
            get
            {
            //$ return this.inner().enableFloatingIP();


                return null;
            }
        }
        public int? IdleTimeoutInMinutes
        {
            get
            {
            //$ return this.inner().idleTimeoutInMinutes();


                return null;
            }
        }
        public int? FrontendPort
        {
            get
            {
            //$ return this.inner().frontendPort();


                return null;
            }
        }
        public int? BackendPort
        {
            get
            {
            //$ if (this.inner().backendPort() == null) {
            //$ return 0;
            //$ } else {
            //$ return this.inner().backendPort();
            //$ }


                return null;
            }
        }
        public string LoadDistribution
        {
            get
            {
            //$ return this.inner().loadDistribution();


                return null;
            }
        }
        public IFrontend Frontend ()
        {

            //$ SubResource frontendRef = this.inner().frontendIPConfiguration();
            //$ if (frontendRef == null) {
            //$ return null;
            //$ } else {
            //$ String frontendName = ResourceUtils.nameFromResourceId(frontendRef.id());
            //$ return this.parent().frontends().get(frontendName);
            //$ }

            return null;
        }

        public IBackend Backend ()
        {

            //$ SubResource backendRef = this.inner().backendAddressPool();
            //$ if (backendRef == null) {
            //$ return null;
            //$ } else {
            //$ String backendName = ResourceUtils.nameFromResourceId(backendRef.id());
            //$ return this.parent().backends().get(backendName);
            //$ }

            return null;
        }

        public IProbe Probe ()
        {

            //$ SubResource probeRef = this.inner().probe();
            //$ if (probeRef == null) {
            //$ return null;
            //$ } else {
            //$ String probeName = ResourceUtils.nameFromResourceId(probeRef.id());
            //$ if (this.parent().httpProbes().containsKey(probeName)) {
            //$ return this.parent().httpProbes().get(probeName);
            //$ } else if (this.parent().tcpProbes().containsKey(probeName)) {
            //$ return this.parent().tcpProbes().get(probeName);
            //$ } else {
            //$ return null;
            //$ }
            //$ }

            return null;
        }

        public LoadBalancingRuleImpl WithIdleTimeoutInMinutes (int minutes)
        {

            //$ this.inner().withIdleTimeoutInMinutes(minutes);
            //$ return this;

            return this;
        }

        public LoadBalancingRuleImpl WithFloatingIp (bool enable)
        {

            //$ this.inner().withEnableFloatingIP(enable);
            //$ return this;

            return this;
        }

        public LoadBalancingRuleImpl WithFloatingIpEnabled ()
        {

            //$ return withFloatingIp(true);

            return this;
        }

        public LoadBalancingRuleImpl WithFloatingIpDisabled ()
        {

            //$ return withFloatingIp(false);

            return this;
        }

        public LoadBalancingRuleImpl WithProtocol (string protocol)
        {

            //$ this.inner().withProtocol(protocol);
            //$ return this;

            return this;
        }

        public LoadBalancingRuleImpl WithFrontendPort (int port)
        {

            //$ this.inner().withFrontendPort(port);
            //$ 
            //$ // If backend port not specified earlier, make it the same as the frontend by default
            //$ if (this.inner().backendPort() == null || this.inner().backendPort() == 0) {
            //$ this.inner().withBackendPort(port);
            //$ }
            //$ 
            //$ return this;

            return this;
        }

        public LoadBalancingRuleImpl WithBackendPort (int port)
        {

            //$ this.inner().withBackendPort(port);
            //$ return this;

            return this;
        }

        public LoadBalancingRuleImpl WithLoadDistribution (string loadDistribution)
        {

            //$ this.inner().withLoadDistribution(loadDistribution);
            //$ return this;

            return this;
        }

        public LoadBalancingRuleImpl WithFrontend (string frontendName)
        {

            //$ SubResource frontendRef = new SubResource()
            //$ .withId(this.parent().futureResourceId() + "/frontendIPConfigurations/" + frontendName);
            //$ this.inner().withFrontendIPConfiguration(frontendRef);
            //$ return this;

            return this;
        }

        public LoadBalancingRuleImpl WithBackend (string backendName)
        {

            //$ SubResource backendRef = new SubResource()
            //$ .withId(this.parent().futureResourceId() + "/backendAddressPools/" + backendName);
            //$ this.inner().withBackendAddressPool(backendRef);
            //$ return this;

            return this;
        }

        public LoadBalancingRuleImpl WithProbe (string name)
        {

            //$ SubResource probeRef = new SubResource()
            //$ .withId(this.parent().futureResourceId() + "/probes/" + name);
            //$ this.inner().withProbe(probeRef);
            //$ return this;

            return this;
        }

        public LoadBalancerImpl Attach ()
        {

            //$ return this.parent().withLoadBalancingRule(this);

            return null;
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            throw new NotImplementedException();
        }
    }
}