// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;

    internal partial class LoadBalancerProbeImpl 
    {
        LoadBalancerHttpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> LoadBalancerHttpProbe.Definition.IWithRequestPath<LoadBalancer.Definition.IWithCreate>.WithRequestPath(string requestPath)
        {
            return this.WithRequestPath(requestPath) as LoadBalancerHttpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the HTTP request path for the probe to monitor.
        /// </summary>
        /// <param name="requestPath">A request path.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerHttpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerHttpProbe.UpdateDefinition.IWithRequestPath<LoadBalancer.Update.IUpdate>.WithRequestPath(string requestPath)
        {
            return this.WithRequestPath(requestPath) as LoadBalancerHttpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Gets the protocol.
        /// </summary>
        Models.ProbeProtocol Microsoft.Azure.Management.Network.Fluent.IHasProtocol<Models.ProbeProtocol>.Protocol
        {
            get
            {
                return this.Protocol() as Models.ProbeProtocol;
            }
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerTcpProbe.Update.IUpdate LoadBalancerTcpProbe.Update.IWithPort.WithPort(int port)
        {
            return this.WithPort(port) as LoadBalancerTcpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerHttpProbe.Update.IUpdate LoadBalancerHttpProbe.Update.IWithPort.WithPort(int port)
        {
            return this.WithPort(port) as LoadBalancerHttpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">Number of probes.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerTcpProbe.Update.IUpdate LoadBalancerTcpProbe.Update.IWithNumberOfProbes.WithNumberOfProbes(int probes)
        {
            return this.WithNumberOfProbes(probes) as LoadBalancerTcpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">Number of probes.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerHttpProbe.Update.IUpdate LoadBalancerHttpProbe.Update.IWithNumberOfProbes.WithNumberOfProbes(int probes)
        {
            return this.WithNumberOfProbes(probes) as LoadBalancerHttpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerTcpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerTcpProbe.UpdateDefinition.IWithPort<LoadBalancer.Update.IUpdate>.WithPort(int port)
        {
            return this.WithPort(port) as LoadBalancerTcpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerHttpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> LoadBalancerHttpProbe.Definition.IWithPort<LoadBalancer.Definition.IWithCreate>.WithPort(int port)
        {
            return this.WithPort(port) as LoadBalancerHttpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerHttpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerHttpProbe.UpdateDefinition.IWithPort<LoadBalancer.Update.IUpdate>.WithPort(int port)
        {
            return this.WithPort(port) as LoadBalancerHttpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerTcpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> LoadBalancerTcpProbe.Definition.IWithPort<LoadBalancer.Definition.IWithCreate>.WithPort(int port)
        {
            return this.WithPort(port) as LoadBalancerTcpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Gets number of failed probes before the node is determined to be unhealthy.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.ILoadBalancerProbe.NumberOfProbes
        {
            get
            {
                return this.NumberOfProbes();
            }
        }

        /// <summary>
        /// Gets number of seconds between probes.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.ILoadBalancerProbe.IntervalInSeconds
        {
            get
            {
                return this.IntervalInSeconds();
            }
        }

        /// <summary>
        /// Gets the port number.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IHasPort.Port
        {
            get
            {
                return this.Port();
            }
        }

        /// <summary>
        /// Specifies the HTTP request path for the probe to monitor.
        /// </summary>
        /// <param name="requestPath">A request path.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerHttpProbe.Update.IUpdate LoadBalancerHttpProbe.Update.IWithRequestPath.WithRequestPath(string requestPath)
        {
            return this.WithRequestPath(requestPath) as LoadBalancerHttpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">Number of probes.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerTcpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerTcpProbe.UpdateDefinition.IWithNumberOfProbes<LoadBalancer.Update.IUpdate>.WithNumberOfProbes(int probes)
        {
            return this.WithNumberOfProbes(probes) as LoadBalancerTcpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">Number of probes.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerHttpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> LoadBalancerHttpProbe.Definition.IWithNumberOfProbes<LoadBalancer.Definition.IWithCreate>.WithNumberOfProbes(int probes)
        {
            return this.WithNumberOfProbes(probes) as LoadBalancerHttpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">Number of probes.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerHttpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerHttpProbe.UpdateDefinition.IWithNumberOfProbes<LoadBalancer.Update.IUpdate>.WithNumberOfProbes(int probes)
        {
            return this.WithNumberOfProbes(probes) as LoadBalancerHttpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">Number of probes.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerTcpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> LoadBalancerTcpProbe.Definition.IWithNumberOfProbes<LoadBalancer.Definition.IWithCreate>.WithNumberOfProbes(int probes)
        {
            return this.WithNumberOfProbes(probes) as LoadBalancerTcpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<LoadBalancer.Update.IUpdate>.Attach()
        {
            return this.Attach() as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<LoadBalancer.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as LoadBalancer.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">Number of seconds.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerTcpProbe.Update.IUpdate LoadBalancerTcpProbe.Update.IWithIntervalInSeconds.WithIntervalInSeconds(int seconds)
        {
            return this.WithIntervalInSeconds(seconds) as LoadBalancerTcpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">Number of seconds.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerHttpProbe.Update.IUpdate LoadBalancerHttpProbe.Update.IWithIntervalInSeconds.WithIntervalInSeconds(int seconds)
        {
            return this.WithIntervalInSeconds(seconds) as LoadBalancerHttpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">Number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerTcpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerTcpProbe.UpdateDefinition.IWithIntervalInSeconds<LoadBalancer.Update.IUpdate>.WithIntervalInSeconds(int seconds)
        {
            return this.WithIntervalInSeconds(seconds) as LoadBalancerTcpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">Number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerHttpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> LoadBalancerHttpProbe.Definition.IWithIntervalInSeconds<LoadBalancer.Definition.IWithCreate>.WithIntervalInSeconds(int seconds)
        {
            return this.WithIntervalInSeconds(seconds) as LoadBalancerHttpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">Number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerHttpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerHttpProbe.UpdateDefinition.IWithIntervalInSeconds<LoadBalancer.Update.IUpdate>.WithIntervalInSeconds(int seconds)
        {
            return this.WithIntervalInSeconds(seconds) as LoadBalancerHttpProbe.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">Number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerTcpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate> LoadBalancerTcpProbe.Definition.IWithIntervalInSeconds<LoadBalancer.Definition.IWithCreate>.WithIntervalInSeconds(int seconds)
        {
            return this.WithIntervalInSeconds(seconds) as LoadBalancerTcpProbe.Definition.IWithAttach<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Gets the associated load balancing rules from this load balancer, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.IHasLoadBalancingRules.LoadBalancingRules
        {
            get
            {
                return this.LoadBalancingRules() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule>;
            }
        }

        /// <summary>
        /// Gets the HTTP request path for the HTTP probe to call to check the health status.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ILoadBalancerHttpProbe.RequestPath
        {
            get
            {
                return this.RequestPath();
            }
        }
    }
}