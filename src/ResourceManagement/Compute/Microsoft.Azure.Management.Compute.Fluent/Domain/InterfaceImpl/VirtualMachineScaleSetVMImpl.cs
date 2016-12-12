// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System.Collections.Generic;
    using System.Threading;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    internal partial class VirtualMachineScaleSetVMImpl
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM;
        }

        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>The name of the region the resource is in.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IResource.RegionName
        {
            get
            {
                return this.RegionName() as string;
            }
        }

        /// <return>The tags for the resource.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Microsoft.Azure.Management.Resource.Fluent.Core.IResource.Tags
        {
            get
            {
                return this.Tags() as System.Collections.Generic.IReadOnlyDictionary<string, string>;
            }
        }

        /// <return>The region the resource is in.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Microsoft.Azure.Management.Resource.Fluent.Core.IResource.Region
        {
            get
            {
                return this.Region() as Microsoft.Azure.Management.Resource.Fluent.Core.Region;
            }
        }

        /// <return>The type of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IResource.Type
        {
            get
            {
                return this.Type() as string;
            }
        }

        /// <return>The resource ID string.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id() as string;
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

        /// <return>True if this is a Windows virtual machine and Vm agent is provisioned, false otherwise.</return>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.IsWindowsVmAgentProvisioned
        {
            get
            {
                return this.IsWindowsVmAgentProvisioned();
            }
        }

        /// <return>Resource id of primary network interface associated with virtual machine instance.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.PrimaryNetworkInterfaceId
        {
            get
            {
                return this.PrimaryNetworkInterfaceId() as string;
            }
        }

        /// <summary>
        /// Stops the virtual machine instance.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.PowerOff()
        {

            this.PowerOff();
        }

        /// <return>The time zone of the Windows virtual machine.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.WindowsTimeZone
        {
            get
            {
                return this.WindowsTimeZone() as string;
            }
        }

        /// <return>
        /// True if the operating system of the virtual machine instance is based on platform image,
        /// false if based on custom image.
        /// </return>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.IsOsBasedOnPlatformImage
        {
            get
            {
                return this.IsOsBasedOnPlatformImage();
            }
        }

        /// <summary>
        /// Gets the instance view of the virtual machine instance.
        /// <p>
        /// To get the latest instance view use VirtualMachineScaleSetVM.refreshInstanceView().
        /// </summary>
        /// <return>The instance view.</return>
        Models.VirtualMachineInstanceView Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.InstanceView
        {
            get
            {
                return this.InstanceView() as Models.VirtualMachineInstanceView;
            }
        }

        /// <return>The name of the admin user.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.AdministratorUserName
        {
            get
            {
                return this.AdministratorUserName() as string;
            }
        }

        /// <return>Virtual machine instance size.</return>
        Models.VirtualMachineSizeTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Size
        {
            get
            {
                return this.Size() as Models.VirtualMachineSizeTypes;
            }
        }

        /// <return>True if this is a Windows virtual machine and automatic update is turned on, false otherwise.</return>
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

        /// <return>True if the boot diagnostic is enabled, false otherwise.</return>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.BootDiagnosticEnabled
        {
            get
            {
                return this.BootDiagnosticEnabled();
            }
        }

        /// <return>The list of resource id of network interface associated with the virtual machine instance.</return>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.NetworkInterfaceIds
        {
            get
            {
                return this.NetworkInterfaceIds() as System.Collections.Generic.IList<string>;
            }
        }

        /// <return>The operating system profile of an virtual machine instance.</return>
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

        /// <return>The diagnostics profile of the virtual machine instance.</return>
        Models.DiagnosticsProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.DiagnosticsProfile
        {
            get
            {
                return this.DiagnosticsProfile() as Models.DiagnosticsProfile;
            }
        }

        /// <summary>
        /// Starts the virtual machine instance.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Start()
        {

            this.Start();
        }

        /// <return>
        /// Reference to the platform image that the virtual machine instance operating system is based on,
        /// null will be returned if the operating system is based on custom image.
        /// </return>
        Models.ImageReference Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.PlatformImageReference
        {
            get
            {
                return this.PlatformImageReference() as Models.ImageReference;
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

        /// <return>
        /// The sku of the virtual machine instance, this will be sku used while creating the parent
        /// virtual machine scale set.
        /// </return>
        Models.Sku Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Sku
        {
            get
            {
                return this.Sku() as Models.Sku;
            }
        }

        /// <return>True if the latest scale set model changes are applied to the virtual machine instance.</return>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.IsLatestScaleSetUpdateApplied
        {
            get
            {
                return this.IsLatestScaleSetUpdateApplied();
            }
        }

        /// <return>
        /// The platform image that the virtual machine instance operating system is based on, null be
        /// returned if the operating system is based on custom image.
        /// </return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.GetPlatformImage()
        {
            return this.GetPlatformImage() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage;
        }

        /// <return>True if this is a Linux virtual machine and password based login is enabled, false otherwise.</return>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.IsLinuxPasswordAuthenticationEnabled
        {
            get
            {
                return this.IsLinuxPasswordAuthenticationEnabled();
            }
        }

        /// <return>The operating system type.</return>
        Models.OperatingSystemTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.OsType
        {
            get
            {
                return this.OsType();
            }
        }

        /// <summary>
        /// Deletes the virtual machine instance.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Delete()
        {

            this.Delete();
        }

        /// <return>The virtual machine instance computer name with prefix VirtualMachineScaleSet.computerNamePrefix().</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.ComputerName
        {
            get
            {
                return this.ComputerName() as string;
            }
        }

        /// <return>The power state of the virtual machine instance.</return>
        Microsoft.Azure.Management.Compute.Fluent.PowerState Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.PowerState
        {
            get
            {
                return this.PowerState() as Microsoft.Azure.Management.Compute.Fluent.PowerState;
            }
        }

        /// <return>The resource id of the availability set that this virtual machine instance belongs to.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.AvailabilitySetId
        {
            get
            {
                return this.AvailabilitySetId() as string;
            }
        }

        /// <return>The storage profile of the virtual machine instance.</return>
        Models.StorageProfile Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.StorageProfile
        {
            get
            {
                return this.StorageProfile() as Models.StorageProfile;
            }
        }

        /// <return>The name of the operating system disk.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.OsDiskName
        {
            get
            {
                return this.OsDiskName() as string;
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

        /// <return>The caching type of the operating system disk.</return>
        Models.CachingTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.OsDiskCachingType
        {
            get
            {
                return this.OsDiskCachingType();
            }
        }

        /// <return>The extensions associated with the virtual machine instance, indexed by name.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMInstanceExtension> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Extensions
        {
            get
            {
                return this.Extensions() as System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMInstanceExtension>;
            }
        }

        /// <summary>
        /// Restarts the virtual machine instance.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.Restart()
        {

            this.Restart();
        }

        /// <return>
        /// Vhd uri of the custom image that the virtual machine instance operating system is based on,
        /// null will be returned if the operating system is based on platform image.
        /// </return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.CustomImageVhdUri
        {
            get
            {
                return this.CustomImageVhdUri() as string;
            }
        }

        /// <return>Vhd uri to the operating system disk.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.OsDiskVhdUri
        {
            get
            {
                return this.OsDiskVhdUri() as string;
            }
        }

        /// <return>The instance id assigned to this virtual machine instance.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.InstanceId
        {
            get
            {
                return this.InstanceId() as string;
            }
        }

        /// <return>The size of the operating system disk.</return>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.OsDiskSizeInGB
        {
            get
            {
                return this.OsDiskSizeInGB();
            }
        }

        /// <return>The uri to the storage account storing boot diagnostics log.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM.BootDiagnosticStorageAccountUri
        {
            get
            {
                return this.BootDiagnosticStorageAccountUri() as string;
            }
        }
    }
}