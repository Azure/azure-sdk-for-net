// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal sealed class BlobListener : IListener, IScaleMonitorProvider, ITargetScalerProvider
    {
        private readonly ISharedListener _sharedListener;
        private readonly ILogger<BlobListener> _logger;

        private bool _started;
        private bool _disposed;
        private string _details;

        // for mock test purposes only
        internal BlobListener(ISharedListener sharedListener)
        {
            _sharedListener = sharedListener;
        }

        public BlobListener(ISharedListener sharedListener, BlobContainerClient containerClient, IBlobPathSource blobPathSource, ILoggerFactory loggerFactory)
        {
            _sharedListener = sharedListener;
            _details = $"blob container name={containerClient.Name}, storage account name={containerClient.AccountName}, blob name pattern={blobPathSource.BlobNamePattern}";
            _logger = loggerFactory.CreateLogger<BlobListener>();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            if (_started)
            {
                throw new InvalidOperationException("The listener has already been started.");
            }

            await StartAsyncCore(cancellationToken).ConfigureAwait(false);
            _logger.LogDebug($"Storage blob listener started ({_details})");
        }

        private async Task StartAsyncCore(CancellationToken cancellationToken)
        {
            // Starts the entire shared listener (if not yet started).
            // There is currently no scenario for controlling a single blob listener independently.
            await _sharedListener.EnsureAllStartedAsync(cancellationToken).ConfigureAwait(false);
            _started = true;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            if (!_started)
            {
                throw new InvalidOperationException(
                    "The listener has not yet been started or has already been stopped.");
            }

            await StopAsyncCore(cancellationToken).ConfigureAwait(false);
            _logger.LogDebug($"Storage blob listener stopped ({_details})");
        }

        private async Task StopAsyncCore(CancellationToken cancellationToken)
        {
            // Stops the entire shared listener (if not yet stopped).
            // There is currently no scenario for controlling a single blob listener independently.
            await _sharedListener.EnsureAllStoppedAsync(cancellationToken).ConfigureAwait(false);
            _started = false;
        }

        public void Cancel()
        {
            ThrowIfDisposed();
            _sharedListener.EnsureAllCanceled();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                // Disposes the entire shared listener (if not yet disposed).
                // There is currently no scenario for controlling a single blob listener independently.
                _sharedListener.EnsureAllDisposed();

                _disposed = true;
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(null);
            }
        }

        public IScaleMonitor GetMonitor()
        {
            // BlobListener is special - it uses a single shared QueueListener for all BlobTrigger functions,
            // so we must return that single shared instance.
            // Each individual BlobTrigger function will have its own listener, each pointing to the single
            // shared QueueListener. If all BlobTrigger functions are disabled, their listeners won't be created
            // so the shared queue won't be monitored.
            return ((IScaleMonitorProvider)_sharedListener).GetMonitor();
        }

        public ITargetScaler GetTargetScaler()
        {
            return ((ITargetScalerProvider)_sharedListener).GetTargetScaler();
        }
    }
}
