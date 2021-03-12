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
        private string _userName;
        private string _password;

        public BasicAuthenticationPolicy(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            var valueBytes = Encoding.UTF8.GetBytes($"{_userName}:{_password}");
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
