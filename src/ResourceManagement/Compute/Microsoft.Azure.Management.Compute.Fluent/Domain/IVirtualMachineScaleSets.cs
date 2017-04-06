// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using VirtualMachineScaleSet.Definition;
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point to virtual machine scale set management API.
    /// </summary>
    public interface IVirtualMachineScaleSets  :
        ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        ISupportsGettingById<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        ISupportsCreating<VirtualMachineScaleSet.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        ISupportsBatchDeletion,
        IHasManager<IComputeManager>,
        IHasInner<IVirtualMachineScaleSetsOperations>
    {
        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Reimage(string groupName, string name);

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        Task ReimageAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Restarts the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Restart(string groupName, string name);

        /// <summary>
        /// Restarts the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        Task RestartAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void PowerOff(string groupName, string name);

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        Task PowerOffAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Shuts down the virtual machine in the scale set and releases the compute resources.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Deallocate(string groupName, string name);

        /// <summary>
        /// Shuts down the virtual machine in the scale set and releases the compute resources.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        Task DeallocateAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Start(string groupName, string name);

        /// <summary>
        /// Starts the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        Task StartAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}