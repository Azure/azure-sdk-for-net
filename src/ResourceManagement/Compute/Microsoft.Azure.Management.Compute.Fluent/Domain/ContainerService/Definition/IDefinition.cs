// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;

    /// <summary>
    /// The stage of the container service definition allowing to specify an agent pool profile.
    /// </summary>
    public interface IWithAgentPool 
    {
        /// <summary>
        /// Begins the definition of a agent pool profile to be attached to the container service.
        /// </summary>
        /// <param name="name">The name for the agent pool profile.</param>
        /// <return>The stage representing configuration for the agent pool profile.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition.IBlank<Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithCreate> DefineAgentPool(string name);
    }

    /// <summary>
    /// Container interface for all the definitions related to a container service.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IBlank,
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithGroup,
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithOrchestrator,
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithMasterNodeCount,
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithMasterLeafDomainLabel,
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithLinux,
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithLinuxRootUsername,
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithLinuxSshKey,
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithAgentPool,
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the container service definition allowing to specify orchestration type.
    /// </summary>
    public interface IWithOrchestrator 
    {
        /// <summary>
        /// Specifies the DCOS orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithLinux WithDcosOrchestration();

        /// <summary>
        /// Specifies the Swarm orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithLinux WithSwarmOrchestration();

        /// <summary>
        /// Specifies the Kubernetes orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithLinux WithKubernetesOrchestration();
    }

    /// <summary>
    /// The stage of the container service definition allowing to specific the Linux SSH key.
    /// </summary>
    public interface IWithLinuxSshKey 
    {
        /// <summary>
        /// Begins the definition to specify Linux ssh key.
        /// </summary>
        /// <param name="sshKeyData">The SSH key data.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithMasterNodeCount WithSshKey(string sshKeyData);
    }

    /// <summary>
    /// The first stage of a container service definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the container service definition allowing to specify the master node count.
    /// </summary>
    public interface IWithMasterNodeCount 
    {
        /// <summary>
        /// Specifies the master node count.
        /// </summary>
        /// <param name="count">Master profile count (1, 3, 5).</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithMasterLeafDomainLabel WithMasterNodeCount(ContainerServiceMasterProfileCount count);
    }

    /// <summary>
    /// The stage of the container service definition allowing to specific the Linux root username.
    /// </summary>
    public interface IWithLinuxRootUsername 
    {
        /// <summary>
        /// Begins the definition to specify Linux root username.
        /// </summary>
        /// <param name="rootUserName">The root username.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithLinuxSshKey WithRootUsername(string rootUserName);
    }

    /// <summary>
    /// The stage of the container service definition allowing to specify the master Dns label.
    /// </summary>
    public interface IWithMasterLeafDomainLabel 
    {
        /// <summary>
        /// Specifies the master node Dns label.
        /// </summary>
        /// <param name="dnsLabel">The Dns prefix.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithAgentPool WithMasterLeafDomainLabel(string dnsLabel);
    }

    /// <summary>
    /// The stage of the container service definition allowing to specific diagnostic settings.
    /// </summary>
    public interface IWithDiagnostics 
    {
        /// <summary>
        /// Enable diagnostics.
        /// </summary>
        /// <return>The create stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithCreate WithDiagnostics();
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows for any other optional settings to
    /// be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Compute.Fluent.IContainerService>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithCreate>,
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithDiagnostics
    {
    }

    /// <summary>
    /// The stage of the container service definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithOrchestrator>
    {
    }

    /// <summary>
    /// The stage of the container service definition allowing the start of defining Linux specific settings.
    /// </summary>
    public interface IWithLinux 
    {
        /// <summary>
        /// Begins the definition to specify Linux settings.
        /// </summary>
        /// <return>The stage representing configuration of Linux specific settings.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition.IWithLinuxRootUsername WithLinux();
    }
}