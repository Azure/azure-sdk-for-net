// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

/// <summary>
/// Test helpers for composing the Core event-stream primitive
/// (<see cref="EventStreamRegistry"/> / <see cref="EventStream"/>) the same way the Responses
/// layer does in production. The Responses layer no longer owns an event-stream provider — SSE
/// streaming is delegated to the Core primitive — so tests obtain a registry the same way.
/// </summary>
internal static class TestEventStreams
{
    /// <summary>Cursor selector mapping a <see cref="ResponseStreamEvent"/> to its sequence number.</summary>
    public static Func<object, int> Cursor { get; } = payload => (int)((ResponseStreamEvent)payload).SequenceNumber;

    /// <summary>Serializes a <see cref="ResponseStreamEvent"/> payload for durable file-backed replay.</summary>
    public static Func<object, byte[]> Serializer { get; } = payload =>
        ModelReaderWriter.Write((ResponseStreamEvent)payload, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default).ToArray();

    /// <summary>Deserializes a <see cref="ResponseStreamEvent"/> payload from durable file-backed replay.</summary>
    public static Func<byte[], object> Deserializer { get; } = bytes =>
        ModelReaderWriter.Read<ResponseStreamEvent>(BinaryData.FromBytes(bytes), ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default)!;

    /// <summary>Builds a standalone in-memory <see cref="EventStreamRegistry"/> for unit tests.</summary>
    public static EventStreamRegistry CreateInMemoryRegistry()
    {
        var services = new ServiceCollection();
        services.AddEventStreams(o => o.UseInMemoryReplay(Cursor));
        return services.BuildServiceProvider().GetRequiredService<EventStreamRegistry>();
    }

    /// <summary>Builds a standalone file-backed <see cref="EventStreamRegistry"/> under <paramref name="storageDir"/>.</summary>
    /// <remarks>
    /// The registry writes replay files to <c>&lt;storageDir&gt;/streams</c>, mirroring the production
    /// <see cref="Azure.AI.AgentServer.Responses.Internal.Resilience.ResponsesStatePaths.StreamsRoot"/>
    /// convention where the responses root holds a <c>streams/</c> sub-directory.
    /// </remarks>
    public static EventStreamRegistry CreateFileBackedRegistry(string storageDir, TimeSpan? ttl = null)
    {
        var services = new ServiceCollection();
        services.AddEventStreams(o => o.UseFileBackedReplay(
            StreamsDir(storageDir), Cursor, ttl ?? TimeSpan.FromMinutes(30), Serializer, Deserializer));
        return services.BuildServiceProvider().GetRequiredService<EventStreamRegistry>();
    }

    /// <summary>Replaces the registered <see cref="EventStreamRegistry"/> with an in-memory one.</summary>
    public static void UseInMemory(IServiceCollection services)
    {
        services.RemoveAll<EventStreamRegistry>();
        services.AddEventStreams(o => o.UseInMemoryReplay(Cursor));
    }

    /// <summary>
    /// Replaces the registered <see cref="EventStreamRegistry"/> with a file-backed one writing to
    /// <c>&lt;storageDir&gt;/streams</c> (production <c>StreamsRoot()</c> convention).
    /// </summary>
    public static void UseFileBacked(IServiceCollection services, string storageDir, TimeSpan? ttl = null)
    {
        services.RemoveAll<EventStreamRegistry>();
        services.AddEventStreams(o => o.UseFileBackedReplay(
            StreamsDir(storageDir), Cursor, ttl ?? TimeSpan.FromMinutes(30), Serializer, Deserializer));
    }

    private static string StreamsDir(string storageDir)
        => System.IO.Path.Combine(storageDir, "streams");

    /// <summary>Creates an <see cref="IAsyncObserver{T}"/> publisher over the stream for <paramref name="responseId"/>.</summary>
    public static async Task<IAsyncObserver<ResponseStreamEvent>> CreatePublisherAsync(
        EventStreamRegistry registry, string responseId)
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
        EventStreamRegistry registry, string responseId, List<ResponseStreamEvent> events, long? after = null)
        => new(registry, responseId, events, after);
}

/// <summary>Background subscription handle exposing a <see cref="Completed"/> task like the old observer.</summary>
internal sealed class TestSubscription
{
    private readonly TaskCompletionSource _completed = new(TaskCreationOptions.RunContinuationsAsynchronously);

    public TestSubscription(EventStreamRegistry registry, string responseId, List<ResponseStreamEvent> events, long? after)
    {
        _ = RunAsync(registry, responseId, events, after);
    }

    /// <summary>Completes when the underlying stream closes (or faults on error).</summary>
    public Task Completed => _completed.Task;

    private async Task RunAsync(EventStreamRegistry registry, string responseId, List<ResponseStreamEvent> events, long? after)
    {
        try
        {
            var stream = await registry.GetOrCreateAsync(responseId).ConfigureAwait(false);
            await foreach (var payload in stream.Subscribe((int?)after).ConfigureAwait(false))
            {
                events.Add((ResponseStreamEvent)payload);
            }

            _completed.TrySetResult();
        }
        catch (Exception ex)
        {
            _completed.TrySetException(ex);
        }
    }
}
