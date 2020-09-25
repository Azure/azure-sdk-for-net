// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Pipeline
{
    internal static class ClientOptionsExtensions
    {
        public static HttpPipeline BuildHttpPipline(this ClientOptions options, ConnectionString connectionString)
        {
            var authPolicy = new HMACAuthenticationPolicy(connectionString.GetRequired("accesskey"));

            return HttpPipelineBuilder.Build(options, authPolicy);
        }
    }
}