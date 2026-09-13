// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class MetricHelper
    {
        private const int Version = 2;

        private const string InstrumentationKeyAttributeName = SemanticConventions.AttributeMicrosoftInstrumentationKey;
        private const string IngestionEndpointAttributeName = SemanticConventions.AttributeMicrosoftIngestionEndpoint;
        private const string CloudRoleAttributeName = SemanticConventions.AttributeMicrosoftMultiEndpointCloudRole;

        internal static (List<TelemetryItem> TelemetryItems, TelemetrySchemaTypeCounter TelemetrySchemaTypeCounter) OtelToAzureMonitorMetrics(Batch<Metric> batch, AzureMonitorResource? resource, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new();

            foreach (var metric in batch)
            {
                foreach (ref readonly var metricPoint in metric.GetMetricPoints())
                {
                    try
                    {
                        var telemetryItem = new TelemetryItem(metricPoint.EndTime.UtcDateTime, resource, instrumentationKey)
                        {
                            Data = new MonitorBase
                            {
                                BaseType = "MetricData",
                                BaseData = new MetricsData(Version, metric, metricPoint)
                            }
                        };
                        telemetryItems.Add(telemetryItem);
                    }
                    catch (Exception ex)
                    {
                        AzureMonitorExporterEventSource.Log.FailedToConvertMetricPoint(meterName: metric.MeterName, instrumentName: metric.Name, ex: ex);
                    }
                }
            }

            return (telemetryItems, new TelemetrySchemaTypeCounter() { _metricCount = telemetryItems.Count });
        }

        /// <summary>
        /// Converts a batch into envelopes grouped by the ingestion endpoint each <see cref="MetricPoint"/>
        /// was stamped with. A point whose routing dimensions are missing or invalid is dropped rather
        /// than sent under the exporter's own connection string.
        /// </summary>
        /// <remarks>
        /// Routing is per <see cref="MetricPoint"/>, not per <see cref="Metric"/>: one instrument's
        /// points carry different dimension values, so a single instrument can feed several endpoints.
        /// </remarks>
        internal static void OtelToAzureMonitorMetricsMultiEndpoint(Batch<Metric> batch, AzureMonitorResource? resource, EndpointRouteBatch routeBatch)
        {
            int collected = 0;
            int rejected = 0;

            foreach (var metric in batch)
            {
                foreach (ref readonly var metricPoint in metric.GetMetricPoints())
                {
                    try
                    {
                        if (!TryGetMetricRoute(in metricPoint, out var instrumentationKey, out var ingestionEndpoint, out var cloudRole, out var rejection))
                        {
                            // Routing dimensions are stamped upstream only on measurements meant to be
                            // routed. Host-derived instruments (runtime, process, HTTP client) carry
                            // none and are dropped, which is the expected steady state rather than a
                            // failed conversion.
                            rejected++;
                            AzureMonitorExporterEventSource.Log.RoutedMetricRejected(routeBatch.Sequence, rejection, metric.MeterName, metric.Name);
                            continue;
                        }

                        var telemetryItem = new TelemetryItem(metricPoint.EndTime.UtcDateTime, resource, instrumentationKey)
                        {
                            Data = new MonitorBase
                            {
                                BaseType = "MetricData",
                                BaseData = new MetricsData(Version, metric, metricPoint, consumeMultiEndpointAttributes: true)
                            }
                        };

                        telemetryItem.SetCloudRole(cloudRole);

                        routeBatch.GetOrAdd(ingestionEndpoint).TelemetryItems.Add(telemetryItem);
                        collected++;

                        AzureMonitorExporterEventSource.Log.RoutedMetricCollected(routeBatch.Sequence, ingestionEndpoint, instrumentationKey, metric.MeterName, metric.Name);
                    }
                    catch (Exception ex)
                    {
                        AzureMonitorExporterEventSource.Log.FailedToConvertMetricPoint(meterName: metric.MeterName, instrumentName: metric.Name, ex: ex);
                    }
                }
            }

            // Nothing to say about a collection that held no metric points.
            if (collected != 0 || rejected != 0)
            {
                AzureMonitorExporterEventSource.Log.RoutedExportSummary(routeBatch.Sequence, collected, routeBatch.Count, rejected);
            }
        }

        /// <summary>
        /// Reads the route and cloud role off a <see cref="MetricPoint"/>'s dimensions. Only string
        /// values are accepted (first occurrence of each key wins), matching how trace and log
        /// routing read their attributes.
        /// </summary>
        internal static bool TryGetMetricRoute(
            in MetricPoint metricPoint,
            [NotNullWhen(true)] out string? instrumentationKey,
            [NotNullWhen(true)] out string? ingestionEndpoint,
            [NotNullWhen(true)] out string? cloudRole,
            out RoutingRejectionReason reason)
        {
            object? rawKey = null;
            object? rawEndpoint = null;
            object? rawCloudRole = null;
            bool keySeen = false;
            bool endpointSeen = false;
            bool cloudRoleSeen = false;

            foreach (var tag in metricPoint.Tags)
            {
                if (!keySeen && tag.Key == InstrumentationKeyAttributeName)
                {
                    rawKey = tag.Value;
                    keySeen = true;
                }
                else if (!endpointSeen && tag.Key == IngestionEndpointAttributeName)
                {
                    rawEndpoint = tag.Value;
                    endpointSeen = true;
                }
                else if (!cloudRoleSeen && tag.Key == CloudRoleAttributeName)
                {
                    rawCloudRole = tag.Value;
                    cloudRoleSeen = true;
                }
            }

            cloudRole = EndpointRouting.GetCloudRole(rawCloudRole as string);

            // A non-string value stringifies unpredictably (e.g. "System.String[]" for an array), so
            // 'as string' drops it and routing fails, exactly as the trace and log paths do.
            return EndpointRouting.TryGetRoute(rawKey as string, rawEndpoint as string, out instrumentationKey, out ingestionEndpoint, out reason);
        }
    }
}
