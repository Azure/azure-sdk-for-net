// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

/// <summary>
/// Test helpers for composing the Core event-stream primitive
/// (<see cref="AgentEventStreamRegistry"/> / <see cref="AgentEventStream"/>) the same way the Responses
/// layer does in production. The Responses layer no longer owns an event-stream provider — SSE
/// streaming is delegated to the Core primitive — so tests obtain a registry the same way. The Core
/// stream carries pre-serialized <see cref="System.Net.ServerSentEvents.SseItem{T}"/> items; tests
/// bridge to and from <see cref="ResponseStreamEvent"/> via <see cref="ResponseWireStreamCodec"/>.
/// </summary>
internal static class TestEventStreams
{
    /// <summary>Builds a standalone in-memory <see cref="AgentEventStreamRegistry"/> for unit tests.</summary>
    public static AgentEventStreamRegistry CreateInMemoryRegistry()
    {
        var services = new ServiceCollection();
        services.AddAgentEventStreams(o => o.UseInMemoryReplay());
        return services.BuildServiceProvider().GetRequiredService<AgentEventStreamRegistry>();
    }

    /// <summary>Builds a standalone file-backed <see cref="AgentEventStreamRegistry"/> under <paramref name="storageDir"/>.</summary>
    /// <remarks>
    /// The registry writes replay files to <c>&lt;storageDir&gt;/streams</c>, mirroring the production
    /// <see cref="Azure.AI.AgentServer.Responses.Internal.Resilience.ResponsesStatePaths.StreamsRoot"/>
    /// convention where the responses root holds a <c>streams/</c> sub-directory.
    /// </remarks>
    public static AgentEventStreamRegistry CreateFileBackedRegistry(string storageDir, TimeSpan? ttl = null)
    {
        var services = new ServiceCollection();
        services.AddAgentEventStreams(o => o.UseFileBackedReplay(
            StreamsDir(storageDir), ttl ?? TimeSpan.FromMinutes(30)));
        return services.BuildServiceProvider().GetRequiredService<AgentEventStreamRegistry>();
    }

    /// <summary>Replaces the registered <see cref="AgentEventStreamRegistry"/> with an in-memory one.</summary>
    public static void UseInMemory(IServiceCollection services)
    {
        services.RemoveAll<AgentEventStreamRegistry>();
        services.AddAgentEventStreams(o => o.UseInMemoryReplay());
    }

    /// <summary>
    /// Replaces the registered <see cref="AgentEventStreamRegistry"/> with a file-backed one writing to
    /// <c>&lt;storageDir&gt;/streams</c> (production <c>StreamsRoot()</c> convention).
    /// </summary>
    public static void UseFileBacked(IServiceCollection services, string storageDir, TimeSpan? ttl = null)
    {
        services.RemoveAll<AgentEventStreamRegistry>();
        services.AddAgentEventStreams(o => o.UseFileBackedReplay(
            StreamsDir(storageDir), ttl ?? TimeSpan.FromMinutes(30)));
    }

    private static string StreamsDir(string storageDir)
        => System.IO.Path.Combine(storageDir, "streams");

    /// <summary>Creates an <see cref="IAsyncObserver{T}"/> publisher over the stream for <paramref name="responseId"/>.</summary>
    public static async Task<IAsyncObserver<ResponseStreamEvent>> CreatePublisherAsync(
        AgentEventStreamRegistry registry, string responseId)
    {
        var stream = await registry.GetOrCreateAsync(responseId);
        return await EventStreamObserver.CreateAsync(stream);
    }

    /// <summary>
    /// Subscribes to the stream for <paramref name="responseId"/> in the background, collecting
    /// events into <paramref name="events"/> and signalling completion when the stream closes.
    /// Mirrors the legacy provider Subscribe helper the tests relied on.
    /// </summary>
    public static TestSubscription Subscribe(
        AgentEventStreamRegistry registry, string responseId, List<ResponseStreamEvent> events, long? after = null)
        => new(registry, responseId, events, after);
}

/// <summary>Background subscription handle exposing a <see cref="Completed"/> task like the old observer.</summary>
internal sealed class TestSubscription
{
    private readonly TaskCompletionSource _completed = new(TaskCreationOptions.RunContinuationsAsynchronously);

    public TestSubscription(AgentEventStreamRegistry registry, string responseId, List<ResponseStreamEvent> events, long? after)
    {
        _ = RunAsync(registry, responseId, events, after);
    }

    /// <summary>Completes when the underlying stream closes (or faults on error).</summary>
    public Task Completed => _completed.Task;

    private async Task RunAsync(AgentEventStreamRegistry registry, string responseId, List<ResponseStreamEvent> events, long? after)
    {
        try
        {
            var stream = await registry.GetOrCreateAsync(responseId).ConfigureAwait(false);
            await foreach (var item in stream.Subscribe(after?.ToString(CultureInfo.InvariantCulture)).ConfigureAwait(false))
            {
                events.Add(ResponseWireStreamCodec.FromWireItem(item));
            }

            _completed.TrySetResult();
        }
        catch (Exception ex)
        {
            _completed.TrySetException(ex);
        }
    }
}
