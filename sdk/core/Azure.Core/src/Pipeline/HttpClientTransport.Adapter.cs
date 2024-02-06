// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net.Http;

namespace Azure.Core.Pipeline
{
    public partial class HttpClientTransport
    {
        /// <summary>
        /// Adds Azure.Core features to the System.ClientModel HttpClient-based transport.
        ///
        /// This type inherits from System.ClientModel's <see cref="HttpClientPipelineTransport"/>
        /// and overrides the extensibility points for <see cref="OnSendingRequest(PipelineMessage, HttpRequestMessage)"/>
        /// and <see cref="OnReceivedResponse(PipelineMessage, HttpResponseMessage)"/> to add
        /// features specific to Azure, such as <see cref="Request.ClientRequestId"/>.
        /// </summary>
        private class ClientModelHttpClientTransport : HttpClientPipelineTransport
        {
            public ClientModelHttpClientTransport(HttpClient client) : base(client)
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

                if (message.Response is not PipelineResponse pipelineResponse)
                {
                    throw new InvalidOperationException($"Unsupported response type: '{message?.GetType()}'.");
                }

                string clientRequestId = httpMessage.Request.ClientRequestId;
                httpMessage.Response = new HttpClientTransportResponse(clientRequestId, pipelineResponse);
            }
        }
    }
}
