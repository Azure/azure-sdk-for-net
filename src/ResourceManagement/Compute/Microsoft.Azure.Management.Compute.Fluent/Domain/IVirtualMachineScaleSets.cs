// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Compute
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition;
    /// <summary>
    /// Entry point to virtual machine scale set management API.
    /// </summary>
    public interface IVirtualMachineScaleSets  :
        ISupportsListing<Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet>,
        ISupportsGettingById<Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet>,
        ISupportsCreating<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IBlank>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet>
    {
        /// <summary>
        /// Shuts down the virtual machine in the scale set and releases the compute resources.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine scale set is in</param>
        /// <param name="name">name the name of the virtual machine scale set</param>
        void Deallocate(string groupName, string name);

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine scale set is in</param>
        /// <param name="name">name the name of the virtual machine scale set</param>
        void PowerOff(string groupName, string name);

        /// <summary>
        /// Restarts the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine scale set is in</param>
        /// <param name="name">name the name of the virtual machine scale set</param>
        void Restart(string groupName, string name);

        /// <summary>
        /// Starts the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine scale set is in</param>
        /// <param name="name">name the name of the virtual machine scale set</param>
        void Start(string groupName, string name);

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">groupName the name of the resource group the virtual machine scale set is in</param>
        /// <param name="name">name the name of the virtual machine scale set</param>
        void Reimage(string groupName, string name);

    }
}