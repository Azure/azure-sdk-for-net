// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter;
using NUnit.Framework;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class EndpointOutageTransportTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public async Task BlocksOnlySelectedEndpointUntilRecovery(bool isAsync)
        {
            var inner = new MockTransport(new MockResponse(200), new MockResponse(200));
            var transport = new EndpointOutageTransport(inner, new Uri("https://unavailable.example/"));
            var pipeline = HttpPipelineBuilder.Build(new AzureMonitorExporterOptions { Transport = transport, Retry = { MaxRetries = 0 } });

            using var blocked = pipeline.CreateMessage();
            blocked.Request.Uri.Reset(new Uri("https://unavailable.example/v2.1/track"));
            await SendAsync(blocked);
            Assert.That(blocked.Response.Status, Is.EqualTo(503));
            Assert.That(inner.Requests, Is.Empty);

            using var healthy = pipeline.CreateMessage();
            healthy.Request.Uri.Reset(new Uri("https://healthy.example/v2.1/track"));
            await SendAsync(healthy);
            Assert.That(healthy.Response.Status, Is.EqualTo(200));

            transport.Recover();
            using var recovered = pipeline.CreateMessage();
            recovered.Request.Uri.Reset(new Uri("https://unavailable.example/v2.1/track"));
            await SendAsync(recovered);
            Assert.That(recovered.Response.Status, Is.EqualTo(200));
            Assert.That(transport.FailedRequests, Is.EqualTo(1));
            Assert.That(inner.Requests.Count, Is.EqualTo(2));

            async Task SendAsync(HttpMessage message)
            {
                if (isAsync)
                {
                    await pipeline.SendAsync(message, default);
                }
                else
                {
                    pipeline.Send(message, default);
                }
            }
        }
    }
}
#endif