// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Pipeline
{
    internal class ClientRequestIdPolicy : HttpPipelineSynchronousPolicy
    {
        private const string ClientRequestIdHeader = "x-ms-client-request-id";
        private const string EchoClientRequestId = "x-ms-return-client-request-id";

        protected ClientRequestIdPolicy()
        {
        }

        public static ClientRequestIdPolicy Shared { get; } = new ClientRequestIdPolicy();

        public override void OnSendingRequest(HttpMessage message)
        {
            message.Request.Headers.Add(ClientRequestIdHeader, message.Request.ClientRequestId);
            message.Request.Headers.Add(EchoClientRequestId, "true");
        }
    }
}
