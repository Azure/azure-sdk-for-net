// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Resource.Core;
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
        ISupportsDeletingByGroup
    {
    }
}