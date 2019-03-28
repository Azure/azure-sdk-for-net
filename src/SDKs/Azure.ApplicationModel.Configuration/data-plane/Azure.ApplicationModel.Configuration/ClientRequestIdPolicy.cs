// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;

namespace Azure.ApplicationModel.Configuration
{
    internal class ClientRequestIdPolicy : HttpPipelinePolicy
    {
        private const string ClientRequestIdHeader = "x-ms-client-request-id";
        private const string EchoClientRequestId = "x-ms-return-client-request-id";

        public static ClientRequestIdPolicy Singleton { get; } = new ClientRequestIdPolicy();

        public override Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            message.Request.AddHeader(ClientRequestIdHeader, Guid.NewGuid().ToString());
            message.Request.AddHeader(EchoClientRequestId, "true");

            return ProcessNextAsync(pipeline, message);
        }
    }
}