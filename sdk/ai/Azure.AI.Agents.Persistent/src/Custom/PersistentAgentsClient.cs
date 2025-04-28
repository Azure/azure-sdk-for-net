// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.AI.Agents.Persistent.Custom;
using Azure.Core;

namespace Azure.AI.Agents.Persistent
{
    public class PersistentAgentsClient
    {
        protected PersistentAgentsClient()
        { }

        private AgentsAdministrationClient _client;
        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsClient(string endpoint, TokenCredential credential) : this(endpoint, credential, new AgentsAdministrationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsClient(string endpoint, TokenCredential credential, AgentsAdministrationClientOptions options)
        {
            _client = new(endpoint, credential, options);
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsClient(string endpoint, AzureKeyCredential credential, AgentsAdministrationClientOptions options)
        {
            _client = new(endpoint, credential, options);
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsClient(string endpoint, AzureKeyCredential credential) : this(endpoint, credential, new AgentsAdministrationClientOptions())
        {
        }

        public AgentsAdministrationClient AgentsAdministration { get => _client; }
        public FilesClient Files { get => _client.GetFilesClient(); }
        public ThreadMessagesClient Messages { get => _client.GetThreadMessagesClient();}
        public ThreadsClient Threads { get => _client.GetThreadsClient(); }
        public RunsClient Runs { get => _client.GetRunsClient(); }
        public RunStepsClient RunSteps { get => _client.GetRunStepsClient(); }
        public VectorStoresClient VectorStores { get => _client.GetVectorStoresClient(); }
        public VectorStoreFileBatchesClient VectorStoreFileBatches { get => _client.GetVectorStoreFileBatchesClient(); }
        public VectorStoreFilesClient VectorStoreFiles { get => _client.GetVectorStoreFilesClient(); }
    }
}
