// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Threading.Tasks;

namespace Azure.AI.TextTranslator
{
    internal class GlobalEndpointAuthenticationPolicy : HttpPipelinePolicy
    {
        private const string KEY_HEADER_NAME = "Ocp-Apim-Subscription-Key";
        private const string REGION_HEADER_NAME = "Ocp-Apim-Subscription-Region";

        private readonly AzureKeyCredential key;
        private readonly string region;

        public GlobalEndpointAuthenticationPolicy(AzureKeyCredential key, string region)
        {
            this.key = key;
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
            message.Request.Headers.Add(KEY_HEADER_NAME, key.Key);
            message.Request.Headers.Add(REGION_HEADER_NAME, region);
        }
    }
}
