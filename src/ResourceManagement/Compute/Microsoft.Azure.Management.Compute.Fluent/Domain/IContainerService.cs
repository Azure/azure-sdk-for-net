// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.ContainerService.Update;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An client-side representation for a container service.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IContainerService  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<IComputeManager,Models.ContainerServiceInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IContainerService>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ContainerService.Update.IUpdate>
    {
        /// <summary>
        /// Gets the agent pool count.
        /// </summary>
        int AgentPoolCount { get; }

        /// <summary>
        /// Gets the master node count.
        /// </summary>
        int MasterNodeCount { get; }

        /// <summary>
        /// Gets the agent pool FQDN.
        /// </summary>
        string AgentPoolFqdn { get; }

        /// <summary>
        /// Gets the linux ssh key.
        /// </summary>
        string SshKey { get; }

        /// <summary>
        /// Gets the master leaf domain label.
        /// </summary>
        string MasterLeafDomainLabel { get; }

        /// <summary>
        /// Gets diagnostics enabled.
        /// </summary>
        bool IsDiagnosticsEnabled { get; }

        /// <summary>
        /// Gets the agent pool VM size.
        /// </summary>
        string AgentPoolVMSize { get; }

        /// <summary>
        /// Gets the agent pool name.
        /// </summary>
        string AgentPoolName { get; }

        /// <summary>
        /// Gets the linux root username.
        /// </summary>
        string LinuxRootUsername { get; }

        /// <summary>
        /// Gets the agent pool leaf domain label.
        /// </summary>
        string AgentPoolLeafDomainLabel { get; }

        /// <summary>
        /// Gets the master FQDN.
        /// </summary>
        string MasterFqdn { get; }

        /// <summary>
        /// Gets the type of the orchestrator.
        /// </summary>
        Models.ContainerServiceOchestratorTypes OrchestratorType { get; }

        /// <summary>
        /// Gets the service principal clientId.
        /// </summary>
        string ServicePrincipalClientId { get;  }

        /// <summary>
        /// Gets the service principal secret.
        /// </summary>
        string ServicePrincipalSecret { get; }
    }
}