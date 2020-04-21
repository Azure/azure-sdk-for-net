// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Pipeline
{
    internal class ReadClientRequestIdPolicy : HttpPipelineSynchronousPolicy
    {
        protected ReadClientRequestIdPolicy()
        {
        }

        public static ReadClientRequestIdPolicy Shared { get; } = new ReadClientRequestIdPolicy();

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.Request.Headers.TryGetValue(ClientRequestIdPolicy.ClientRequestIdHeader, out string? value))
            {
                message.Request.ClientRequestId = value;
            }
        }
    }
}