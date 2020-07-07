// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Listeners
{
    internal class FunctionListener : IListener
    {
        private readonly TimeSpan _minRetryInterval;
        private readonly TimeSpan _maxRetryInterval;
        private readonly IListener _listener;
        private readonly FunctionDescriptor _descriptor;
        private readonly ILogger _logger;
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);
        private bool _started = false;
        private bool _allowPartialHostStartup;
        private CancellationTokenSource _retryCancellationTokenSource;

        /// <summary>
        /// Wraps a listener. If the listener throws an exception OnStart,
        /// it attempts to recover by passing the exception through the trace pipeline.
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="descriptor"></param>        
        /// <param name="loggerFactory"></param>
        /// <param name="allowPartialHostStartup"></param>
        /// <param name="maxRetryInterval"></param>
        /// <param name="minRetryInterval"></param>
        public FunctionListener(IListener listener, FunctionDescriptor descriptor, ILoggerFactory loggerFactory, bool allowPartialHostStartup = false, TimeSpan? minRetryInterval = null, TimeSpan? maxRetryInterval = null)
        {
            _listener = listener;
            _descriptor = descriptor;
            _logger = loggerFactory?.CreateLogger(LogCategories.Startup);
            _allowPartialHostStartup = allowPartialHostStartup;
            _minRetryInterval = minRetryInterval ?? TimeSpan.FromSeconds(2);
            _maxRetryInterval = maxRetryInterval ?? TimeSpan.FromMinutes(2);
        }

        public void Cancel()
        {
            _listener.Cancel();
            _retryCancellationTokenSource?.Cancel();
        }

        public void Dispose()
        {
            _listener.Dispose();
            _retryCancellationTokenSource?.Cancel();
            _semaphoreSlim.Dispose();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await StartAsync(cancellationToken, allowRetry: true);
        }

        private async Task StartAsync(CancellationToken cancellationToken, bool allowRetry = false)
        {
            try
            {
                await _listener.StartAsync(cancellationToken);
                _started = true;
            }
            catch (Exception e)
            {
                var flx = new FunctionListenerException(_descriptor.ShortName, e);
                if (_allowPartialHostStartup)
                {
                    flx.Handled = true;
                }

                flx.TryRecover(_logger);

                if (allowRetry && _allowPartialHostStartup)
                {
                    // if to here, the listener exception was handled and
                    // we're in partial startup mode.
                    // we spin up a background task retrying to start the listener
                    _retryCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                    cancellationToken = _retryCancellationTokenSource.Token;
                    Task taskIgnore = Task.Run(() => RetryStartWithBackoffAsync(cancellationToken), cancellationToken);
                }
            }
        }

        public async Task RetryStartWithBackoffAsync(CancellationToken cancellationToken)
        {
            var backoffStrategy = new RandomizedExponentialBackoffStrategy(_minRetryInterval, _maxRetryInterval);
            int attempt = 0;
            string message;
            while (!_started && !cancellationToken.IsCancellationRequested)
            {
                var delay = backoffStrategy.GetNextDelay(false);
                await Task.Delay(delay, cancellationToken);

                if (!cancellationToken.IsCancellationRequested)
                {
                    message = $"Retrying to start listener for function '{_descriptor.ShortName}' (Attempt {++attempt})";
                    _logger?.LogInformation(message);

                    await StartAsync(cancellationToken, allowRetry: false);

                    if (_started)
                    {
                        message = $"Listener successfully started for function '{_descriptor.ShortName}' after {attempt} retries.";
                        _logger?.LogInformation(message);

                        if (cancellationToken.IsCancellationRequested)
                        {
                            // stop has been called while we were in the process of starting
                            // so we need to stop this listener
                            await StopAsync(cancellationToken);

                            message = $"Listener for function '{_descriptor.ShortName}' stopped. A stop was initiated while starting.";
                            _logger?.LogInformation(message);
                        }
                    }
                }
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            // ensure we stop any background retry loop before
            // we issue the Stop
            _retryCancellationTokenSource?.Cancel();

            await _semaphoreSlim.WaitAsync();
            {
                try
                {
                    if (_started)
                    {
                        string listenerName = _listener.GetType().FullName;
                        string functionName = _descriptor.LogName;
                        _logger?.LogInformation("Stopping the listener '{listenerName}' for function '{functionName}'", listenerName, functionName);

                        await _listener.StopAsync(cancellationToken);

                        _logger?.LogInformation("Stopped the listener '{listenerName}' for function '{functionName}'", listenerName, functionName);

                        _started = false;
                    }
                }
                finally
                {
                    _semaphoreSlim.Release();
                }
            }
        }
    }
}
