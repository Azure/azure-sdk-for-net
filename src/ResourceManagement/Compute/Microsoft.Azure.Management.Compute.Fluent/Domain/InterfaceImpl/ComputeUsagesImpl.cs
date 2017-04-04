// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;

    internal partial class ComputeUsagesImpl 
    {
        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">The selected Azure region.</param>
        /// <return>List of resources.</return>
        IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeUsage> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IComputeUsage>.ListByRegion(Region region)
        {
            return this.ListByRegion(region);
        }

        /// <summary>
        /// List all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="regionName">The name of an Azure region.</param>
        /// <return>List of resources.</return>
        IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeUsage> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IComputeUsage>.ListByRegion(string regionName)
        {
            return this.ListByRegion(regionName);
        }
    }
}