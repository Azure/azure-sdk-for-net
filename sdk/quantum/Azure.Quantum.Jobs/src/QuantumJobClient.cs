// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Quantum.Jobs.Models;

namespace Azure.Quantum.Jobs
{
    /// <summary>
    /// The sample jobs client.
    /// </summary>
    public class QuantumJobClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumJobClient"/> class.
        /// </summary>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="workspaceName">Name of the workspace.</param>
        /// <param name="location">The location.</param>
        /// <param name="credential">The token credential.</param>
        /// <param name="options">The options.</param>
        public QuantumJobClient(
            string subscriptionId,
            string resourceGroupName,
            string workspaceName,
            string location,
            TokenCredential credential = default,
            QuantumJobClientOptions options = default)
        {
            if (options == null)
            {
                options = new QuantumJobClientOptions();
            }

            var authPolicy = new BearerTokenAuthenticationPolicy(credential, "https://quantum.microsoft.com/.default");
            var diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, authPolicy);
            var endpoint = new Uri($"https://{location}.quantum.azure.com");

            _jobs = new JobsRestClient(diagnostics, pipeline, subscriptionId, resourceGroupName, workspaceName, endpoint);
            _providers = new ProvidersRestClient(diagnostics, pipeline, subscriptionId, resourceGroupName, workspaceName, endpoint);
            _quotas = new QuotasRestClient(diagnostics, pipeline, subscriptionId, resourceGroupName, workspaceName, endpoint);
            _storage = new StorageRestClient(diagnostics, pipeline, subscriptionId, resourceGroupName, workspaceName, endpoint);
        }

        /// <summary> Get job by id. </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public virtual Response<JobDetails> GetJob(string jobId, CancellationToken cancellationToken = default)
        {
            return _jobs.Get(jobId, cancellationToken);
        }

        /// <summary> Get job by id. </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public virtual async Task<Response<JobDetails>> GetJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            return await _jobs.GetAsync(jobId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return list of jobs. </summary>
        public virtual Pageable<JobDetails> GetJobs(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable(cont => ToPage(string.IsNullOrEmpty(cont) ? _jobs.List() : _jobs.ListNextPage(cont)));
        }

        /// <summary> Return list of jobs. </summary>
        public virtual AsyncPageable<JobDetails> GetJobsAsync(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async cont => ToPage(string.IsNullOrEmpty(cont) ? await _jobs.ListAsync().ConfigureAwait(false) : await _jobs.ListNextPageAsync(cont).ConfigureAwait(false)));
        }

        /// <summary> Create a job. </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="job"> The complete metadata of the job to submit. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="job"/> is null. </exception>
        public virtual Response<JobDetails> CreateJob(string jobId, JobDetails job, CancellationToken cancellationToken = default)
        {
            return _jobs.Create(jobId, job, cancellationToken);
        }

        /// <summary> Create a job. </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="job"> The complete metadata of the job to submit. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="job"/> is null. </exception>
        public virtual async Task<Response<JobDetails>> CreateJobAsync(string jobId, JobDetails job, CancellationToken cancellationToken = default)
        {
            return await _jobs.CreateAsync(jobId, job, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Cancel a job. </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public virtual Response CancelJob(string jobId, CancellationToken cancellationToken = default)
        {
            return _jobs.Cancel(jobId, cancellationToken);
        }

        /// <summary> Cancel a job. </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public virtual async Task<Response> CancelJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            return await _jobs.CancelAsync(jobId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get provider status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ProviderStatus> GetProviderStatus(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable(cont => ToPage(string.IsNullOrEmpty(cont) ? _providers.GetStatus() : _providers.GetStatusNextPage(cont)));
        }

        /// <summary> Get provider status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ProviderStatus> GetProviderStatusAsync(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async cont => ToPage(string.IsNullOrEmpty(cont) ? await _providers.GetStatusAsync().ConfigureAwait(false) : await _providers.GetStatusNextPageAsync(cont).ConfigureAwait(false)));
        }

        /// <summary> Get quota status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<QuantumJobQuota> GetQuotas(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable(cont => ToPage(string.IsNullOrEmpty(cont) ? _quotas.List() : _quotas.ListNextPage(cont)));
        }

        /// <summary> Get quota status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<QuantumJobQuota> GetQuotasAsync(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async cont => ToPage(string.IsNullOrEmpty(cont) ? await _quotas.ListAsync().ConfigureAwait(false) : await _quotas.ListNextPageAsync(cont).ConfigureAwait(false)));
        }

        /// <summary> Gets a URL with SAS token for a container/blob in the storage account associated with the workspace. The SAS URL can be used to upload job input and/or download job output. </summary>
        /// <param name="blobDetails"> The details (name and container) of the blob to store or download data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="blobDetails"/> is null. </exception>
        public virtual Response<SasUriResponse> GetStorageSasUri(BlobDetails blobDetails, CancellationToken cancellationToken = default)
        {
            return _storage.SasUri(blobDetails, cancellationToken);
        }

        /// <summary> Gets a URL with SAS token for a container/blob in the storage account associated with the workspace. The SAS URL can be used to upload job input and/or download job output. </summary>
        /// <param name="blobDetails"> The details (name and container) of the blob to store or download data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="blobDetails"/> is null. </exception>
        public virtual async Task<Response<SasUriResponse>> GetStorageSasUriAsync(BlobDetails blobDetails, CancellationToken cancellationToken = default)
        {
            return await _storage.SasUriAsync(blobDetails, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Initializes a new instance of QuantumJobClient for mocking. </summary>
        protected QuantumJobClient()
        {
        }

        private static Page<JobDetails> ToPage(Response<JobDetailsList> list) =>
            Page.FromValues(list.Value.Value, list.Value.NextLink, list.GetRawResponse());

        private static Page<ProviderStatus> ToPage(Response<ProviderStatusList> list) =>
            Page.FromValues(list.Value.Value, list.Value.NextLink, list.GetRawResponse());

        private static Page<QuantumJobQuota> ToPage(Response<QuantumJobQuotaList> list) =>
            Page.FromValues(list.Value.Value, list.Value.NextLink, list.GetRawResponse());

        private readonly JobsRestClient _jobs;
        private readonly ProvidersRestClient _providers;
        private readonly QuotasRestClient _quotas;
        private readonly StorageRestClient _storage;
    }
}
