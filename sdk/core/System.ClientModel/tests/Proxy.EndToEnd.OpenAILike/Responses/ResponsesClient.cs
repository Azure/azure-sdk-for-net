// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAILike.Responses
{
    /// <summary>
    /// Mock responses client shaped like a generated client. It snapshots the
    /// <see cref="ModelReaderWriterOptions"/> carried by its <see cref="ResponsesClientOptions"/> at construction
    /// and uses them to write request bodies and to read responses, including the nested
    /// <see cref="ResponseTool"/> values inside a <see cref="ResponseResult"/>. A proxy registered on the client
    /// options therefore takes over those reads without the client knowing about it.
    /// </summary>
    public class ResponsesClient
    {
        private static readonly Uri s_defaultEndpoint = new("https://mock.openai.test/v1/");

        private readonly Uri _endpoint;
        private readonly ClientPipeline _pipeline;
        private readonly ModelReaderWriterOptions _wireOptions;

        public ResponsesClient(ApiKeyCredential credential, ResponsesClientOptions? options = null)
        {
            if (credential is null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new ResponsesClientOptions();
            _endpoint = s_defaultEndpoint;
            _wireOptions = WireOptions.Create(options);
            _pipeline = ClientPipeline.Create(
                options,
                perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
                perTryPolicies: new PipelinePolicy[] { ApiKeyAuthenticationPolicy.CreateBearerAuthorizationPolicy(credential) },
                beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        }

        internal ResponsesClient(Uri endpoint, ClientPipeline pipeline, ModelReaderWriterOptions wireOptions)
        {
            _endpoint = endpoint;
            _pipeline = pipeline;
            _wireOptions = wireOptions;
        }

        /// <summary>Sends a GET request for the response with the given id.</summary>
        public virtual async Task<ClientResult<ResponseResult>> GetResponseAsync(string responseId, CancellationToken cancellationToken = default)
        {
            if (responseId is null)
            {
                throw new ArgumentNullException(nameof(responseId));
            }

            using PipelineMessage message = _pipeline.CreateMessage();
            message.Request.Method = "GET";
            message.Request.Uri = new Uri(_endpoint, $"responses/{Uri.EscapeDataString(responseId)}");

            return await SendAsync(message, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>Sends a POST request whose body is <paramref name="options"/> serialized with the client's wire options.</summary>
        public virtual async Task<ClientResult<ResponseResult>> CreateResponseAsync(CreateResponseOptions options, CancellationToken cancellationToken = default)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            using PipelineMessage message = _pipeline.CreateMessage();
            message.Request.Method = "POST";
            message.Request.Uri = new Uri(_endpoint, "responses");
            message.Request.Headers.Set("Content-Type", "application/json");
            message.Request.Content = BinaryContent.Create(options, _wireOptions);

            return await SendAsync(message, cancellationToken).ConfigureAwait(false);
        }

        private async Task<ClientResult<ResponseResult>> SendAsync(PipelineMessage message, CancellationToken cancellationToken)
        {
            message.Apply(new RequestOptions { CancellationToken = cancellationToken });

            await _pipeline.SendAsync(message).ConfigureAwait(false);

            PipelineResponse response = message.Response
                ?? throw new InvalidOperationException("The pipeline did not produce a response.");
            if (response.IsError)
            {
                throw await ClientResultException.CreateAsync(response).ConfigureAwait(false);
            }

            using JsonDocument document = JsonDocument.Parse(response.Content);
            return ClientResult.FromValue(ResponseResult.DeserializeResponseResult(document.RootElement, _wireOptions), response);
        }
    }
}
