// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="ResponseEventStream.InternalMetadata"/> — the .NET port of Python's
/// <c>stream.internal_metadata</c> persist-but-strip contract. Values a handler writes ride on the
/// response (folded into <c>metadata["_internal_metadata"]</c> as a compact JSON string so they are
/// persisted with every snapshot the orchestrator writes and survive recovery), yet are stripped
/// from every client-facing egress payload.
/// </summary>
public class ResponseEventStreamInternalMetadataTests : IDisposable
{
    private readonly string _root;

    public ResponseEventStreamInternalMetadataTests()
    {
        _root = Path.Combine(Path.GetTempPath(), "im-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_root);
    }

    public void Dispose()
    {
        try
        {
            if (Directory.Exists(_root))
            {
                Directory.Delete(_root, recursive: true);
            }
        }
        catch (IOException)
        {
        }
    }

    [Test]
    public void InternalMetadata_Set_FoldsIntoResponseMetadataAsJsonString()
    {
        var stream = NewStream("resp_fold");

        stream.InternalMetadata["k"] = "v";

        Assert.That(stream.Response.Metadata, Is.Not.Null);
        Assert.That(stream.Response.Metadata!.AdditionalProperties.ContainsKey("_internal_metadata"), Is.True);

        var json = stream.Response.Metadata.AdditionalProperties["_internal_metadata"];
        using var doc = JsonDocument.Parse(json);
        Assert.That(doc.RootElement.GetProperty("k").GetString(), Is.EqualTo("v"));
    }

    [Test]
    public void InternalMetadata_MultipleWrites_AccumulateAndReserialize()
    {
        var stream = NewStream("resp_multi");

        stream.InternalMetadata["a"] = "1";
        stream.InternalMetadata["b"] = "2";
        stream.InternalMetadata["a"] = "updated";

        var json = stream.Response.Metadata!.AdditionalProperties["_internal_metadata"];
        using var doc = JsonDocument.Parse(json);
        Assert.Multiple(() =>
        {
            Assert.That(doc.RootElement.GetProperty("a").GetString(), Is.EqualTo("updated"));
            Assert.That(doc.RootElement.GetProperty("b").GetString(), Is.EqualTo("2"));
        });
    }

    [Test]
    public void InternalMetadata_DoesNotDisturbUserMetadata()
    {
        var request = new CreateResponse
        {
            Model = "test-model",
            Metadata = new Metadata { AdditionalProperties = { ["user"] = "keep" } },
        };
        var stream = new ResponseEventStream(new StubContext("resp_user"), request);

        stream.InternalMetadata["secret"] = "hidden";

        Assert.Multiple(() =>
        {
            Assert.That(stream.Response.Metadata!.AdditionalProperties["user"], Is.EqualTo("keep"));
            Assert.That(stream.Response.Metadata!.AdditionalProperties.ContainsKey("_internal_metadata"), Is.True);
        });
    }

    [Test]
    public void InternalMetadata_SurvivesSnapshot_Durable()
    {
        var stream = NewStream("resp_snap");
        stream.InternalMetadata["trace"] = "abc";

        var snapshot = stream.Response.Snapshot();

        var json = snapshot.Metadata!.AdditionalProperties["_internal_metadata"];
        using var doc = JsonDocument.Parse(json);
        Assert.That(doc.RootElement.GetProperty("trace").GetString(), Is.EqualTo("abc"));
    }

    [Test]
    public void InternalMetadata_Remove_UpdatesFoldedValue()
    {
        var stream = NewStream("resp_remove");
        stream.InternalMetadata["a"] = "1";
        stream.InternalMetadata["b"] = "2";

        stream.InternalMetadata.Remove("a");

        var json = stream.Response.Metadata!.AdditionalProperties["_internal_metadata"];
        using var doc = JsonDocument.Parse(json);
        Assert.Multiple(() =>
        {
            Assert.That(doc.RootElement.TryGetProperty("a", out _), Is.False);
            Assert.That(doc.RootElement.GetProperty("b").GetString(), Is.EqualTo("2"));
        });
    }

    [Test]
    public void InternalMetadata_Clear_RemovesFoldedKey()
    {
        var stream = NewStream("resp_clear");
        stream.InternalMetadata["a"] = "1";

        stream.InternalMetadata.Clear();

        var meta = stream.Response.Metadata;
        Assert.That(meta is null || !meta.AdditionalProperties.ContainsKey("_internal_metadata"), Is.True);
    }

    [Test]
    public void RecoveryConstructor_HydratesInternalMetadataFromPersistedResponse()
    {
        // Turn 1: write internal metadata, then take the durable snapshot the orchestrator would persist.
        var stream = NewStream("resp_recover");
        stream.InternalMetadata["phase"] = "analyze";
        var persisted = stream.Response.Snapshot();

        // Recovery re-invocation: the stream is seeded from the persisted snapshot.
        var recovered = new ResponseEventStream(new StubContext("resp_recover"), persisted);

        Assert.Multiple(() =>
        {
            Assert.That(recovered.InternalMetadata.TryGetValue("phase", out var value), Is.True);
            Assert.That(value, Is.EqualTo("analyze"));
        });
    }

    [Test]
    public async Task InternalMetadata_RoundTripsThroughFileResponsesProvider()
    {
        var stream = NewStream("resp_file_rt");
        stream.InternalMetadata["k"] = "v";
        var snapshot = stream.Response.Snapshot();

        var provider = new FileResponsesProvider(_root);
        await provider.CreateResponseAsync(new CreateResponseRequest(snapshot, null, null), PlatformContext.Empty);
        var retrieved = await provider.GetResponseAsync("resp_file_rt", PlatformContext.Empty);

        Assert.That(retrieved.Metadata, Is.Not.Null);
        Assert.That(retrieved.Metadata!.AdditionalProperties.ContainsKey("_internal_metadata"), Is.True);
        using var doc = JsonDocument.Parse(retrieved.Metadata.AdditionalProperties["_internal_metadata"]);
        Assert.That(doc.RootElement.GetProperty("k").GetString(), Is.EqualTo("v"));
    }

    [Test]
    public void InternalMetadata_IsStrippedFromClientEgressPayload()
    {
        var stream = NewStream("resp_egress");
        stream.InternalMetadata["secret"] = "value";
        stream.Response.Metadata!.AdditionalProperties["user"] = "keep";

        // Serialize the response the way an egress path would, then strip.
        var data = System.ClientModel.Primitives.ModelReaderWriter.Write(
            stream.Response,
            System.ClientModel.Primitives.ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default);
        var node = JsonNode.Parse(data.ToString())!;

        var stripped = (JsonObject)InternalMetadataEgress.Strip(node)!;

        var metadata = (JsonObject)stripped["metadata"]!;
        Assert.Multiple(() =>
        {
            Assert.That(metadata.ContainsKey("_internal_metadata"), Is.False, "internal metadata must not reach the client");
            Assert.That(metadata["user"]!.GetValue<string>(), Is.EqualTo("keep"));
            Assert.That(stripped.ToJsonString(), Does.Not.Contain("secret"));
        });
    }

    [Test]
    public void InternalMetadata_MockingConstructor_UsesInMemoryDictionary()
    {
        var stream = new MockStream();

        Assert.DoesNotThrow(() => stream.InternalMetadata["k"] = "v");
        Assert.That(stream.InternalMetadata["k"], Is.EqualTo("v"));
    }

    private static ResponseEventStream NewStream(string responseId)
        => new(new StubContext(responseId), new CreateResponse { Model = "test-model" });

    private sealed class MockStream : ResponseEventStream
    {
    }

    private sealed class StubContext : ResponseContext
    {
        public StubContext(string responseId)
            : base(responseId)
        {
        }

        public override Task<IReadOnlyList<Item>> GetInputItemsAsync(bool resolveReferences = true, CancellationToken cancellationToken = default)
            => Task.FromResult<IReadOnlyList<Item>>(Array.Empty<Item>());

        public override Task<IReadOnlyList<OutputItem>> GetHistoryAsync(CancellationToken cancellationToken = default)
            => Task.FromResult<IReadOnlyList<OutputItem>>(Array.Empty<OutputItem>());
    }
}
