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
            /// Cancellation token.
            /// </param>
            public static async Task<JobDefinition> GetAsync( this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<JobDefinition> result = await operations.GetWithHttpMessagesAsync(resourceGroupName, jobCollectionName, jobName, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
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
            /// Cancellation token.
            /// </param>
            public static async Task<JobDefinition> CreateOrUpdateAsync( this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, JobDefinition job, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<JobDefinition> result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, jobCollectionName, jobName, job, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
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
            /// Cancellation token.
            /// </param>
            public static async Task<JobDefinition> PatchAsync( this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, JobDefinition job, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<JobDefinition> result = await operations.PatchWithHttpMessagesAsync(resourceGroupName, jobCollectionName, jobName, job, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
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
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAsync( this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, CancellationToken cancellationToken = default(CancellationToken))
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
            /// Cancellation token.
            /// </param>
            public static async Task RunAsync( this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, CancellationToken cancellationToken = default(CancellationToken))
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
            /// <param name='top'>
            /// The number of jobs to request, in the of range [1..100].
            /// </param>
            /// <param name='skip'>
            /// The (0-based) index of the job history list from which to begin requesting
            /// entries.
            /// </param>
            public static JobListResult List(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, int? top = default(int?), int? skip = default(int?))
            {
                return Task.Factory.StartNew(s => ((IJobsOperations)s).ListAsync(resourceGroupName, jobCollectionName, top, skip), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            /// <param name='top'>
            /// The number of jobs to request, in the of range [1..100].
            /// </param>
            /// <param name='skip'>
            /// The (0-based) index of the job history list from which to begin requesting
            /// entries.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<JobListResult> ListAsync( this IJobsOperations operations, string resourceGroupName, string jobCollectionName, int? top = default(int?), int? skip = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<JobListResult> result = await operations.ListWithHttpMessagesAsync(resourceGroupName, jobCollectionName, top, skip, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
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
            /// <param name='top'>
            /// the number of job history to request, in the of range [1..100].
            /// </param>
            /// <param name='skip'>
            /// The (0-based) index of the job history list from which to begin requesting
            /// entries.
            /// </param>
            public static JobHistoryListResult ListJobHistory(this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, int? top = default(int?), int? skip = default(int?))
            {
                return Task.Factory.StartNew(s => ((IJobsOperations)s).ListJobHistoryAsync(resourceGroupName, jobCollectionName, jobName, top, skip), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            /// <param name='top'>
            /// the number of job history to request, in the of range [1..100].
            /// </param>
            /// <param name='skip'>
            /// The (0-based) index of the job history list from which to begin requesting
            /// entries.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<JobHistoryListResult> ListJobHistoryAsync( this IJobsOperations operations, string resourceGroupName, string jobCollectionName, string jobName, int? top = default(int?), int? skip = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<JobHistoryListResult> result = await operations.ListJobHistoryWithHttpMessagesAsync(resourceGroupName, jobCollectionName, jobName, top, skip, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
