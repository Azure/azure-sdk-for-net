// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    internal class ApiVersionPolicy : HttpPipelinePolicy
    {
        private string _versionString;

        public ApiVersionPolicy(string versionString)
        {
            _versionString = versionString;
        }

        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).GetAwaiter().GetResult();
        }

        public override Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        private async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            message.Request.UriBuilder.AppendQuery("api-version", _versionString);

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }
        }
    }
}
