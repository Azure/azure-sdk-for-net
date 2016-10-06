// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update
{

    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
    /// <summary>
    /// The template for an availability set update operation, containing all the settings that
    /// can be modified.
    /// <p>
    /// Call {@link Update#apply()} to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update.IUpdate>
    {
    }
}