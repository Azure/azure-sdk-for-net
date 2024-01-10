// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
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

        private DateTimeOffset _lastSuccessfulPing = DateTimeOffset.UtcNow;
        private DateTimeOffset _lastSuccessfulPost = DateTimeOffset.UtcNow;

        private void OnPing()
        {
            try
            {
                Debug.WriteLine($"{DateTime.Now}: OnPing invoked.");

                var response = _quickPulseSDKClientAPIsRestClient.PingCustom(
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

                if (IsResponseSuccess(response))
                {
                    _lastSuccessfulPing = DateTimeOffset.UtcNow;

                    if (response.GetRawResponse().Headers.TryGetValue("x-ms-qps-configuration-etag", out string? etagValue) && etagValue != _etag)
                    {
                        Debug.WriteLine($"OnPing: updated etag: {etagValue}");
                        _etag = etagValue;
                    }

                    if (response.GetRawResponse().Headers.TryGetValue("x-ms-qps-subscribed", out string? subscribedValue) && Convert.ToBoolean(subscribedValue))
                    {
                        Debug.WriteLine($"OnPing: Subscribed: {subscribedValue}");
                        SetPostState();
                    }
                }
                else
                {
                    // TODO: NEED TO INSPECT THE ServiceError OBJECT AND LOG.
                }
            }
            catch (Exception ex)
            {
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

                var response = _quickPulseSDKClientAPIsRestClient.PostCustom(
                    ikey: _connectionVars.InstrumentationKey,
                    apikey: null,
                    xMsQpsConfigurationEtag: _etag,
                    xMsQpsTransmissionTime: null,
                    monitoringDataPoints: new MonitoringDataPoint[] { dataPoint }, // TODO: CHECK WITH SERVICE TEAM. WHY DOES THIS NEED TO BE A COLLECITON?
                    cancellationToken: default);

                if (IsResponseSuccess(response))
                {
                    _lastSuccessfulPost = DateTimeOffset.UtcNow;

                    if (response.GetRawResponse().Headers.TryGetValue("x-ms-qps-configuration-etag", out string? etagValue) && etagValue != _etag)
                    {
                        Debug.WriteLine($"OnPost: updated etag: {etagValue}");
                        _etag = etagValue;
                    }

                    if (response.GetRawResponse().Headers.TryGetValue("x-ms-qps-subscribed", out string? subscribedValue) && !Convert.ToBoolean(subscribedValue))
                    {
                        Debug.WriteLine($"OnPost: Subscribed: {subscribedValue}");
                        _etag = string.Empty;
                        SetPingState();
                    }
                }
                else
                {
                    // TODO: NEED TO INSPECT THE ServiceError OBJECT AND LOG.
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private bool IsResponseSuccess(Response response)
        {
            // TODO: COULD THIS BE MOVED INTO THE REST CLIENT CUSTOMIZATION? ie: avoid checking Status code twice?
            return response.Status >= 200 && response.Status < 300;
        }
    }
}
