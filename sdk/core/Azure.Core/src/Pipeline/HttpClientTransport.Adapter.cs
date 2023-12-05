// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net.Http;

namespace Azure.Core.Pipeline
{
    public partial class HttpClientTransport
    {
        private class AzureCoreHttpPipelineTransport : HttpClientPipelineTransport
        {
            public AzureCoreHttpPipelineTransport(HttpClient client) : base(client)
            {
            }

            protected override PipelineMessage CreateMessageCore()
            {
                PipelineMessage message = base.CreateMessageCore();
                HttpClientTransportRequest request = new(message.Request);
                return new HttpMessage(request, ResponseClassifier.Shared);
            }

            /// <inheritdoc />
            protected override void OnSendingRequest(PipelineMessage message, HttpRequestMessage httpRequest)
            {
                if (message is not HttpMessage httpMessage)
                {
                    throw new InvalidOperationException($"Unsupported message type: '{message?.GetType()}'.");
                }

                HttpClientTransportRequest.AddAzureProperties(httpMessage, httpRequest);

                httpMessage.ClearResponse();
            }

            /// <inheritdoc />
            protected override void OnReceivedResponse(PipelineMessage message, HttpResponseMessage httpResponse)
            {
                if (message is not HttpMessage httpMessage)
                {
                    throw new InvalidOperationException($"Unsupported message type: '{message?.GetType()}'.");
                }

                string clientRequestId = httpMessage.Request.ClientRequestId;
                httpMessage.Response = new HttpClientTransportResponse(clientRequestId, message.Response);
            }
        }
    }
}
