// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Timers;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
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
        private readonly bool _isAadEnabled;
        private bool _disposed;

        internal TransmitFromStorageHandler(ApplicationInsightsRestClient applicationInsightsRestClient, PersistentBlobProvider blobProvider, TransmissionStateManager transmissionStateManager, ConnectionVars connectionVars, bool isAadEnabled)
        {
            _applicationInsightsRestClient = applicationInsightsRestClient;
            _connectionVars = connectionVars;
            _isAadEnabled = isAadEnabled;
            _blobProvider = blobProvider;
            _transmissionStateManager = transmissionStateManager;
            _transmitFromStorageTimer = new System.Timers.Timer();
            _transmitFromStorageTimer.Elapsed += TransmitFromStorage;
            _transmitFromStorageTimer.AutoReset = true;
            _transmitFromStorageTimer.Interval = 120000;
            _transmitFromStorageTimer.Start();
            _isAadEnabled = isAadEnabled;
        }

        internal void TransmitFromStorage(object? sender, ElapsedEventArgs? e)
        {
            // Only process 10 files at a time so that we don't end up taking lot of cpu
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

                            AzureMonitorExporterEventSource.Log.TransmitFromStorageSuccess(_isAadEnabled, _connectionVars.InstrumentationKey);

                            // In case if the delete fails, there is a possibility
                            // that the current batch will be transmitted more than once resulting in duplicates.
                            var deleteSucceeded = blob.TryDelete();
                            if (!deleteSucceeded)
                            {
                                AzureMonitorExporterEventSource.Log.DeletedFailed();
                            }
                        }
                        else
                        {
                            _transmissionStateManager.EnableBackOff(httpMessage.HasResponse ? httpMessage.Response : null);
                            HttpPipelineHelper.ProcessTransmissionResult(httpMessage, _blobProvider, blob, _connectionVars, TelemetryItemOrigin.Storage, _isAadEnabled);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        AzureMonitorExporterEventSource.Log.FailedToTransmitFromStorage(_isAadEnabled, _connectionVars.InstrumentationKey, ex);
                        CustomerSdkStatsHelper.TrackDropped(null, (int)DropCode.ClientException, CustomerSdkStatsHelper.GetDropReason(ex));
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
