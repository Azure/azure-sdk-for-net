// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    /// <summary>
    /// Entry point to batch account management API.
    /// </summary>
    public interface IBatchAccounts  :
        ISupportsCreating<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>,
        ISupportsGettingById<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>
    {
        /// <summary>
        /// Queries the number of the batch account can be created in specified region`.
        /// </summary>
        /// <param name="region">region the region in for which to check quota</param>
        /// <returns>whether the number of batch accounts can be created in specified region.</returns>
        int GetBatchAccountQuotaByLocation(Region region);

    }
}