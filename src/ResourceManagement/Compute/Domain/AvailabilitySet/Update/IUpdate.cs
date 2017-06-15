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
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update.IUpdate>,
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update.IWithSku
    {
    }

    /// <summary>
    /// The stage of the availability set definition allowing to specify SKU.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the SKU type for the availability set.
        /// </summary>
        /// <param name="skuType">The SKU type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update.IUpdate WithSku(AvailabilitySetSkuTypes skuType);
    }
}