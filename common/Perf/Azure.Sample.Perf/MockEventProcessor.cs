// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    public class MockEventProcessor
    {
        private static readonly MockEventArgs _eventArgs = new MockEventArgs(partition: 0, data: "hello");

        private bool _processing = false;
        private bool _stopProcessing = false;

        private Func<MockEventArgs, Task> _processEventAsync;

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
            if (_processing)
            {
                throw new InvalidOperationException("Processing has already been started.");
            }

            _ = Process();
            return Task.CompletedTask;
        }

        private async Task Process()
        {
            await Task.Yield();

            _processing = true;
            while (!_stopProcessing)
            {
                await _processEventAsync(_eventArgs);
            }
            _processing = false;
        }

        public async Task StopProcessingAsync()
        {
            if (!_processing)
            {
                throw new InvalidOperationException("Processing has already been stopped.");
            }

            _stopProcessing = true;

            while (_processing)
            {
                await Task.Delay(10);
            }

            _stopProcessing = false;
        }
    }
}
