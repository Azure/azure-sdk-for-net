// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    /// <summary>
    /// Entry point to virtual machine management API.
    /// </summary>
    public interface IVirtualMachines :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<VirtualMachine.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Compute.Fluent.IComputeManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinesOperations>,
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinesBeta
    {
        /// <summary>
        /// Restarts a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Restart(string groupName, string name);

        /// <summary>
        /// Powers off (stops) a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void PowerOff(string groupName, string name);

        /// <summary>
        /// Shuts down the virtual machine and releases the compute resources.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Deallocate(string groupName, string name);

        /// <summary>
        /// Starts a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Start(string groupName, string name);

        /// <summary>
        /// Migrates the virtual machine with unmanaged disks to use managed disks.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        void MigrateToManaged(string groupName, string name);

        /// <summary>
        /// Captures the virtual machine by copying virtual hard disks of the VM and returns template as a JSON
        /// string that can be used to create similar VMs.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <param name="containerName">Destination container name to store the captured VHD.</param>
        /// <param name="vhdPrefix">The prefix for the VHD holding captured image.</param>
        /// <param name="overwriteVhd">Whether to overwrites destination VHD if it exists.</param>
        /// <return>The template as JSON string.</return>
        string Capture(string groupName, string name, string containerName, string vhdPrefix, bool overwriteVhd);

        /// <summary>
        /// Gets available virtual machine sizes.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSizes Sizes { get; }

        /// <summary>
        /// Generalizes the virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Generalize(string groupName, string name);

        /// <summary>
        /// Redeploys a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Redeploy(string groupName, string name);
    }
}