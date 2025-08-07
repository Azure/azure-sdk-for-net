// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Translation.Text
{
    /// <summary>
    /// A policy that sends an <see cref="AccessToken"/> provided by a <see cref="TokenCredential"/> as an Authentication header
    /// together with the Ocp-Apim-Subscription-Region and Ocp-Apim-ResourceId headers.
    /// </summary>
    internal class TextTranslationAADAuthenticationPolicy : BearerTokenAuthenticationPolicy
    {
        private const string RESOURCE_ID_HEADER_NAME = "Ocp-Apim-ResourceId";
        private const string REGION_HEADER_NAME = "Ocp-Apim-Subscription-Region";

        private readonly string region;
        private readonly string resourceId;

        public TextTranslationAADAuthenticationPolicy(TokenCredential credential, string scope, string region, string resourceId) : base(credential, scope)
        {
            this.region = region;
            this.resourceId = resourceId;
        }

        public TextTranslationAADAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes, string region, string resourceId) : base(credential, scopes)
        {
            this.region = region;
            this.resourceId = resourceId;
        }

        /// <inheritdoc />
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            this.AddAuthenticationHeaders(message);
            return base.ProcessAsync(message, pipeline);
        }

        /// <inheritdoc />
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            this.AddAuthenticationHeaders(message);
            base.Process(message, pipeline);
        }

        private void AddAuthenticationHeaders(HttpMessage message)
        {
            message.Request.Headers.Add(REGION_HEADER_NAME, region);
            message.Request.Headers.Add(RESOURCE_ID_HEADER_NAME, resourceId);
        }
    }
}
