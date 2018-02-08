
namespace Microsoft.Azure.Management.StorSimple8000Series
{
    using Azure;
    using Management;
    using Rest;
    using Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for StorageAccountCredentialsOperations.
    /// </summary>
    public static partial class StorageAccountCredentialsOperationsExtensions
    {
            /// <summary>
            /// Gets all the storage account credentials in a manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static IEnumerable<StorageAccountCredential> ListByManager(this IStorageAccountCredentialsOperations operations, string resourceGroupName, string managerName)
            {
                return operations.ListByManagerAsync(resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the storage account credentials in a manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<StorageAccountCredential>> ListByManagerAsync(this IStorageAccountCredentialsOperations operations, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByManagerWithHttpMessagesAsync(resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the properties of the specified storage account credential name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='storageAccountCredentialName'>
            /// The name of storage account credential to be fetched.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static StorageAccountCredential Get(this IStorageAccountCredentialsOperations operations, string storageAccountCredentialName, string resourceGroupName, string managerName)
            {
                return operations.GetAsync(storageAccountCredentialName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the properties of the specified storage account credential name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='storageAccountCredentialName'>
            /// The name of storage account credential to be fetched.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StorageAccountCredential> GetAsync(this IStorageAccountCredentialsOperations operations, string storageAccountCredentialName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(storageAccountCredentialName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates the storage account credential.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='storageAccountCredentialName'>
            /// The storage account credential name.
            /// </param>
            /// <param name='parameters'>
            /// The storage account credential to be added or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static StorageAccountCredential CreateOrUpdate(this IStorageAccountCredentialsOperations operations, string storageAccountCredentialName, StorageAccountCredential parameters, string resourceGroupName, string managerName)
            {
                return operations.CreateOrUpdateAsync(storageAccountCredentialName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the storage account credential.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='storageAccountCredentialName'>
            /// The storage account credential name.
            /// </param>
            /// <param name='parameters'>
            /// The storage account credential to be added or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StorageAccountCredential> CreateOrUpdateAsync(this IStorageAccountCredentialsOperations operations, string storageAccountCredentialName, StorageAccountCredential parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(storageAccountCredentialName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the storage account credential.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='storageAccountCredentialName'>
            /// The name of the storage account credential.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void Delete(this IStorageAccountCredentialsOperations operations, string storageAccountCredentialName, string resourceGroupName, string managerName)
            {
                operations.DeleteAsync(storageAccountCredentialName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the storage account credential.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='storageAccountCredentialName'>
            /// The name of the storage account credential.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IStorageAccountCredentialsOperations operations, string storageAccountCredentialName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(storageAccountCredentialName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Creates or updates the storage account credential.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='storageAccountCredentialName'>
            /// The storage account credential name.
            /// </param>
            /// <param name='parameters'>
            /// The storage account credential to be added or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static StorageAccountCredential BeginCreateOrUpdate(this IStorageAccountCredentialsOperations operations, string storageAccountCredentialName, StorageAccountCredential parameters, string resourceGroupName, string managerName)
            {
                return operations.BeginCreateOrUpdateAsync(storageAccountCredentialName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the storage account credential.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='storageAccountCredentialName'>
            /// The storage account credential name.
            /// </param>
            /// <param name='parameters'>
            /// The storage account credential to be added or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<StorageAccountCredential> BeginCreateOrUpdateAsync(this IStorageAccountCredentialsOperations operations, string storageAccountCredentialName, StorageAccountCredential parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(storageAccountCredentialName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the storage account credential.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='storageAccountCredentialName'>
            /// The name of the storage account credential.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void BeginDelete(this IStorageAccountCredentialsOperations operations, string storageAccountCredentialName, string resourceGroupName, string managerName)
            {
                operations.BeginDeleteAsync(storageAccountCredentialName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the storage account credential.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='storageAccountCredentialName'>
            /// The name of the storage account credential.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IStorageAccountCredentialsOperations operations, string storageAccountCredentialName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithHttpMessagesAsync(storageAccountCredentialName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

    }
}

