// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.TcpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.TcpProbe.Definition;
    using Microsoft.Azure.Management.V2.Network.HttpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition;
    using Microsoft.Azure.Management.V2.Network.TcpProbe.Update;
    using Microsoft.Azure.Management.V2.Network.HttpProbe.Update;
    using Microsoft.Azure.Management.V2.Network.HttpProbe.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Resource.Core.ChildResourceActions;
    using System;

    /// <summary>
    /// Implementation for {@link TcpProbe} and its create and update interfaces.
    /// </summary>
    public partial class ProbeImpl  :
        ChildResource<Microsoft.Azure.Management.Network.Models.ProbeInner,Microsoft.Azure.Management.V2.Network.LoadBalancerImpl,Microsoft.Azure.Management.V2.Network.ILoadBalancer>,
        ITcpProbe,
        Microsoft.Azure.Management.V2.Network.TcpProbe.Definition.IDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>,
        Microsoft.Azure.Management.V2.Network.TcpProbe.UpdateDefinition.IUpdateDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.V2.Network.TcpProbe.Update.IUpdate,
        IHttpProbe,
        Microsoft.Azure.Management.V2.Network.HttpProbe.Definition.IDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>,
        Microsoft.Azure.Management.V2.Network.HttpProbe.UpdateDefinition.IUpdateDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.V2.Network.HttpProbe.Update.IUpdate
    {
        protected  ProbeImpl (ProbeInner inner, LoadBalancerImpl parent) : base(inner.Name, inner, parent)
        {

            //$ super(inner, parent);
            //$ }

        }

        public int? IntervalInSeconds
        {
            get
            {
            //$ return this.inner().intervalInSeconds();


                return null;
            }
        }
        public int? Port
        {
            get
            {
            //$ return this.inner().port();


                return null;
            }
        }
        public int? NumberOfProbes
        {
            get
            {
            //$ return this.inner().numberOfProbes();


                return null;
            }
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
        public string RequestPath
        {
            get
            {
            //$ return this.inner().requestPath();


                return null;
            }
        }
        public IDictionary<string,Microsoft.Azure.Management.V2.Network.ILoadBalancingRule> LoadBalancingRules ()
        {

            //$ final Map<String, LoadBalancingRule> rules = new TreeMap<>();
            //$ if (this.inner().loadBalancingRules() != null) {
            //$ for (SubResource inner : this.inner().loadBalancingRules()) {
            //$ String name = ResourceUtils.nameFromResourceId(inner.id());
            //$ LoadBalancingRule rule = this.parent().loadBalancingRules().get(name);
            //$ if (rule != null) {
            //$ rules.put(name, rule);
            //$ }
            //$ }
            //$ }
            //$ 
            //$ return Collections.unmodifiableMap(rules);

            return null;
        }

        public ProbeImpl WithPort (int port)
        {

            //$ this.inner().withPort(port);
            //$ return this;

            return this;
        }

        public ProbeImpl WithRequestPath (string requestPath)
        {

            //$ this.inner().withRequestPath(requestPath);
            //$ return this;

            return this;
        }

        public ProbeImpl WithIntervalInSeconds (int seconds)
        {

            //$ this.inner().withIntervalInSeconds(seconds);
            //$ return this;

            return this;
        }

        public ProbeImpl WithNumberOfProbes (int probes)
        {

            //$ this.inner().withNumberOfProbes(probes);
            //$ return this;

            return this;
        }

        public LoadBalancerImpl Attach ()
        {

            //$ return this.parent().withProbe(this);

            return null;
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            throw new NotImplementedException();
        }
    }
}