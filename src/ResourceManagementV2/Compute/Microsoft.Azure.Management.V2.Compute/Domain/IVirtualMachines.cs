/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition;
    /// <summary>
    /// Entry point to virtual machine management API.
    /// </summary>
    public interface IVirtualMachines  :
        ISupportsListing<IVirtualMachine>,
        ISupportsListingByGroup<IVirtualMachine>,
        ISupportsGettingByGroup<IVirtualMachine>,
        ISupportsGettingById<IVirtualMachine>,
        ISupportsCreating<IBlank>,
        ISupportsDeleting,
        ISupportsDeletingByGroup
    {
        /// <returns>entry point to virtual machine sizes</returns>
        IVirtualMachineSizes Sizes ();

        /// <summary>
        /// Shuts down the Virtual Machine and releases the compute resources.
        /// <p>
        /// You are not billed for the compute resources that this Virtual Machine uses
        /// </summary>
        /// <param name="groupName">groupName the resource group name</param>
        /// <param name="name">name the virtual machine name</param>
        void Deallocate (string groupName, string name);

        /// <summary>
        /// Generalize the Virtual Machine.
        /// </summary>
        /// <param name="groupName">groupName the resource group name</param>
        /// <param name="name">name the virtual machine name</param>
        void Generalize (string groupName, string name);

        /// <summary>
        /// Power off (stop) a virtual machine.
        /// <p>
        /// You will be billed for the compute resources that this Virtual Machine uses
        /// </summary>
        /// <param name="groupName">groupName the resource group name</param>
        /// <param name="name">name the virtual machine name</param>
        void PowerOff (string groupName, string name);

        /// <summary>
        /// Restart a virtual machine.
        /// </summary>
        /// <param name="groupName">groupName the resource group name</param>
        /// <param name="name">name the virtual machine name</param>
        void Restart (string groupName, string name);

        /// <summary>
        /// Start a virtual machine.
        /// </summary>
        /// <param name="groupName">groupName the resource group name</param>
        /// <param name="name">name the virtual machine name</param>
        void Start (string groupName, string name);

        /// <summary>
        /// Redeploy a virtual machine.
        /// </summary>
        /// <param name="groupName">groupName the resource group name</param>
        /// <param name="name">name the virtual machine name</param>
        void Redeploy (string groupName, string name);

        /// <summary>
        /// Captures the virtual machine by copying virtual hard disks of the VM and returns template as json
        /// string that can be used to create similar VMs.
        /// </summary>
        /// <param name="groupName">groupName the resource group name</param>
        /// <param name="name">name the virtual machine name</param>
        /// <param name="containerName">containerName destination container name to store the captured Vhd</param>
        /// <param name="overwriteVhd">overwriteVhd whether to overwrites destination vhd if it exists</param>
        /// <returns>the template as json string</returns>
        string Capture (string groupName, string name, string containerName, bool overwriteVhd);

    }
}