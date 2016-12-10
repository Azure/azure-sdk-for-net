// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Definition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The final stage of the probe definition.
    /// At this stage, any remaining optional settings can be specified, or the probe definition
    /// can be attached to the parent load balancer definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The parent resource type.</typeparam>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        IWithIntervalInSeconds<ParentT>,
        IWithNumberOfProbes<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a probe definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final DefinitionStages.WithAttach.attach().</typeparam>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithPort<ParentT>
    {
    }

    /// <summary>
    /// The stage of the TCP probe definition allowing to specify the probe interval.
    /// </summary>
    /// <typeparam name="Parent">The parent resource type.</typeparam>
    public interface IWithIntervalInSeconds<ParentT> 
    {
        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">Number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Definition.IWithAttach<ParentT> WithIntervalInSeconds(int seconds);
    }

    /// <summary>
    /// The stage of the TCP probe definition allowing to specify the port number to monitor.
    /// </summary>
    /// <typeparam name="Parent">The parent resource type.</typeparam>
    public interface IWithPort<ParentT> 
    {
        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Definition.IWithAttach<ParentT> WithPort(int port);
    }

    /// <summary>
    /// The first stage of the probe definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IBlank<ParentT>  :
        IWithPort<ParentT>
    {
    }

    /// <summary>
    /// The stage of the TCP probe definition allowing to specify the number of unsuccessful probes before failure is determined.
    /// </summary>
    /// <typeparam name="Parent">The parent resource type.</typeparam>
    public interface IWithNumberOfProbes<ParentT> 
    {
        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">Number of probes.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Definition.IWithAttach<ParentT> WithNumberOfProbes(int probes);
    }
}