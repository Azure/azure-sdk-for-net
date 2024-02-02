// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    /// <summary>
    /// This partial class encapsulates the Ping and Post methods.
    /// This is the data that is sent to the Live Metrics service.
    /// </summary>
    internal partial class Manager
    {
        /// <summary>
        /// This is a unique identifier that comes from the LiveMetrics service and identifies our connected session.
        /// </summary>
        private string _etag = string.Empty;
        private CollectionConfigurationInfo? _collectionConfigurationInfo = null;

        private DateTimeOffset _lastSuccessfulPing = DateTimeOffset.UtcNow;
        private DateTimeOffset _lastSuccessfulPost = DateTimeOffset.UtcNow;

        private void OnPing()
        {
            try
            {
                Debug.WriteLine($"{DateTime.Now}: OnPing invoked.");

                var response = _quickPulseSDKClientAPIsRestClient.CustomPing(
                    ikey: _connectionVars.InstrumentationKey,
                    apikey: null,
                    xMsQpsTransmissionTime: null,
                    xMsQpsMachineName: "Desktop-Name",
                    xMsQpsInstanceName: "Desktop-Name",
                    xMsQpsStreamId: _streamId,
                    xMsQpsRoleName: null,
                    xMsQpsInvariantVersion: "5",
                    xMsQpsConfigurationEtag: _etag,
                    monitoringDataPoint: null,
                    cancellationToken: default);

                if (response.Success)
                {
                    _lastSuccessfulPing = DateTimeOffset.UtcNow;

                    if (response.Subscribed)
                    {
                        Debug.WriteLine($"OnPing: Subscribed: {response.Subscribed}.");
                        RefreshConfigurationOnEtagChange(response);
                        SetPostState();
                    }
                }
            }
            catch (System.Exception ex)
            {
                LiveMetricsExporterEventSource.Log.PingFailedWithUnknownException(ex);
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Send data to LiveMetrics service.
        /// </summary>
        /// <remarks>
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Requests/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Request Duration", Value = 0, Weight = 0 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Requests Failed/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Requests Succeeded/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Dependency Calls/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Dependency Call Duration", Value = 0, Weight = 0 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Dependency Calls Failed/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Dependency Calls Succeeded/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\ApplicationInsights\\Exceptions/Sec", Value = 0, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\Memory\\Committed Bytes", Value = 41372430336, Weight = 1 });
        /// dataPoint.Metrics.Add(new MetricPoint { Name = "\\Processor(_Total)\\% Processor Time", Value = 14.1891f, Weight = 1 });.
        /// </remarks>
        private void OnPost()
        {
            try
            {
                Debug.WriteLine($"{DateTime.Now}: OnPost invoked.");

                var dataPoint = GetDataPoint();

                var response = _quickPulseSDKClientAPIsRestClient.CustomPost(
                    ikey: _connectionVars.InstrumentationKey,
                    apikey: null,
                    xMsQpsConfigurationEtag: _etag,
                    xMsQpsTransmissionTime: null,
                    monitoringDataPoints: new MonitoringDataPoint[] { dataPoint }, // This collection is used to send multiple samples. For example, if a Post fails and we want to retry at the next Post.
                    cancellationToken: default);

                if (response.Success)
                {
                    _lastSuccessfulPost = DateTimeOffset.UtcNow;

                    if (!response.Subscribed)
                    {
                        Debug.WriteLine($"OnPost: Subscribed: {response.Subscribed}.");
                        _etag = string.Empty;
                        SetPingState();
                        // TODO: double check if subscribedValue is false, we should stop collecting properly: (QuickPulseTelemetryModule.OnStopCollection).
                    }
                    else
                    {
                        RefreshConfigurationOnEtagChange(response);
                    }

                    // TODO: if parsing "x-ms-qps-subscribed" failed, what should do we with the data which was supposed to be sent? (QuickPulseTelemetryModule.OnReturnFailedSamples).
                }
            }
            catch (System.Exception ex)
            {
                LiveMetricsExporterEventSource.Log.PostFailedWithUnknownException(ex);
                Debug.WriteLine(ex);
            }
        }

        // This method updates etag and CollectionConfigurationInfo if needed. It should be called whenever Subscribed is true.
        private void RefreshConfigurationOnEtagChange(QuickPulseResponse response)
        {
            if (response.ConfigurationEtag != null && response.ConfigurationEtag != _etag)
            {
                Debug.WriteLine($"Updated etag: {response.ConfigurationEtag}.");
                _etag = response.ConfigurationEtag;
                if (response.CollectionConfigurationInfo != null)
                {
                    _collectionConfigurationInfo = response.CollectionConfigurationInfo;
                }
            }
        }
    }
}
