// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Options for configuring the Azure.Core HTTP pipeline
/// used by <see cref="FoundryStorageProvider"/> to communicate with the
/// Azure AI Foundry storage API.
/// <para>
/// Inheriting from <see cref="ClientOptions"/> provides automatic retry,
/// request ID, user-agent telemetry, logging, and distributed tracing.
/// </para>
/// </summary>
internal sealed class FoundryStorageClientOptions : ClientOptions
{
    public FoundryStorageClientOptions()
    {
        // Enable transparent decompression for gzip, deflate, and brotli responses.
        // Intermediary gateways and load-balancers may return compressed error pages
        // or compressed JSON regardless of Accept-Encoding. Without this, raw gzip
        // bytes would reach our JSON deserializers and cause parse failures.
        // SocketsHttpHandler also automatically sends Accept-Encoding: gzip, deflate, br
        // so servers that support compression can use it on success paths too.
        Transport = new HttpClientTransport(
            new SocketsHttpHandler
            {
                AllowAutoRedirect = false,
                AutomaticDecompression = DecompressionMethods.GZip
                    | DecompressionMethods.Deflate
                    | DecompressionMethods.Brotli,
            });
    }
}
