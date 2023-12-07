// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    internal sealed class LiveMetricsExtractionProcessor : BaseProcessor<Activity>
    {
        private bool _disposed;
        private LiveMetricsResource? _resource;
        private readonly Manager _manager;
        //private readonly DoubleBuffer _doubleBuffer;

        internal LiveMetricsResource? LiveMetricsResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource();

        internal LiveMetricsExtractionProcessor(Manager manager)
        {
            _manager = manager;
        }

        public override void OnEnd(Activity activity)
        {
            // Validate if live metrics is enabled.
            if (!_manager._state.IsEnabled())
            {
                return;
            }

            if (_manager.liveMetricsResource == null && LiveMetricsResource != null)
            {
                _manager.liveMetricsResource = LiveMetricsResource;
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
                _manager._metricsContainer._requests.Add(1);
                // Export needs to divide by count to get the average.
                // this.AIRequestDurationAveInMs = requestCount > 0 ? (double)requestDurationInTicks / TimeSpan.TicksPerMillisecond / requestCount : 0;
                _manager._metricsContainer._requestDuration.Record(activity.Duration.TotalMilliseconds);
                if (IsSuccess(activity, statusCodeAttributeValue))
                {
                    _manager._metricsContainer._requestSucceededPerSecond.Add(1);
                }
                else
                {
                    _manager._metricsContainer._requestFailedPerSecond.Add(1);
                }

                AddRequestDocument(activity, statusCodeAttributeValue);
            }
            else
            {
                _manager._metricsContainer._dependency.Add(1);
                // Export needs to divide by count to get the average.
                // this.AIDependencyCallDurationAveInMs = dependencyCount > 0 ? (double)dependencyDurationInTicks / TimeSpan.TicksPerMillisecond / dependencyCount : 0;
                // Export DependencyDurationLiveMetric, Meter: LiveMetricMeterName
                // (2023 - 11 - 03T23: 20:56.0282406Z, 2023 - 11 - 03T23: 21:00.9830153Z] Histogram Value: Sum: 798.9463000000001 Count: 7 Min: 4.9172 Max: 651.8997
                _manager._metricsContainer._dependencyDuration.Record(activity.Duration.TotalMilliseconds);
                if (IsSuccess(activity, statusCodeAttributeValue))
                {
                    _manager._metricsContainer._dependencySucceededPerSecond.Add(1);
                }
                else
                {
                    _manager._metricsContainer._dependencyFailedPerSecond.Add(1);
                }

                AddRemoteDependencyDocument(activity);
            }

            if (activity.Events != null)
            {
                foreach (ref readonly var @event in activity.EnumerateEvents())
                {
                    if (@event.Name == SemanticConventions.AttributeExceptionEventName)
                    {
                        _manager._metricsContainer._exceptionsPerSecond.Add(1);
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

            _manager._metricsContainer._documentBuffer.Instance.WriteDocument(exceptionDocumentIngress);
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

            _manager._metricsContainer._documentBuffer.Instance.WriteDocument(remoteDependencyDocumentIngress);
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

            _manager._metricsContainer._documentBuffer.Instance.WriteDocument(requestDocumentIngress);
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
