// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal sealed class SharedBlobListener : ISharedListener
    {
        private readonly IBlobListenerStrategy _strategy;
        private readonly ITaskSeriesTimer _timer;

        private bool _started;
        private bool _disposed;

        public SharedBlobListener(string hostId, StorageAccount storageAccount,
            IWebJobsExceptionHandler exceptionHandler, ILogger<BlobListener> logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (exceptionHandler == null)
            {
                throw new ArgumentNullException(nameof(exceptionHandler));
            }

            _strategy = CreateStrategy(hostId, storageAccount, exceptionHandler, logger);

            // Start the first iteration immediately.
            _timer = new TaskSeriesTimer(_strategy, exceptionHandler, initialWait: Task.Delay(0));
        }

        public IBlobWrittenWatcher BlobWritterWatcher
        {
            get { return _strategy; }
        }

        public Task RegisterAsync(CloudBlobContainer container, ITriggerExecutor<BlobTriggerExecutorContext> triggerExecutor,
            CancellationToken cancellationToken)
        {
            if (_started)
            {
                throw new InvalidOperationException(
                    "Registrations may not be added while the shared listener is running.");
            }

            return _strategy.RegisterAsync(container, triggerExecutor, cancellationToken);
        }

        public Task EnsureAllStartedAsync(CancellationToken cancellationToken)
        {
            if (!_started)
            {
                _timer.Start();
                _strategy.Start();
                _started = true;
            }

            return Task.FromResult(0);
        }

        public async Task EnsureAllStoppedAsync(CancellationToken cancellationToken)
        {
            if (_started)
            {
                _strategy.Cancel();
                await _timer.StopAsync(cancellationToken);
                _started = false;
            }
        }

        public void EnsureAllCanceled()
        {
            _strategy.Cancel();
            _timer.Cancel();
        }

        public void EnsureAllDisposed()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _strategy.Dispose();
                _timer.Dispose();
                _disposed = true;
            }
        }

        private static IBlobListenerStrategy CreateStrategy(string hostId, StorageAccount account, IWebJobsExceptionHandler exceptionHandler, ILogger<BlobListener> logger)
        {
            if (!account.IsDevelopmentStorageAccount())
            {
                IBlobScanInfoManager scanInfoManager = new StorageBlobScanInfoManager(hostId, account.CreateCloudBlobClient());
                return new ScanBlobScanLogHybridPollingStrategy(scanInfoManager, exceptionHandler, logger);
            }
            else
            {
                return new ScanContainersStrategy();
            }
        }
    }
}
