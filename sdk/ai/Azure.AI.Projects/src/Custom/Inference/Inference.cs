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
            // OverrideApiVersionPolicy overrideApiVersionPolicy = new OverrideApiVersionPolicy(AIProjectClientOptions.ServiceVersion.V2025_05_15_Preview.ToString());
            OverrideApiVersionPolicy overrideApiVersionPolicy = new OverrideApiVersionPolicy("2024-05-01-preview"); // TODO: update to default version or remove this line

            options.AddPolicy(overrideApiVersionPolicy, HttpPipelinePosition.PerRetry);
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
            // OverrideApiVersionPolicy overrideApiVersionPolicy = new OverrideApiVersionPolicy(AIProjectClientOptions.ServiceVersion.V2025_05_15_Preview.ToString());
            // OverrideApiVersionPolicy overrideApiVersionPolicy = new OverrideApiVersionPolicy("2025-05-15-preview");

            // options.AddPolicy(overrideApiVersionPolicy, HttpPipelinePosition.PerRetry);
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
            // OverrideApiVersionPolicy overrideApiVersionPolicy = new OverrideApiVersionPolicy(AIProjectClientOptions.ServiceVersion.V2025_05_15_Preview.ToString());
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
        /// <param name="apiVersion"></param>
        /// <param name="deploymentName"></param>
        /// <returns></returns>
        public ChatClient GetAzureOpenAIChatClient(string? apiVersion = null, string? deploymentName = null)
        {
            ChatClientKey chatClientKey = new(deploymentName);
            AzureOpenAIClientKey openAIClientKey = new();

            ChatClient chatClient = this.Subclients.GetClient(chatClientKey, () =>
            {
                AzureOpenAIClient aoaiClient = this.Subclients.GetClient(openAIClientKey, () => CreateAzureOpenAIClient(apiVersion));
                return this.CreateChatClient(aoaiClient, deploymentName);
            });

            return chatClient;
        }

        private AzureOpenAIClient CreateAzureOpenAIClient(string? apiVersion = null)
        {
            ClientConnection connection = this.GetConnection(typeof(AzureOpenAIClient).FullName!);

            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }

            uri = new Uri($"https://{uri.Host}/openai/deployments");

            AzureOpenAIClientOptions options = new AzureOpenAIClientOptions();
            // OverrideApiVersionPolicy overrideApiVersionPolicy = new OverrideApiVersionPolicy(AIProjectClientOptions.ServiceVersion.V2025_05_15_Preview.ToString());
            OverrideApiVersionPolicy overrideApiVersionPolicy = new OverrideApiVersionPolicy(apiVersion ?? "2024-05-01-preview");

            options.AddPolicy(overrideApiVersionPolicy, HttpPipelinePosition.PerRetry);
            BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy((TokenCredential)connection.Credential!, AuthorizationScopes);
            options.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

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
        private record ChatClientKey(string? deploymentName); // TODO: this line is causing an issue with netstandard2.0, I added custom/IsExternalInit.cs as a workaround but i dont think it's ideal

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
        #nullable disable
    }
}
