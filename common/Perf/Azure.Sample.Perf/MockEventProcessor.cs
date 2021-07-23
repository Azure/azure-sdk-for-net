// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    public class MockEventProcessor
    {
        public int Partitions { get; }
        public int MaxEventsPerSecond { get; }
        private double MaxEventsPerSecondPerPartition => ((double)MaxEventsPerSecond) / Partitions;

        private readonly MockEventArgs[] _eventArgs;
        private readonly int[] _eventsRaised;
        private readonly Stopwatch _sw = new Stopwatch();

        private Func<MockEventArgs, Task> _processEventAsync;

        public MockEventProcessor(int partitions, int maxEventsPerSecond)
        {
            Partitions = partitions;
            MaxEventsPerSecond = maxEventsPerSecond;

            _eventArgs = new MockEventArgs[partitions];
            for (var i=0; i < partitions; i++)
            {
                _eventArgs[i] = new MockEventArgs(partition: i, data: "hello");
            }

            _eventsRaised = new int[partitions];
        }

        public event Func<MockEventArgs, Task> ProcessEventAsync
        {
            add
            {
                _processEventAsync = value;
            }
            remove
            {
                _processEventAsync = default;
            }
        }

        public Task StartProcessingAsync()
        {
            _sw.Start();

            for (var i=0; i < Partitions; i++)
            {
                _ = Process(i);
            }

            return Task.CompletedTask;
        }

        private async Task Process(int partition)
        {
            await Task.Yield();

            var eventArgs = _eventArgs[partition];

            if (MaxEventsPerSecond > 0)
            {
                while (true)
                {
                    var eventsRaised = _eventsRaised[partition];
                    var targetEventsRaised = _sw.Elapsed.TotalSeconds * MaxEventsPerSecondPerPartition;

                    if (eventsRaised < targetEventsRaised)
                    {
                        await _processEventAsync(eventArgs).ConfigureAwait(false);
                        _eventsRaised[partition]++;
                    }
                    else
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1 / MaxEventsPerSecondPerPartition));
                    }
                }
            }
            else
            {
                while (true)
                {
                    await _processEventAsync(eventArgs).ConfigureAwait(false);
                    _eventsRaised[partition]++;
                }
            }
        }
    }
}
