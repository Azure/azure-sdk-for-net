// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core;

namespace Azure.AI.Agents.Persistent
{
    public class PersistentAgentsClient
    {
        protected PersistentAgentsClient()
        { }

        internal PersistentAgentsClient(PersistentAgentsAdministrationClient client)
        {
            _client = client;
        }

        private PersistentAgentsAdministrationClient _client;
        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsClient(string endpoint, TokenCredential credential) : this(endpoint, credential, new PersistentAgentsAdministrationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsClient(string endpoint, TokenCredential credential, PersistentAgentsAdministrationClientOptions options)
        {
            _client = new(endpoint, credential, options);
        }

        public virtual Response<ThreadRun> CreateThreadAndRun(string assistantId, ThreadAndRunOptions options, CancellationToken cancellationToken = default)
        {
            return _client.CreateThreadAndRun(
                assistantId: assistantId,
                thread: options.ThreadOptions,
                overrideModelName: options.OverrideModelName,
                overrideInstructions: options.OverrideInstructions,
                overrideTools: options.OverrideTools,
                toolResources: options.ToolResources,
                stream: options.Stream,
                temperature: options.Temperature,
                topP: options.TopP,
                maxPromptTokens: options.MaxPromptTokens,
                maxCompletionTokens: options.MaxCompletionTokens,
                truncationStrategy: options.TruncationStrategy,
                toolChoice: options.ToolChoice,
                responseFormat: options.ResponseFormat,
                parallelToolCalls: options.ParallelToolCalls,
                metadata: options.Metadata,
                cancellationToken: cancellationToken
            );
        }

        public virtual async Task<Response<ThreadRun>> CreateThreadAndRunAsync(string assistantId, ThreadAndRunOptions options, CancellationToken cancellationToken = default)
        {
            return await _client.CreateThreadAndRunAsync(
                assistantId: assistantId,
                thread: options.ThreadOptions,
                overrideModelName: options.OverrideModelName,
                overrideInstructions: options.OverrideInstructions,
                overrideTools: options.OverrideTools,
                toolResources: options.ToolResources,
                stream: options.Stream,
                temperature: options.Temperature,
                topP: options.TopP,
                maxPromptTokens: options.MaxPromptTokens,
                maxCompletionTokens: options.MaxCompletionTokens,
                truncationStrategy: options.TruncationStrategy,
                toolChoice: options.ToolChoice,
                responseFormat: options.ResponseFormat,
                parallelToolCalls: options.ParallelToolCalls,
                metadata: options.Metadata,
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);
        }

        public PersistentAgentsAdministrationClient Administration { get => _client; }
        public PersistentAgentsFiles Files { get => _client.GetPersistentAgentsFilesClient(); }
        public ThreadMessages Messages { get => _client.GetThreadMessagesClient();}
        public Threads Threads { get => _client.GetThreadsClient(); }
        public ThreadRuns Runs { get => _client.GetThreadRunsClient(); }
        public VectorStores VectorStores { get => _client.GetVectorStoresClient(); }
    }
}
