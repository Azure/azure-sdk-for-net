// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Network.Fluent.HttpProbe.Update;
    using Microsoft.Azure.Management.Network.Fluent.HttpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.TcpProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Network.Fluent.TcpProbe.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using System.Collections.Generic;
    public partial class ProbeImpl 
    {
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithRequestPath<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithRequestPath(string requestPath) { 
            return this.WithRequestPath( requestPath) as Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        Microsoft.Azure.Management.Network.Fluent.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HttpProbe.UpdateDefinition.IWithRequestPath<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithRequestPath(string requestPath) { 
            return this.WithRequestPath( requestPath) as Microsoft.Azure.Management.Network.Fluent.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <returns>the protocol</returns>
        string Microsoft.Azure.Management.Network.Fluent.IHasProtocol<string>.Protocol
        {
            get
            { 
            return this.Protocol() as string;
            }
        }
        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.TcpProbe.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.TcpProbe.Update.IWithPort.WithPort(int port) { 
            return this.WithPort( port) as Microsoft.Azure.Management.Network.Fluent.TcpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HttpProbe.Update.IWithPort.WithPort(int port) { 
            return this.WithPort( port) as Microsoft.Azure.Management.Network.Fluent.HttpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.TcpProbe.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.TcpProbe.Update.IWithNumberOfProbes.WithNumberOfProbes(int probes) { 
            return this.WithNumberOfProbes( probes) as Microsoft.Azure.Management.Network.Fluent.TcpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HttpProbe.Update.IWithNumberOfProbes.WithNumberOfProbes(int probes) { 
            return this.WithNumberOfProbes( probes) as Microsoft.Azure.Management.Network.Fluent.HttpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.TcpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.TcpProbe.Definition.IWithPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithPort(int port) { 
            return this.WithPort( port) as Microsoft.Azure.Management.Network.Fluent.TcpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition.IWithPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithPort(int port) { 
            return this.WithPort( port) as Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithPort(int port) { 
            return this.WithPort( port) as Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HttpProbe.UpdateDefinition.IWithPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithPort(int port) { 
            return this.WithPort( port) as Microsoft.Azure.Management.Network.Fluent.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        Microsoft.Azure.Management.Network.Fluent.HttpProbe.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HttpProbe.Update.IWithRequestPath.WithRequestPath(string requestPath) { 
            return this.WithRequestPath( requestPath) as Microsoft.Azure.Management.Network.Fluent.HttpProbe.Update.IUpdate;
        }

        /// <returns>the port number the probe is monitoring</returns>
        int Microsoft.Azure.Management.Network.Fluent.IProbe.Port
        {
            get
            { 
            return this.Port();
            }
        }
        /// <returns>number of failed probes before the node is determined to be unhealthy</returns>
        int Microsoft.Azure.Management.Network.Fluent.IProbe.NumberOfProbes
        {
            get
            { 
            return this.NumberOfProbes();
            }
        }
        /// <returns>number of seconds between probes</returns>
        int Microsoft.Azure.Management.Network.Fluent.IProbe.IntervalInSeconds
        {
            get
            { 
            return this.IntervalInSeconds();
            }
        }
        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.TcpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.TcpProbe.Definition.IWithNumberOfProbes<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithNumberOfProbes(int probes) { 
            return this.WithNumberOfProbes( probes) as Microsoft.Azure.Management.Network.Fluent.TcpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition.IWithNumberOfProbes<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithNumberOfProbes(int probes) { 
            return this.WithNumberOfProbes( probes) as Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithNumberOfProbes<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithNumberOfProbes(int probes) { 
            return this.WithNumberOfProbes( probes) as Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HttpProbe.UpdateDefinition.IWithNumberOfProbes<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithNumberOfProbes(int probes) { 
            return this.WithNumberOfProbes( probes) as Microsoft.Azure.Management.Network.Fluent.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule;
        }

        /// <returns>the HTTP request path for the HTTP probe to call to check the health status</returns>
        string Microsoft.Azure.Management.Network.Fluent.IHttpProbe.RequestPath
        {
            get
            { 
            return this.RequestPath() as string;
            }
        }
        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.TcpProbe.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.TcpProbe.Update.IWithIntervalInSeconds.WithIntervalInSeconds(int seconds) { 
            return this.WithIntervalInSeconds( seconds) as Microsoft.Azure.Management.Network.Fluent.TcpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HttpProbe.Update.IWithIntervalInSeconds.WithIntervalInSeconds(int seconds) { 
            return this.WithIntervalInSeconds( seconds) as Microsoft.Azure.Management.Network.Fluent.HttpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.TcpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.TcpProbe.Definition.IWithIntervalInSeconds<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithIntervalInSeconds(int seconds) { 
            return this.WithIntervalInSeconds( seconds) as Microsoft.Azure.Management.Network.Fluent.TcpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition.IWithIntervalInSeconds<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithIntervalInSeconds(int seconds) { 
            return this.WithIntervalInSeconds( seconds) as Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithIntervalInSeconds<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>.WithIntervalInSeconds(int seconds) { 
            return this.WithIntervalInSeconds( seconds) as Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HttpProbe.UpdateDefinition.IWithIntervalInSeconds<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithIntervalInSeconds(int seconds) { 
            return this.WithIntervalInSeconds( seconds) as Microsoft.Azure.Management.Network.Fluent.HttpProbe.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <returns>the associated load balancing rules from this load balancer, indexed by their names</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.IHasLoadBalancingRules.LoadBalancingRules
        {
            get
            { 
            return this.LoadBalancingRules() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule>;
            }
        }
        /// <returns>the name of this child object</returns>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>.Name
        {
            get
            { 
            return this.Name() as string;
            }
        }
    }
}