/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Update
{

    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Compute;
    /// <summary>
    /// The template for an availability set update operation, containing all the settings that
    /// can be modified.
    /// <p>
    /// Call {@link Update#apply()} to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<IAvailabilitySet>,
        IUpdateWithTags<IUpdate>
    {
    }
}