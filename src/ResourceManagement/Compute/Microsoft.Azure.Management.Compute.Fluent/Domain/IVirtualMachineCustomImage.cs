// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine custom image.
    /// </summary>
    public interface IVirtualMachineCustomImage  :
        IGroupableResource<IComputeManager>,
        IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>,
        IHasInner<Models.ImageInner>
    {
        /// <summary>
        /// Gets operating system disk image in this image.
        /// </summary>
        Models.ImageOSDisk OsDiskImage { get; }

        /// <summary>
        /// Gets true if this image is created by capturing a virtual machine.
        /// </summary>
        bool IsCreatedFromVirtualMachine { get; }

        /// <summary>
        /// Gets id of the virtual machine if this image is created by capturing that virtual machine.
        /// </summary>
        string SourceVirtualMachineId { get; }

        /// <summary>
        /// Gets data disk images in this image, indexed by the disk lun.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int,Models.ImageDataDisk> DataDiskImages { get; }
    }
}