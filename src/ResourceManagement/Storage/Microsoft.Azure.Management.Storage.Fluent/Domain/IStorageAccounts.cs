// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.CollectionActions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point for storage accounts management API.
    /// </summary>
    public interface IStorageAccounts  :
        ISupportsListing<IStorageAccount>,
        ISupportsCreating<StorageAccount.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsListingByResourceGroup<IStorageAccount>,
        ISupportsGettingByResourceGroup<IStorageAccount>,
        ISupportsGettingById<IStorageAccount>,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<IStorageAccount>,
        IHasManager<IStorageManager>,
        IHasInner<IStorageAccountsOperations>
    {
        /// <summary>
        /// Checks that account name is valid and is not in use.
        /// </summary>
        /// <param name="name">name the account name to check</param>
        /// <returns>whether the name is available and other info if not</returns>
        CheckNameAvailabilityResult CheckNameAvailability(string name);
        
        /// <summary>
        /// Checks that account name is valid and is not in use.
        /// </summary>
        /// <param name="name">name the account name to check</param>
        /// <returns>whether the name is available and other info if not</returns>
        Task<CheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}