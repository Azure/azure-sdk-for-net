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
        private OpenAIClientOptions.ClientType _type = OpenAIClientOptions.ClientType.AzureOpenAI;

        /// <summary> Initializes a non-Azure instance of OpenAIClient. </summary>
        /// <param name="token"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="token"/> is null. </exception>
        public OpenAIClient(string token) : this(token, new OpenAIClientOptions())
        {
        }

        /// <summary> Initializes a new instance of non-Azure OpenAIClient. </summary>
        /// <param name="token"> String token to generate a token credential </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="token"/> is null. </exception>
        public OpenAIClient(string token, OpenAIClientOptions options)
        {
            Argument.AssertNotNullOrEmpty(token, nameof(token));
            options ??= new OpenAIClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            AccessToken accessToken = new AccessToken(token, DateTimeOffset.Now.AddDays(180));
            _tokenCredential = DelegatedTokenCredential.Create((_, _) => accessToken);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = new Uri("https://api.openai.com/v1");
            _apiVersion = options.Version;
            _type = options.EndpointType;
        }

        /// <summary> Return the completion for a given prompt. </summary>
        /// <param name="deploymentId"> Deployment id (also known as model name) to use for operations </param>
        /// <param name="prompt"> Input string prompt to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Completions>> GetCompletionsAsync(string deploymentId, string prompt, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
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

            if (_type == OpenAIClientOptions.ClientType.AzureOpenAI)
            {
                Argument.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
                CompletionsOptions completionsOptions = new CompletionsOptions();
                completionsOptions.Prompt.Add(prompt);
                return GetCompletions(deploymentId, completionsOptions, cancellationToken);
            }
            else
            {
                return GetNonAzureCompletions(prompt, cancellationToken);
            }
        }

        /// <summary> Return the completions for a given prompt. </summary>
        /// <param name="prompt"> Input string prompt to create a prompt completion from a deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Completions> GetNonAzureCompletions(string prompt, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(prompt, nameof(prompt));

            CompletionsOptions completionsOptions = new CompletionsOptions();
            completionsOptions.Prompt.Add(prompt);
            completionsOptions.Model = "text-ada-001"; // OpenAI endpoints require model
            return GetOAICompletions(completionsOptions, cancellationToken);
        }
        public virtual Response<Completions> GetOAICompletions(CompletionsOptions completionsOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(completionsOptions, nameof(completionsOptions));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetOAICompletions(completionsOptions.ToRequestContent(), context);
            return Response.FromValue(Completions.FromResponse(response), response);
        }

        public virtual Response GetOAICompletions(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("OpenAIClient.GetOAICompletions");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOAIGetCompletionsRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateOAIGetCompletionsRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/completions", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }
    }
}
