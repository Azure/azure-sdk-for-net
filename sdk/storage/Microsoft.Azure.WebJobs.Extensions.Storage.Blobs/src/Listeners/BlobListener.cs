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
    internal sealed class BlobListener : IListener, IScaleMonitorProvider
    {
        private readonly ISharedListener _sharedListener;
        private readonly ILogger<BlobListener> _logger;

        private bool _started;
        private bool _disposed;
        private Lazy<string> _details;

        // for mock test purposes only
        internal BlobListener(ISharedListener sharedListener)
        {
            _sharedListener = sharedListener;
        }

        public BlobListener(ISharedListener sharedListener, BlobContainerClient containerClient, ILoggerFactory loggerFactory)
        {
            _sharedListener = sharedListener;
            _details = new Lazy<string>(() => $"blob container={containerClient.Name}, storage account name={containerClient.AccountName}");
            _logger = loggerFactory.CreateLogger<BlobListener>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                ThrowIfDisposed();

                if (_started)
                {
                    throw new InvalidOperationException("The listener has already been started.");
                }

                _logger.LogDebug($"Storage blob listener started ({_details.Value})");
                return StartAsyncCore(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Storage blob listener encountered an error during starting ({_details.Value})");
                throw;
            }
        }

        private async Task StartAsyncCore(CancellationToken cancellationToken)
        {
            // Starts the entire shared listener (if not yet started).
            // There is currently no scenario for controlling a single blob listener independently.
            await _sharedListener.EnsureAllStartedAsync(cancellationToken).ConfigureAwait(false);
            _started = true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                ThrowIfDisposed();

                if (!_started)
                {
                    throw new InvalidOperationException(
                        "The listener has not yet been started or has already been stopped.");
                }

                return StopAsyncCore(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Storage blob listener encountered an error during stopping ({_details.Value})");
                throw;
            }
            finally
            {
                _logger.LogDebug($"Storage blob listener stopped ({_details.Value})");
            }
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
    }
}
