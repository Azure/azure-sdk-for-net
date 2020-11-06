// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace System.PerfStress
{
    public class TimerRunTest : PerfTest<PerfOptions>
    {
        private readonly SemaphoreSlim _semaphoreSlim;

        [SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "<Pending>")]
        private readonly Timer _timer;

        public TimerRunTest(PerfOptions options) : base(options)
        {
            _semaphoreSlim = new SemaphoreSlim(0);
            _timer = new Timer(_ => _semaphoreSlim.Release(), state: null, dueTime: TimeSpan.FromSeconds(1), period: TimeSpan.FromSeconds(1));
        }

        public override void Run(CancellationToken cancellationToken)
        {
            _semaphoreSlim.Wait();
        }

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            return _semaphoreSlim.WaitAsync();
        }
    }
}
