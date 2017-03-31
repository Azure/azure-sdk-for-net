// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class VirtualMachineScaleSetVMImpl 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM;
        }

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
        /// Gets the name of the region the resource is in.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.RegionName
        {
            get
            {
                return this.RegionName();
            }
        }

        /// <summary>
        /// Gets the tags for the resource.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Tags
        {
            get
            {
                return this.Tags() as System.Collections.Generic.IReadOnlyDictionary<string,string>;
            }
        }

        /// <summary>
        /// Gets the region the resource is in.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Region
        {
            get
            {
                return this.Region() as Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region;
            }
        }

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Restarts the virtual machine instance.
        /// </summary>
        /// <return>The observable to the restart action.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.RestartAsync(CancellationToken cancellationToken)
        {
 
            await this.RestartAsync(cancellationToken);
        }

        /// <summary>
        /// Gets true if this is a Windows virtual machine and VM agent is provisioned, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.IsWindowsVMAgentProvisioned
        {
            get
            {
                return this.IsWindowsVMAgentProvisioned();
            }
        }

        /// <summary>
        /// Gets vhd uri of the custom image that the virtual machine instance operating system is based on,
        /// null will be returned if the operating system is based on platform image.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.StoredImageUnmanagedVhdUri
        {
            get
            {
                return this.StoredImageUnmanagedVhdUri();
            }
        }

        /// <summary>
        /// Gets resource id of primary network interface associated with virtual machine instance.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.PrimaryNetworkInterfaceId
        {
            get
            {
                return this.PrimaryNetworkInterfaceId();
            }
        }

        /// <summary>
        /// Stops the virtual machine instance.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.PowerOff()
        {
 
            this.PowerOff();
        }

        /// <summary>
        /// Gets the time zone of the Windows virtual machine.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.WindowsTimeZone
        {
            get
            {
                return this.WindowsTimeZone();
            }
        }

        /// <summary>
        /// Gets Gets the instance view of the virtual machine instance.
        /// To get the latest instance view use VirtualMachineScaleSetVM.refreshInstanceView().
        /// </summary>
        /// <summary>
        /// Gets the instance view.
        /// </summary>
        Models.VirtualMachineInstanceView Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.InstanceView
        {
            get
            {
                return this.InstanceView() as Models.VirtualMachineInstanceView;
            }
        }

        /// <summary>
        /// Gets the name of the admin user.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.AdministratorUserName
        {
            get
            {
                return this.AdministratorUserName();
            }
        }

        /// <summary>
        /// Gets virtual machine instance size.
        /// </summary>
        Models.VirtualMachineSizeTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Size
        {
            get
            {
                return this.Size() as Models.VirtualMachineSizeTypes;
            }
        }

        /// <summary>
        /// Gets true if this is a Windows virtual machine and automatic update is turned on, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.IsWindowsAutoUpdateEnabled
        {
            get
            {
                return this.IsWindowsAutoUpdateEnabled();
            }
        }

        /// <summary>
        /// Updates the version of the installed operating system in the virtual machine instance.
        /// </summary>
        /// <return>The observable to the reimage action.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.ReimageAsync(CancellationToken cancellationToken)
        {
 
            await this.ReimageAsync(cancellationToken);
        }

        /// <summary>
        /// Gets true if the boot diagnostic is enabled, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.BootDiagnosticEnabled
        {
            get
            {
                return this.BootDiagnosticEnabled();
            }
        }

        /// <summary>
        /// Gets resource id of the managed disk backing OS disk.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.OsDiskId
        {
            get
            {
                return this.OsDiskId();
            }
        }

        /// <return>
        /// The platform image that the virtual machine instance operating system is based on, null be
        /// returned otherwise.
        /// </return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.GetOSPlatformImage()
        {
            return this.GetOSPlatformImage() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage;
        }

        /// <summary>
        /// Gets the list of resource id of network interface associated with the virtual machine instance.
        /// </summary>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.NetworkInterfaceIds
        {
            get
            {
                return this.NetworkInterfaceIds() as System.Collections.Generic.IList<string>;
            }
        }

        /// <summary>
        /// Gets the operating system profile of an virtual machine instance.
        /// </summary>
        Models.OSProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.OsProfile
        {
            get
            {
                return this.OsProfile() as Models.OSProfile;
            }
        }

        /// <summary>
        /// Stops the virtual machine instance.
        /// </summary>
        /// <return>The observable to the poweroff action.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.PowerOffAsync(CancellationToken cancellationToken)
        {
 
            await this.PowerOffAsync(cancellationToken);
        }

        /// <summary>
        /// Refreshes the instance view.
        /// </summary>
        /// <return>The instance view.</return>
        Models.VirtualMachineInstanceView Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.RefreshInstanceView()
        {
            return this.RefreshInstanceView() as Models.VirtualMachineInstanceView;
        }

        /// <summary>
        /// Deletes the virtual machine instance.
        /// </summary>
        /// <return>The observable to the delete action.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.DeleteAsync(CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(cancellationToken);
        }

        /// <summary>
        /// Gets true if the operating system of the virtual machine instance is based on custom image.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.IsOSBasedOnCustomImage
        {
            get
            {
                return this.IsOSBasedOnCustomImage();
            }
        }

        /// <summary>
        /// Gets the diagnostics profile of the virtual machine instance.
        /// </summary>
        Models.DiagnosticsProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.DiagnosticsProfile
        {
            get
            {
                return this.DiagnosticsProfile() as Models.DiagnosticsProfile;
            }
        }

        /// <return>
        /// The custom image that the virtual machine instance operating system is based on, null be
        /// returned otherwise.
        /// </return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.GetOSCustomImage()
        {
            return this.GetOSCustomImage() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage;
        }

        /// <summary>
        /// Starts the virtual machine instance.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Start()
        {
 
            this.Start();
        }

        /// <summary>
        /// Gets reference to the platform image that the virtual machine instance operating system is based on,
        /// null will be returned if the operating system is based on custom image.
        /// </summary>
        ImageReference Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.PlatformImageReference
        {
            get
            {
                return this.PlatformImageReference() as ImageReference;
            }
        }

        /// <summary>
        /// Shuts down the virtual machine instance and releases the associated compute resources.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Deallocate()
        {
 
            this.Deallocate();
        }

        /// <summary>
        /// Updates the version of the installed operating system in the virtual machine instance.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Reimage()
        {
 
            this.Reimage();
        }

        /// <summary>
        /// Starts the virtual machine instance.
        /// </summary>
        /// <return>The observable to the start action.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.StartAsync(CancellationToken cancellationToken)
        {
 
            await this.StartAsync(cancellationToken);
        }

        /// <summary>
        /// Gets true if the operating system of the virtual machine instance is based on platform image.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.IsOSBasedOnPlatformImage
        {
            get
            {
                return this.IsOSBasedOnPlatformImage();
            }
        }

        /// <summary>
        /// Gets the sku of the virtual machine instance, this will be sku used while creating the parent
        /// virtual machine scale set.
        /// </summary>
        Models.Sku Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Sku
        {
            get
            {
                return this.Sku() as Models.Sku;
            }
        }

        /// <summary>
        /// Gets the managed data disks associated with this virtual machine instance, indexed by lun.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.DataDisks
        {
            get
            {
                return this.DataDisks() as System.Collections.Generic.IReadOnlyDictionary<int,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk>;
            }
        }

        /// <summary>
        /// Gets the unmanaged data disks associated with this virtual machine instance, indexed by lun.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.UnmanagedDataDisks
        {
            get
            {
                return this.UnmanagedDataDisks() as System.Collections.Generic.IReadOnlyDictionary<int,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk>;
            }
        }

        /// <summary>
        /// Gets true if the latest scale set model changes are applied to the virtual machine instance.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.IsLatestScaleSetUpdateApplied
        {
            get
            {
                return this.IsLatestScaleSetUpdateApplied();
            }
        }

        /// <summary>
        /// Gets true if this is a Linux virtual machine and password based login is enabled, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.IsLinuxPasswordAuthenticationEnabled
        {
            get
            {
                return this.IsLinuxPasswordAuthenticationEnabled();
            }
        }

        /// <return>The network interfaces associated with this virtual machine instance.</return>
        IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.ListNetworkInterfaces()
        {
            return this.ListNetworkInterfaces();
        }

        /// <summary>
        /// Gets the operating system type.
        /// </summary>
        Models.OperatingSystemTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.OsType
        {
            get
            {
                return this.OsType();
            }
        }

        /// <summary>
        /// Gets true if managed disk is used for the virtual machine's disks (os, data).
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.IsManagedDiskEnabled
        {
            get
            {
                return this.IsManagedDiskEnabled();
            }
        }

        /// <summary>
        /// Deletes the virtual machine instance.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Delete()
        {
 
            this.Delete();
        }

        /// <summary>
        /// Gets the virtual machine instance computer name with prefix VirtualMachineScaleSet.computerNamePrefix().
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.ComputerName
        {
            get
            {
                return this.ComputerName();
            }
        }

        /// <summary>
        /// Gets the power state of the virtual machine instance.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.PowerState Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.PowerState
        {
            get
            {
                return this.PowerState() as Microsoft.Azure.Management.Compute.Fluent.PowerState;
            }
        }

        /// <summary>
        /// Gets true if the operating system of the virtual machine instance is based on stored image.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.IsOSBasedOnStoredImage
        {
            get
            {
                return this.IsOSBasedOnStoredImage();
            }
        }

        /// <summary>
        /// Gets the resource id of the availability set that this virtual machine instance belongs to.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.AvailabilitySetId
        {
            get
            {
                return this.AvailabilitySetId();
            }
        }

        /// <summary>
        /// Gets the storage profile of the virtual machine instance.
        /// </summary>
        Models.StorageProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.StorageProfile
        {
            get
            {
                return this.StorageProfile() as Models.StorageProfile;
            }
        }

        /// <summary>
        /// Gets the name of the operating system disk.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.OsDiskName
        {
            get
            {
                return this.OsDiskName();
            }
        }

        /// <summary>
        /// Shuts down the virtual machine instance and releases the associated compute resources.
        /// </summary>
        /// <return>The observable to the deallocate action.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.DeallocateAsync(CancellationToken cancellationToken)
        {
 
            await this.DeallocateAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the caching type of the operating system disk.
        /// </summary>
        Models.CachingTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.OsDiskCachingType
        {
            get
            {
                return this.OsDiskCachingType();
            }
        }

        /// <summary>
        /// Gets a network interface associated with this virtual machine instance.
        /// </summary>
        /// <param name="name">The name of the network interface.</param>
        /// <return>The network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.GetNetworkInterface(string name)
        {
            return this.GetNetworkInterface(name) as Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface;
        }

        /// <summary>
        /// Gets the extensions associated with the virtual machine instance, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMInstanceExtension> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Extensions
        {
            get
            {
                return this.Extensions() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMInstanceExtension>;
            }
        }

        /// <summary>
        /// Restarts the virtual machine instance.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Restart()
        {
 
            this.Restart();
        }

        /// <summary>
        /// Gets vhd uri to the operating system disk.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.OsUnmanagedDiskVhdUri
        {
            get
            {
                return this.OsUnmanagedDiskVhdUri();
            }
        }

        /// <summary>
        /// Gets the instance id assigned to this virtual machine instance.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.InstanceId
        {
            get
            {
                return this.InstanceId();
            }
        }

        /// <summary>
        /// Gets the size of the operating system disk.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.OsDiskSizeInGB
        {
            get
            {
                return this.OsDiskSizeInGB();
            }
        }

        /// <summary>
        /// Gets the uri to the storage account storing boot diagnostics log.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.BootDiagnosticStorageAccountUri
        {
            get
            {
                return this.BootDiagnosticStorageAccountUri();
            }
        }
    }
}