// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine custom image.
    /// </summary>
    public interface IVirtualMachineCustomImage  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Compute.Fluent.IComputeManager,Models.ImageInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>
    {
        /// <summary>
        /// Gets true if this image was created by capturing a virtual machine.
        /// </summary>
        bool IsCreatedFromVirtualMachine { get; }

        /// <summary>
        /// Gets ID of the virtual machine if this image was created by capturing that virtual machine.
        /// </summary>
        string SourceVirtualMachineId { get; }

        /// <summary>
        /// Gets data disk images in this image, indexed by the disk LUN.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int,Models.ImageDataDisk> DataDiskImages { get; }

        /// <summary>
        /// Gets operating system disk image in this image.
        /// </summary>
        Models.ImageOSDisk OSDiskImage { get; }
    }
}