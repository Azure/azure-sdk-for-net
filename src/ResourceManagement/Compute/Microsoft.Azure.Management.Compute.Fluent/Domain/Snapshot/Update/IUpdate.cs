// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.Snapshot.Update
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Compute.Fluent.Models;

    /// <summary>
    /// The template for an update operation, containing all the settings that
    /// can be modified.
    /// Call Disk.Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Compute.Fluent.ISnapshot>,
        IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.Snapshot.Update.IUpdate>,
        IWithSku,
        IWithOsSettings
    {
    }

    /// <summary>
    /// The stage of the managed snapshot update allowing to choose account type.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the account type.
        /// </summary>
        /// <param name="sku">Sku type.</param>
        /// <return>The next stage of the managed snapshot update.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Update.IUpdate WithSku(DiskSkuTypes sku);
    }

    /// <summary>
    /// The stage of the managed snapshot update allowing to specify Os settings.
    /// </summary>
    public interface IWithOsSettings 
    {
        /// <summary>
        /// Specifies the operating system type.
        /// </summary>
        /// <param name="osType">Operating system type.</param>
        /// <return>The next stage of the managed snapshot update.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Update.IUpdate WithOSType(OperatingSystemTypes osType);
    }
}