// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Pipeline;
using Azure.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using Azure.AI.Inference.Telemetry;

namespace Azure.AI.Inference
{
    [SuppressMessage("Azure Analysis", "AZC0007", Justification = "Analyzer is incorrectly flagging valid overloads.")]
    [CodeGenSuppress("Embed", typeof(ImageEmbeddingsOptions), typeof(ExtraParameters?), typeof(CancellationToken))]
    [CodeGenSuppress("EmbedAsync", typeof(ImageEmbeddingsOptions), typeof(ExtraParameters?), typeof(CancellationToken))]
    public partial class ImageEmbeddingsClient
    {
        /// <summary> Initializes a new instance of ImageEmbeddingsClient. </summary>
        /// <param name="endpoint"> Service host. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ImageEmbeddingsClient(Uri endpoint, AzureKeyCredential credential, AzureAIInferenceClientOptions options)
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
        /// Return the embedding vectors for given images.
        /// The method makes a REST API call to the `/images/embeddings` route on the given endpoint.
        /// </summary>
        /// <param name="imageEmbeddingsOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageEmbeddingsOptions"/> is null. </exception>
        public virtual async Task<Response<EmbeddingsResult>> EmbedAsync(ImageEmbeddingsOptions imageEmbeddingsOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(imageEmbeddingsOptions, nameof(imageEmbeddingsOptions));
            ExtraParameters? extraParams = null;

            // CUSTOM CODE NOTE:
            //   If AdditionalProperties are provided, the decision has been made to default extraParams to "PassThrough"
            if (imageEmbeddingsOptions.AdditionalProperties != null && imageEmbeddingsOptions.AdditionalProperties.Count > 0)
            {
                extraParams ??= ExtraParameters.PassThrough;
            }

            using RequestContent content = imageEmbeddingsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await EmbedAsync(content, extraParams?.ToString(), context).ConfigureAwait(false);
            return Response.FromValue(EmbeddingsResult.FromResponse(response), response);
        }

        /// <summary>
        /// Return the embedding vectors for given images.
        /// The method makes a REST API call to the `/images/embeddings` route on the given endpoint.
        /// </summary>
        /// <param name="imageEmbeddingsOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageEmbeddingsOptions"/> is null. </exception>
        public virtual Response<EmbeddingsResult> Embed(ImageEmbeddingsOptions imageEmbeddingsOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(imageEmbeddingsOptions, nameof(imageEmbeddingsOptions));
            ExtraParameters? extraParams = null;

            // CUSTOM CODE NOTE:
            //   If AdditionalProperties are provided, the decision has been made to default extraParams to "PassThrough"
            if (imageEmbeddingsOptions.AdditionalProperties != null && imageEmbeddingsOptions.AdditionalProperties.Count > 0)
            {
                extraParams ??= ExtraParameters.PassThrough;
            }

            using RequestContent content = imageEmbeddingsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Embed(content, extraParams?.ToString(), context);
            return Response.FromValue(EmbeddingsResult.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Return the embedding vectors for given images.
        /// The method makes a REST API call to the `/images/embeddings` route on the given endpoint.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="EmbedAsync(ImageEmbeddingsOptions,CancellationToken)"/> convenience overload with strongly typed models first.
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
        internal virtual async Task<Response> EmbedAsync(RequestContent content, string extraParams = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ImageEmbeddingsClient.Embed");
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
        /// [Protocol Method] Return the embedding vectors for given images.
        /// The method makes a REST API call to the `/images/embeddings` route on the given endpoint.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Embed(ImageEmbeddingsOptions,CancellationToken)"/> convenience overload with strongly typed models first.
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
        internal virtual Response Embed(RequestContent content, string extraParams = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ImageEmbeddingsClient.Embed");
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
