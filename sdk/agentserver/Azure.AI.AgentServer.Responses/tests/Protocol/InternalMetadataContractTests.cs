// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Responses.Internal.Resilience;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Contract tests for <see cref="InternalMetadataEgress"/> — persist-but-strip behavior for
/// framework-reserved internal metadata. Verifies item-level <c>internal_metadata</c> and
/// response-level <c>_internal_metadata</c> are removed on egress while ordinary user metadata
/// is preserved, matching the Python <c>strip_internal_metadata</c> contract.
/// </summary>
public class InternalMetadataContractTests
{
    [Test]
    public void Strip_RemovesItemLevelInternalMetadataAtRoot()
    {
        var node = JsonNode.Parse("""{ "id": "x", "internal_metadata": { "k": "v" } }""")!;
        var result = (JsonObject)InternalMetadataEgress.Strip(node)!;

        Assert.That(result.ContainsKey("internal_metadata"), Is.False);
        Assert.That(result["id"]!.GetValue<string>(), Is.EqualTo("x"));
    }

    [Test]
    public void Strip_RemovesItemLevelInternalMetadataNested()
    {
        var node = JsonNode.Parse("""
        {
          "output": [
            { "type": "message", "internal_metadata": { "trace": "1" },
              "content": [ { "text": "hi", "internal_metadata": { "deep": true } } ] }
          ]
        }
        """)!;

        var result = (JsonObject)InternalMetadataEgress.Strip(node)!;

        var item = (JsonObject)result["output"]!.AsArray()[0]!;
        Assert.That(item.ContainsKey("internal_metadata"), Is.False);
        var content = (JsonObject)item["content"]!.AsArray()[0]!;
        Assert.That(content.ContainsKey("internal_metadata"), Is.False);
        Assert.That(content["text"]!.GetValue<string>(), Is.EqualTo("hi"));
    }

    [Test]
    public void Strip_RemovesResponseLevelInternalMetadataFromMetadataMap()
    {
        var node = JsonNode.Parse("""
        { "metadata": { "user_key": "keep", "_internal_metadata": "{...}" } }
        """)!;

        var result = (JsonObject)InternalMetadataEgress.Strip(node)!;
        var metadata = (JsonObject)result["metadata"]!;

        Assert.That(metadata.ContainsKey("_internal_metadata"), Is.False);
        Assert.That(metadata["user_key"]!.GetValue<string>(), Is.EqualTo("keep"));
    }

    [Test]
    public void Strip_EmptiedMetadataMapNormalizesToNull()
    {
        var node = JsonNode.Parse("""
        { "metadata": { "_internal_metadata": "{...}" } }
        """)!;

        var result = (JsonObject)InternalMetadataEgress.Strip(node)!;

        Assert.That(result["metadata"], Is.Null);
        Assert.That(result.ContainsKey("metadata"), Is.True, "metadata key remains present, normalized to null");
    }

    [Test]
    public void Strip_PreservesOrdinaryUserMetadata()
    {
        var node = JsonNode.Parse("""
        { "metadata": { "a": "1", "b": "2" } }
        """)!;

        var result = (JsonObject)InternalMetadataEgress.Strip(node)!;
        var metadata = (JsonObject)result["metadata"]!;

        Assert.That(metadata.Count, Is.EqualTo(2));
        Assert.That(metadata["a"]!.GetValue<string>(), Is.EqualTo("1"));
        Assert.That(metadata["b"]!.GetValue<string>(), Is.EqualTo("2"));
    }

    [Test]
    public void Strip_NonObjectRoot_ReturnedUnchanged()
    {
        var array = JsonNode.Parse("[1,2,3]")!;
        var result = InternalMetadataEgress.Strip(array);
        Assert.That(result, Is.SameAs(array));
    }

    [Test]
    public void Strip_Null_ReturnsNull()
    {
        Assert.That(InternalMetadataEgress.Strip(null), Is.Null);
    }

    [Test]
    public void Strip_BothReservedKeysTogether()
    {
        var node = JsonNode.Parse("""
        {
          "id": "resp",
          "internal_metadata": { "x": 1 },
          "metadata": { "keep": "yes", "_internal_metadata": "secret" },
          "output": [ { "internal_metadata": { "y": 2 }, "text": "t" } ]
        }
        """)!;

        var result = (JsonObject)InternalMetadataEgress.Strip(node)!;

        Assert.Multiple(() =>
        {
            Assert.That(result.ContainsKey("internal_metadata"), Is.False);
            var metadata = (JsonObject)result["metadata"]!;
            Assert.That(metadata.ContainsKey("_internal_metadata"), Is.False);
            Assert.That(metadata["keep"]!.GetValue<string>(), Is.EqualTo("yes"));
            var item = (JsonObject)result["output"]!.AsArray()[0]!;
            Assert.That(item.ContainsKey("internal_metadata"), Is.False);
            Assert.That(item["text"]!.GetValue<string>(), Is.EqualTo("t"));
        });
    }
}
