
namespace Microsoft.Azure.Management.Scheduler
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure.OData;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for JobsOperations.
    /// </summary>
    public static partial class JobsOperationsExtensions
    {
            /// <summary>
            /// Gets a job.
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
            /// <param name='jobName'>
            /// The job name.
            /// </param>
            public static JobDefinition Get(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName)
            {
                return Task.Factory.StartNew(s => ((IJobsOperations)s).GetAsync(resourceGroupName, jobCollectionName, jobName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a job.
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
            /// <param name='jobName'>
            /// The job name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<JobDefinition> GetAsync(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, jobCollectionName, jobName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Provisions a new job or updates an existing job.
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
            /// <param name='jobName'>
            /// The job name.
            /// </param>
            /// <param name='job'>
            /// The job definition.
            /// </param>
            public static JobDefinition CreateOrUpdate(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, JobDefinition job)
            {
                return Task.Factory.StartNew(s => ((IJobsOperations)s).CreateOrUpdateAsync(resourceGroupName, jobCollectionName, jobName, job), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Provisions a new job or updates an existing job.
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
            /// <param name='jobName'>
            /// The job name.
            /// </param>
            /// <param name='job'>
            /// The job definition.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<JobDefinition> CreateOrUpdateAsync(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, JobDefinition job, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, jobCollectionName, jobName, job, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Patches an existing job.
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
            /// <param name='jobName'>
            /// The job name.
            /// </param>
            /// <param name='job'>
            /// The job definition.
            /// </param>
            public static JobDefinition Patch(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, JobDefinition job)
            {
                return Task.Factory.StartNew(s => ((IJobsOperations)s).PatchAsync(resourceGroupName, jobCollectionName, jobName, job), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Patches an existing job.
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
            /// <param name='jobName'>
            /// The job name.
            /// </param>
            /// <param name='job'>
            /// The job definition.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<JobDefinition> PatchAsync(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, JobDefinition job, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PatchWithHttpMessagesAsync(resourceGroupName, jobCollectionName, jobName, job, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes a job.
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
            /// <param name='jobName'>
            /// The job name.
            /// </param>
            public static void Delete(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName)
            {
                Task.Factory.StartNew(s => ((IJobsOperations)s).DeleteAsync(resourceGroupName, jobCollectionName, jobName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes a job.
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
            /// <param name='jobName'>
            /// The job name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(resourceGroupName, jobCollectionName, jobName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Runs a job.
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
            /// <param name='jobName'>
            /// The job name.
            /// </param>
            public static void Run(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName)
            {
                Task.Factory.StartNew(s => ((IJobsOperations)s).RunAsync(resourceGroupName, jobCollectionName, jobName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Runs a job.
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
            /// <param name='jobName'>
            /// The job name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task RunAsync(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.RunWithHttpMessagesAsync(resourceGroupName, jobCollectionName, jobName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Lists all jobs under the specified job collection.
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
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            public static IPage<JobDefinition> List(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, ODataQuery<JobStateFilter> odataQuery = default(ODataQuery<JobStateFilter>))
            {
                return Task.Factory.StartNew(s => ((IJobsOperations)s).ListAsync(resourceGroupName, jobCollectionName, odataQuery), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists all jobs under the specified job collection.
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
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<JobDefinition>> ListAsync(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, ODataQuery<JobStateFilter> odataQuery = default(ODataQuery<JobStateFilter>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, jobCollectionName, odataQuery, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists job history.
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
            /// <param name='jobName'>
            /// The job name.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            public static IPage<JobHistoryDefinition> ListJobHistory(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, ODataQuery<JobHistoryFilter> odataQuery = default(ODataQuery<JobHistoryFilter>))
            {
                return Task.Factory.StartNew(s => ((IJobsOperations)s).ListJobHistoryAsync(resourceGroupName, jobCollectionName, jobName, odataQuery), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists job history.
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
            /// <param name='jobName'>
            /// The job name.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<JobHistoryDefinition>> ListJobHistoryAsync(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, ODataQuery<JobHistoryFilter> odataQuery = default(ODataQuery<JobHistoryFilter>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListJobHistoryWithHttpMessagesAsync(resourceGroupName, jobCollectionName, jobName, odataQuery, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists all jobs under the specified job collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<JobDefinition> ListNext(this IJobsOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IJobsOperations)s).ListNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists all jobs under the specified job collection.
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
            public static async Task<IPage<JobDefinition>> ListNextAsync(this IJobsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists job history.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<JobHistoryDefinition> ListJobHistoryNext(this IJobsOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IJobsOperations)s).ListJobHistoryNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists job history.
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
            public static async Task<IPage<JobHistoryDefinition>> ListJobHistoryNextAsync(this IJobsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListJobHistoryNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
