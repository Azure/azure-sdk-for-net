// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using VirtualMachine.Definition;

    /// <summary>
    /// Entry point to virtual machine management API.
    /// </summary>
    public interface IVirtualMachines :
        ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        ISupportsGettingById<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        ISupportsCreating<VirtualMachine.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>
    {
        /// <return>Available virtual machine sizes.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSizes Sizes { get; }

        /// <summary>
        /// Restart a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Restart(string groupName, string name);

        /// <summary>
        /// Power off (stop) a virtual machine.
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
        /// Start a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Start(string groupName, string name);

        /// <summary>
        /// Generalize the virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Generalize(string groupName, string name);

        /// <summary>
        /// Redeploy a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Redeploy(string groupName, string name);

        /// <summary>
        /// Captures the virtual machine by copying virtual hard disks of the VM and returns template as json
        /// string that can be used to create similar VMs.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <param name="containerName">Destination container name to store the captured VHD.</param>
        /// <param name="vhdPrefix">The prefix for the vhd holding captured image.</param>
        /// <param name="overwriteVhd">Whether to overwrites destination VHD if it exists.</param>
        /// <return>The template as JSON string.</return>
        string Capture(string groupName, string name, string containerName, string vhdPrefix, bool overwriteVhd);
    }
}