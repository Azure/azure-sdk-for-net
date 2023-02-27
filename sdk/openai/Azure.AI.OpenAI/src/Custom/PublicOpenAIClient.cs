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
    /// <summary> Public OpenAI APIs for completions and search. </summary>
    public partial class PublicOpenAIClient : OpenAIClient
    {
        private const string publicOpenAIVersion = "1";
        private const string publicOpenAIEndpoint = $"https://api.openai.com/v{publicOpenAIVersion}";

        /// <summary> Initializes a new instance of PublicOpenAIClient for mocking. </summary>
        protected PublicOpenAIClient()
        {
        }

        /// <summary> Initializes a instance of OpenAIClient using the public OpenAI endpoint. </summary>
        /// <param name="token"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="token"/> is null. </exception>
        public PublicOpenAIClient(string token) : this(token, new OpenAIClientOptions())
        {
        }

        /// <summary> Initializes a instance of OpenAIClient using the public OpenAI endpoint. </summary>
        /// <param name="token"> String token to generate a token credential </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="token"/> is null. </exception>
        public PublicOpenAIClient(string token, OpenAIClientOptions options) : base(new Uri(publicOpenAIEndpoint), CreateDelegatedToken(token), options)
        {
        }

        internal new HttpMessage CreateGetCompletionsRequest(string _, RequestContent content, RequestContext context)
        {
            var endpoint = (Uri) (GetType().GetField("_endpoint").GetValue(this));
            var pipeline = (HttpPipeline) (GetType().GetField("_pipeline").GetValue(this));
            var privateResponseClassifier200 = (ResponseClassifier) (GetType().GetField("_responseClassifier200").GetValue(this));
            var responseClassifier200 = privateResponseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
            var message = pipeline.CreateMessage(context, responseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/completions", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static TokenCredential CreateDelegatedToken(string token)
        {
            AccessToken accessToken = new AccessToken(token, DateTimeOffset.Now.AddDays(180));
            return DelegatedTokenCredential.Create((_, _) => accessToken);
        }
    }
}
