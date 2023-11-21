// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net.Http;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    public partial class HttpClientTransport
    {
        private class AzureCoreHttpPipelineTransport : PipelineTransport
        {
            private readonly PipelineTransport _httpPipelineTransport;

            public AzureCoreHttpPipelineTransport(HttpClient client)
            {
                _httpPipelineTransport = Create(client,
                    OnSendingRequest,
                    OnReceivedResponse);
            }

            /// <inheritdoc />
            private void OnSendingRequest(PipelineMessage message, HttpRequestMessage httpRequest)
            {
                if (message is not HttpMessage httpMessage)
                {
                    throw new InvalidOperationException($"Unsupported message type: '{message?.GetType()}'.");
                }

                HttpClientTransportRequest.AddAzureProperties(httpMessage, httpRequest);

                httpMessage.ClearResponse();
            }

            /// <inheritdoc />
            private void OnReceivedResponse(PipelineMessage message, HttpResponseMessage httpResponse)
            {
                if (message is not HttpMessage httpMessage)
                {
                    throw new InvalidOperationException($"Unsupported message type: '{message?.GetType()}'.");
                }

                httpMessage.Response = new HttpClientTransportResponse(
                    httpMessage.Request.ClientRequestId,
                    message.Response);
            }

            public override void Process(PipelineMessage message)
                => _httpPipelineTransport.Process(message);

            public override async ValueTask ProcessAsync(PipelineMessage message)
                => await _httpPipelineTransport.ProcessAsync(message).ConfigureAwait(false);

            public override PipelineMessage CreateMessage()
                => _httpPipelineTransport.CreateMessage();

            public override void Dispose()
                => _httpPipelineTransport.Dispose();
        }
    }
}
