
namespace Microsoft.Azure.Management.Scheduler
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
    /// Extension methods for JobCollectionsOperations.
    /// </summary>
    public static partial class JobCollectionsOperationsExtensions
    {
            /// <summary>
            /// Gets all job collections under specified subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IPage<JobCollectionDefinition> ListBySubscription(this IJobCollectionsOperations operations)
            {
                return Task.Factory.StartNew(s => ((IJobCollectionsOperations)s).ListBySubscriptionAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all job collections under specified subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<JobCollectionDefinition>> ListBySubscriptionAsync(this IJobCollectionsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySubscriptionWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets all job collections under specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            public static IPage<JobCollectionDefinition> ListByResourceGroup(this IJobCollectionsOperations operations, string resourceGroupName)
            {
                return Task.Factory.StartNew(s => ((IJobCollectionsOperations)s).ListByResourceGroupAsync(resourceGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all job collections under specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<JobCollectionDefinition>> ListByResourceGroupAsync(this IJobCollectionsOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            public static JobCollectionDefinition Get(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName)
            {
                return Task.Factory.StartNew(s => ((IJobCollectionsOperations)s).GetAsync(resourceGroupName, jobCollectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<JobCollectionDefinition> GetAsync(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, jobCollectionName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Provisions a new job collection or updates an existing job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            /// <param name='jobCollection'>
            /// The job collection definition.
            /// </param>
            public static JobCollectionDefinition CreateOrUpdate(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName, JobCollectionDefinition jobCollection)
            {
                return Task.Factory.StartNew(s => ((IJobCollectionsOperations)s).CreateOrUpdateAsync(resourceGroupName, jobCollectionName, jobCollection), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Provisions a new job collection or updates an existing job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            /// <param name='jobCollection'>
            /// The job collection definition.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<JobCollectionDefinition> CreateOrUpdateAsync(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName, JobCollectionDefinition jobCollection, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, jobCollectionName, jobCollection, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Patches an existing job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            /// <param name='jobCollection'>
            /// The job collection definition.
            /// </param>
            public static JobCollectionDefinition Patch(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName, JobCollectionDefinition jobCollection)
            {
                return Task.Factory.StartNew(s => ((IJobCollectionsOperations)s).PatchAsync(resourceGroupName, jobCollectionName, jobCollection), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Patches an existing job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            /// <param name='jobCollection'>
            /// The job collection definition.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<JobCollectionDefinition> PatchAsync(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName, JobCollectionDefinition jobCollection, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PatchWithHttpMessagesAsync(resourceGroupName, jobCollectionName, jobCollection, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes a job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            public static void Delete(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName)
            {
                Task.Factory.StartNew(s => ((IJobCollectionsOperations)s).DeleteAsync(resourceGroupName, jobCollectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes a job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(resourceGroupName, jobCollectionName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Deletes a job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            public static void BeginDelete(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName)
            {
                Task.Factory.StartNew(s => ((IJobCollectionsOperations)s).BeginDeleteAsync(resourceGroupName, jobCollectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes a job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, jobCollectionName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Enables all of the jobs in the job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            public static void Enable(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName)
            {
                Task.Factory.StartNew(s => ((IJobCollectionsOperations)s).EnableAsync(resourceGroupName, jobCollectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Enables all of the jobs in the job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task EnableAsync(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.EnableWithHttpMessagesAsync(resourceGroupName, jobCollectionName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Enables all of the jobs in the job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            public static void BeginEnable(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName)
            {
                Task.Factory.StartNew(s => ((IJobCollectionsOperations)s).BeginEnableAsync(resourceGroupName, jobCollectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Enables all of the jobs in the job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginEnableAsync(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginEnableWithHttpMessagesAsync(resourceGroupName, jobCollectionName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Disables all of the jobs in the job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            public static void Disable(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName)
            {
                Task.Factory.StartNew(s => ((IJobCollectionsOperations)s).DisableAsync(resourceGroupName, jobCollectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Disables all of the jobs in the job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DisableAsync(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DisableWithHttpMessagesAsync(resourceGroupName, jobCollectionName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Disables all of the jobs in the job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            public static void BeginDisable(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName)
            {
                Task.Factory.StartNew(s => ((IJobCollectionsOperations)s).BeginDisableAsync(resourceGroupName, jobCollectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Disables all of the jobs in the job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='jobCollectionName'>
            /// The job collection name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDisableAsync(this IJobCollectionsOperations operations, string resourceGroupName, string jobCollectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDisableWithHttpMessagesAsync(resourceGroupName, jobCollectionName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Gets all job collections under specified subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<JobCollectionDefinition> ListBySubscriptionNext(this IJobCollectionsOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IJobCollectionsOperations)s).ListBySubscriptionNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all job collections under specified subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<JobCollectionDefinition>> ListBySubscriptionNextAsync(this IJobCollectionsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySubscriptionNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets all job collections under specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<JobCollectionDefinition> ListByResourceGroupNext(this IJobCollectionsOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IJobCollectionsOperations)s).ListByResourceGroupNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all job collections under specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<JobCollectionDefinition>> ListByResourceGroupNextAsync(this IJobCollectionsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
