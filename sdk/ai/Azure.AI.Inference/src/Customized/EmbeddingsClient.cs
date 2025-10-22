// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Inference
{
    // CUSTOM CODE NOTE:
    //   Modified code for the ChatCompletionsClient

    /// <summary> The Embeddings service client. </summary>

    [SuppressMessage("Azure Analysis", "AZC0007", Justification = "Analyzer is incorrectly flagging valid overloads.")]
    [CodeGenSuppress("Embed", typeof(EmbeddingsOptions), typeof(ExtraParameters?), typeof(CancellationToken))]
    [CodeGenSuppress("EmbedAsync", typeof(EmbeddingsOptions), typeof(ExtraParameters?), typeof(CancellationToken))]
    public partial class EmbeddingsClient
    {
        /// <summary> Initializes a new instance of EmbeddingsClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EmbeddingsClient(Uri endpoint, AzureKeyCredential credential, AzureAIInferenceClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AzureAIInferenceClientOptions();
            credential.Deconstruct(out var key);
            options.AddPolicy(new AddApiKeyHeaderPolicy(key), HttpPipelinePosition.PerCall);

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// Return the embedding vectors for given text prompts.
        /// The method makes a REST API call to the `/embeddings` route on the given endpoint.
        /// </summary>
        /// <param name="embeddingsOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="embeddingsOptions"/> is null. </exception>
        /// <include file="./Docs/EmbeddingsClient.xml" path="doc/members/member[@name='EmbedAsync(EmbeddingsOptions,ExtraParameters?,CancellationToken)']/*" />
        public virtual async Task<Response<EmbeddingsResult>> EmbedAsync(EmbeddingsOptions embeddingsOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(embeddingsOptions, nameof(embeddingsOptions));
            ExtraParameters? extraParams = null;

            // CUSTOM CODE NOTE:
            //   If AdditionalProperties are provided, the decision has been made to default extraParams to "PassThrough"
            if (embeddingsOptions.AdditionalProperties != null && embeddingsOptions.AdditionalProperties.Count > 0)
            {
                extraParams ??= ExtraParameters.PassThrough;
            }

            using RequestContent content = embeddingsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await EmbedAsync(content, extraParams?.ToString(), context).ConfigureAwait(false);
            return Response.FromValue(EmbeddingsResult.FromResponse(response), response);
        }

        /// <summary>
        /// Return the embedding vectors for given text prompts.
        /// The method makes a REST API call to the `/embeddings` route on the given endpoint.
        /// </summary>
        /// <param name="embeddingsOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="embeddingsOptions"/> is null. </exception>
        /// <include file="./Docs/EmbeddingsClient.xml" path="doc/members/member[@name='Embed(EmbeddingsOptions,ExtraParameters?,CancellationToken)']/*" />
        public virtual Response<EmbeddingsResult> Embed(EmbeddingsOptions embeddingsOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(embeddingsOptions, nameof(embeddingsOptions));
            ExtraParameters? extraParams = null;

            // CUSTOM CODE NOTE:
            //   If AdditionalProperties are provided, the decision has been made to default extraParams to "PassThrough"
            if (embeddingsOptions.AdditionalProperties != null && embeddingsOptions.AdditionalProperties.Count > 0)
            {
                extraParams ??= ExtraParameters.PassThrough;
            }

            using RequestContent content = embeddingsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Embed(content, extraParams?.ToString(), context);
            return Response.FromValue(EmbeddingsResult.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Return the embedding vectors for given text prompts.
        /// The method makes a REST API call to the `/embeddings` route on the given endpoint.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="EmbedAsync(EmbeddingsOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="extraParams">
        /// Controls what happens if extra parameters, undefined by the REST API,
        /// are passed in the JSON request payload.
        /// This sets the HTTP request header `extra-parameters`. Allowed values: "error" | "drop" | "pass-through"
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> EmbedAsync(RequestContent content, string extraParams = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("EmbeddingsClient.Embed");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEmbedRequest(content, extraParams, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return the embedding vectors for given text prompts.
        /// The method makes a REST API call to the `/embeddings` route on the given endpoint.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Embed(EmbeddingsOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="extraParams">
        /// Controls what happens if extra parameters, undefined by the REST API,
        /// are passed in the JSON request payload.
        /// This sets the HTTP request header `extra-parameters`. Allowed values: "error" | "drop" | "pass-through"
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response Embed(RequestContent content, string extraParams = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("EmbeddingsClient.Embed");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEmbedRequest(content, extraParams, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private class AddApiKeyHeaderPolicy : HttpPipelinePolicy
        {
            public string Token { get; }

            public AddApiKeyHeaderPolicy(string token)
            {
                Token = token;
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                // Add your desired header name and value
                message.Request.Headers.Add("api-key", Token);

                ProcessNext(message, pipeline);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                // Add your desired header name and value
                message.Request.Headers.Add("api-key", Token);

                return ProcessNextAsync(message, pipeline);
            }
        }
    }
}
