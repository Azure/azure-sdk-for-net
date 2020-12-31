// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse
{
    internal static class SynapseClientPipeline
    {
        private const string DefaultScope = "https://dev.azuresynapse.net/.default";

        public static HttpPipeline Build(ClientOptions options, TokenCredential credential)
        {
            return HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, DefaultScope));
        }
    }
}
