// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    /// <summary>
    /// The stage of the HTTP probe definition allowing to specify the probe interval.
    /// @param <ParentT> the parent resource type
    /// </summary>
    public interface IWithIntervalInSeconds<ParentT> 
    {
        /// <summary>
        /// Specifies the interval between probes, in seconds.
        /// </summary>
        /// <param name="seconds">seconds number of seconds</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithAttach<ParentT> WithIntervalInSeconds(int seconds);

    }
    /// <summary>
    /// The final stage of the probe definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the probe definition
    /// can be attached to the parent load balancer definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        IWithPort<ParentT>,
        IWithIntervalInSeconds<ParentT>,
        IWithNumberOfProbes<ParentT>
    {
    }
    /// <summary>
    /// The stage of the probe definition allowing to specify the HTTP request path for the probe to monitor.
    /// @param <ParentT> the parent type
    /// </summary>
    public interface IWithRequestPath<ParentT> 
    {
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithAttach<ParentT> WithRequestPath(string requestPath);

    }
    /// <summary>
    /// The entirety of a probe definition.
    /// @param <ParentT> the return type of the final {@link DefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithRequestPath<ParentT>
    {
    }
    /// <summary>
    /// The stage of the probe definition allowing to specify the port to monitor.
    /// @param <ParentT> the parent type
    /// </summary>
    public interface IWithPort<ParentT> 
    {
        /// <summary>
        /// Specifies the port number to call for health monitoring.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithAttach<ParentT> WithPort(int port);

    }
    /// <summary>
    /// The first stage of the probe definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithRequestPath<ParentT>
    {
    }
    /// <summary>
    /// The stage of the HTTP probe definition allowing to specify the number of unsuccessful probes before failure is determined.
    /// @param <ParentT> the parent type
    /// </summary>
    public interface IWithNumberOfProbes<ParentT> 
    {
        /// <summary>
        /// Specifies the number of unsuccessful probes before failure is determined.
        /// </summary>
        /// <param name="probes">probes number of probes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.HttpProbe.Definition.IWithAttach<ParentT> WithNumberOfProbes(int probes);

    }
}