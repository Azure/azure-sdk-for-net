// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.Snapshot.Update
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Compute.Fluent.Models;

    /// <summary>
    /// The template for an update operation, containing all the settings that
    /// can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Compute.Fluent.ISnapshot>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.Snapshot.Update.IUpdate>,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Update.IWithSku,
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Update.IWithOSSettings
    {
    }

    /// <summary>
    /// The stage of the managed snapshot update allowing to specify OS settings.
    /// </summary>
    public interface IWithOSSettings 
    {
        /// <summary>
        /// Specifies the operating system type.
        /// </summary>
        /// <param name="osType">Operating system type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Update.IUpdate WithOSType(OperatingSystemTypes osType);
    }

    /// <summary>
    /// The stage of the managed snapshot update allowing to choose account type.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the account type.
        /// </summary>
        /// <param name="sku">SKU type.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.Snapshot.Update.IUpdate WithSku(DiskSkuTypes sku);
    }
}