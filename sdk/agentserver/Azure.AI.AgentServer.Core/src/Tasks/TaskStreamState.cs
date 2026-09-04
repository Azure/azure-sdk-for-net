// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;

namespace Azure.AI.AgentServer.Core.Tasks;

internal sealed class TaskStreamState
{
    private readonly object _gate = new();
    private readonly AgentEventStreamRegistry _registry;
    private readonly string _taskId;
    private readonly string _inputId;
    private Task<AgentEventStream>? _streamTask;
    private bool _closed;

    public TaskStreamState(
        AgentEventStreamRegistry registry,
        string taskId,
        string inputId)
    {
        _registry = registry;
        _taskId = taskId;
        _inputId = inputId;
        Reader = new TaskStream(this);
        Writer = new TaskStreamWriter(this);
    }

    public TaskStream Reader { get; }

    public TaskStreamWriter Writer { get; }

    public async ValueTask<AgentEventStream> GetStreamAsync(
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        Task<AgentEventStream> streamTask;
        lock (_gate)
        {
            streamTask = _streamTask ??= CreateStreamAsync();
        }

        AgentEventStream stream = await streamTask.WaitAsync(cancellationToken).ConfigureAwait(false);
        bool close;
        lock (_gate)
        {
            close = _closed;
        }

        if (close)
        {
            await stream.CloseAsync(CancellationToken.None).ConfigureAwait(false);
        }

        return stream;
    }

    public async ValueTask CloseAsync()
    {
        Task<AgentEventStream>? streamTask;
        lock (_gate)
        {
            _closed = true;
            streamTask = _streamTask;
        }

        if (streamTask is null)
        {
            return;
        }

        AgentEventStream stream = await streamTask.ConfigureAwait(false);
        await stream.CloseAsync(CancellationToken.None).ConfigureAwait(false);
    }

    private async Task<AgentEventStream> CreateStreamAsync()
        => _registry is ITaskEventStreamRegistry taskRegistry
            ? await taskRegistry
                .GetOrCreateTaskStreamAsync(_taskId, _inputId, CancellationToken.None)
                .ConfigureAwait(false)
            : await _registry
                .GetOrCreateAsync(_inputId, CancellationToken.None)
                .ConfigureAwait(false);
}
