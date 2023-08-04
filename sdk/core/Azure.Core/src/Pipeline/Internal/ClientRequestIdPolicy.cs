// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Pipeline
{
    internal class ClientRequestIdPolicy : HttpPipelineSynchronousPolicy
    {
        internal const string ClientRequestIdHeader = "x-ms-client-request-id";
        internal const string EchoClientRequestId = "x-ms-return-client-request-id";

        protected ClientRequestIdPolicy()
        {
        }

        public static ClientRequestIdPolicy Shared { get; } = new ClientRequestIdPolicy();

        public override void OnSendingRequest(HttpMessage message)
        {
            message.Request.Headers.SetValue(ClientRequestIdHeader, message.Request.ClientRequestId);
            message.Request.Headers.SetValue(EchoClientRequestId, "true");
        }
    }
}
