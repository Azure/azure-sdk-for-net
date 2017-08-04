// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Rest;

    internal partial class VirtualMachineScaleSetsImpl
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        VirtualMachineScaleSet.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<VirtualMachineScaleSet.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as VirtualMachineScaleSet.Definition.IBlank;
        }

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine in the scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetsBeta.PowerOffAsync(string groupName, string name, CancellationToken cancellationToken)
        {

            await this.PowerOffAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Starts the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSets.Start(string groupName, string name)
        {

            this.Start(groupName, name);
        }

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSets.Reimage(string groupName, string name)
        {

            this.Reimage(groupName, name);
        }

        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetsBeta.ReimageAsync(string groupName, string name, CancellationToken cancellationToken)
        {

            await this.ReimageAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSets.PowerOff(string groupName, string name)
        {

            this.PowerOff(groupName, name);
        }

        /// <summary>
        /// Starts the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetsBeta.StartAsync(string groupName, string name, CancellationToken cancellationToken)
        {

            await this.StartAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases the compute resources asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetsBeta.DeallocateAsync(string groupName, string name, CancellationToken cancellationToken)
        {

            await this.DeallocateAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases the compute resources.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSets.Deallocate(string groupName, string name)
        {

            this.Deallocate(groupName, name);
        }

        /// <summary>
        /// Restarts the virtual machines in the scale set.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <throws>CloudException thrown for an invalid response from the service.</throws>
        /// <throws>IOException exception thrown from serialization/deserialization.</throws>
        /// <throws>InterruptedException exception thrown when the operation is interrupted.</throws>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSets.Restart(string groupName, string name)
        {

            this.Restart(groupName, name);
        }

        /// <summary>
        /// Restarts the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The virtual machine scale set name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetsBeta.RestartAsync(string groupName, string name, CancellationToken cancellationToken)
        {

            await this.RestartAsync(groupName, name, cancellationToken);
        }

    }
}