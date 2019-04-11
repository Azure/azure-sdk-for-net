// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Base.Pipeline.Policies
{
    public class ClientRequestIdPolicy : HttpPipelinePolicy
    {
        private const string ClientRequestIdHeader = "x-ms-client-request-id";
        private const string EchoClientRequestId = "x-ms-return-client-request-id";

        protected ClientRequestIdPolicy()
        {
        }

        public static ClientRequestIdPolicy Singleton { get; } = new ClientRequestIdPolicy();

        public override Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            message.Request.AddHeader(ClientRequestIdHeader, message.Request.RequestId);
            message.Request.AddHeader(EchoClientRequestId, "true");

            return ProcessNextAsync(pipeline, message);
        }
    }
}
