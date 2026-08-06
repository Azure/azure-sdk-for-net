// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Provider;

/// <summary>
/// Unit tests for <see cref="FileResponsesProvider"/> — the durable filesystem-backed
/// implementation of <see cref="ResponsesProvider"/> that enables single-process crash recovery.
/// Verifies CRUD parity with the in-memory provider plus the durability guarantees the in-memory
/// provider cannot offer: state survives a new provider instance over the same directory, deletes
/// are persisted, and corrupt files are skipped rather than crashing rehydration.
/// </summary>
public class FileResponsesProviderTests : IDisposable
{
    private readonly string _dir;

    public FileResponsesProviderTests()
    {
        _dir = Path.Combine(Path.GetTempPath(), "fileresp-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_dir);
    }

    public void Dispose()
    {
        try
        {
            Directory.Delete(_dir, recursive: true);
        }
        catch (IOException)
        {
        }
    }

    private FileResponsesProvider NewProvider() => new(_dir);

    [Test]
    public async Task Create_Then_Get_RoundTrips()
    {
        var provider = NewProvider();
        var response = new Models.ResponseObject("resp_rt", "gpt-4o") { Status = ResponseStatus.InProgress };

        await provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), PlatformContext.Empty);

        var retrieved = await provider.GetResponseAsync("resp_rt", PlatformContext.Empty);
        Assert.That(retrieved.Id, Is.EqualTo("resp_rt"));
        Assert.That(retrieved.Status, Is.EqualTo(ResponseStatus.InProgress));
    }

    [Test]
    public async Task State_Survives_New_Provider_Instance()
    {
        // Write with one instance.
        var writer = NewProvider();
        var response = new Models.ResponseObject("resp_durable", "gpt-4o") { Status = ResponseStatus.Completed };
        await writer.CreateResponseAsync(new CreateResponseRequest(response, null, null), PlatformContext.Empty);

        // Read back with a fresh instance over the same directory (simulates process restart).
        var reader = NewProvider();
        var retrieved = await reader.GetResponseAsync("resp_durable", PlatformContext.Empty);
        Assert.That(retrieved.Id, Is.EqualTo("resp_durable"));
        Assert.That(retrieved.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public async Task Update_Persists_Across_Instances()
    {
        var writer = NewProvider();
        var response = new Models.ResponseObject("resp_upd", "gpt-4o") { Status = ResponseStatus.InProgress };
        await writer.CreateResponseAsync(new CreateResponseRequest(response, null, null), PlatformContext.Empty);

        response.Status = ResponseStatus.Completed;
        await writer.UpdateResponseAsync(response, PlatformContext.Empty);

        var reader = NewProvider();
        var retrieved = await reader.GetResponseAsync("resp_upd", PlatformContext.Empty);
        Assert.That(retrieved.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public async Task Delete_Is_Persisted_As_Tombstone()
    {
        var writer = NewProvider();
        var response = new Models.ResponseObject("resp_del", "gpt-4o") { Status = ResponseStatus.Completed };
        await writer.CreateResponseAsync(new CreateResponseRequest(response, null, null), PlatformContext.Empty);
        await writer.DeleteResponseAsync("resp_del", PlatformContext.Empty);

        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => writer.GetResponseAsync("resp_del", PlatformContext.Empty));

        // The tombstone survives restart: still 404, never resurrected.
        var reader = NewProvider();
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => reader.GetResponseAsync("resp_del", PlatformContext.Empty));
    }

    [Test]
    public async Task Get_Unknown_Throws_ResourceNotFound()
    {
        var provider = NewProvider();
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => provider.GetResponseAsync("resp_missing", PlatformContext.Empty));
    }

    [Test]
    public async Task Duplicate_Create_Throws()
    {
        var provider = NewProvider();
        var response = new Models.ResponseObject("resp_dup", "gpt-4o") { Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), PlatformContext.Empty);
        Assert.ThrowsAsync<InvalidOperationException>(
            () => provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), PlatformContext.Empty));
    }

    [Test]
    public async Task UserIsolation_Mismatch_Returns_NotFound_Across_Instances()
    {
        var writer = NewProvider();
        var response = new Models.ResponseObject("resp_iso", "gpt-4o") { Status = ResponseStatus.Completed };
        var owner = new PlatformContext("user-owner", null);
        await writer.CreateResponseAsync(new CreateResponseRequest(response, null, null), owner);

        var reader = NewProvider();
        var stranger = new PlatformContext("user-other", null);
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => reader.GetResponseAsync("resp_iso", stranger));

        // Same owner still resolves after restart.
        var retrieved = await reader.GetResponseAsync("resp_iso", owner);
        Assert.That(retrieved.Id, Is.EqualTo("resp_iso"));
    }

    [Test]
    public async Task Input_Items_Survive_Restart()
    {
        var writer = NewProvider();
        var response = new Models.ResponseObject("resp_items", "gpt-4o") { Status = ResponseStatus.Completed };
        var inputItem = new OutputItemMessage("msg_in_1", MessageStatus.Completed, MessageRole.User, Array.Empty<MessageContent>());
        await writer.CreateResponseAsync(
            new CreateResponseRequest(response, new OutputItem[] { inputItem }, null),
            PlatformContext.Empty);

        var reader = NewProvider();
        var page = await reader.GetInputItemsAsync("resp_items", PlatformContext.Empty);
        Assert.That(page.Data.Count, Is.EqualTo(1));
        Assert.That(page.Data[0].GetId(), Is.EqualTo("msg_in_1"));
    }

    [Test]
    public async Task GetItems_Returns_Null_For_Missing()
    {
        var provider = NewProvider();
        var results = (await provider.GetItemsAsync(new[] { "no_such_item" }, PlatformContext.Empty)).ToList();
        Assert.That(results, Has.Count.EqualTo(1));
        Assert.That(results[0], Is.Null);
    }

    [Test]
    public async Task Corrupt_Envelope_File_Is_Skipped_On_Rehydrate()
    {
        var writer = NewProvider();
        var good = new Models.ResponseObject("resp_good", "gpt-4o") { Status = ResponseStatus.Completed };
        await writer.CreateResponseAsync(new CreateResponseRequest(good, null, null), PlatformContext.Empty);

        // Drop a corrupt file alongside the good one.
        var envelopesDir = Path.Combine(_dir, "envelopes");
        File.WriteAllText(Path.Combine(envelopesDir, "resp_bad.json"), "{ this is not valid json", Encoding.UTF8);

        // A fresh instance must rehydrate the good record and skip the corrupt one without throwing.
        var reader = NewProvider();
        var retrieved = await reader.GetResponseAsync("resp_good", PlatformContext.Empty);
        Assert.That(retrieved.Id, Is.EqualTo("resp_good"));
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => reader.GetResponseAsync("resp_bad", PlatformContext.Empty));
    }

    [Test]
    public async Task ListResponseIds_Excludes_Deleted()
    {
        var provider = NewProvider();
        var a = new Models.ResponseObject("resp_a", "gpt-4o") { Status = ResponseStatus.Completed };
        var b = new Models.ResponseObject("resp_b", "gpt-4o") { Status = ResponseStatus.Completed };
        await provider.CreateResponseAsync(new CreateResponseRequest(a, null, null), PlatformContext.Empty);
        await provider.CreateResponseAsync(new CreateResponseRequest(b, null, null), PlatformContext.Empty);
        await provider.DeleteResponseAsync("resp_b", PlatformContext.Empty);

        var ids = provider.ListResponseIds();
        Assert.That(ids, Does.Contain("resp_a"));
        Assert.That(ids, Does.Not.Contain("resp_b"));
    }
}
