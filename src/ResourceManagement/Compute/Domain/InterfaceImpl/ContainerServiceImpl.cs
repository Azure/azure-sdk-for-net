// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.ContainerService.Update;
    using Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;

    internal partial class ContainerServiceImpl 
    {
        /// <summary>
        /// Specifies the DCOS orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithDiagnostics ContainerService.Definition.IWithOrchestrator.WithDcosOrchestration()
        {
            return this.WithDcosOrchestration() as ContainerService.Definition.IWithDiagnostics;
        }

        /// <summary>
        /// Specifies the Kubernetes orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithServicePrincipalProfile ContainerService.Definition.IWithOrchestrator.WithKubernetesOrchestration()
        {
            return this.WithKubernetesOrchestration() as ContainerService.Definition.IWithServicePrincipalProfile;
        }

        /// <summary>
        /// Specifies the Swarm orchestration type for the container service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithDiagnostics ContainerService.Definition.IWithOrchestrator.WithSwarmOrchestration()
        {
            return this.WithSwarmOrchestration() as ContainerService.Definition.IWithDiagnostics;
        }

        /// <summary>
        /// Begins the definition to specify Linux ssh key.
        /// </summary>
        /// <param name="sshKeyData">The SSH key data.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithMasterNodeCount ContainerService.Definition.IWithLinuxSshKey.WithSshKey(string sshKeyData)
        {
            return this.WithSshKey(sshKeyData) as ContainerService.Definition.IWithMasterNodeCount;
        }

        /// <summary>
        /// Begins the definition of a agent pool profile to be attached to the container service.
        /// </summary>
        /// <param name="name">The name for the agent pool profile.</param>
        /// <return>The stage representing configuration for the agent pool profile.</return>
        ContainerServiceAgentPool.Definition.IBlank<ContainerService.Definition.IWithCreate> ContainerService.Definition.IWithAgentPool.DefineAgentPool(string name)
        {
            return this.DefineAgentPool(name) as ContainerServiceAgentPool.Definition.IBlank<ContainerService.Definition.IWithCreate>;
        }

        /// <summary>
        /// Begins the definition to specify Linux root username.
        /// </summary>
        /// <param name="rootUserName">The root username.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithLinuxSshKey ContainerService.Definition.IWithLinuxRootUsername.WithRootUsername(string rootUserName)
        {
            return this.WithRootUsername(rootUserName) as ContainerService.Definition.IWithLinuxSshKey;
        }

        /// <summary>
        /// Begins the definition to specify Linux settings.
        /// </summary>
        /// <return>The stage representing configuration of Linux specific settings.</return>
        ContainerService.Definition.IWithLinuxRootUsername ContainerService.Definition.IWithLinux.WithLinux()
        {
            return this.WithLinux() as ContainerService.Definition.IWithLinuxRootUsername;
        }

        /// <summary>
        /// Enables diagnostics.
        /// </summary>
        /// <param name="agentCount">
        /// The number of agents (VMs) to host docker containers.
        /// Allowed values must be in the range of 1 to 100 (inclusive).
        /// The default value is 1.
        /// </param>
        /// <return>The next stage of the update.</return>
        ContainerService.Update.IUpdate ContainerService.Update.IWithUpdateAgentPoolCount.WithAgentVMCount(int agentCount)
        {
            return this.WithAgentVMCount(agentCount) as ContainerService.Update.IUpdate;
        }

        /// <summary>
        /// Enable diagnostics.
        /// </summary>
        /// <return>The create stage of the definition.</return>
        ContainerService.Definition.IWithLinux ContainerService.Definition.IWithDiagnostics.WithDiagnostics()
        {
            return this.WithDiagnostics() as ContainerService.Definition.IWithLinux;
        }

        /// <summary>
        /// Specifies the master node count.
        /// </summary>
        /// <param name="count">Master profile count (1, 3, 5).</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithMasterLeafDomainLabel ContainerService.Definition.IWithMasterNodeCount.WithMasterNodeCount(ContainerServiceMasterProfileCount count)
        {
            return this.WithMasterNodeCount(count) as ContainerService.Definition.IWithMasterLeafDomainLabel;
        }

        /// <summary>
        /// Specifies the master node Dns label.
        /// </summary>
        /// <param name="dnsLabel">The Dns prefix.</param>
        /// <return>The next stage of the definition.</return>
        ContainerService.Definition.IWithAgentPool ContainerService.Definition.IWithMasterLeafDomainLabel.WithMasterLeafDomainLabel(string dnsLabel)
        {
            return this.WithMasterLeafDomainLabel(dnsLabel) as ContainerService.Definition.IWithAgentPool;
        }

        /// <summary>
        /// Gets the master leaf domain label.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IContainerService.MasterLeafDomainLabel
        {
            get
            {
                return this.MasterLeafDomainLabel();
            }
        }

        /// <summary>
        /// Gets the master FQDN.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IContainerService.MasterFqdn
        {
            get
            {
                return this.MasterFqdn();
            }
        }

        /// <summary>
        /// Gets the linux root username.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IContainerService.LinuxRootUsername
        {
            get
            {
                return this.LinuxRootUsername();
            }
        }

        /// <summary>
        /// Gets the master node count.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IContainerService.MasterNodeCount
        {
            get
            {
                return this.MasterNodeCount();
            }
        }

        /// <summary>
        /// Gets diagnostics enabled.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IContainerService.IsDiagnosticsEnabled
        {
            get
            {
                return this.IsDiagnosticsEnabled();
            }
        }

        /// <summary>
        /// Gets the agent pool name.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IContainerService.AgentPoolName
        {
            get
            {
                return this.AgentPoolName();
            }
        }

        /// <summary>
        /// Gets the agent pool VM size.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IContainerService.AgentPoolVMSize
        {
            get
            {
                return this.AgentPoolVMSize() as string;
            }
        }

        /// <summary>
        /// Gets the type of the orchestrator.
        /// </summary>
        Models.ContainerServiceOchestratorTypes Microsoft.Azure.Management.Compute.Fluent.IContainerService.OrchestratorType
        {
            get
            {
                return this.OrchestratorType();
            }
        }

        /// <summary>
        /// Gets the linux ssh key.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IContainerService.SshKey
        {
            get
            {
                return this.SshKey();
            }
        }

        /// <summary>
        /// Gets the agent pool count.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IContainerService.AgentPoolCount
        {
            get
            {
                return this.AgentPoolCount();
            }
        }

        /// <summary>
        /// Gets the agent pool leaf domain label.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IContainerService.AgentPoolLeafDomainLabel
        {
            get
            {
                return this.AgentPoolLeafDomainLabel();
            }
        }

        /// <summary>
        /// Gets the agent pool FQDN.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IContainerService.AgentPoolFqdn
        {
            get
            {
                return this.AgentPoolFqdn();
            }
        }

        /// <summary>
        /// Gets the service principal clientId.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IContainerService.ServicePrincipalClientId
        {
            get
            {
                return this.ServicePrincipalClientId();
            }
        }

        /// <summary>
        /// Gets the service principal secret.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IContainerService.ServicePrincipalSecret
        {
            get
            {
                return this.ServicePrincipalSecret();
            }
        }

    }
}