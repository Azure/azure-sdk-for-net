
namespace Microsoft.Azure.Management.Media
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for MediaServiceOperations.
    /// </summary>
    public static partial class MediaServiceOperationsExtensions
    {
            /// <summary>
            /// Check whether the Media Service resource name is available. The name must
            /// be globally unique.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='checkNameAvailabilityInput'>
            /// Properties needed to check the availability of a name.
            /// </param>
            public static CheckNameAvailabilityOutput CheckNameAvailabilty(this IMediaServiceOperations operations, CheckNameAvailabilityInput checkNameAvailabilityInput)
            {
                return Task.Factory.StartNew(s => ((IMediaServiceOperations)s).CheckNameAvailabiltyAsync(checkNameAvailabilityInput), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Check whether the Media Service resource name is available. The name must
            /// be globally unique.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='checkNameAvailabilityInput'>
            /// Properties needed to check the availability of a name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<CheckNameAvailabilityOutput> CheckNameAvailabiltyAsync(this IMediaServiceOperations operations, CheckNameAvailabilityInput checkNameAvailabilityInput, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CheckNameAvailabiltyWithHttpMessagesAsync(checkNameAvailabilityInput, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// List all of the Media Services in a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            public static IEnumerable<MediaService> ListByResourceGroup(this IMediaServiceOperations operations, string resourceGroupName)
            {
                return Task.Factory.StartNew(s => ((IMediaServiceOperations)s).ListByResourceGroupAsync(resourceGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// List all of the Media Services in a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<MediaService>> ListByResourceGroupAsync(this IMediaServiceOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get a Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            public static MediaService Get(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName)
            {
                return Task.Factory.StartNew(s => ((IMediaServiceOperations)s).GetAsync(resourceGroupName, mediaServiceName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<MediaService> GetAsync(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, mediaServiceName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Create a Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            /// <param name='mediaService'>
            /// Media Service properties needed for creation.
            /// </param>
            public static MediaService Create(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName, MediaService mediaService)
            {
                return Task.Factory.StartNew(s => ((IMediaServiceOperations)s).CreateAsync(resourceGroupName, mediaServiceName, mediaService), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create a Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            /// <param name='mediaService'>
            /// Media Service properties needed for creation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<MediaService> CreateAsync(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName, MediaService mediaService, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(resourceGroupName, mediaServiceName, mediaService, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete a Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            public static void Delete(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName)
            {
                Task.Factory.StartNew(s => ((IMediaServiceOperations)s).DeleteAsync(resourceGroupName, mediaServiceName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(resourceGroupName, mediaServiceName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            /// <param name='mediaService'>
            /// Media Service properties needed for update.
            /// </param>
            public static MediaService Update(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName, MediaService mediaService)
            {
                return Task.Factory.StartNew(s => ((IMediaServiceOperations)s).UpdateAsync(resourceGroupName, mediaServiceName, mediaService), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Update a Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            /// <param name='mediaService'>
            /// Media Service properties needed for update.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<MediaService> UpdateAsync(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName, MediaService mediaService, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(resourceGroupName, mediaServiceName, mediaService, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Regenerate the key for a Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            /// <param name='regenerateKeyInput'>
            /// Properties needed to regenerate the Media Service key.
            /// </param>
            public static RegenerateKeyOutput RegenerateKey(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName, RegenerateKeyInput regenerateKeyInput)
            {
                return Task.Factory.StartNew(s => ((IMediaServiceOperations)s).RegenerateKeyAsync(resourceGroupName, mediaServiceName, regenerateKeyInput), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Regenerate the key for a Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            /// <param name='regenerateKeyInput'>
            /// Properties needed to regenerate the Media Service key.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<RegenerateKeyOutput> RegenerateKeyAsync(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName, RegenerateKeyInput regenerateKeyInput, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.RegenerateKeyWithHttpMessagesAsync(resourceGroupName, mediaServiceName, regenerateKeyInput, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// List the keys for a Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            public static ServiceKeys ListKeys(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName)
            {
                return Task.Factory.StartNew(s => ((IMediaServiceOperations)s).ListKeysAsync(resourceGroupName, mediaServiceName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// List the keys for a Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ServiceKeys> ListKeysAsync(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListKeysWithHttpMessagesAsync(resourceGroupName, mediaServiceName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Synchronize the keys for a storage account to the Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            /// <param name='syncStorageKeysInput'>
            /// Properties needed to sycnronize the keys for a storage account to the
            /// Media Service.
            /// </param>
            public static MediaService SyncStorageKeys(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName, SyncStorageKeysInput syncStorageKeysInput)
            {
                return Task.Factory.StartNew(s => ((IMediaServiceOperations)s).SyncStorageKeysAsync(resourceGroupName, mediaServiceName, syncStorageKeysInput), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Synchronize the keys for a storage account to the Media Service.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group within the Azure subscription.
            /// </param>
            /// <param name='mediaServiceName'>
            /// Name of the Media Service.
            /// </param>
            /// <param name='syncStorageKeysInput'>
            /// Properties needed to sycnronize the keys for a storage account to the
            /// Media Service.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<MediaService> SyncStorageKeysAsync(this IMediaServiceOperations operations, string resourceGroupName, string mediaServiceName, SyncStorageKeysInput syncStorageKeysInput, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SyncStorageKeysWithHttpMessagesAsync(resourceGroupName, mediaServiceName, syncStorageKeysInput, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
