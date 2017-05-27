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
    internal partial class ContainerServiceAgentPoolImpl  :
        ChildResource<Models.ContainerServiceAgentPoolProfile,Microsoft.Azure.Management.Compute.Fluent.ContainerServiceImpl,Microsoft.Azure.Management.Compute.Fluent.IContainerService>,
        IContainerServiceAgentPool,
        ContainerServiceAgentPool.Definition.IDefinition<IContainerService>
    {
                public int Count()
        {
            //$ return this.Inner().Count();

            return 0;
        }

                public string DnsLabel()
        {
            //$ return this.Inner().DnsPrefix();

            return null;
        }

                public ContainerService.Definition.IDefinition Attach()
        {
            //$ this.Parent().AttachAgentPoolProfile(this);
            //$ return this.Parent();

            return null;
        }

                public override string Name()
        {
            //$ return this.Inner().Name();

            return null;
        }

                public ContainerServiceAgentPoolImpl WithLeafDomainLabel(string param0)
        {
            //$ this.Inner().WithDnsPrefix(param0);
            //$ return this;

            return this;
        }

                public string VMSize()
        {
            //$ return this.Inner().VmSize();

            return null;
        }

                public string Fqdn()
        {
            //$ return this.Inner().Fqdn();

            return null;
        }

        internal  ContainerServiceAgentPoolImpl(ContainerServiceAgentPoolProfile inner, ContainerServiceImpl parent) :
            base(inner, parent)
        {
            //$ super(inner, parent);
            //$ }

        }

                public ContainerServiceAgentPoolImpl WithVMCount(int agentPoolCount)
        {
            //$ if (agentPoolCount < 0 || agentPoolCount > 100) {
            //$ throw new RuntimeException("Agent pool count  must be in the range of 1 to 100 (inclusive)");
            //$ }
            //$ 
            //$ this.Inner().WithCount(agentPoolCount);
            //$ return this;

            return this;
        }

                public ContainerServiceAgentPoolImpl WithVMSize(string param0)
        {
            //$ this.Inner().WithVmSize(param0);
            //$ return this;

            return this;
        }
    }
}