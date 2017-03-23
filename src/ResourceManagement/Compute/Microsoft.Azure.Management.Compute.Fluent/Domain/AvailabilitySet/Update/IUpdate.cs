// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Compute.Fluent.Models;

    /// <summary>
    /// The template for an availability set update operation, containing all the settings that
    /// can be modified.
    /// Call Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update.IUpdate>,
        IWithSku
    {
    }

    /// <summary>
    /// The stage of the availability set definition allowing to specify sku.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the sku type for the availability set.
        /// </summary>
        /// <param name="skuType">The sku type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update.IUpdate WithSku(AvailabilitySetSkuTypes skuType);
    }
}