// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.Agents.Persistent
{
    /// <summary> A convenience client that provides access to all persistent agents sub-clients. </summary>
    public class PersistentAgentsClient
    {
        /// <summary> Initializes a new instance of the <see cref="PersistentAgentsClient"/> class for mocking. </summary>
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

        /// <summary> Creates a new thread and immediately starts a run against it. </summary>
        /// <param name="assistantId"> The identifier of the agent to run. </param>
        /// <param name="options"> The options for thread creation and run configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The <see cref="ThreadRun"/> representing the created run. </returns>
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
                metadata: options.Metadata?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                cancellationToken: cancellationToken
            );
        }

        /// <summary> Creates a new thread and immediately starts a run against it. </summary>
        /// <param name="assistantId"> The identifier of the agent to run. </param>
        /// <param name="options"> The options for thread creation and run configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The <see cref="ThreadRun"/> representing the created run. </returns>
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
                metadata: options.Metadata?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary> Gets the administration sub-client. </summary>
        public PersistentAgentsAdministrationClient Administration { get => _client; }
        /// <summary> Gets the files sub-client. </summary>
        public PersistentAgentsFiles Files { get => _client.GetPersistentAgentsFilesClient(); }
        /// <summary> Gets the messages sub-client. </summary>
        public ThreadMessages Messages { get => _client.GetThreadMessagesClient(); }
        /// <summary> Gets the threads sub-client. </summary>
        public Threads Threads { get => _client.GetThreadsClient(); }
        /// <summary> Gets the runs sub-client. </summary>
        public ThreadRuns Runs { get => _client.GetThreadRunsClient(); }
        /// <summary> Gets the vector stores sub-client. </summary>
        public VectorStores VectorStores { get => _client.GetVectorStoresClient(); }
    }
}
