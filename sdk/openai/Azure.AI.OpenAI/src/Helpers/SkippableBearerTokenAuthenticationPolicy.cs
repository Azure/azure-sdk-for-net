// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    internal class SkippableBearerTokenAuthenticationPolicy : BearerTokenAuthenticationPolicy
    {
        public static readonly string SkipPropertyKey = "should-skip-bearer-auth";

        public SkippableBearerTokenAuthenticationPolicy(TokenCredential tokenCredential, IEnumerable<string> scopes)
            : base(tokenCredential, scopes) { }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!MessageShouldSkipBearerAuth(message))
            {
                base.Process(message, pipeline);
            }
            ProcessNext(message, pipeline);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!MessageShouldSkipBearerAuth(message))
            {
                await base.ProcessAsync(message, pipeline).ConfigureAwait(false);
            }
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
        }

        private static bool MessageShouldSkipBearerAuth(HttpMessage message)
        {
            bool hasSkipProperty = message.TryGetProperty(SkipPropertyKey, out var propertyValue);
            return hasSkipProperty && (bool)propertyValue;
        }
    }
}
