// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    [NonParallelizable]
    public class MultiTenantExportPipelineTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public async Task WebAppExportsBothSignalsThroughTheRealPipeline(bool simulateOutage)
        {
            var resources = CreateResources();
            var accepted = new ConcurrentBag<(Uri Endpoint, JsonElement Item)>();
            var transport = new MockTransport(request =>
            {
                using var content = new MemoryStream();
                request.Content!.WriteTo(content, default);
                content.Position = 0;
                using var reader = new StreamReader(content);
                int count = 0;
                while (reader.ReadLine() is { } line)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        using var item = JsonDocument.Parse(line);
                        accepted.Add((request.Uri.ToUri(), item.RootElement.Clone()));
                        count++;
                    }
                }
                return new MockResponse(200).WithContent($"{{\"itemsReceived\":{count},\"itemsAccepted\":{count},\"errors\":[]}}");
            });

            int verificationCount = 0;
            await MultiTenantExportLiveTests.RunExportAsync(resources, simulateOutage, transport, (expected, runId, cancellationToken) =>
            {
                verificationCount++;
                var seen = new HashSet<string>();
                foreach (var envelope in accepted)
                {
                    var data = envelope.Item.GetProperty("data");
                    var properties = data.GetProperty("baseData").GetProperty("properties");
                    if (!properties.TryGetProperty("multiTenantRunId", out var marker) || marker.GetString() != runId)
                    {
                        continue;
                    }

                    var recordId = properties.GetProperty("multiTenantRecordId").GetString()!;
                    Assert.That(expected.TryGetValue(recordId, out var item), Is.True, $"Unexpected routed record {recordId}.");
                    Assert.That(envelope.Item.GetProperty("iKey").GetString(), Is.EqualTo(item!.Resource.InstrumentationKey));
                    Assert.That(envelope.Endpoint.GetLeftPart(UriPartial.Authority), Is.EqualTo(item.Resource.Endpoint.GetLeftPart(UriPartial.Authority)));
                    var table = data.GetProperty("baseType").GetString() switch
                    {
                        "RequestData" => "AppRequests",
                        "RemoteDependencyData" => "AppDependencies",
                        "MessageData" => "AppTraces",
                        "ExceptionData" => "AppExceptions",
                        var unexpected => throw new InvalidOperationException($"Unexpected telemetry type {unexpected}.")
                    };
                    Assert.That(table, Is.EqualTo(item.Table));
                    var tags = envelope.Item.GetProperty("tags");
                    Assert.That(tags.TryGetProperty("ai.operation.id", out var operationId) ? operationId.GetString() : string.Empty, Is.EqualTo(item.OperationId));
                    Assert.That(tags.TryGetProperty("ai.operation.parentId", out var parentId) ? parentId.GetString() : string.Empty, Is.EqualTo(item.ParentId));
                    seen.Add(recordId);
                }

                Assert.That(seen, Is.EquivalentTo(expected.Keys));
                return Task.CompletedTask;
            });

            Assert.That(verificationCount, Is.EqualTo(simulateOutage ? 2 : 1));
        }

        private static IReadOnlyList<TenantResource> CreateResources()
        {
            var endpoints = new[] { "host.example", "west.example", "west.example", "east.example" };
            return endpoints.Select((endpoint, index) => new TenantResource(
                $"resource-{index}",
                $"InstrumentationKey={Guid.NewGuid()};IngestionEndpoint=https://{endpoint}/",
                Guid.NewGuid().ToString(),
                $"/subscriptions/{Guid.NewGuid()}/resourceGroups/test/providers/Microsoft.Insights/components/resource-{index}")).ToArray();
        }
    }
}
#endif