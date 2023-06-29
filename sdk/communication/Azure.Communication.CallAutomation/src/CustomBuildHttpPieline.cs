// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Pipeline
{
    internal static class CustomBuildHttpPieline
    {
        public static HttpPipeline CustomBuildHttpPipeline(this ClientOptions options, ConnectionString connectionString)
        {
            string stringSign = new Uri(connectionString.GetRequired("endpoint")).Host;

            var authPolicy = new CustomHMACAuthenticationPolicy(new AzureKeyCredential(connectionString.GetRequired("accesskey")), stringSign);
            HttpPipelineOptions httpPipelineOptions = new(options) { PerRetryPolicies = { authPolicy } };
            HttpPipelineTransportOptions httpPipelineTransportOptions = new() { IsClientRedirectEnabled = true };
            return HttpPipelineBuilder.Build(httpPipelineOptions, httpPipelineTransportOptions);
        }

        public static HttpPipeline CustomBuildHttpPipeline(this ClientOptions options, Uri acsEndpoint, TokenCredential tokenCredential)
        {
            string stringSign = acsEndpoint.Host;

            var authPolicy = new CustomBearerTokenAuthenticationPolicy(tokenCredential, "https://communication.azure.com//.default", stringSign);
            return HttpPipelineBuilder.Build(options, authPolicy);
        }
    }
}
