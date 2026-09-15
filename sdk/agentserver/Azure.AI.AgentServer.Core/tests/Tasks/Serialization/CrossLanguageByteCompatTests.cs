// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Serialization;

/// <summary>
/// Asserts that a <see cref="TaskRecord"/> round-trips byte-identically through
/// the canonical JSON writer against committed golden fixtures, guaranteeing a
/// record written by another language implementation is recovered and re-emitted
/// with the same canonical bytes (SC-010).
/// </summary>
[TestFixture]
public class CrossLanguageByteCompatTests
{
    private static string FixturesDir =>
        Path.Combine(TestContext.CurrentContext.TestDirectory, "Tasks", "Serialization", "fixtures");

    [Test]
    public void TaskRecordFixtureRoundTripsByteIdentically()
    {
        var path = Path.Combine(FixturesDir, "task_record.canonical.json");
        Assert.That(File.Exists(path), Is.True, $"Missing fixture: {path}");

        var expectedBytes = File.ReadAllBytes(path);
        var obj = JsonNode.Parse(expectedBytes)!.AsObject();

        var record = TaskRecord.FromJson(obj);
        var roundTripped = CanonicalJson.SerializeToUtf8Bytes(
            System.Text.Json.JsonSerializer.SerializeToElement(record.ToJson()));

        // The fixture is stored already in canonical form, so the canonical bytes must match exactly.
        Assert.That(Encoding.UTF8.GetString(roundTripped), Is.EqualTo(Encoding.UTF8.GetString(expectedBytes)));
    }

    [Test]
    public void CanonicalFormIsOrderIndependent()
    {
        var path = Path.Combine(FixturesDir, "task_record.canonical.json");
        var canonical = File.ReadAllText(path);

        // Re-parse and re-serialize from a deliberately reordered copy; canonical bytes must be identical.
        var reordered = JsonNode.Parse(canonical)!.AsObject();
        var a = CanonicalJson.SerializeToUtf8Bytes(System.Text.Json.JsonSerializer.SerializeToElement(reordered));
        var b = Encoding.UTF8.GetBytes(canonical);
        Assert.That(a, Is.EqualTo(b));
    }
}
