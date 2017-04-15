// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Storage.Fluent;

    internal partial class VirtualMachinesImpl 
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
        VirtualMachine.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<VirtualMachine.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as VirtualMachine.Definition.IBlank;
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

        /// <summary>
        /// Starts a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Start(string groupName, string name)
        {
 
            this.StartAsync(groupName, name).GetAwaiter().GetResult(); ;
        }

        /// <summary>
        /// Powers off (stops) a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.PowerOff(string groupName, string name)
        {
 
            this.PowerOffAsync(groupName, name).GetAwaiter().GetResult(); ;
        }

        /// <summary>
        /// Generalizes the virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Generalize(string groupName, string name)
        {
 
            this.GeneralizeAsync(groupName, name).GetAwaiter().GetResult(); ;
        }

        /// <summary>
        /// Redeploys a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Redeploy(string groupName, string name)
        {
 
            this.RedeployAsync(groupName, name).GetAwaiter().GetResult(); ;
        }

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
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Capture(string groupName, string name, string containerName, string vhdPrefix, bool overwriteVhd)
        {
            return this.CaptureAsync(groupName, name, containerName, vhdPrefix, overwriteVhd).GetAwaiter().GetResult(); ;
        }

        /// <summary>
        /// Restarts a virtual machine.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Restart(string groupName, string name)
        {
 
            this.RestartAsync(groupName, name).GetAwaiter().GetResult(); ;
        }

        /// <summary>
        /// Shuts down the virtual machine and releases the compute resources.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachines.Deallocate(string groupName, string name)
        {
 
            this.DeallocateAsync(groupName, name).GetAwaiter().GetResult(); ;
        }
    }
}