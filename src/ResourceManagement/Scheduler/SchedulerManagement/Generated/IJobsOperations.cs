namespace Microsoft.Azure.Management.Scheduler
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// JobsOperations operations.
    /// </summary>
    public partial interface IJobsOperations
    {
        /// <summary>
        /// Gets a job.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name.
        /// </param>
        /// <param name='jobCollectionName'>
        /// The job collection name.
        /// </param>
        /// <param name='jobName'>
        /// The job name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<JobDefinition>> GetWithHttpMessagesAsync(string resourceGroupName, string jobCollectionName, string jobName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Provisions a new job or updates an existing job.
        /// </summary>
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
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<JobDefinition>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string jobCollectionName, string jobName, JobDefinition job, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Patches an existing job.
        /// </summary>
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
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<JobDefinition>> PatchWithHttpMessagesAsync(string resourceGroupName, string jobCollectionName, string jobName, JobDefinition job, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes a job.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name.
        /// </param>
        /// <param name='jobCollectionName'>
        /// The job collection name.
        /// </param>
        /// <param name='jobName'>
        /// The job name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string jobCollectionName, string jobName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Runs a job.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name.
        /// </param>
        /// <param name='jobCollectionName'>
        /// The job collection name.
        /// </param>
        /// <param name='jobName'>
        /// The job name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> RunWithHttpMessagesAsync(string resourceGroupName, string jobCollectionName, string jobName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists all jobs under the specified job collection.
        /// </summary>
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
        /// The (0-based) index of the job history list from which to begin
        /// requesting entries.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<JobListResult>> ListWithHttpMessagesAsync(string resourceGroupName, string jobCollectionName, int? top = default(int?), int? skip = default(int?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists job history.
        /// </summary>
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
        /// The (0-based) index of the job history list from which to begin
        /// requesting entries.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<JobHistoryListResult>> ListJobHistoryWithHttpMessagesAsync(string resourceGroupName, string jobCollectionName, string jobName, int? top = default(int?), int? skip = default(int?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
