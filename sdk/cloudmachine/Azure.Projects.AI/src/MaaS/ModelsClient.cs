// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using Azure.Core;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Embeddings;

namespace Azure.AI.Models
{
    /// <summary>
    /// ModelsClient is a client for interacting with the Models AI service.
    /// </summary>
    public class ModelsClient
    {
        private readonly Uri _endpoint;
        private readonly TokenCredential? _tokenCredential;
        private readonly ApiKeyCredential? _keyCredential;
        private readonly OpenAIClientOptions _options;

        /// <summary>
        /// Constructs a ModelsClient with the specified endpoint and API key credential.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="credential"></param>
        public ModelsClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, MaaSClientHelpers.CreateOptions(endpoint))
        {}

        /// <summary>
        /// Constructs a ModelsClient with the specified endpoint and API key credential.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="credential"></param>
        /// <param name="options"></param>
        public ModelsClient(Uri endpoint, TokenCredential credential, OpenAIClientOptions options)
        {
            _options = options;
            _tokenCredential = credential;
            _endpoint = endpoint;
            _keyCredential = null;
        }

        /// <summary>
        /// Constructs a ModelsClient with the specified endpoint and API key credential.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="credential"></param>
        public ModelsClient(Uri endpoint, ApiKeyCredential credential)
            : this(endpoint, credential, MaaSClientHelpers.CreateOptions(endpoint))
        { }

        /// <summary>
        /// Constructs a ModelsClient with the specified endpoint and API key credential.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="credential"></param>
        /// <param name="options"></param>
        public ModelsClient(Uri endpoint, ApiKeyCredential credential, OpenAIClientOptions options)
        {
            _options = options;
            _keyCredential = credential;
            _endpoint = endpoint;
            _tokenCredential = null;
        }

        /// <summary>
        /// This is for mocking
        /// </summary>
        protected ModelsClient() {
            _endpoint = null!;
            _keyCredential = null;
            _tokenCredential = null;
            _options = null!;
        }

        /// <summary>
        /// Get a chat client for the specified model.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public ChatClient GetChatClient(string model)
        {
            if (_keyCredential!= null)
                return new ModelsChatClient(model, _endpoint, _keyCredential);
            if (_tokenCredential != null)
                return new ModelsChatClient(model, _endpoint, _tokenCredential);
            throw new InvalidOperationException("No credential provided.");
        }

        /// <summary>
        /// Get an embedding client for the specified model.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public EmbeddingClient GetEmbeddingClient(string model)
        {
            if (_keyCredential!= null)
                return new ModelEmbeddingsClient(model, _endpoint, _keyCredential);
            if (_tokenCredential != null)
                return new ModelEmbeddingsClient(model, _endpoint, _tokenCredential);
            throw new InvalidOperationException("No credential provided.");
        }
    }
}
