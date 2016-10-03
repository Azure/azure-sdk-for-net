// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition;
    /// <summary>
    /// The first stage of the probe definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithPort<ParentT>
    {
    }
    /// <summary>
    /// The stage of the TCP probe definition allowing to specify the number of unsuccessful probes before failure is determined.
    /// @param <ParentT> the parent resource type
    /// </summary>
    public interface IWithNumberOfProbes<ParentT> 
    {
        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IWithAttach<ParentT> WithNumberOfProbes(int probes);

    }
    /// <summary>
    /// The stage of the TCP probe definition allowing to specify the port number to monitor.
    /// @param <ParentT> the parent resource type
    /// </summary>
    public interface IWithPort<ParentT> 
    {
        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IWithAttach<ParentT> WithPort(int port);

    }
    /// <summary>
    /// The final stage of the probe definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the probe definition
    /// can be attached to the parent load balancer definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the parent resource type
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        IWithIntervalInSeconds<ParentT>,
        IWithNumberOfProbes<ParentT>
    {
    }
    /// <summary>
    /// The stage of the TCP probe definition allowing to specify the probe interval.
    /// @param <ParentT> the parent resource type
    /// </summary>
    public interface IWithIntervalInSeconds<ParentT> 
    {
        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IWithAttach<ParentT> WithIntervalInSeconds(int seconds);

    }
    /// <summary>
    /// The entirety of a probe definition.
    /// @param <ParentT> the return type of the final {@link DefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithPort<ParentT>
    {
    }
}