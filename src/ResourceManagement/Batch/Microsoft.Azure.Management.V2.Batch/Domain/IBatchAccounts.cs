/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Batch
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core;
    /// <summary>
    /// Entry point to batch account management API.
    /// </summary>
    public interface IBatchAccounts  :
        ISupportsCreating<IBlank>,
        ISupportsListing<IBatchAccount>,
        ISupportsListingByGroup<IBatchAccount>,
        ISupportsGettingByGroup<IBatchAccount>,
        ISupportsGettingById<IBatchAccount>,
        ISupportsDeleting,
        ISupportsDeletingByGroup
    {
    }
}