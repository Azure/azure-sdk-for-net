// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// HTTP pipeline policy that configures the HTTP header `x-ms-useragent`,
    /// using the environment variable `AZURE_USERAGENT_OVERRIDE`.
    /// </summary>
    internal class MSUserAgentPolicy : HttpPipelinePolicy
    {
        /// <summary>
        /// Processes message adding the HTTP header x-ms-useragent if applicable.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="pipeline"></param>
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            addHeader(message);
            ProcessNext(message, pipeline);
        }

        /// <summary>
        /// Processes message asynchronously adding the HTTP header x-ms-useragent if applicable.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="pipeline"></param>
        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            addHeader(message);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds x-ms-useragent HTTP header if environment variable AZURE_USERAGENT_OVERRIDE is set.
        /// </summary>
        /// <param name="message"></param>
        private static void addHeader(HttpMessage message)
        {
            var useragent = Environment.GetEnvironmentVariable("AZURE_USERAGENT_OVERRIDE");
            if (useragent != null)
            {
                message.Request.Headers.Add("x-ms-useragent", useragent);
            }
        }
    }
}
