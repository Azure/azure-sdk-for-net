﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal.Core;
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

            /// <inheritdoc />
            protected override void OnSendingRequest(ClientMessage message, HttpRequestMessage httpRequest)
            {
                if (message is not HttpMessage httpMessage)
                {
                    throw new InvalidOperationException($"Unsupported message type: '{message?.GetType()}'.");
                }

                HttpClientTransportRequest.AddAzureProperties(httpMessage, httpRequest);

                httpMessage.ClearResponse();
            }

            /// <inheritdoc />
            protected override void OnReceivedResponse(ClientMessage message, HttpResponseMessage httpResponse)
            {
                if (message is not HttpMessage httpMessage)
                {
                    throw new InvalidOperationException($"Unsupported message type: '{message?.GetType()}'.");
                }

                string clientRequestId = httpMessage.Request.ClientRequestId;
                httpMessage.Response = new ResponseAdapter(new HttpClientTransportResponse(clientRequestId, httpResponse));
            }
        }
    }
}
