// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    /// <summary>
    /// The final stage of the probe definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the probe definition
    /// can be attached to the parent load balancer definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>,
        IWithNumberOfProbes<ParentT>,
        IWithIntervalInSeconds<ParentT>
    {
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
        Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition.IWithAttach<ParentT> WithPort(int port);

    }
    /// <summary>
    /// The first stage of the probe definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithPort<ParentT>
    {
    }
    /// <summary>
    /// The entirety of a probe definition as part of a load balancer update.
    /// @param <ParentT> the return type of the final {@link UpdateDefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
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
        Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition.IWithAttach<ParentT> WithNumberOfProbes(int probes);

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
        Microsoft.Azure.Management.Network.Fluent.TcpProbe.UpdateDefinition.IWithAttach<ParentT> WithIntervalInSeconds(int seconds);

    }
}