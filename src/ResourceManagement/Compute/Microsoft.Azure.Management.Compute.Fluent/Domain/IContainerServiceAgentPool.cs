// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A client-side representation for a container service agent pool.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IContainerServiceAgentPool  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Compute.Fluent.IContainerService>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ContainerServiceAgentPoolProfile>
    {
        /// <summary>
        /// Gets the number of agents (VMs) to host docker containers.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets DNS prefix to be used to create the FQDN for the agent pool.
        /// </summary>
        string DnsLabel { get; }

        /// <summary>
        /// Gets size of agent VMs.
        /// </summary>
        string VMSize { get; }

        /// <summary>
        /// Gets FDQN for the agent pool.
        /// </summary>
        string Fqdn { get; }
    }
}