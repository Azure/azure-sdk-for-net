// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Fluent.Network.TcpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Fluent.Network.TcpProbe.Update;
    using Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update;
    using Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update;
    public partial class ProbeImpl 
    {
        Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IWithRequestPath<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithRequestPath (string requestPath) { 
            return this.WithRequestPath( requestPath) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IWithRequestPath<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithRequestPath (string requestPath) { 
            return this.WithRequestPath( requestPath) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <returns>the protocol</returns>
        string Microsoft.Azure.Management.Fluent.Network.IHasProtocol<string>.Protocol () {
                return this.Protocol as string;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.TcpProbe.Update.IWithPort.WithPort (int port) { 
            return this.WithPort( port) as Microsoft.Azure.Management.Fluent.Network.TcpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IWithPort.WithPort (int port) { 
            return this.WithPort( port) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.TcpProbe.Update.IWithNumberOfProbes.WithNumberOfProbes (int probes) { 
            return this.WithNumberOfProbes( probes) as Microsoft.Azure.Management.Fluent.Network.TcpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IWithNumberOfProbes.WithNumberOfProbes (int probes) { 
            return this.WithNumberOfProbes( probes) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IWithPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithPort (int port) { 
            return this.WithPort( port) as Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.TcpProbe.UpdateDefinition.IWithPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithPort (int port) { 
            return this.WithPort( port) as Microsoft.Azure.Management.Fluent.Network.TcpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IWithPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithPort (int port) { 
            return this.WithPort( port) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IWithPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithPort (int port) { 
            return this.WithPort( port) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IWithRequestPath.WithRequestPath (string requestPath) { 
            return this.WithRequestPath( requestPath) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IUpdate;
        }

        /// <returns>the port number the probe is monitoring</returns>
        int? Microsoft.Azure.Management.Fluent.Network.IProbe.Port
        {
            get
            {
                return this.Port;
            }
        }
        /// <returns>number of failed probes before the node is determined to be unhealthy</returns>
        int? Microsoft.Azure.Management.Fluent.Network.IProbe.NumberOfProbes
        {
            get
            {
                return this.NumberOfProbes;
            }
        }
        /// <returns>number of seconds between probes</returns>
        int? Microsoft.Azure.Management.Fluent.Network.IProbe.IntervalInSeconds
        {
            get
            {
                return this.IntervalInSeconds;
            }
        }
        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IWithNumberOfProbes<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithNumberOfProbes (int probes) { 
            return this.WithNumberOfProbes( probes) as Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.TcpProbe.UpdateDefinition.IWithNumberOfProbes<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithNumberOfProbes (int probes) { 
            return this.WithNumberOfProbes( probes) as Microsoft.Azure.Management.Fluent.Network.TcpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IWithNumberOfProbes<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithNumberOfProbes (int probes) { 
            return this.WithNumberOfProbes( probes) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IWithNumberOfProbes<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithNumberOfProbes (int probes) { 
            return this.WithNumberOfProbes( probes) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.Attach () { 
            return this.Attach() as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.Attach () { 
            return this.Attach() as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule;
        }

        /// <returns>the HTTP request path for the HTTP probe to call to check the health status</returns>
        string Microsoft.Azure.Management.Fluent.Network.IHttpProbe.RequestPath
        {
            get
            {
                return this.RequestPath as string;
            }
        }
        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.TcpProbe.Update.IWithIntervalInSeconds.WithIntervalInSeconds (int seconds) { 
            return this.WithIntervalInSeconds( seconds) as Microsoft.Azure.Management.Fluent.Network.TcpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IWithIntervalInSeconds.WithIntervalInSeconds (int seconds) { 
            return this.WithIntervalInSeconds( seconds) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IWithIntervalInSeconds<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithIntervalInSeconds (int seconds) { 
            return this.WithIntervalInSeconds( seconds) as Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.TcpProbe.UpdateDefinition.IWithIntervalInSeconds<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithIntervalInSeconds (int seconds) { 
            return this.WithIntervalInSeconds( seconds) as Microsoft.Azure.Management.Fluent.Network.TcpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IWithIntervalInSeconds<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithIntervalInSeconds (int seconds) { 
            return this.WithIntervalInSeconds( seconds) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IWithIntervalInSeconds<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithIntervalInSeconds (int seconds) { 
            return this.WithIntervalInSeconds( seconds) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <returns>the associated load balancing rules from this load balancer, indexed by their names</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.ILoadBalancingRule> Microsoft.Azure.Management.Fluent.Network.IHasLoadBalancingRules.LoadBalancingRules () { 
            return this.LoadBalancingRules() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.ILoadBalancingRule>;
        }

        /// <returns>the name of this child object</returns>
        string Microsoft.Azure.Management.Fluent.Resource.Core.IChildResource<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>.Name
        {
            get
            {
                return this.Name as string;
            }
        }
    }
}