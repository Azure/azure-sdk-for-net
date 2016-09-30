// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Storage
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Fluent.Storage.StorageAccount.Definition;
    /// <summary>
    /// Entry point for storage accounts management API.
    /// </summary>
    public interface IStorageAccounts  :
        ISupportsListing<Microsoft.Azure.Management.Fluent.Storage.IStorageAccount>,
        ISupportsCreating<Microsoft.Azure.Management.Fluent.Storage.StorageAccount.Definition.IBlank>,
        ISupportsDeleting,
        ISupportsListingByGroup<Microsoft.Azure.Management.Fluent.Storage.IStorageAccount>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Fluent.Storage.IStorageAccount>,
        ISupportsGettingById<Microsoft.Azure.Management.Fluent.Storage.IStorageAccount>,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Fluent.Storage.IStorageAccount>
    {
        /// <summary>
        /// Checks that account name is valid and is not in use.
        /// </summary>
        /// <param name="name">name the account name to check</param>
        /// <returns>whether the name is available and other info if not</returns>
        Microsoft.Azure.Management.Fluent.Storage.CheckNameAvailabilityResult CheckNameAvailability(string name);

    }
}