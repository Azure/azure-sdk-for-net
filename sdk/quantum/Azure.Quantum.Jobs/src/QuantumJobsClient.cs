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
    /// The sample secrets client.
    /// </summary>
    public class QuantumJobsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal JobsRestClient JobsRestClient { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumJobsClient"/>.
        /// </summary>
//TODO         public QuantumJobsClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new MiniSecretClientOptions())
//         {
//         }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumJobsClient"/>.
        /// </summary>
//TODO         public QuantumJobsClient(Uri endpoint, TokenCredential credential, MiniSecretClientOptions options) : this(
//             new ClientDiagnostics(options),
//             HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://vault.azure.net/.default")),
//             endpoint.ToString(),
//             options.Version)
//         {
//         }

        /// <summary> Initializes a new instance of QuantumJobsClient for mocking. </summary>
        protected QuantumJobsClient()
        {
        }

        /// <summary> Initializes a new instance of JobsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000). </param>
        /// <param name="resourceGroupName"> Name of an Azure resource group. </param>
        /// <param name="workspaceName"> Name of the workspace. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, or <paramref name="workspaceName"/> is null. </exception>
        internal QuantumJobsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, string resourceGroupName, string workspaceName, Uri endpoint = null)
        {
            JobsRestClient = new JobsRestClient(clientDiagnostics, pipeline, subscriptionId, resourceGroupName, workspaceName, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Create a job. </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="job"> The complete metadata of the job to submit. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="job"/> is null. </exception>
        public Response<JobDetails> Create(string jobId, JobDetails job, CancellationToken cancellationToken = default)
        {
            return JobsRestClient.Create(jobId, job, cancellationToken);
        }

        /// <summary> List jobs. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<JobDetailsList> List(CancellationToken cancellationToken = default)
        {
            return JobsRestClient.List(cancellationToken);
        }

        /// <summary> Get job by id. </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public Response<JobDetails> Get(string jobId, CancellationToken cancellationToken = default)
        {
            return JobsRestClient.Get(jobId, cancellationToken);
        }

        /// <summary> Cancel a job. </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public Response Cancel(string jobId, CancellationToken cancellationToken = default)
        {
            return JobsRestClient.Cancel(jobId, cancellationToken);
        }
    }
}
