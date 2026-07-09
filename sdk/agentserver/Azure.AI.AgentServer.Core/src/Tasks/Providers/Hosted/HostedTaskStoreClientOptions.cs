// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.AgentServer.Core.Tasks.Providers.Hosted;

/// <summary>
/// Options for configuring the Azure.Core HTTP pipeline used by
/// <see cref="HostedTaskStore"/> to communicate with the Azure AI Foundry
/// task storage API.
/// <para>
/// Inheriting from <see cref="ClientOptions"/> provides automatic retry,
/// request ID, user-agent telemetry, logging, and distributed tracing.
/// </para>
/// </summary>
internal sealed class HostedTaskStoreClientOptions : ClientOptions
{
    public HostedTaskStoreClientOptions()
    {
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
