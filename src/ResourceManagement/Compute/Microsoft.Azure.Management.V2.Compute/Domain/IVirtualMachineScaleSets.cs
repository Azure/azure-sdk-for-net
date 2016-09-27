// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition;
    /// <summary>
    /// Entry point to virtual machine scale set management API.
    /// </summary>
    public interface IVirtualMachineScaleSets  :
        ISupportsListing<IVirtualMachineScaleSet>,
        ISupportsListingByGroup<IVirtualMachineScaleSet>,
        ISupportsGettingByGroup<IVirtualMachineScaleSet>,
        ISupportsGettingById<IVirtualMachineScaleSet>,
        ISupportsCreating<IBlank>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<IVirtualMachineScaleSet>
    {
        /// <summary>
        /// Shuts down the Virtual Machine in the scale set and releases the compute resources.
        /// Note: You are not billed for the compute resources that the Virtual Machines uses
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine scale set is in</param>
        /// <param name="name">name the name of the virtual machine scale set</param>
        void Deallocate (string groupName, string name);

        /// <summary>
        /// Power off (stop) the virtual machines in the scale set.
        /// Note: You will be billed for the compute resources that the Virtual Machines uses.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine scale set is in</param>
        /// <param name="name">name the name of the virtual machine scale set</param>
        void PowerOff (string groupName, string name);

        /// <summary>
        /// Restart the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine scale set is in</param>
        /// <param name="name">name the name of the virtual machine scale set</param>
        void Restart (string groupName, string name);

        /// <summary>
        /// Start the virtual machines  in the scale set.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine scale set is in</param>
        /// <param name="name">name the name of the virtual machine scale set</param>
        void Start (string groupName, string name);

        /// <summary>
        /// Re-image (update the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine scale set is in</param>
        /// <param name="name">name the name of the virtual machine scale set</param>
        void Reimage (string groupName, string name);

    }
}