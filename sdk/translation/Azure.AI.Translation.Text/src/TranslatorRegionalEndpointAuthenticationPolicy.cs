// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Threading.Tasks;

namespace Azure.AI.Translation.Text
{
    internal class TranslatorRegionalEndpointAuthenticationPolicy : HttpPipelinePolicy
    {
        private const string REGION_HEADER_NAME = "Ocp-Apim-Subscription-Region";

        private readonly string region;

        internal TranslatorRegionalEndpointAuthenticationPolicy(string region)
        {
            this.region = region;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            this.AddAuthenticationHeaders(message);
            ProcessNext(message, pipeline);
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            this.AddAuthenticationHeaders(message);
            return ProcessNextAsync(message, pipeline);
        }

        private void AddAuthenticationHeaders(HttpMessage message)
        {
            message.Request.Headers.Add(REGION_HEADER_NAME, region);
        }
    }
}
