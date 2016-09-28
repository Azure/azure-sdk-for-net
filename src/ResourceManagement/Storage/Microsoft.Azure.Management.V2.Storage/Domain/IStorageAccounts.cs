// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Storage
{

    using Microsoft.Azure.Management.V2.Storage.StorageAccount.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Storage.Models;
    /// <summary>
    /// Entry point for storage accounts management API.
    /// </summary>
    public interface IStorageAccounts  :
        ISupportsListing<Microsoft.Azure.Management.V2.Storage.IStorageAccount>,
        ISupportsCreating<Microsoft.Azure.Management.V2.Storage.StorageAccount.Definition.IBlank>,
        ISupportsDeleting,
        ISupportsListingByGroup<Microsoft.Azure.Management.V2.Storage.IStorageAccount>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.V2.Storage.IStorageAccount>,
        ISupportsGettingById<Microsoft.Azure.Management.V2.Storage.IStorageAccount>,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.V2.Storage.IStorageAccount>
    {
        /// <summary>
        /// Checks that account name is valid and is not in use.
        /// </summary>
        /// <param name="name">name the account name to check</param>
        /// <returns>whether the name is available and other info if not</returns>
        CheckNameAvailabilityResult CheckNameAvailability (string name);

    }
}