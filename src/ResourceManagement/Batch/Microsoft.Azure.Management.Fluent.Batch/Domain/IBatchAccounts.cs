// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition;
    /// <summary>
    /// Entry point to batch account management API.
    /// </summary>
    public interface IBatchAccounts  :
        ISupportsCreating<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Fluent.Batch.IBatchAccount>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Fluent.Batch.IBatchAccount>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Fluent.Batch.IBatchAccount>,
        ISupportsGettingById<Microsoft.Azure.Management.Fluent.Batch.IBatchAccount>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Fluent.Batch.IBatchAccount>
    {
        /// <summary>
        /// Queries the number of the batch account can be created in specified region`.
        /// </summary>
        /// <param name="region">region the region in for which to check quota</param>
        /// <returns>whether the number of batch accounts can be created in specified region.</returns>
        int GetBatchAccountQuotaByLocation (Region region);

    }
}