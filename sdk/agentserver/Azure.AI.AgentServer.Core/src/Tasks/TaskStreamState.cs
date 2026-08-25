// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;

namespace Azure.AI.AgentServer.Core.Tasks;

internal sealed class TaskStreamState
{
    private readonly Lazy<Task<AgentEventStream>> _stream;
    private int _closed;

    public TaskStreamState(
        AgentEventStreamRegistry registry,
        string taskId,
        string inputId)
    {
        _stream = new Lazy<Task<AgentEventStream>>(
            async () =>
            {
                AgentEventStream stream = registry is ITaskEventStreamRegistry taskRegistry
                    ? await taskRegistry
                        .GetOrCreateTaskStreamAsync(taskId, inputId, CancellationToken.None)
                        .ConfigureAwait(false)
                    : await registry
                        .GetOrCreateAsync(inputId, CancellationToken.None)
                        .ConfigureAwait(false);
                if (Volatile.Read(ref _closed) != 0)
                {
                    await stream.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                }

                return stream;
            },
            LazyThreadSafetyMode.ExecutionAndPublication);
        Reader = new TaskStream(this);
        Writer = new TaskStreamWriter(this);
    }

    public TaskStream Reader { get; }

    public TaskStreamWriter Writer { get; }

    public async ValueTask<AgentEventStream> GetStreamAsync(
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return await _stream.Value.WaitAsync(cancellationToken).ConfigureAwait(false);
    }

    public async ValueTask CloseAsync()
    {
        Interlocked.Exchange(ref _closed, 1);
        if (!_stream.IsValueCreated)
        {
            return;
        }

        AgentEventStream stream = await _stream.Value.ConfigureAwait(false);
        await stream.CloseAsync(CancellationToken.None).ConfigureAwait(false);
    }
}
