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
            var authPolicy = new HMACAuthenticationPolicy(new AzureKeyCredential(connectionString.GetRequired("accesskey")));
            var msUserAgentPolicy = new MSUserAgentPolicy();
            return HttpPipelineBuilder.Build(options, authPolicy, msUserAgentPolicy);
        }

        public static HttpPipeline BuildPhoneNumbersHttpPipeline(this ClientOptions options, AzureKeyCredential keyCredential)
        {
            var authPolicy = new HMACAuthenticationPolicy(keyCredential);
            var msUserAgentPolicy = new MSUserAgentPolicy();
            return HttpPipelineBuilder.Build(options, authPolicy, msUserAgentPolicy);
        }

        public static HttpPipeline BuildPhoneNumbersHttpPipeline(this ClientOptions options, TokenCredential tokenCredential)
        {
            var authPolicy = new BearerTokenAuthenticationPolicy(tokenCredential, "https://communication.azure.com//.default");
            var msUserAgentPolicy = new MSUserAgentPolicy();
            return HttpPipelineBuilder.Build(options, authPolicy, msUserAgentPolicy);
        }
    }
}
