// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.OpenAI
{
    // Data plane generated client.
    /// <summary> Azure OpenAI APIs for completions and search. </summary>
    public partial class OpenAIClient
    {
        private const string publicOpenAIVersion = "1";
        private const string publicOpenAIEndpoint = $"https://api.openai.com/v{publicOpenAIVersion}";

        private TokenCredential _tokenCredential;
        private HttpPipeline _pipeline;
        private Uri _endpoint;

        private string _publicOpenAIToken = string.Empty;

        public string PublicOpenAIToken
        {
            get => _publicOpenAIToken;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _publicOpenAIToken = value;
                    _endpoint = new Uri(publicOpenAIEndpoint);
                    AccessToken accessToken = new AccessToken(_publicOpenAIToken, DateTimeOffset.Now.AddDays(180));
                    _tokenCredential = DelegatedTokenCredential.Create((_, _) => accessToken);
                    _pipeline = HttpPipelineBuilder.Build(new OpenAIClientOptions(), Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
                }
            }
        }

        /// <summary> Return the completion for a given prompt. </summary>
        /// <param name="deploymentId"> Deployment id (also known as model name) to use for operations </param>
        /// <param name="prompt"> Input string prompt to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Completions>> GetCompletionsAsync(string deploymentId, string prompt, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));

            CompletionsOptions completionsOptions = new CompletionsOptions();
            completionsOptions.Prompt.Add(prompt);
            return await GetCompletionsAsync(deploymentId, completionsOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return the completions for a given prompt. </summary>
        /// <param name="deploymentId"> Deployment id (also known as model name) to use for operations </param>
        /// <param name="prompt"> Input string prompt to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Completions> GetCompletions(string deploymentId, string prompt, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));
            CompletionsOptions completionsOptions = new CompletionsOptions();
            completionsOptions.Prompt.Add(prompt);
            return GetCompletions(deploymentId, completionsOptions, cancellationToken);
        }

        internal HttpMessage CreateGetCompletionsRequest(string deploymentId, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            if (string.IsNullOrEmpty(_publicOpenAIToken))
            {
                Argument.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
                uri.AppendRaw("/openai", false);
                uri.AppendPath("/deployments/", false);
                uri.AppendPath(deploymentId, true);
                uri.AppendPath("/completions", false);
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            else
            {
                uri.AppendPath("/completions", false);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }
    }
}
