// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.Proxy.OpenAILike
{
    /// <summary>
    /// A minimal "OpenAI-like" client. It mirrors a generated SDK client: it owns a
    /// <see cref="ClientPipeline"/> and, on each call, sends a request, reads the response body, and
    /// deserializes it through <see cref="ModelReaderWriter"/> using the caller-provided
    /// <see cref="ModelReaderWriterOptions"/>. Because those options can carry a registered proxy, this
    /// <c>Read</c> is the exact join point where a conditional proxy takes over — which makes a call to
    /// this client a true end-to-end exercise of the proxy feature.
    /// </summary>
    public class ResponseToolsClient
    {
        private readonly ClientPipeline _pipeline;
        private readonly ModelReaderWriterOptions _mrwOptions;
        private readonly Uri _endpoint;

        /// <summary>Creates a client against a mock endpoint using the supplied pipeline and MRW options.</summary>
        public ResponseToolsClient(ClientPipelineOptions pipelineOptions, ModelReaderWriterOptions mrwOptions)
            : this(new Uri("https://mock.openai.test"), pipelineOptions, mrwOptions)
        {
        }

        /// <summary>Creates a client against <paramref name="endpoint"/> using the supplied pipeline and MRW options.</summary>
        public ResponseToolsClient(Uri endpoint, ClientPipelineOptions pipelineOptions, ModelReaderWriterOptions mrwOptions)
        {
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            _pipeline = ClientPipeline.Create(pipelineOptions ?? new ClientPipelineOptions());
            _mrwOptions = mrwOptions ?? new ModelReaderWriterOptions("J");
        }

        /// <summary>
        /// Simulates a service call that returns a response tool. The response body is produced by the
        /// pipeline's transport (a mock in tests); deserialization routes through any proxy registered
        /// on the client's <see cref="ModelReaderWriterOptions"/>.
        /// </summary>
        /// <param name="toolId">An identifier included in the request URI.</param>
        /// <returns>The deserialized <see cref="ResponseTool"/> — a proxy-provided subtype when a proxy handled it.</returns>
        public ResponseTool GetTool(string toolId)
        {
            PipelineMessage message = _pipeline.CreateMessage();
            message.Request.Method = "GET";
            message.Request.Uri = new Uri(_endpoint, $"/tools/{toolId}");

            _pipeline.Send(message);

            PipelineResponse response = message.Response
                ?? throw new InvalidOperationException("The pipeline did not produce a response.");

            return ModelReaderWriter.Read<ResponseTool>(response.Content, _mrwOptions)!;
        }
    }
}
