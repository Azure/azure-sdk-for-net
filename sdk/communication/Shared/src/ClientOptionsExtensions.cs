// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Pipeline
{
    internal static class ClientOptionsExtensions
    {
        public static HttpPipeline BuildHttpPipeline(this ClientOptions options, ConnectionString connectionString)
        {
            var authPolicy = new HMACAuthenticationPolicy(connectionString.GetRequired("accesskey"));
            return HttpPipelineBuilder.Build(options, authPolicy);
        }

        public static HttpPipeline BuildHttpPipeline(this ClientOptions options, TokenCredential tokenCredential)
        {
            var authPolicy = new BearerTokenAuthenticationPolicy(tokenCredential, "https://communication.azure.com//.default");
            return HttpPipelineBuilder.Build(options, authPolicy);
        }
    }
}