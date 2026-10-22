// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core.Internal;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class BaggageToLogProcessorTests
{
    [Test]
    public void ExportedLogs_HaveFoundryMarker(
        [Values(false, true)] bool hasActivity,
        [Values("null", "empty", "conflicting")] string attributes)
    {
        using var exporter = new CapturingExporter();
        using var factory = LoggerFactory.Create(logging => logging.AddOpenTelemetry(options =>
        {
            options.AddProcessor(new BaggageToLogProcessor());
            options.AddProcessor(new SimpleLogRecordExportProcessor(exporter));
        }));
        using var activity = hasActivity ? new Activity("test").Start() : null;
        activity?.SetBaggage("microsoft.foundry", "baggage-value");
        activity?.SetBaggage("correlation", "baggage-correlation");
        activity?.SetBaggage("existing", "baggage-existing");

        List<KeyValuePair<string, object?>>? state = attributes switch
        {
            "null" => null,
            "empty" => new(),
            _ => new()
            {
                new("microsoft.foundry", "other-value"),
                new("gen_ai.provider.name", "other-provider"),
                new("existing", "call-site-value")
            }
        };
        factory.CreateLogger("framework").Log(
            LogLevel.Information, default, state, null, static (_, _) => "test log");

        Assert.That(exporter.Attributes, Has.Count.EqualTo(1));
        var exported = exporter.Attributes[0];
        Assert.That(exported, Is.Not.Null);
        Assert.That(exported!.Count(attribute => attribute.Key == "microsoft.foundry"), Is.EqualTo(1));
        Assert.That(exported.Single(attribute => attribute.Key == "microsoft.foundry").Value, Is.EqualTo("True"));
        if (hasActivity)
        {
            Assert.That(exported.Single(attribute => attribute.Key == "correlation").Value, Is.EqualTo("baggage-correlation"));
        }
        if (attributes == "conflicting")
        {
            Assert.That(exported.Single(attribute => attribute.Key == "gen_ai.provider.name").Value, Is.EqualTo("other-provider"));
            Assert.That(exported.Single(attribute => attribute.Key == "existing").Value, Is.EqualTo("call-site-value"));
        }
        else
        {
            Assert.That(exported.Any(attribute => attribute.Key == "gen_ai.provider.name"), Is.False);
        }
    }

    private sealed class CapturingExporter : BaseExporter<LogRecord>
    {
        public List<KeyValuePair<string, object?>[]?> Attributes { get; } = new();

        public override ExportResult Export(in Batch<LogRecord> batch)
        {
            foreach (var record in batch)
            {
                Attributes.Add(record.Attributes?.ToArray());
            }
            return ExportResult.Success;
        }
    }
}
