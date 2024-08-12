// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Communication.Pipeline;
using Azure.Core.Pipeline;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers.SipRouting
{
    internal static class SipRoutingClientOptionsExtensions
    {
        public static HttpPipeline BuildSipRoutingHttpPipeline(this ClientOptions options, ConnectionString connectionString)
        {
            var pipelineOptions = new HttpPipelineOptions(options)
            {
                RequestFailedDetailsParser = new CommunicationRequestFailedDetailsParser(),
                PerRetryPolicies =
                {
                    new HMACAuthenticationPolicy(new AzureKeyCredential(connectionString.GetRequired("accesskey"))),
                    new MSUserAgentPolicy()
                }
            };
            HttpPipelineTransportOptions httpPipelineTransportOptions = new() { IsClientRedirectEnabled = true };
            return HttpPipelineBuilder.Build(pipelineOptions, httpPipelineTransportOptions);
        }

        public static HttpPipeline BuildSipRoutingHttpPipeline(this ClientOptions options, AzureKeyCredential keyCredential)
        {
            var pipelineOptions = new HttpPipelineOptions(options)
            {
                RequestFailedDetailsParser = new CommunicationRequestFailedDetailsParser(),
                PerRetryPolicies =
                {
                    new HMACAuthenticationPolicy(keyCredential),
                    new MSUserAgentPolicy()
                }
            };
            HttpPipelineTransportOptions httpPipelineTransportOptions = new() { IsClientRedirectEnabled = true };
            return HttpPipelineBuilder.Build(pipelineOptions, httpPipelineTransportOptions);
        }

        public static HttpPipeline BuildSipRoutingHttpPipeline(this ClientOptions options, TokenCredential tokenCredential)
        {
            var pipelineOptions = new HttpPipelineOptions(options)
            {
                RequestFailedDetailsParser = new CommunicationRequestFailedDetailsParser(),
                PerRetryPolicies =
                {
                    new BearerTokenAuthenticationPolicy(tokenCredential, "https://communication.azure.com//.default"),
                    new MSUserAgentPolicy()
                }
            };
            return HttpPipelineBuilder.Build(pipelineOptions);
        }
    }
}
