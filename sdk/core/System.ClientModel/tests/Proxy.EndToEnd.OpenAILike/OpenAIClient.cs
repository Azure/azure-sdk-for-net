// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using OpenAILike.Responses;

namespace OpenAILike
{
    /// <summary>
    /// Mock root client. It snapshots the <see cref="ModelReaderWriterOptions"/> carried by its
    /// <see cref="OpenAIClientOptions"/> at construction and hands the same pipeline and snapshot to each
    /// subclient it creates, the way a generated root client does.
    /// </summary>
    public class OpenAIClient
    {
        private static readonly Uri s_defaultEndpoint = new("https://mock.openai.test/v1/");

        private readonly ClientPipeline _pipeline;
        private readonly ModelReaderWriterOptions _wireOptions;

        public OpenAIClient(ApiKeyCredential credential, OpenAIClientOptions? options = null)
        {
            if (credential is null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new OpenAIClientOptions();
            _wireOptions = WireOptions.Create(options);
            _pipeline = ClientPipeline.Create(
                options,
                perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
                perTryPolicies: new PipelinePolicy[] { ApiKeyAuthenticationPolicy.CreateBearerAuthorizationPolicy(credential) },
                beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        }

        /// <summary>Gets a <see cref="ResponsesClient"/> that shares this client's pipeline and proxy registrations.</summary>
        public ResponsesClient GetResponsesClient() => new(s_defaultEndpoint, _pipeline, _wireOptions);
    }
}
