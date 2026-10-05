// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

internal sealed class TaskDeletionState
{
    private readonly object _gate = new();
    private readonly Dictionary<string, InputStreams> _inputs = new(StringComparer.Ordinal);
    private readonly Action<string, Exception> _closeFailed;
    private bool _confirmed;

    public TaskDeletionState(Action<string, Exception> closeFailed)
    {
        _closeFailed = closeFailed;
    }

    public void Track(TaskStreamState stream, string inputId, Task producerUnwound)
    {
        lock (_gate)
        {
            if (!_inputs.TryGetValue(inputId, out InputStreams? input))
            {
                input = new InputStreams(inputId);
                _inputs.Add(inputId, input);
            }
            input.Streams.Add(stream);
            input.Producers.Add(producerUnwound);
        }
    }

    public Task ConfirmAsync()
    {
        lock (_gate)
        {
            _confirmed = true;
        }
        return CloseReadyAsync();
    }

    public async Task CloseReadyAsync()
    {
        List<(InputStreams Input, Task Producers)> selected = new();
        lock (_gate)
        {
            if (!_confirmed)
            {
                return;
            }

            foreach (InputStreams input in _inputs.Values)
            {
                if (!input.Closing)
                {
                    input.Closing = true;
                    selected.Add((input, Task.WhenAll(input.Producers)));
                }
            }
        }

        List<Task> ready = new();
        foreach ((InputStreams input, Task producers) in selected)
        {
            Task closing = CloseAfterUnwindAsync(input, producers);
            if (producers.IsCompleted)
            {
                ready.Add(closing);
            }
        }
        await Task.WhenAll(ready).ConfigureAwait(false);
    }

    private async Task CloseAfterUnwindAsync(InputStreams input, Task producers)
    {
        try
        {
            // A retried delete can capture another lifetime of the same input. Only those
            // producers share a closure dependency; unrelated inputs must not hold it open.
            await producers.ConfigureAwait(false);
            TaskStreamState[] streams;
            lock (_gate)
            {
                streams = input.Streams.ToArray();
            }
            foreach (TaskStreamState stream in streams)
            {
                await stream.CloseAsync().ConfigureAwait(false);
            }
        }
        catch (Exception exception)
        {
            lock (_gate)
            {
                input.Closing = false;
            }
            _closeFailed(input.InputId, exception);
        }
    }

    private sealed class InputStreams(string inputId)
    {
        public string InputId { get; } = inputId;
        public HashSet<TaskStreamState> Streams { get; } = new();
        public HashSet<Task> Producers { get; } = new();
        public bool Closing { get; set; }
    }
}
