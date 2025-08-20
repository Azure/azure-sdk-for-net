// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.AI.Inference;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Azure.AI.OpenAI;
using OpenAI.Chat;

namespace Azure.AI.Projects
{
    // Data plane generated client.
    /// <summary> The AzureAI service client. </summary>
    public partial class AIProjectClient : ClientConnectionProvider
    {
        #nullable enable
        public ChatCompletionsClient GetChatCompletionsClient()
        {
            ChatCompletionsClientKey chatCompletionsClientKey = new();
            ChatCompletionsClient chatClient = this.Subclients.GetClient(chatCompletionsClientKey, () => CreateChatCompletionsClient());
            return chatClient;
        }

        private ChatCompletionsClient CreateChatCompletionsClient()
        {
            ClientConnection connection = this.GetConnection(typeof(ChatCompletionsClient).FullName!);

            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }
            uri = new Uri($"https://{uri.Host}/models");

            AzureAIInferenceClientOptions options = new AzureAIInferenceClientOptions();
            BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy((TokenCredential)connection.Credential!, AuthorizationScopes);
            options.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

            return connection.CredentialKind switch
            {
                CredentialKind.ApiKeyString => new ChatCompletionsClient(uri, new AzureKeyCredential((string)connection.Credential!)),
                CredentialKind.TokenCredential => new ChatCompletionsClient(uri, (TokenCredential)connection.Credential!, options),
                _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
            };
        }

        private record ChatCompletionsClientKey();

        /// <summary>
        /// Gets the embeddings client.
        /// </summary>
        /// <returns></returns>
        public EmbeddingsClient GetEmbeddingsClient()
        {
            EmbeddingsClientKey embeddingsClientKey = new();
            EmbeddingsClient embeddingsClient = this.Subclients.GetClient(embeddingsClientKey, () => CreateEmbeddingsClient());
            return embeddingsClient;
        }

        private EmbeddingsClient CreateEmbeddingsClient()
        {
            ClientConnection connection = this.GetConnection(typeof(ChatCompletionsClient).FullName!);

            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }
            uri = new Uri($"https://{uri.Host}/models");

            AzureAIInferenceClientOptions options = new AzureAIInferenceClientOptions();
            BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy((TokenCredential)connection.Credential!, AuthorizationScopes);
            options.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

            return connection.CredentialKind switch
            {
                CredentialKind.ApiKeyString => new EmbeddingsClient(uri, new AzureKeyCredential((string)connection.Credential!)),
                CredentialKind.TokenCredential => new EmbeddingsClient(uri, (TokenCredential)connection.Credential!, options),
                _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
            };
        }

        private record EmbeddingsClientKey();

        /// <summary>
        /// Gets the image embeddings client.
        /// </summary>
        /// <returns></returns>
        public ImageEmbeddingsClient GetImageEmbeddingsClient()
        {
            ImageEmbeddingsClientKey imageEmbeddingsClientKey = new();
            ImageEmbeddingsClient imageEmbeddingsClient = this.Subclients.GetClient(imageEmbeddingsClientKey, () => CreateImageEmbeddingsClient());
            return imageEmbeddingsClient;
        }

        private ImageEmbeddingsClient CreateImageEmbeddingsClient()
        {
            ClientConnection connection = this.GetConnection(typeof(ImageEmbeddingsClient).FullName!);

            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }
            uri = new Uri($"https://{uri.Host}/models");

            AzureAIInferenceClientOptions options = new AzureAIInferenceClientOptions();
            OverrideApiVersionPolicy overrideApiVersionPolicy = new OverrideApiVersionPolicy("2024-05-01-preview");

            options.AddPolicy(overrideApiVersionPolicy, HttpPipelinePosition.PerRetry);
            BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy((TokenCredential)connection.Credential!, AuthorizationScopes);
            options.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

            return connection.CredentialKind switch
            {
                CredentialKind.ApiKeyString => new ImageEmbeddingsClient(uri, new AzureKeyCredential((string)connection.Credential!)),
                CredentialKind.TokenCredential => new ImageEmbeddingsClient(uri, (TokenCredential)connection.Credential!, options),
                _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
            };
        }

        private record ImageEmbeddingsClientKey();

        /// <summary>
        /// Gets the OpenAI chat client.
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="apiVersion"></param>
        /// <param name="deploymentName"></param>
        /// <returns></returns>
        public ChatClient GetAzureOpenAIChatClient(string? connectionName = null, string? apiVersion = null, string? deploymentName = null)
        {
            ChatClientKey chatClientKey = new();
            AzureOpenAIClientKey openAIClientKey = new();

            ChatClient chatClient = this.Subclients.GetClient(chatClientKey, () =>
            {
                AzureOpenAIClient aoaiClient = this.Subclients.GetClient(openAIClientKey, () => CreateAzureOpenAIClient(connectionName, apiVersion));
                return this.CreateChatClient(aoaiClient, deploymentName);
            });

            return chatClient;
        }

        private AzureOpenAIClient CreateAzureOpenAIClient(string? connectionName = null, string? apiVersion = null)
        {
            if (!string.IsNullOrEmpty(connectionName))
            {
                Connection selectedConnection = this.GetConnectionsClient().Get(connectionName, includeCredentials: true);
                if (selectedConnection.Type != ConnectionType.AzureOpenAI)
                {
                    throw new InvalidOperationException($"Connection '{connectionName}' is not of type AzureOpenAI.");
                }
                string endpoint = selectedConnection.Target.EndsWith("/")
                    ? selectedConnection.Target.Substring(0, selectedConnection.Target.Length - 1)
                    : selectedConnection.Target;

                if (selectedConnection.Credentials is ApiKeyCredentials apiKeyCreds)
                {
                    if (string.IsNullOrEmpty(apiKeyCreds.ApiKey))
                    {
                        throw new InvalidOperationException("Connection does not have an api key.");
                    }
                    string apiKey = apiKeyCreds.ApiKey;
                    return new AzureOpenAIClient(new Uri(endpoint), new ApiKeyCredential(apiKey));
                }
                ;
            }
            ClientConnection connection = this.GetConnection(typeof(AzureOpenAIClient).FullName!);

            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }

            uri = new Uri($"https://{uri.Host}");

            AzureOpenAIClientOptions options = new AzureOpenAIClientOptions();

            if (apiVersion != null)
            {
                OverrideApiVersionPolicyPipeline overrideApiVersionPolicy = new OverrideApiVersionPolicyPipeline(apiVersion);
                options.AddPolicy(overrideApiVersionPolicy, PipelinePosition.PerTry);
            }

            options.Audience = new AzureOpenAIAudience(AuthorizationScopes[0]);

            return connection.CredentialKind switch
            {
                CredentialKind.ApiKeyString => new AzureOpenAIClient(uri, new ApiKeyCredential((string)connection.Credential!)),
                CredentialKind.TokenCredential => new AzureOpenAIClient(uri, (TokenCredential)connection.Credential!, options),
                _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
            };
        }

        private ChatClient CreateChatClient(AzureOpenAIClient client, string? deploymentName = null)
        {
            ClientConnection connection = this.GetConnection(typeof(ChatClient).FullName!);
            ChatClient chat = client.GetChatClient(deploymentName ?? connection.Locator);
            return chat;
        }

        private record AzureOpenAIClientKey();
        private record ChatClientKey();
        private class OverrideApiVersionPolicy : HttpPipelinePolicy
        {
            private string ApiVersion { get; }

            public OverrideApiVersionPolicy(string apiVersion)
            {
                ApiVersion = apiVersion;
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                message.Request.Uri.Query = $"?api-version={ApiVersion}";
                ProcessNext(message, pipeline);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                message.Request.Uri.Query = $"?api-version={ApiVersion}";
                var task = ProcessNextAsync(message, pipeline);

                return task;
            }
        }

        private class OverrideApiVersionPolicyPipeline : PipelinePolicy
        {
            private string ApiVersion { get; }

            public OverrideApiVersionPolicyPipeline(string apiVersion)
            {
                ApiVersion = apiVersion;
            }

            public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int index)
            {
                if (message.Request.Uri != null)
                {
                    var uriBuilder = new UriBuilder(message.Request.Uri);
                    uriBuilder.Query = $"api-version={ApiVersion}";
                    message.Request.Uri = uriBuilder.Uri;
                }
                ProcessNext(message, pipeline, index);
            }

            public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int index)
            {
                if (message.Request.Uri != null)
                {
                    var uriBuilder = new UriBuilder(message.Request.Uri);
                    uriBuilder.Query = $"api-version={ApiVersion}";
                    message.Request.Uri = uriBuilder.Uri;
                }
                return ProcessNextAsync(message, pipeline, index);
            }
        }
        #nullable disable
    }
}
