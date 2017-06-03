// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.ContainerService.Update;
    using Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The implementation for ContainerService and its create and update interfaces.
    /// </summary>
    internal partial class ContainerServiceImpl :
         GroupableResource<IContainerService,
        ContainerServiceInner,
        ContainerServiceImpl,
        IComputeManager,
        ContainerService.Definition.IWithGroup,
        ContainerService.Definition.IWithOrchestrator,
        ContainerService.Definition.IWithCreate,
        ContainerService.Update.IUpdate>,
        IContainerService,
        IDefinition,
        IUpdate
    {
        IComputeManager IHasManager<IComputeManager>.Manager
        {
            get
            {
                return this.Manager;
            }
        }

        public int AgentPoolCount()
        {
            if (this.GetSingleAgentPool() == null)
            {
                return 0;
            }

            return this.GetSingleAgentPool().Count;
        }

        public int MasterNodeCount()
        {
            if (this.Inner.MasterProfile == null
            || this.Inner.MasterProfile.Count == null
            || !this.Inner.MasterProfile.Count.HasValue)
            {
                return 0;
            }

            return this.Inner.MasterProfile.Count.Value;
        }

        public ContainerServiceImpl WithoutDiagnostics()
        {
            this.WithDiagnosticsProfile(false);
            return this;

            return this;
        }

        internal void AttachAgentPoolProfile(IContainerServiceAgentPool agentPoolProfile)
        {
            this.Inner.AgentPoolProfiles.Add(agentPoolProfile.Inner);
        }

        public ContainerServiceImpl WithSwarmOrchestration()
        {
            this.WithOrchestratorProfile(ContainerServiceOchestratorTypes.Swarm);
            return this;
        }

        private ContainerServiceImpl WithDiagnosticsProfile(bool enabled)
        {
            if (this.Inner.DiagnosticsProfile == null)
            {
                this.Inner.DiagnosticsProfile = new ContainerServiceDiagnosticsProfile();
            }

            if (this.Inner.DiagnosticsProfile.VmDiagnostics == null)
            {
                this.Inner.DiagnosticsProfile.VmDiagnostics = new ContainerServiceVMDiagnostics();
            }

            this.Inner.DiagnosticsProfile.VmDiagnostics.Enabled = enabled;
            return this;
        }

        public ContainerServiceImpl WithSshKey(string sshKeyData)
        {
            ContainerServiceSshConfiguration ssh = new ContainerServiceSshConfiguration();
            ssh.PublicKeys = new List<ContainerServiceSshPublicKey>();
            ContainerServiceSshPublicKey sshPublicKey = new ContainerServiceSshPublicKey();
            sshPublicKey.KeyData = sshKeyData;
            ssh.PublicKeys.Add(sshPublicKey);
            this.Inner.LinuxProfile.Ssh = ssh;
            return this;
        }

        public ContainerServiceImpl WithKubernetesOrchestration()
        {
            this.WithOrchestratorProfile(ContainerServiceOchestratorTypes.Kubernetes);
            return this;
        }

        public bool IsDiagnosticsEnabled()
        {
            if (this.Inner.DiagnosticsProfile == null
            || this.Inner.DiagnosticsProfile.VmDiagnostics == null)
            {
                throw new Exception("Diagnostic profile is missing!");
            }

            return this.Inner.DiagnosticsProfile.VmDiagnostics.Enabled;
        }

        public ContainerServiceImpl WithRootUsername(string rootUserName)
        {
            this.Inner.LinuxProfile.AdminUsername = rootUserName;
            return this;
        }

        private ContainerServiceAgentPoolProfile GetSingleAgentPool()
        {
            if (this.Inner.AgentPoolProfiles == null
            || this.Inner.AgentPoolProfiles.Count == 0)
            {
                return null;
            }

            return this.Inner.AgentPoolProfiles[0];
        }

        public string LinuxRootUsername()
        {
            if (this.Inner.LinuxProfile == null)
            {
                return null;
            }

            return this.Inner.LinuxProfile.AdminUsername;
        }

        public override async Task<Microsoft.Azure.Management.Compute.Fluent.IContainerService> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var containerService = await this.Manager.Inner.ContainerServices.CreateOrUpdateAsync(ResourceGroupName, Name, Inner);
            this.SetInner(containerService);
            return this;
        }

        public string MasterFqdn()
        {
            if (this.Inner.MasterProfile == null)
            {
                return null;
            }

            return this.Inner.MasterProfile.Fqdn;
        }

        public ContainerServiceImpl WithDcosOrchestration()
        {
            this.WithOrchestratorProfile(ContainerServiceOchestratorTypes.DCOS);
            return this;
        }

        public string SshKey()
        {
            if (this.Inner.LinuxProfile == null
            || this.Inner.LinuxProfile.Ssh == null
            || this.Inner.LinuxProfile.Ssh.PublicKeys == null
            || this.Inner.LinuxProfile.Ssh.PublicKeys.Count == 0)
            {
                return null;
            }

            return this.Inner.LinuxProfile.Ssh.PublicKeys[0].KeyData;
        }

        public string AgentPoolLeafDomainLabel()
        {
            if (this.GetSingleAgentPool() == null)
            {
                return null;
            }

            return this.GetSingleAgentPool().DnsPrefix;
        }

        internal ContainerServiceImpl(string name, ContainerServiceInner innerObject, IComputeManager manager) :
            base(name, innerObject, manager)
        {
            if (this.Inner.AgentPoolProfiles == null)
            {
                this.Inner.AgentPoolProfiles = new List<ContainerServiceAgentPoolProfile>();
            }
        }

        public ContainerServiceImpl WithAgentVMCount(int agentCount)
        {
            this.GetSingleAgentPool().Count = agentCount;
            return this;
        }

        public ContainerServiceImpl WithMasterNodeCount(ContainerServiceMasterProfileCount profileCount)
        {
            ContainerServiceMasterProfile masterProfile = new ContainerServiceMasterProfile();
            masterProfile.Count = (int)profileCount;
            this.Inner.MasterProfile = masterProfile;
            return this;
        }

        public ContainerServiceImpl WithDiagnostics()
        {
            this.WithDiagnosticsProfile(true);
            return this;
        }

        public string AgentPoolName()
        {
            if (this.GetSingleAgentPool() == null)
            {
                return null;
            }

            return this.GetSingleAgentPool().Name;
        }

        public ContainerServiceOchestratorTypes OrchestratorType()
        {
            if (this.Inner.OrchestratorProfile == null)
            {
                throw new Exception("Orchestrator profile is missing!");
            }

            return this.Inner.OrchestratorProfile.OrchestratorType;
        }

        public ContainerServiceImpl WithMasterLeafDomainLabel(string dnsPrefix)
        {
            this.Inner.MasterProfile.DnsPrefix = dnsPrefix;
            return this;
        }

        public string AgentPoolFqdn()
        {
            if (this.GetSingleAgentPool() == null)
            {
                return null;
            }

            return this.GetSingleAgentPool().Fqdn;

            return null;
        }

        public string MasterLeafDomainLabel()
        {
            if (this.Inner.MasterProfile == null)
            {
                return null;
            }

            return this.Inner.MasterProfile.DnsPrefix;

            return null;
        }


        private ContainerServiceImpl WithOrchestratorProfile(ContainerServiceOchestratorTypes orchestratorType)
        {
            ContainerServiceOrchestratorProfile orchestratorProfile = new ContainerServiceOrchestratorProfile();
            orchestratorProfile.OrchestratorType = orchestratorType;
            this.Inner.OrchestratorProfile = orchestratorProfile;
            return this;
        }

        public string AgentPoolVMSize()
        {
            if (this.GetSingleAgentPool() == null)
            {
                return "Unknown";
            }

            return this.GetSingleAgentPool().VmSize;
        }

        public ContainerServiceAgentPoolImpl DefineAgentPool(string name)
        {
            ContainerServiceAgentPoolProfile innerPoolProfile = new ContainerServiceAgentPoolProfile();
            innerPoolProfile.Name = name;
            return new ContainerServiceAgentPoolImpl(innerPoolProfile, this);
        }

        public ContainerServiceImpl WithLinux()
        {
            if (this.Inner.LinuxProfile == null)
            {
                this.Inner.LinuxProfile = new ContainerServiceLinuxProfile();
            }

            return this;
        }

        protected override async Task<ContainerServiceInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.ContainerServices.GetAsync(this.ResourceGroupName, this.Name);
        }

        public IWithLinux WithServicePrincipal(string clientId, string secret)
        {
            ContainerServiceServicePrincipalProfile serviceProfile =
                new ContainerServiceServicePrincipalProfile();
            serviceProfile.ClientId = clientId;
            serviceProfile.Secret = secret;
            this.Inner.ServicePrincipalProfile = serviceProfile;
            return this;
        }

        public string ServicePrincipalClientId()
        {
            if (this.Inner.ServicePrincipalProfile == null)
            {
                return null;
            }

            return this.Inner.ServicePrincipalProfile.ClientId;
        }

        public string ServicePrincipalSecret()
        {
            if (this.Inner.ServicePrincipalProfile == null)
            {
                return null;
            }

            return this.Inner.ServicePrincipalProfile.Secret;
        }
    }
}