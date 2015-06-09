using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure;
using Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Management.Storage
{
    /// <summary>
    /// </summary>
    public partial interface IStorageAccountsOperations
    {
        /// <summary>
        /// Checks that account name is valid and is not in use.
        /// </summary>
        /// <param name='accountName'>
        /// The name of the storage account within the specified resource
        /// group. Storage account names must be between 3 and 24 characters
        /// in length and use numbers and lower-case letters only.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<CheckNameAvailabilityResponse>> CheckNameAvailabilityWithOperationResponseAsync(StorageAccountCheckNameAvailabilityParameters accountName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Asynchronously creates a new storage account with the specified
        /// parameters. Existing accounts cannot be updated with this API and
        /// should instead use the Update Storage Account API. If an account
        /// is already created and subsequent create request is issued with
        /// exact same set of properties, the request succeeds.The max number
        /// of storage accounts that can be created per subscription is
        /// limited to 20.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the userâ€™s subscription.
        /// </param>
        /// <param name='accountName'>
        /// The name of the storage account within the specified resource
        /// group. Storage account names must be between 3 and 24 characters
        /// in length and use numbers and lower-case letters only.
        /// </param>
        /// <param name='parameters'>
        /// The parameters to provide for the created account.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<StorageAccount>> CreateWithOperationResponseAsync(string resourceGroupName, string accountName, StorageAccountCreateParameters parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Asynchronously creates a new storage account with the specified
        /// parameters. Existing accounts cannot be updated with this API and
        /// should instead use the Update Storage Account API. If an account
        /// is already created and subsequent create request is issued with
        /// exact same set of properties, the request succeeds.The max number
        /// of storage accounts that can be created per subscription is
        /// limited to 20.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the userâ€™s subscription.
        /// </param>
        /// <param name='accountName'>
        /// The name of the storage account within the specified resource
        /// group. Storage account names must be between 3 and 24 characters
        /// in length and use numbers and lower-case letters only.
        /// </param>
        /// <param name='parameters'>
        /// The parameters to provide for the created account.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<StorageAccount>> BeginCreateWithOperationResponseAsync(string resourceGroupName, string accountName, StorageAccountCreateParameters parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes a storage account in Microsoft Azure.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the userâ€™s subscription.
        /// </param>
        /// <param name='accountName'>
        /// The name of the storage account within the specified resource
        /// group. Storage account names must be between 3 and 24 characters
        /// in length and use numbers and lower-case letters only.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Returns the properties for the specified storage account including
        /// but not limited to name, account type, location, and account
        /// status. The ListKeys operation should be used to retrieve storage
        /// keys.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the userâ€™s subscription.
        /// </param>
        /// <param name='accountName'>
        /// The name of the storage account within the specified resource
        /// group. Storage account names must be between 3 and 24 characters
        /// in length and use numbers and lower-case letters only.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<StorageAccount>> GetPropertiesWithOperationResponseAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Updates the account type or tags for a storage account. It can
        /// also be used to add a custom domain (note that custom domains
        /// cannot be added via the Create operation). Only one custom domain
        /// is supported per storage account. This API can only be used to
        /// update one of tags, accountType, or customDomain per call. To
        /// update multiple of these properties, call the API multiple times
        /// with one change per call. This call does not change the storage
        /// keys for the account. If you want to change storage account keys,
        /// use the RegenerateKey operation. The location and name of the
        /// storage account cannot be changed after creation.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the userâ€™s subscription.
        /// </param>
        /// <param name='accountName'>
        /// The name of the storage account within the specified resource
        /// group. Storage account names must be between 3 and 24 characters
        /// in length and use numbers and lower-case letters only.
        /// </param>
        /// <param name='parameters'>
        /// The parameters to update on the account. Note that only one
        /// property can be changed at a time using this API.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<StorageAccount>> UpdateWithOperationResponseAsync(string resourceGroupName, string accountName, StorageAccountUpdateParameters parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the access keys for the specified storage account.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='accountName'>
        /// The name of the storage account.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<StorageAccountKeys>> ListKeysWithOperationResponseAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists all the storage accounts available under the subscription.
        /// Note that storage keys are not returned; use the ListKeys
        /// operation for this.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<StorageAccountListResponse>> ListWithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists all the storage accounts available under the given resource
        /// group. Note that storage keys are not returned; use the ListKeys
        /// operation for this.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the userâ€™s subscription.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<StorageAccountListResponse>> ListByResourceGroupWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Regenerates the access keys for the specified storage account.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the userâ€™s subscription.
        /// </param>
        /// <param name='accountName'>
        /// The name of the storage account within the specified resource
        /// group. Storage account names must be between 3 and 24 characters
        /// in length and use numbers and lower-case letters only.
        /// </param>
        /// <param name='regenerateKey'>
        /// Specifies name of the key which should be regenerated.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<StorageAccountKeys>> RegenerateKeyWithOperationResponseAsync(string resourceGroupName, string accountName, StorageAccountRegenerateKeyParameters regenerateKey, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists all the storage accounts available under the subscription.
        /// Note that storage keys are not returned; use the ListKeys
        /// operation for this.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<StorageAccountListResponse>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists all the storage accounts available under the given resource
        /// group. Note that storage keys are not returned; use the ListKeys
        /// operation for this.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<StorageAccountListResponse>> ListByResourceGroupNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
