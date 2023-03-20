// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Timers;
using OpenTelemetry;
using OpenTelemetry.Extensions.PersistentStorage.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class TransmitFromStorageHandler : IDisposable
    {
        private readonly ApplicationInsightsRestClient _applicationInsightsRestClient;
        private readonly PersistentBlobProvider _blobProvider;
        private readonly TransmissionStateManager _transmissionStateManager;
        private readonly System.Timers.Timer _transmitFromStorageTimer;
        private bool _disposed;

        internal TransmitFromStorageHandler(ApplicationInsightsRestClient applicationInsightsRestClient, PersistentBlobProvider blobProvider, TransmissionStateManager transmissionStateManager)
        {
            _applicationInsightsRestClient = applicationInsightsRestClient;
            _blobProvider = blobProvider;
            _transmissionStateManager = transmissionStateManager;
            _transmitFromStorageTimer = new System.Timers.Timer();
            _transmitFromStorageTimer.Elapsed += TransmitFromStorage;
            _transmitFromStorageTimer.AutoReset = true;
            _transmitFromStorageTimer.Interval = 120000;
            _transmitFromStorageTimer.Start();
        }

        internal void TransmitFromStorage(object? sender, ElapsedEventArgs? e)
        {
            while (_transmissionStateManager.State == TransmissionState.Closed && _blobProvider.TryGetBlob(out var blob) && blob.TryLease(1000))
            {
                try
                {
                    blob.TryRead(out var data);

                    using var httpMessage = _applicationInsightsRestClient.InternalTrackAsync(data, CancellationToken.None).Result;
                    var result = HttpPipelineHelper.IsSuccess(httpMessage);

                    if (result == ExportResult.Success)
                    {
                        _transmissionStateManager.ResetConsecutiveErrors();
                        _transmissionStateManager.CloseTransmission();

                        AzureMonitorExporterEventSource.Log.WriteInformational("TransmitFromStorageSuccess", "Successfully transmitted a blob from storage.");

                        // In case if the delete fails, there is a possibility
                        // that the current batch will be transmitted more than once resulting in duplicates.
                        blob.TryDelete();
                    }
                    else
                    {
                        _transmissionStateManager.EnableBackOff(httpMessage.Response);
                        HttpPipelineHelper.HandleFailures(httpMessage, blob, _blobProvider);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.WriteError("FailedToTransmitFromStorage", ex);
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transmitFromStorageTimer?.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
