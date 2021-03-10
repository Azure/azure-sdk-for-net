// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// This method of authentication is being deprecated by the service.  It is included here to unblock client development
    /// while the feature crew works on the correct auth policies for this service.
    /// </summary>
    internal class BasicAuthenticationPolicy : HttpPipelinePolicy
    {
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

#pragma warning disable CA1822 // Mark members as static
        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
#pragma warning restore CA1822 // Mark members as static
        {
            var valueBytes = Encoding.UTF8.GetBytes("<username>:<password>");
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, $"Basic {Convert.ToBase64String(valueBytes)}");

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
