// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
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

        internal TransmitFromStorageHandler(ApplicationInsightsRestClient applicationInsightsRestClient, PersistentBlobProvider blobProvider, TransmissionStateManager transmissionStateManager, ConnectionVars connectionVars, bool isAadEnabled, TimeSpan? transmitInterval = null)
        {
            _applicationInsightsRestClient = applicationInsightsRestClient;
            _connectionVars = connectionVars;
            _isAadEnabled = isAadEnabled;
            _blobProvider = blobProvider;
            _transmissionStateManager = transmissionStateManager;
            _transmitFromStorageTimer = new System.Timers.Timer();
            _transmitFromStorageTimer.Elapsed += TransmitFromStorage;
            _transmitFromStorageTimer.AutoReset = true;

            var interval = transmitInterval ?? TimeSpan.FromSeconds(120);
            if (interval != System.Threading.Timeout.InfiniteTimeSpan)
            {
                _transmitFromStorageTimer.Interval = interval.TotalMilliseconds;
                _transmitFromStorageTimer.Start();
            }
        }

        /// <summary>
        /// Drains all accumulated blobs from offline storage. Unlike <see cref="TransmitFromStorage"/>
        /// which caps at 10 files per tick, this method loops until all blobs are uploaded
        /// or a transmission failure occurs.
        /// </summary>
        internal void DrainAll()
        {
            while (true)
            {
                if (_transmissionStateManager.State != TransmissionState.Closed)
                {
                    break;
                }

                if (!_blobProvider.TryGetBlob(out var blob) || !blob.TryLease(120000))
                {
                    break;
                }

                TelemetrySchemaTypeCounter? telemetrySchemaTypeCounter = new TelemetrySchemaTypeCounter();

                try
                {
                    blob.TryRead(out var data);

                    if (data == null)
                    {
                        // Unreadable blob — delete it to avoid spinning on the same blob forever.
                        blob.TryDelete();
                        continue;
                    }

                    try
                    {
                        var telemetryItems = Encoding.UTF8.GetString(data).Split('\n');
                        for (int i = 0; i < telemetryItems.Length; i++)
                        {
                            var telemetryType = HttpPipelineHelper.GetTelemetryTypeFromJson(telemetryItems[i]);
                            HttpPipelineHelper.IncrementCounterByType(telemetrySchemaTypeCounter, telemetryType);
                        }
                    }
                    catch (Exception)
                    {
                        // Best-effort counter population; proceed with transmission regardless.
                    }

                    using var httpMessage = _applicationInsightsRestClient.InternalTrackAsync(data, CancellationToken.None).Result;
                    var result = HttpPipelineHelper.IsSuccess(httpMessage, telemetrySchemaTypeCounter);

                    if (result == ExportResult.Success)
                    {
                        _transmissionStateManager.ResetConsecutiveErrors();
                        _transmissionStateManager.CloseTransmission();
                        blob.TryDelete();
                    }
                    else
                    {
                        _transmissionStateManager.EnableBackOff(httpMessage.HasResponse ? httpMessage.Response : null);
                        HttpPipelineHelper.ProcessTransmissionResult(httpMessage, _blobProvider, blob, _connectionVars, TelemetryItemOrigin.Storage, _isAadEnabled, telemetrySchemaTypeCounter);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.FailedToTransmitFromStorage(_isAadEnabled, _connectionVars.InstrumentationKey, ex);
                    break;
                }
            }
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
                    TelemetrySchemaTypeCounter? telemetrySchemaTypeCounter = new TelemetrySchemaTypeCounter();

                    try
                    {
                        blob.TryRead(out var data);

                        if (data != null)
                        {
                            try
                            {
                                var telemetryItems = Encoding.UTF8.GetString(data).Split('\n');
                                var totalItems = telemetryItems.Length;

                                if (totalItems == 0)
                                {
                                    continue;
                                }

                                for (int i = 0; i < totalItems; i++)
                                {
                                    var telemetryType = HttpPipelineHelper.GetTelemetryTypeFromJson(telemetryItems[i]);
                                    HttpPipelineHelper.IncrementCounterByType(telemetrySchemaTypeCounter, telemetryType);
                                }
                            }
                            catch (Exception)
                            {
                                // TODO: Log the exception.
                            }
                        }

                        using var httpMessage = _applicationInsightsRestClient.InternalTrackAsync(data, CancellationToken.None).Result;
                        var result = HttpPipelineHelper.IsSuccess(httpMessage, telemetrySchemaTypeCounter);

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
                            HttpPipelineHelper.ProcessTransmissionResult(httpMessage, _blobProvider, blob, _connectionVars, TelemetryItemOrigin.Storage, _isAadEnabled, telemetrySchemaTypeCounter);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        AzureMonitorExporterEventSource.Log.FailedToTransmitFromStorage(_isAadEnabled, _connectionVars.InstrumentationKey, ex);
                        CustomerSdkStatsHelper.TrackDropped(telemetrySchemaTypeCounter, (int)DropCode.ClientException, CustomerSdkStatsHelper.GetDropReason(ex));
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
