// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Communication.Pipeline;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// This class extends the PhoneNumbersClientsOptions to be able to inject the x-ms-useragent header into the HttpPipeline
    /// </summary>
    internal static class PhoneNumbersClientOptionsExtensions
    {
        public static HttpPipeline BuildPhoneNumbersHttpPipeline(this ClientOptions options, ConnectionString connectionString)
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

        public static HttpPipeline BuildPhoneNumbersHttpPipeline(this ClientOptions options, AzureKeyCredential keyCredential)
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

        public static HttpPipeline BuildPhoneNumbersHttpPipeline(this ClientOptions options, TokenCredential tokenCredential)
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
