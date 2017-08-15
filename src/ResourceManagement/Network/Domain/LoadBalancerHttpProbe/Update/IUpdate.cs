// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of the HTTP probe update allowing to modify the probe interval.
    /// </summary>
    public interface IWithIntervalInSeconds 
    {
        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">Number of seconds.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update.IUpdate WithIntervalInSeconds(int seconds);
    }

    /// <summary>
    /// The entirety of a probe update as part of a load balancer update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update.IWithIntervalInSeconds,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update.IWithNumberOfProbes,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update.IWithPort,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update.IWithRequestPath
    {
    }

    /// <summary>
    /// The stage of the HTTP probe update allowing to modify the number of unsuccessful probes before failure is determined.
    /// </summary>
    public interface IWithNumberOfProbes 
    {
        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">Number of probes.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update.IUpdate WithNumberOfProbes(int probes);
    }

    /// <summary>
    /// The stage of the HTTP probe update allowing to modify the port number to monitor.
    /// </summary>
    public interface IWithPort 
    {
        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update.IUpdate WithPort(int port);
    }

    /// <summary>
    /// The stage of the HTTP probe update allowing to modify the HTTP request path for the probe to monitor.
    /// </summary>
    public interface IWithRequestPath 
    {
        /// <summary>
        /// Specifies the HTTP request path for the probe to monitor.
        /// </summary>
        /// <param name="requestPath">A request path.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update.IUpdate WithRequestPath(string requestPath);
    }
}