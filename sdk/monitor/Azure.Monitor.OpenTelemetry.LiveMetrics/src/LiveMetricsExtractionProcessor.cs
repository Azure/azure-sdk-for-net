// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    internal sealed class LiveMetricsExtractionProcessor : BaseProcessor<Activity>
    {
        private bool _disposed;
        private LiveMetricsResource? _resource;
        internal readonly MeterProvider? _meterProvider;
        private readonly Meter _meter;
        private readonly Counter<long> _requests;
        private readonly Histogram<double> _requestDuration;
        private readonly Counter<long> _requestSucceededPerSecond;
        private readonly Counter<long> _requestFailedPerSecond;
        private readonly Counter<long> _dependency;
        private readonly Histogram<double> _dependencyDuration;
        private readonly Counter<long> _dependencySucceededPerSecond;
        private readonly Counter<long> _dependencyFailedPerSecond;
        private readonly Counter<long> _exceptionsPerSecond;
        // TODO: Explore concurrent collections.
        private readonly List<DocumentIngress> _documentIngress = new();

        internal LiveMetricsResource? LiveMetricsResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource();

        internal LiveMetricsExtractionProcessor(LiveMetricsExporter liveMetricExporter)
        {
            _meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(LiveMetricConstants.LiveMetricMeterName)
                .AddReader(new PeriodicExportingMetricReader(exporter: liveMetricExporter, exportIntervalMilliseconds:5000)
                { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
                // TODO: Remove Console Exporter
                .AddConsoleExporter()
                .Build();

            _meter = new Meter(LiveMetricConstants.LiveMetricMeterName);
            _requests = _meter.CreateCounter<long>(LiveMetricConstants.RequestsInstrumentName);
            _requestDuration = _meter.CreateHistogram<double>(LiveMetricConstants.RequestDurationInstrumentName);
            _requestSucceededPerSecond = _meter.CreateCounter<long>(LiveMetricConstants.RequestsSucceededPerSecondInstrumentName);
            _requestFailedPerSecond = _meter.CreateCounter<long>(LiveMetricConstants.RequestsFailedPerSecondInstrumentName);
            _dependency = _meter.CreateCounter<long>(LiveMetricConstants.DependencyInstrumentName);
            _dependencyDuration = _meter.CreateHistogram<double>(LiveMetricConstants.DependencyDurationInstrumentName);
            _dependencySucceededPerSecond = _meter.CreateCounter<long>(LiveMetricConstants.DependencySucceededPerSecondInstrumentName);
            _dependencyFailedPerSecond = _meter.CreateCounter<long>(LiveMetricConstants.DependencyFailedPerSecondInstrumentName);
            _exceptionsPerSecond = _meter.CreateCounter<long>(LiveMetricConstants.ExceptionsPerSecondInstrumentName);
        }

        public override void OnEnd(Activity activity)
        {
            // Validate if live metrics is enabled.
            if (!_requests.Enabled)
            {
                return;
            }

            string? statusCodeAttributeValue = null;

            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                if (tag.Key == SemanticConventions.AttributeHttpResponseStatusCode)
                {
                    statusCodeAttributeValue = tag.Value?.ToString();
                    break;
                }
            }

            if (activity.Kind == ActivityKind.Server || activity.Kind == ActivityKind.Consumer)
            {
                _requests.Add(1);
                // Export needs to divide by count to get the average.
                // this.AIRequestDurationAveInMs = requestCount > 0 ? (double)requestDurationInTicks / TimeSpan.TicksPerMillisecond / requestCount : 0;
                _requestDuration.Record(activity.Duration.TotalMilliseconds);
                if (IsSuccess(activity, statusCodeAttributeValue))
                {
                    _requestFailedPerSecond.Add(1);
                }
                else
                {
                    _requestSucceededPerSecond.Add(1);
                }

                AddRequestDocument(activity, statusCodeAttributeValue);
            }
            else
            {
                _dependency.Add(1);
                // Export needs to divide by count to get the average.
                // this.AIDependencyCallDurationAveInMs = dependencyCount > 0 ? (double)dependencyDurationInTicks / TimeSpan.TicksPerMillisecond / dependencyCount : 0;
                // Export DependencyDurationLiveMetric, Meter: LiveMetricMeterName
                // (2023 - 11 - 03T23: 20:56.0282406Z, 2023 - 11 - 03T23: 21:00.9830153Z] Histogram Value: Sum: 798.9463000000001 Count: 7 Min: 4.9172 Max: 651.8997
                _dependencyDuration.Record(activity.Duration.TotalMilliseconds);
                if (IsSuccess(activity, statusCodeAttributeValue))
                {
                    _dependencyFailedPerSecond.Add(1);
                }
                else
                {
                    _dependencySucceededPerSecond.Add(1);
                }

                AddRemoteDependencyDocument(activity);
            }

            if (activity.Events != null)
            {
                foreach (ref readonly var @event in activity.EnumerateEvents())
                {
                    if (@event.Name == SemanticConventions.AttributeExceptionEventName)
                    {
                        _exceptionsPerSecond.Add(1);
                    }

                    string? exceptionType = null;
                    string? exceptionMessage = null;

                    foreach (ref readonly var tag in @event.EnumerateTagObjects())
                    {
                        // TODO: see if these can be cached
                        if (tag.Key == SemanticConventions.AttributeExceptionType)
                        {
                            exceptionType = tag.Value?.ToString();
                            continue;
                        }
                        if (tag.Key == SemanticConventions.AttributeExceptionMessage)
                        {
                            exceptionMessage = tag.Value?.ToString();
                            continue;
                        }
                    }

                    AddExceptionDocument(exceptionType, exceptionMessage);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    try
                    {
                        _meterProvider?.Dispose();
                        _meter?.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }

        private void AddExceptionDocument(string? exceptionType, string? exceptionMessage)
        {
            ExceptionDocumentIngress exceptionDocumentIngress = new()
            {
                ExceptionType = exceptionType,
                ExceptionMessage = exceptionMessage,
                DocumentType = DocumentIngressDocumentType.Request,
                // TODO: DocumentStreamIds = new List<string>(),
                // TODO: Properties = new Dictionary<string, string>(), - Validate with UX team if this is needed.
            };
            _documentIngress.Add(exceptionDocumentIngress);
        }

        private void AddRemoteDependencyDocument(Activity activity)
        {
            RemoteDependencyDocumentIngress remoteDependencyDocumentIngress = new()
            {
                Name = activity.DisplayName,
                // TODO: Implementation needs to be copied from Exporter.
                // TODO: Value of dependencyTelemetry.Data
                CommandName = "",
                // TODO: Value of dependencyTelemetry.ResultCode
                ResultCode = "",
                Duration = activity.Duration < SchemaConstants.RequestData_Duration_LessThanDays
                                                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                                                : SchemaConstants.Duration_MaxValue,
                DocumentType = DocumentIngressDocumentType.Request,
                // TODO: DocumentStreamIds = new List<string>(),
                // TODO: Properties = new Dictionary<string, string>(), - Validate with UX team if this is needed.
            };
            _documentIngress.Add(remoteDependencyDocumentIngress);
        }

        private void AddRequestDocument(Activity activity, string? statusCodeAttributeValue)
        {
            RequestDocumentIngress requestDocumentIngress = new()
            {
                Name = activity.DisplayName,
                // TODO: Implementation needs to be copied from Exporter.
                // Value of requestTelemetry.ResultCode
                Url = "",
                ResponseCode = statusCodeAttributeValue,
                Duration = activity.Duration < SchemaConstants.RequestData_Duration_LessThanDays
                                                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                                                : SchemaConstants.Duration_MaxValue,
                DocumentType = DocumentIngressDocumentType.Request,
                // TODO: DocumentStreamIds = new List<string>(),
                // TODO: Properties = new Dictionary<string, string>(), - Validate with UX team if this is needed.
            };
            _documentIngress.Add(requestDocumentIngress);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsSuccess(Activity activity, string? responseCode)
        {
            if (responseCode != null && int.TryParse(responseCode, out int statusCode))
            {
                bool isSuccessStatusCode = statusCode != 0 && statusCode < 400;
                return activity.Status != ActivityStatusCode.Error && isSuccessStatusCode;
            }
            else
            {
                return activity.Status != ActivityStatusCode.Error;
            }
        }
    }
}
