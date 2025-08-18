// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI;

namespace Azure.AI.Projects
{
    // Data plane generated client.
    /// <summary> The AzureAI service client. </summary>
    public partial class AIProjectClient : ClientConnectionProvider
    {
        #nullable enable

        /// <summary>
        /// Gets the OpenAI client.
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="apiVersion"></param>
        /// <returns></returns>
        public virtual OpenAIClient GetOpenAIClient(string? connectionName = null, string? apiVersion = null)
        {
            AzureOpenAIClientKey openAIClientKey = new();

            AzureOpenAIClient aoaiClient = Subclients.GetClient(openAIClientKey, () => CreateAzureOpenAIClient(connectionName, apiVersion));

            return aoaiClient;
        }

        private AzureOpenAIClient CreateAzureOpenAIClient(string? connectionName = null, string? apiVersion = null)
        {
            if (!string.IsNullOrEmpty(connectionName))
            {
                ConnectionProperties selectedConnection = Connections.GetConnection(connectionName, includeCredentials: true);
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
                else if (selectedConnection.Credentials is EntraIDCredentials)
                {
                    return new AzureOpenAIClient(new Uri(endpoint), this._tokenCredential);
                }
            }
            ClientConnection connection = GetConnection(typeof(AzureOpenAIClient).FullName!);

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
            ClientConnection connection = GetConnection(typeof(ChatClient).FullName!);
            ChatClient chat = client.GetChatClient(deploymentName ?? connection.Locator);
            return chat;
        }

        private EmbeddingClient CreateEmbeddingClient(AzureOpenAIClient client, string? deploymentName = null)
        {
            ClientConnection connection = GetConnection(typeof(EmbeddingClient).FullName!);
            EmbeddingClient embedding = client.GetEmbeddingClient(deploymentName ?? connection.Locator);
            return embedding;
        }

        private record AzureOpenAIClientKey();
        private class ChatClientKey
        {
            public string? DeploymentName { get; }
            public ChatClientKey(string? deploymentName) => DeploymentName = deploymentName;
            public override bool Equals(object? obj) => obj is ChatClientKey other && DeploymentName == other.DeploymentName;
            public override int GetHashCode() => DeploymentName?.GetHashCode() ?? 0;
        }

        private class EmbeddingClientKey
        {
            public string? DeploymentName { get; }
            public EmbeddingClientKey(string? deploymentName) => DeploymentName = deploymentName;
            public override bool Equals(object? obj) => obj is EmbeddingClientKey other && DeploymentName == other.DeploymentName;
            public override int GetHashCode() => DeploymentName?.GetHashCode() ?? 0;
        }
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
