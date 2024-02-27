// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline;

public partial class HttpPipelineTransport
{
    private class AzureCorePipelineTransport : PipelineTransport
    {
        private readonly HttpPipelineTransport _transport;

        public AzureCorePipelineTransport(HttpPipelineTransport transport)
        {
            _transport = transport;
        }

        protected override PipelineMessage CreateMessageCore()
        {
            Request request = _transport.CreateRequest();
            return new HttpMessage(request, ResponseClassifier.Shared);
        }

        protected override void ProcessCore(PipelineMessage message)
        {
            HttpMessage httpMessage = HttpMessage.AssertHttpMessage(message);
            _transport.Process(httpMessage);
        }

        protected override async ValueTask ProcessCoreAsync(PipelineMessage message)
        {
            HttpMessage httpMessage = HttpMessage.AssertHttpMessage(message);
            await _transport.ProcessAsync(httpMessage).ConfigureAwait(false);
        }
    }
}
