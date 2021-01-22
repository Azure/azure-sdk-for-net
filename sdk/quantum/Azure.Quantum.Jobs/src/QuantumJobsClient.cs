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
        public QuantumJobsClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new MiniSecretClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumJobsClient"/>.
        /// </summary>
        public QuantumJobsClient(Uri endpoint, TokenCredential credential, MiniSecretClientOptions options) : this(
            new ClientDiagnostics(options),
            HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://vault.azure.net/.default")),
            endpoint.ToString(),
            options.Version)
        {
        }

        /// <summary> Initializes a new instance of QuantumJobsClient for mocking. </summary>
        protected QuantumJobsClient()
        {
        }
        /// <summary> Initializes a new instance of QuantumJobsClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="vaultBaseUrl"> The vault name, for example https://myvault.vault.azure.net. </param>
        /// <param name="apiVersion"> Api Version. </param>
        internal QuantumJobsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string vaultBaseUrl, string apiVersion = "7.0")
        {
            JobsRestClient = new JobsRestClient(clientDiagnostics, pipeline, vaultBaseUrl, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        public Response<JobDetails> Create(string jobId, JobDetails job, CancellationToken cancellationToken = default)
        {
            return JobsRestClient.Create(jobId, job, cancellationToken);
        }

        public Response<JobDetailsList> List(CancellationToken cancellationToken = default)
        {
            return JobsRestClient.List(cancellationToken);
        }

        public Response<JobDetails> Get(string jobId, CancellationToken cancellationToken = default)
        {
            return JobsRestClient.Get(jobId, cancellationToken);
        }

        public Response Cancel(string jobId, CancellationToken cancellationToken = default)
        {
            return JobsRestClient.Cancel(jobId, cancellationToken);
        }
    }
}
