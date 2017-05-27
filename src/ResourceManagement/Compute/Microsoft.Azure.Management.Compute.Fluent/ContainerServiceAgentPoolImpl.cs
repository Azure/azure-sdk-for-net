// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The implementation for  ContainerServiceAgentPool and its create and update interfaces.
    /// </summary>
    internal partial class ContainerServiceAgentPoolImpl :
        ChildResource<Models.ContainerServiceAgentPoolProfile, Microsoft.Azure.Management.Compute.Fluent.ContainerServiceImpl, Microsoft.Azure.Management.Compute.Fluent.IContainerService>,
        IContainerServiceAgentPool,
        ContainerServiceAgentPool.Definition.IDefinition<IContainerService>
    {
        public int Count()
        {
            return this.Inner.Count;
        }

        public string DnsLabel()
        {
            return this.Inner.DnsPrefix;
        }

        public ContainerService.Definition.IDefinition Attach()
        {
            this.Parent.AttachAgentPoolProfile(this);
            return this.Parent;
        }

        public override string Name()
        {
            return this.Inner.Name;
        }

        public ContainerServiceAgentPoolImpl WithLeafDomainLabel(string param0)
        {
            this.Inner.DnsPrefix = param0;
            return this;

            return this;
        }

        public string VMSize()
        {
            return this.Inner.VmSize;
        }

        public string Fqdn()
        {
            return this.Inner.Fqdn;
        }

        internal ContainerServiceAgentPoolImpl(ContainerServiceAgentPoolProfile inner, ContainerServiceImpl parent) :
            base(inner, parent)
        {
        }

        public ContainerServiceAgentPoolImpl WithVMCount(int agentPoolCount)
        {
            this.Inner.Count = agentPoolCount;
            return this;
        }

        public ContainerServiceAgentPoolImpl WithVMSize(string param0)
        {
            this.Inner.VmSize = param0;
            return this;
        }
    }
}