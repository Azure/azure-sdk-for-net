// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.InboundNatRule.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.HasFloatingIp.Definition;
    using Microsoft.Azure.Management.V2.Network.HasFrontend.Definition;
    using Microsoft.Azure.Management.V2.Network.HasProtocol.Definition;
    using Microsoft.Azure.Management.V2.Network.HasFrontend.Update;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Network.InboundNatRule.Definition;
    using Microsoft.Azure.Management.V2.Network.InboundNatRule.Update;
    using Microsoft.Azure.Management.V2.Network.HasFloatingIp.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.HasBackendPort.Definition;
    using Microsoft.Azure.Management.V2.Network.HasFloatingIp.Update;
    using Microsoft.Azure.Management.V2.Network.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.HasProtocol.Update;
    using Microsoft.Azure.Management.V2.Network.HasBackendPort.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Resource.Core.ChildResourceActions;
    using System;

    /// <summary>
    /// Implementation for {@link InboundNatRule}.
    /// </summary>
    public partial class InboundNatRuleImpl  :
        ChildResource<Microsoft.Azure.Management.Network.Models.InboundNatRuleInner,Microsoft.Azure.Management.V2.Network.LoadBalancerImpl,Microsoft.Azure.Management.V2.Network.ILoadBalancer>,
        IInboundNatRule,
        IDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>,
        IUpdateDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.V2.Network.InboundNatRule.Update.IUpdate
    {
        protected  InboundNatRuleImpl (InboundNatRuleInner inner, LoadBalancerImpl parent) : base(inner.Name, inner, parent)
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
        public string BackendNicIpConfigurationName
        {
            get
            {
            //$ if (this.inner().backendIPConfiguration() == null) {
            //$ return null;
            //$ } else {
            //$ return ResourceUtils.nameFromResourceId(this.inner().backendIPConfiguration().id());
            //$ }


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
            //$ return this.inner().backendPort().intValue();
            //$ }


                return null;
            }
        }
        public string BackendNetworkInterfaceId
        {
            get
            {
            //$ if (this.inner().backendIPConfiguration() == null) {
            //$ return null;
            //$ } else {
            //$ return ResourceUtils.parentResourcePathFromResourceId(this.inner().backendIPConfiguration().id());
            //$ }


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
        public int? FrontendPort
        {
            get
            {
            //$ if (this.inner().frontendPort() == null) {
            //$ return 0;
            //$ } else {
            //$ return this.inner().frontendPort().intValue();
            //$ }


                return null;
            }
        }
        public bool? FloatingIpEnabled
        {
            get
            {
            //$ return this.inner().enableFloatingIP().booleanValue();


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

        public int? IdleTimeoutInMinutes
        {
            get
            {
            //$ return this.inner().idleTimeoutInMinutes();


                return null;
            }
        }
        public InboundNatRuleImpl WithBackendPort (int port)
        {

            //$ this.inner().withBackendPort(port);
            //$ return this;

            return this;
        }

        public InboundNatRuleImpl WithFloatingIpEnabled ()
        {

            //$ return withFloatingIp(true);

            return this;
        }

        public InboundNatRuleImpl WithFloatingIpDisabled ()
        {

            //$ return withFloatingIp(false);

            return this;
        }

        public InboundNatRuleImpl WithFloatingIp (bool enabled)
        {

            //$ this.inner().withEnableFloatingIP(enabled);
            //$ return this;

            return this;
        }

        public InboundNatRuleImpl WithFrontendPort (int port)
        {

            //$ this.inner().withFrontendPort(port);
            //$ if (this.backendPort() == 0) {
            //$ // By default, assume the same backend port
            //$ return this.withBackendPort(port);
            //$ } else {
            //$ return this;
            //$ }

            return this;
        }

        public InboundNatRuleImpl WithIdleTimeoutInMinutes (int minutes)
        {

            //$ this.inner().withIdleTimeoutInMinutes(minutes);
            //$ return this;

            return this;
        }

        public InboundNatRuleImpl WithProtocol (string protocol)
        {

            //$ this.inner().withProtocol(protocol);
            //$ return this;

            return this;
        }

        public InboundNatRuleImpl WithFrontend (string frontendName)
        {

            //$ SubResource frontendRef = new SubResource()
            //$ .withId(this.parent().futureResourceId() + "/frontendIPConfigurations/" + frontendName);
            //$ this.inner().withFrontendIPConfiguration(frontendRef);
            //$ return this;

            return this;
        }

        public LoadBalancerImpl Attach ()
        {

            //$ return this.parent().withInboundNatRule(this);

            return null;
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            throw new NotImplementedException();
        }
    }
}