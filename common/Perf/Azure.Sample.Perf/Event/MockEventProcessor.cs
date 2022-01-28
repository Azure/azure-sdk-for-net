// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf.Event
{
    public class MockEventProcessor
    {
        public int Partitions { get; }
        public int? MaxEventsPerSecond { get; }
        private double MaxEventsPerSecondPerPartition => ((double)MaxEventsPerSecond) / Partitions;

        public TimeSpan? ErrorAfter { get; }
        private bool _errorRaised;
        private object _errorLock = new object();

        private readonly MockEventArgs[] _eventArgs;
        private readonly int[] _eventsRaised;
        private readonly Stopwatch _sw = new Stopwatch();

        private Func<MockEventArgs, Task> _processEventAsync;
        private Func<MockErrorEventArgs, Task> _processErrorAsync;

        public MockEventProcessor(int partitions, int? maxEventsPerSecond, TimeSpan? errorAfter)
        {
            Partitions = partitions;
            MaxEventsPerSecond = maxEventsPerSecond;
            ErrorAfter = errorAfter;

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

        public event Func<MockErrorEventArgs, Task> ProcessErrorAsync
        {
            add
            {
                _processErrorAsync = value;
            }
            remove
            {
                _processErrorAsync = default;
            }
        }

        public Task StartProcessingAsync()
        {
            _sw.Start();

            for (var i=0; i < Partitions; i++)
            {
                var j = i;
                Task.Run(() => Process(j));
            }

            return Task.CompletedTask;
        }

        private void Process(int partition)
        {
            var eventArgs = _eventArgs[partition];

            if (MaxEventsPerSecond.HasValue)
            {
                while (true)
                {
                    if (ErrorAfter.HasValue && !_errorRaised && _sw.Elapsed > ErrorAfter)
                    {
                        lock (_errorLock)
                        {
                            if (!_errorRaised)
                            {
                                _processErrorAsync(new MockErrorEventArgs(partition, new InvalidOperationException("test exception")));
                                _errorRaised = true;
                            }
                        }
                    }
                    else
                    {
                        var eventsRaised = _eventsRaised[partition];
                        var targetEventsRaised = _sw.Elapsed.TotalSeconds * MaxEventsPerSecondPerPartition;

                        if (eventsRaised < targetEventsRaised)
                        {
                            _processEventAsync(eventArgs).Wait();
                            _eventsRaised[partition]++;
                        }
                        else
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1 / MaxEventsPerSecondPerPartition));
                        }
                    }
                }
            }
            else
            {
                while (true)
                {
                    if (ErrorAfter.HasValue && !_errorRaised && _sw.Elapsed > ErrorAfter)
                    {
                        lock (_errorLock)
                        {
                            if (!_errorRaised)
                            {
                                _processErrorAsync(new MockErrorEventArgs(partition, new InvalidOperationException("test exception")));
                                _errorRaised = true;
                            }
                        }
                    }
                    else
                    {
                        _processEventAsync(eventArgs).Wait();
                        _eventsRaised[partition]++;
                    }
                }
            }
        }
    }
}
