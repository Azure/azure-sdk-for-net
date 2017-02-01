// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using VirtualMachineScaleSet.Definition;
    using VirtualMachineScaleSet.Update;
    using VirtualMachineScaleSetUnmanagedDataDisk.Definition;
    using VirtualMachineScaleSetUnmanagedDataDisk.DefinitionWithImage;
    using VirtualMachineScaleSetUnmanagedDataDisk.DefinitionWithNewVhd;
    using VirtualMachineScaleSetUnmanagedDataDisk.Update;
    using VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;

    internal partial class VirtualMachineScaleSetUnmanagedDataDiskImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Specifies the new caching type for the unmanaged data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of unmanaged data disk update.</return>
        VirtualMachineScaleSetUnmanagedDataDisk.Update.IUpdate VirtualMachineScaleSetUnmanagedDataDisk.Update.IWithDiskCaching.WithCaching(CachingTypes cachingType)
        {
            return this.WithCaching(cachingType) as VirtualMachineScaleSetUnmanagedDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<VirtualMachineScaleSet.Update.IWithApply>.Attach()
        {
            return this.Attach() as VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Specifies the logical unit number for the unmanaged data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate> VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>.WithLun(int lun)
        {
            return this.WithLun(lun) as VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies the caching type for the unmanaged data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate> VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>.WithCaching(CachingTypes cachingType)
        {
            return this.WithCaching(cachingType) as VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies the logical unit number for the unmanaged data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Update.IWithApply>.WithLun(int lun)
        {
            return this.WithLun(lun) as VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies the caching type for the unmanaged data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Update.IWithApply>.WithCaching(CachingTypes cachingType)
        {
            return this.WithCaching(cachingType) as VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        VirtualMachineScaleSet.Definition.IWithUnmanagedCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>.Attach()
        {
            return this.Attach() as VirtualMachineScaleSet.Definition.IWithUnmanagedCreate;
        }

        /// <summary>
        /// Specifies the new size in GB for data disk.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of unmanaged data disk update.</return>
        VirtualMachineScaleSetUnmanagedDataDisk.Update.IUpdate VirtualMachineScaleSetUnmanagedDataDisk.Update.IWithDiskSize.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB) as VirtualMachineScaleSetUnmanagedDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the new logical unit number for the unmanaged data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of unmanaged data disk update.</return>
        VirtualMachineScaleSetUnmanagedDataDisk.Update.IUpdate VirtualMachineScaleSetUnmanagedDataDisk.Update.IWithDiskLun.WithLun(int lun)
        {
            return this.WithLun(lun) as VirtualMachineScaleSetUnmanagedDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the size in GB the unmanaged disk needs to be resized.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate> VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB) as VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies the caching type for the unmanaged data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate> VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>.WithCaching(CachingTypes cachingType)
        {
            return this.WithCaching(cachingType) as VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies that unmanaged disk needs to be created with a new vhd of given size.
        /// </summary>
        /// <param name="sizeInGB">The initial disk size in GB.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate> VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithDiskSource<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>.WithNewVhd(int sizeInGB)
        {
            return this.WithNewVhd(sizeInGB) as VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies the image lun identifier of the source disk image.
        /// </summary>
        /// <param name="imageLun">The lun.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate> VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithDiskSource<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>.FromImage(int imageLun)
        {
            return this.FromImage(imageLun) as VirtualMachineScaleSetUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies that unmanaged disk needs to be created with a new vhd of given size.
        /// </summary>
        /// <param name="sizeInGB">The initial disk size in GB.</param>
        /// <return>The next stage of unmanaged data disk definition.</return>
        VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithDiskSource<VirtualMachineScaleSet.Update.IWithApply>.WithNewVhd(int sizeInGB)
        {
            return this.WithNewVhd(sizeInGB) as VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachineScaleSet.Update.IWithApply>;
        }
    }
}