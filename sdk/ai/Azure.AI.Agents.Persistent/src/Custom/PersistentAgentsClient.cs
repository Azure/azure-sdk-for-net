// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Azure.AI.Agents.Persistent.Custom;
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

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsClient(string endpoint, AzureKeyCredential credential, PersistentAgentsAdministrationClientOptions options)
        {
            _client = new(endpoint, credential, options);
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsClient(string endpoint, AzureKeyCredential credential) : this(endpoint, credential, new PersistentAgentsAdministrationClientOptions())
        {
        }

        public virtual Response<ThreadRun> CreateThreadAndRun(string assistantId, PersistentAgentThreadCreationOptions thread = null, string overrideModelName = null, string overrideInstructions = null, IEnumerable<ToolDefinition> overrideTools = null, UpdateToolResourcesOptions toolResources = null, bool? stream = null, float? temperature = null, float? topP = null, int? maxPromptTokens = null, int? maxCompletionTokens = null, TruncationObject truncationStrategy = null, BinaryData toolChoice = null, BinaryData responseFormat = null, bool? parallelToolCalls = null, IReadOnlyDictionary<string, string> metadata = null, CancellationToken cancellationToken = default)
        {
            return _client.CreateThreadAndRun(
                assistantId: assistantId,
                thread: thread,
                overrideModelName: overrideModelName,
                overrideInstructions: overrideInstructions,
                overrideTools: overrideTools,
                toolResources: toolResources,
                stream: stream,
                temperature: temperature,
                topP: topP,
                maxPromptTokens: maxPromptTokens,
                maxCompletionTokens: maxCompletionTokens,
                truncationStrategy: truncationStrategy,
                toolChoice: toolChoice,
                responseFormat: responseFormat,
                parallelToolCalls: parallelToolCalls,
                metadata: metadata,
                cancellationToken: cancellationToken
            );
        }

        public virtual async Task<Response<ThreadRun>> CreateThreadAndRunAsync(string assistantId, PersistentAgentThreadCreationOptions thread = null, string overrideModelName = null, string overrideInstructions = null, IEnumerable<ToolDefinition> overrideTools = null, UpdateToolResourcesOptions toolResources = null, bool? stream = null, float? temperature = null, float? topP = null, int? maxPromptTokens = null, int? maxCompletionTokens = null, TruncationObject truncationStrategy = null, BinaryData toolChoice = null, BinaryData responseFormat = null, bool? parallelToolCalls = null, IReadOnlyDictionary<string, string> metadata = null, CancellationToken cancellationToken = default)
        {
            return await _client.CreateThreadAndRunAsync(
                assistantId: assistantId,
                thread: thread,
                overrideModelName: overrideModelName,
                overrideInstructions: overrideInstructions,
                overrideTools: overrideTools,
                toolResources: toolResources,
                stream: stream,
                temperature: temperature,
                topP: topP,
                maxPromptTokens: maxPromptTokens,
                maxCompletionTokens: maxCompletionTokens,
                truncationStrategy: truncationStrategy,
                toolChoice: toolChoice,
                responseFormat: responseFormat,
                parallelToolCalls: parallelToolCalls,
                metadata: metadata,
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);
        }

        public PersistentAgentsAdministrationClient AgentsAdministration { get => _client; }
        public PersistentAgentsFilesClient PersistentAgentsFiles { get => _client.GetPersistentAgentsFilesClient(); }
        public ThreadMessagesClient Messages { get => _client.GetThreadMessagesClient();}
        public ThreadsClient Threads { get => _client.GetThreadsClient(); }
        public ThreadRunsClient ThreadRuns { get => _client.GetThreadRunsClient(); }
        public ThreadRunStepsClient ThreadRunSteps { get => _client.GetThreadRunStepsClient(); }
        public VectorStoresClient VectorStores { get => _client.GetVectorStoresClient(); }
        public VectorStoreFileBatchesClient VectorStoreFileBatches { get => _client.GetVectorStoreFileBatchesClient(); }
        public VectorStoreFilesClient VectorStoreFiles { get => _client.GetVectorStoreFilesClient(); }
    }
}
