// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.ContainerService.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.ContainerServiceAgentPool.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    internal partial class ContainerServiceAgentPoolImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Specifies the size of the agents VMs.
        /// </summary>
        /// <param name="vmSize">The size of the VM.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithLeafDomainLabel<IContainerService> ContainerServiceAgentPool.Definition.IWithVMSize<IContainerService>.WithVMSize(string vmSize)
        {
            return this.WithVMSize(vmSize) as ContainerServiceAgentPool.Definition.IWithLeafDomainLabel<IContainerService>;
        }

        /// <summary>
        /// Gets size of agent VMs.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IContainerServiceAgentPool.VMSize
        {
            get
            {
                return this.VMSize();
            }
        }

        /// <summary>
        /// Gets FDQN for the agent pool.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IContainerServiceAgentPool.Fqdn
        {
            get
            {
                return this.Fqdn();
            }
        }

        /// <summary>
        /// Gets the number of agents (VMs) to host docker containers.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IContainerServiceAgentPool.Count
        {
            get
            {
                return this.Count();
            }
        }

        /// <summary>
        /// Gets DNS prefix to be used to create the FQDN for the agent pool.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IContainerServiceAgentPool.DnsLabel
        {
            get
            {
                return this.DnsLabel();
            }
        }

        /// <summary>
        /// Specify the DNS prefix to be used to create the FQDN for the agent pool.
        /// </summary>
        /// <param name="dnsLabel">The Dns label.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithAttach<IContainerService> ContainerServiceAgentPool.Definition.IWithLeafDomainLabel<IContainerService>.WithLeafDomainLabel(string dnsLabel)
        {
            return this.WithLeafDomainLabel(dnsLabel) as ContainerServiceAgentPool.Definition.IWithAttach<IContainerService>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        IContainerService Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<IContainerService>.Attach()
        {
            return this.Attach() as IContainerService;
        }

        /// <summary>
        /// Specifies the number of agents (VMs) to host docker containers.
        /// Allowed values must be in the range of 1 to 100 (inclusive).
        /// </summary>
        /// <param name="count">The count.</param>
        /// <return>The next stage of the definition.</return>
        ContainerServiceAgentPool.Definition.IWithVMSize<IContainerService> ContainerServiceAgentPool.Definition.IBlank<IContainerService>.WithVMCount(int count)
        {
            return this.WithVMCount(count) as ContainerServiceAgentPool.Definition.IWithVMSize<IContainerService>;
        }
    }
}