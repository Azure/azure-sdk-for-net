// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.Disk.Update
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the managed disk definition allowing to specify new size.
    /// </summary>
    public interface IWithSize 
    {
        /// <summary>
        /// Specifies the disk size.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the managed disk update.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Update.IUpdate WithSizeInGB(int sizeInGB);
    }

    /// <summary>
    /// The stage of the managed disk update allowing to choose sku type.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the sku.
        /// </summary>
        /// <param name="sku">The sku.</param>
        /// <return>The next stage of the managed disk update.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Update.IUpdate WithSku(DiskSkuTypes sku);
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that
    /// can be modified.
    /// Call Disk.Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.Disk.Update.IUpdate>,
        IWithSku,
        IWithSize,
        IWithOsSettings
    {
    }

    /// <summary>
    /// The stage of the managed disk update allowing to specify Os settings.
    /// </summary>
    public interface IWithOsSettings 
    {
        /// <summary>
        /// Specifies the operating system type.
        /// </summary>
        /// <param name="osType">Operating system type.</param>
        /// <return>The next stage of the managed disk update.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Update.IUpdate WithOSType(OperatingSystemTypes osType);
    }
}