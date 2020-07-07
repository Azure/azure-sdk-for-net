// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Timers;

namespace Microsoft.Azure.WebJobs.Host.Listeners
{
    internal class HeartbeatListener : IListener
    {
        private readonly IRecurrentCommand _heartbeatCommand;
        private readonly IListener _innerListener;
        private readonly ITaskSeriesTimer _timer;

        private bool _disposed;

        public HeartbeatListener(IRecurrentCommand heartbeatCommand,
            IWebJobsExceptionHandler exceptionHandler, IListener innerListener)
        {
            _heartbeatCommand = heartbeatCommand;
            _innerListener = innerListener;
            _timer = CreateTimer(exceptionHandler);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _innerListener.StartAsync(cancellationToken);

            await _heartbeatCommand.TryExecuteAsync(cancellationToken);
            _timer.Start();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _timer.StopAsync(cancellationToken);
            await _innerListener.StopAsync(cancellationToken);
        }

        public void Cancel()
        {
            _timer.Cancel();
            _innerListener.Cancel();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _timer.Dispose();
                _innerListener.Dispose();

                _disposed = true;
            }
        }

        private ITaskSeriesTimer CreateTimer(IWebJobsExceptionHandler exceptionHandler)
        {
            return LinearSpeedupStrategy.CreateTimer(_heartbeatCommand, HeartbeatIntervals.NormalSignalInterval,
                HeartbeatIntervals.MinimumSignalInterval, exceptionHandler);
        }
    }
}
