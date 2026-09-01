// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Time.Testing;

namespace Azure.AI.AgentServer.Responses.Tests.Provider;

/// <summary>
/// Unit tests for <see cref="InMemoryResponsesProvider"/> — the default
/// in-memory implementation of <see cref="ResponsesProvider"/>.
/// </summary>
public class InMemoryResponsesProviderTests : IDisposable
{
    private readonly InMemoryResponsesProvider _provider;

    public InMemoryResponsesProviderTests()
    {
        var options = Options.Create(new InMemoryProviderOptions());
        _provider = new InMemoryResponsesProvider(options, TimeProvider.System);
    }

    // ---------------------------------------------------------------
    // T016: State Operations
    // ---------------------------------------------------------------

    [Test]
    public async Task CreateResponseAsync_Stores_Response()
    {
        var response = new ResponseObject { Id = "resp_abc", Model = "gpt-4o", Status = ResponseStatus.InProgress };

        await _provider.CreateResponseAsync(new CreateResponsePersistRequest(response, null, null), PlatformContext.Empty);

        var retrieved = await _provider.GetResponseAsync("resp_abc", PlatformContext.Empty);
        Assert.That(retrieved, Is.Not.Null);
        Assert.That(retrieved!.Id, Is.EqualTo("resp_abc"));
    }

    [Test]
    public async Task GetResponseAsync_ThrowsResourceNotFound_ForUnknownId()
    {
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _provider.GetResponseAsync("resp_nonexistent", PlatformContext.Empty));
    }

    [Test]
    public async Task UpdateResponseAsync_PersistsChanges()
    {
        var response = new ResponseObject { Id = "resp_update", Model = "gpt-4o", Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponsePersistRequest(response, null, null), PlatformContext.Empty);

        // Mutate and update
        response.Status = ResponseStatus.Completed;
        await _provider.UpdateResponseAsync(response, PlatformContext.Empty);

        var retrieved = await _provider.GetResponseAsync("resp_update", PlatformContext.Empty);
        Assert.That(retrieved, Is.Not.Null);
        Assert.That(retrieved.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public async Task CreateResponseAsync_DuplicateId_Throws()
    {
        var response1 = new ResponseObject { Id = "resp_dup", Model = "gpt-4o", Status = ResponseStatus.InProgress };
        var response2 = new ResponseObject { Id = "resp_dup", Model = "gpt-4o", Status = ResponseStatus.InProgress };

        await _provider.CreateResponseAsync(new CreateResponsePersistRequest(response1, null, null), PlatformContext.Empty);
        Assert.ThrowsAsync<InvalidOperationException>(
            () => _provider.CreateResponseAsync(new CreateResponsePersistRequest(response2, null, null), PlatformContext.Empty));
    }

    [Test]
    public async Task ConcurrentCreateAndGet_Works()
    {
        var tasks = Enumerable.Range(0, 50).Select(async i =>
        {
            var id = $"resp_{i}";
            var response = new ResponseObject { Id = id, Model = "gpt-4o", Status = ResponseStatus.InProgress };
            await _provider.CreateResponseAsync(new CreateResponsePersistRequest(response, null, null), PlatformContext.Empty);
            var retrieved = await _provider.GetResponseAsync(id, PlatformContext.Empty);
            Assert.That(retrieved, Is.Not.Null);
            Assert.That(retrieved!.Id, Is.EqualTo(id));
        });

        await Task.WhenAll(tasks);
    }

    // ---------------------------------------------------------------
    // T018: Cancellation
    // ---------------------------------------------------------------

    [Test]
    public async Task CancelResponseAsync_FiresCancellationToken()
    {
        var response = new ResponseObject { Id = "resp_cancel", Model = "gpt-4o", Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponsePersistRequest(response, null, null), PlatformContext.Empty);

        var ct = await _provider.GetResponseCancellationTokenAsync("resp_cancel");
        Assert.That(ct.IsCancellationRequested, Is.False);

        await _provider.CancelResponseAsync("resp_cancel");

        Assert.That(ct.IsCancellationRequested, Is.True);
    }

    [Test]
    public async Task CancelResponseAsync_IsFireAndForget()
    {
        var response = new ResponseObject { Id = "resp_fandf", Model = "gpt-4o", Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponsePersistRequest(response, null, null), PlatformContext.Empty);

        _ = await _provider.GetResponseCancellationTokenAsync("resp_fandf");

        // Should return immediately (fire-and-forget)
        var task = _provider.CancelResponseAsync("resp_fandf");
        await task; // Should not hang
    }

    [Test]
    public async Task CancelResponseAsync_IdempotentDoubleCancel()
    {
        var response = new ResponseObject { Id = "resp_idem", Model = "gpt-4o", Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponsePersistRequest(response, null, null), PlatformContext.Empty);
        _ = await _provider.GetResponseCancellationTokenAsync("resp_idem");

        // First cancel
        await _provider.CancelResponseAsync("resp_idem");

        // Second cancel — should not throw
        var exception = await Record.ExceptionAsync(() => _provider.CancelResponseAsync("resp_idem"));
        Assert.That(exception, Is.Null);
    }

    [Test]
    public async Task CancelResponseAsync_UnknownId_IsNoOp()
    {
        var exception = await Record.ExceptionAsync(
            () => _provider.CancelResponseAsync("resp_unknown"));
        Assert.That(exception, Is.Null);
    }

    [Test]
    public async Task GetResponseCancellationTokenAsync_CreatesIfAbsent()
    {
        var response = new ResponseObject { Id = "resp_ct", Model = "gpt-4o", Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponsePersistRequest(response, null, null), PlatformContext.Empty);

        // First call creates
        var ct1 = await _provider.GetResponseCancellationTokenAsync("resp_ct");
        // Second call returns same
        var ct2 = await _provider.GetResponseCancellationTokenAsync("resp_ct");

        Assert.That(ct2, Is.EqualTo(ct1));
        Assert.That(ct1.IsCancellationRequested, Is.False);
    }

    // ---------------------------------------------------------------
    // TTL Eviction (responses retained indefinitely; cancellation tokens evicted)
    // ---------------------------------------------------------------

    [Test]
    public async Task ResponseNotEvicted_AfterTtl()
    {
        var timeProvider = new FakeTimeProvider();
        var options = Options.Create(new InMemoryProviderOptions { EventStreamTtl = TimeSpan.FromMinutes(1) });
        using var provider = new InMemoryResponsesProvider(options, timeProvider);

        var response = new ResponseObject { Id = "resp_persist", Model = "gpt-4o", Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(new CreateResponsePersistRequest(response, null, null), PlatformContext.Empty);

        response.Status = ResponseStatus.Completed;
        await provider.UpdateResponseAsync(response, PlatformContext.Empty);

        // Advance well past TTL
        timeProvider.Advance(TimeSpan.FromHours(1));

        // Response still retrievable — responses are retained indefinitely
        Assert.That(await provider.GetResponseAsync("resp_persist", PlatformContext.Empty), Is.Not.Null);
    }

    [Test]
    public async Task DoesNotEvict_InProgressResponse()
    {
        var timeProvider = new FakeTimeProvider();
        var options = Options.Create(new InMemoryProviderOptions { EventStreamTtl = TimeSpan.FromMinutes(5) });
        using var provider = new InMemoryResponsesProvider(options, timeProvider);

        var response = new ResponseObject { Id = "resp_progress", Model = "gpt-4o", Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(new CreateResponsePersistRequest(response, null, null), PlatformContext.Empty);

        // Advance way past TTL — but response never reached terminal status
        timeProvider.Advance(TimeSpan.FromHours(1));

        // Still retrievable since it never reached terminal status
        Assert.That(await provider.GetResponseAsync("resp_progress", PlatformContext.Empty), Is.Not.Null);
    }

    [Test]
    public async Task EvictionCleansUpCancellationToken()
    {
        var timeProvider = new FakeTimeProvider();
        var options = Options.Create(new InMemoryProviderOptions { EventStreamTtl = TimeSpan.FromMinutes(1) });
        using var provider = new InMemoryResponsesProvider(options, timeProvider);

        var response = new ResponseObject { Id = "resp_cleanup", Model = "gpt-4o", Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(new CreateResponsePersistRequest(response, null, null), PlatformContext.Empty);
        var ct = await provider.GetResponseCancellationTokenAsync("resp_cleanup");

        response.Status = ResponseStatus.Completed;
        await provider.UpdateResponseAsync(response, PlatformContext.Empty);

        timeProvider.Advance(TimeSpan.FromMinutes(1).Add(TimeSpan.FromSeconds(1)));

        // Response still available (never evicted)
        Assert.That(await provider.GetResponseAsync("resp_cleanup", PlatformContext.Empty), Is.Not.Null);

        // CancellationTokenSource evicted — new call creates a fresh one
        var newCt = await provider.GetResponseCancellationTokenAsync("resp_cleanup");
        Assert.That(newCt, Is.Not.EqualTo(ct));
    }

    public void Dispose()
    {
        (_provider as IDisposable)?.Dispose();
    }
}
