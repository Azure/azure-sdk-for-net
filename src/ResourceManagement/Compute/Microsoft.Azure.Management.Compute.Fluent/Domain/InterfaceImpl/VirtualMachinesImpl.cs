// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using VirtualMachine.Definition;
    using Models;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Collections.Generic;

    internal partial class VirtualMachinesImpl 
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is Creatable.create().
        /// Note that the Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        VirtualMachine.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<VirtualMachine.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as VirtualMachine.Definition.IBlank;
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>.ListByResourceGroup(string resourceGroupName)
        {
            return this.ListByResourceGroup(resourceGroupName);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name and the name of its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the resource is in.</param>
        /// <param name="name">The name of the resource. (Note, this is not the ID).</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>.GetByResourceGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken)
        {
            return await this.GetByResourceGroupAsync(resourceGroupName, name, cancellationToken) as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine;
        }

        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="groupName">The group the resource is part of.</param>
        /// <param name="name">The name of the resource.</param>
        /// <return>A completable indicates completion or exception of the request.</return>
        async Task Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup.DeleteByResourceGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.DeleteByResourceGroupAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>.List()
        {
            return this.List();
        }

        /// <summary>
        /// Start a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Start(string groupName, string name)
        {
            ((IVirtualMachines)this).StartAsync(groupName, name).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Start a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.StartAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.StartAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Power off (stop) a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.PowerOff(string groupName, string name)
        {
             ((IVirtualMachines)this).PowerOffAsync(groupName, name).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Power off (stop) a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        async Task IVirtualMachines.PowerOffAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.PowerOffAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Generalize the virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Generalize(string groupName, string name)
        {
             ((IVirtualMachines)this).GeneralizeAsync(groupName, name).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Generalize the virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.GeneralizeAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.GeneralizeAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Redeploy a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Redeploy(string groupName, string name)
        { 
            ((IVirtualMachines)this).RedeployAsync(groupName, name).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Redeploy a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.RedeployAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.RedeployAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Convert (migrate) the virtual machine with un-managed disks to use managed disk.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.ConvertToManaged(string groupName, string name)
        {
             ((IVirtualMachines)this).ConvertToManagedAsync(groupName, name).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Convert (migrate) the virtual machine with un-managed disks to use managed disk.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.ConvertToManagedAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.ConvertToManagedAsync(groupName, name, cancellationToken);
        }

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
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Capture(string groupName, string name, string containerName, string vhdPrefix, bool overwriteVhd)
        {
            return ((IVirtualMachines)this).CaptureAsync(groupName, name, containerName, vhdPrefix, overwriteVhd).ConfigureAwait(false).GetAwaiter().GetResult();
        }

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
        async Task<string> IVirtualMachines.CaptureAsync(string groupName, string name, string containerName, string vhdPrefix, bool overwriteVhd, CancellationToken cancellationToken)
        {
            return await this.CaptureAsync(groupName, name, containerName, vhdPrefix, overwriteVhd, cancellationToken);
        }

        /// <summary>
        /// Shuts down the virtual machine and releases the compute resources.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Deallocate(string groupName, string name)
        { 
            ((IVirtualMachines)this).DeallocateAsync(groupName, name).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Shuts down the virtual machine and releases the compute resources.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        async Task IVirtualMachines.DeallocateAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.DeallocateAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Restart a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Restart(string groupName, string name)
        {
             ((IVirtualMachines)this).RestartAsync(groupName, name).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Restart a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.RestartAsync(
            string groupName, 
            string name, 
            CancellationToken cancellationToken)
        {
            await this.RestartAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Gets available virtual machine sizes.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSizes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Sizes
        {
            get
            {
                return this.Sizes() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSizes;
            }
        }
    }
}