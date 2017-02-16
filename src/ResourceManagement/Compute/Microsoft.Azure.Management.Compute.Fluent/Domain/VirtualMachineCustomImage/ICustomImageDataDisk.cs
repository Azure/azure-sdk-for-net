// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineCustomImage
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of a data disk image in an image resource.
    /// </summary>
    public interface ICustomImageDataDisk  :
        IHasInner<Microsoft.Azure.Management.Compute.Fluent.Models.ImageDataDisk>,
        IChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>
    {
    }
}