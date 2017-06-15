// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;

    /// <summary>
    /// The entirety of a container service agent pool definition as a part of a parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition.IWithVMSize<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition.IWithLeafDomainLabel<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a container service agent pool definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> 
    {
        /// <summary>
        /// Specifies the number of agents (VMs) to host docker containers.
        /// Allowed values must be in the range of 1 to 100 (inclusive).
        /// </summary>
        /// <param name="count">The count.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition.IWithVMSize<ParentT> WithVMCount(int count);
    }

    /// <summary>
    /// The final stage of a container service agent pool definition.
    /// At this stage, any remaining optional settings can be specified, or the container service agent pool
    /// can be attached to the parent container service definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the DNS label.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithLeafDomainLabel<ParentT> 
    {
        /// <summary>
        /// Specify the DNS prefix to be used to create the FQDN for the agent pool.
        /// </summary>
        /// <param name="dnsLabel">The Dns label.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition.IWithAttach<ParentT> WithLeafDomainLabel(string dnsLabel);
    }

    /// <summary>
    /// The stage of a container service agent pool definition allowing to specify the agent VM size.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the container service definition to return to after attaching this definition.</typeparam>
    public interface IWithVMSize<ParentT> 
    {
        /// <summary>
        /// Specifies the size of the agents VMs.
        /// </summary>
        /// <param name="vmSize">The size of the VM.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition.IWithLeafDomainLabel<ParentT> WithVMSize(string vmSize);
    }
}