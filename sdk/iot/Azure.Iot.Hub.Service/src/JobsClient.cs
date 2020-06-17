// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// Jobs client to support Import/Export and Scheduled Jobs.
    /// </summary>
    public class JobsClient
    {
        private readonly JobRestClient _jobRestClient;

        protected JobsClient()
        {
            // This constructor only exists for mocking purposes.
        }

        internal JobsClient(JobRestClient jobRestClient)
        {
            Argument.AssertNotNull(jobRestClient, nameof(jobRestClient));

            _jobRestClient = jobRestClient;
        }

        /// <summary>
        /// Creates a job to export device registrations to the container.
        /// </summary>
        /// <param name="outputBlobContainerUri">URI containing SAS token to a blob container. This is used to output the results of the export job.</param>
        /// <param name="excludeKeys">If false, authorization keys are included in export output.</param>
        /// <param name="options">The optional settings for this request.</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        /// <returns>JobProperties of the newly created job.</returns>
        public virtual Response<JobProperties> CreateExportDevicesJob(
            Uri outputBlobContainerUri,
            bool excludeKeys,
            ExportJobRequestOptions options = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(outputBlobContainerUri, nameof(outputBlobContainerUri));

            var jobProperties = new JobProperties
            {
                Type = JobPropertiesType.Export,
                OutputBlobContainerUri = outputBlobContainerUri.ToString(),
                ExcludeKeysInExport = excludeKeys,
                StorageAuthenticationType = options?.AuthenticationType,
                OutputBlobName = options?.OutputBlobName
            };

            return _jobRestClient.CreateImportExportJob(jobProperties, cancellationToken);
        }

        /// <summary>
        /// Creates a job to export device registrations to the container.
        /// </summary>
        /// <param name="outputBlobContainerUri">URI containing SAS token to a blob container. This is used to output the results of the export job.</param>
        /// <param name="excludeKeys">If false, authorization keys are included in export output.</param>
        /// <param name="options">The optional settings for this request.</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        /// <returns>JobProperties of the newly created job.</returns>
        public virtual Task<Response<JobProperties>> CreateExportDevicesJobAsync(
            Uri outputBlobContainerUri,
            bool excludeKeys,
            ExportJobRequestOptions options = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(outputBlobContainerUri, nameof(outputBlobContainerUri));

            var jobProperties = new JobProperties
            {
                Type = JobPropertiesType.Export,
                OutputBlobContainerUri = outputBlobContainerUri.ToString(),
                ExcludeKeysInExport = excludeKeys,
                StorageAuthenticationType = options?.AuthenticationType,
                OutputBlobName = options?.OutputBlobName
            };

            return _jobRestClient.CreateImportExportJobAsync(jobProperties, cancellationToken);
        }

        /// <summary>
        /// Creates a job to import device registrations into the IoT Hub.
        /// </summary>
        /// <param name="importBlobContainerUri">URI containing SAS token to a blob container that contains registry data to sync.</param>
        /// <param name="outputBlobContainerUri">URI containing SAS token to a blob container. This is used to output the status of the job.</param>
        /// <param name="options">The optional settings for this request.</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        /// <returns>JobProperties of the newly created job.</returns>
        public virtual Response<JobProperties> CreateImportDevicesJob(
            Uri importBlobContainerUri,
            Uri outputBlobContainerUri,
            ImportJobRequestOptions options = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(importBlobContainerUri, nameof(importBlobContainerUri));
            Argument.AssertNotNull(outputBlobContainerUri, nameof(outputBlobContainerUri));

            var jobProperties = new JobProperties
            {
                Type = JobPropertiesType.Import,
                InputBlobContainerUri = importBlobContainerUri.ToString(),
                OutputBlobContainerUri = outputBlobContainerUri.ToString(),
                StorageAuthenticationType = options?.AuthenticationType,
                OutputBlobName = options?.OutputBlobName,
                InputBlobName = options?.InputBloblName
            };

            return _jobRestClient.CreateImportExportJob(jobProperties, cancellationToken);
        }

        /// <summary>
        /// Creates a job to import device registrations into the IoT Hub.
        /// </summary>
        /// <param name="importBlobContainerUri">URI containing SAS token to a blob container that contains registry data to sync.</param>
        /// <param name="outputBlobContainerUri">URI containing SAS token to a blob container. This is used to output the status of the job.</param>
        /// <param name="options">The optional settings for this request.</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        /// <returns>JobProperties of the newly created job.</returns>
        public virtual Task<Response<JobProperties>> CreateImportDevicesJobAsync(
            Uri importBlobContainerUri,
            Uri outputBlobContainerUri,
            ImportJobRequestOptions options = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(importBlobContainerUri, nameof(importBlobContainerUri));
            Argument.AssertNotNull(outputBlobContainerUri, nameof(outputBlobContainerUri));

            var jobProperties = new JobProperties
            {
                Type = JobPropertiesType.Import,
                InputBlobContainerUri = importBlobContainerUri.ToString(),
                OutputBlobContainerUri = outputBlobContainerUri.ToString(),
                StorageAuthenticationType = options?.AuthenticationType,
                OutputBlobName = options?.OutputBlobName,
                InputBlobName = options?.InputBloblName
            };

            return _jobRestClient.CreateImportExportJobAsync(jobProperties, cancellationToken);
        }

        /// <summary>
        /// List all import and export jobs for the IoT Hub.
        /// </summary>
        /// <param name="cancellationToken">Task cancellation token</param>
        /// <returns>IEnumerable of JobProperties of all jobs for this IoT Hub.</returns>
        public virtual Response<IReadOnlyList<JobProperties>> GetImportExportJobs(CancellationToken cancellationToken = default)
        {
            return _jobRestClient.GetImportExportJobs(cancellationToken);
        }

        /// <summary>
        /// List all import and export jobs for the IoT Hub.
        /// </summary>
        /// <param name="cancellationToken">Task cancellation token</param>
        /// <returns>IEnumerable of JobProperties of all jobs for this IoT Hub.</returns>
        public virtual Task<Response<IReadOnlyList<JobProperties>>> GetImportExportJobsAsync(CancellationToken cancellationToken = default)
        {
            return _jobRestClient.GetImportExportJobsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the import or export job with the specified ID.
        /// </summary>
        /// <param name="jobId">Id of the Job object to retrieve</param>
        /// <param name="cancellationToken">Task cancellation token</param>
        /// <returns>JobProperties of the job specified by the provided jobId.</returns>
        public virtual Response<JobProperties> GetImportExportJob(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            return _jobRestClient.GetImportExportJob(jobId, cancellationToken);
        }

        /// <summary>
        /// Gets the import or export job with the specified ID.
        /// </summary>
        /// <param name="jobId">Id of the Job object to retrieve</param>
        /// <param name="cancellationToken">Task cancellation token</param>
        /// <returns>JobProperties of the job specified by the provided jobId.</returns>
        public virtual Task<Response<JobProperties>> GetImportExportJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            return _jobRestClient.GetImportExportJobAsync(jobId, cancellationToken);
        }

        /// <summary>
        /// Cancels/Deletes the job with the specified ID.
        /// </summary>
        /// <param name="jobId">Id of the job to cancel</param>
        /// <param name="cancellationToken">Task cancellation token</param>
        /// <returns>A response string object indicating result of the cancellation.</returns>
        public virtual Response<string> CancelImportExportJob(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            return _jobRestClient.CancelImportExportJob(jobId);
        }
    }
}
