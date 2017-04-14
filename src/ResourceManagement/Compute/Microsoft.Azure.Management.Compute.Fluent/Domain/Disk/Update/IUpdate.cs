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
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Update.IUpdate WithSizeInGB(int sizeInGB);
    }

    /// <summary>
    /// The stage of the managed disk update allowing to choose the SKU type.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the SKU.
        /// </summary>
        /// <param name="sku">A SKU.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Update.IUpdate WithSku(DiskSkuTypes sku);
    }

    /// <summary>
    /// The stage of the managed disk update allowing to specify OS settings.
    /// </summary>
    public interface IWithOSSettings 
    {
        /// <summary>
        /// Specifies the operating system.
        /// </summary>
        /// <param name="osType">Operating system type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.Disk.Update.IUpdate WithOSType(OperatingSystemTypes osType);
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that
    /// can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.Disk.Update.IUpdate>,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Update.IWithSku,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Update.IWithSize,
        Microsoft.Azure.Management.Compute.Fluent.Disk.Update.IWithOSSettings
    {
    }
}