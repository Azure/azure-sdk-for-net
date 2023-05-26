﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Timers;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using OpenTelemetry;
using OpenTelemetry.PersistentStorage.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class TransmitFromStorageHandler : IDisposable
    {
        private readonly ApplicationInsightsRestClient _applicationInsightsRestClient;
        private readonly ConnectionVars _connectionVars;
        internal PersistentBlobProvider _blobProvider;
        private readonly TransmissionStateManager _transmissionStateManager;
        private readonly System.Timers.Timer _transmitFromStorageTimer;
        private bool _disposed;

        internal TransmitFromStorageHandler(ApplicationInsightsRestClient applicationInsightsRestClient, PersistentBlobProvider blobProvider, TransmissionStateManager transmissionStateManager, ConnectionVars connectionVars)
        {
            _applicationInsightsRestClient = applicationInsightsRestClient;
            _connectionVars = connectionVars;
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
            // Only proces 10 files at a time so that we don't end up taking lot of cpu
            // if the number of files are large.
            int fileCount = 10;
            while (fileCount > 0)
            {
                if (_transmissionStateManager.State == TransmissionState.Closed && _blobProvider.TryGetBlob(out var blob) && blob.TryLease(120000))
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
                            HttpPipelineHelper.HandleFailures(httpMessage, blob, _blobProvider, _connectionVars);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        AzureMonitorExporterEventSource.Log.WriteError("FailedToTransmitFromStorage", ex);
                    }
                }
                else
                {
                    break;
                }

                fileCount--;
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
