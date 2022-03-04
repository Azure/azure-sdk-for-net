// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Batch.Service.Utilities;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Batch.Service.JobSchedule
{
    /// <summary>
    /// Azure Batch client, used for getting, creating, and updating job schedules.
    /// </summary>
    public class JobScheduleClient
    {
        private readonly Uri _endpoint;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly JobScheduleRestClient _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobScheduleClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint URL of the batch service.</param>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="options">Client configuration options.</param>
        public JobScheduleClient(Uri endpoint, TokenCredential credential, ClientOptions options)
        {
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, Helpers.GetDefaultScope(endpoint)));
            _clientDiagnostics = new ClientDiagnostics(options);
            _endpoint = endpoint;
            _restClient = new JobScheduleRestClient(_clientDiagnostics, _pipeline, _endpoint.AbsoluteUri, "2023-01-01.17.0");
        }

        /// <summary>
        /// Parameterless constructor for mocking an instance of the <see cref="JobScheduleClient"/> class.
        /// </summary>
        protected JobScheduleClient()
        {
        }
    }
}
