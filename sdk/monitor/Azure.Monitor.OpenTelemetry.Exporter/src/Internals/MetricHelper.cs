// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class MetricHelper
    {
        private const int Version = 2;

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

                        SetContextTagsFromMetricTags(telemetryItem, metricPoint);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetContextTagsFromMetricTags(TelemetryItem telemetryItem, in MetricPoint metricPoint)
        {
            string? clientAddress = null;
            string? microsoftClientIp = null;

            foreach (var tag in metricPoint.Tags)
            {
                switch (tag.Key)
                {
                    case SemanticConventions.AttributeEnduserId:
                        telemetryItem.Tags[ContextTagKeys.AiUserAuthUserId.ToString()] = tag.Value?.ToString().Truncate(SchemaConstants.Tags_AiUserAuthUserId_MaxLength);
                        break;
                    case SemanticConventions.AttributeEnduserPseudoId:
                        telemetryItem.Tags[ContextTagKeys.AiUserId.ToString()] = tag.Value?.ToString().Truncate(SchemaConstants.Tags_AiUserId_MaxLength);
                        break;
                    case SemanticConventions.AttributeClientAddress:
                        clientAddress = tag.Value?.ToString();
                        break;
                    case SemanticConventions.AttributeMicrosoftClientIp:
                        microsoftClientIp = tag.Value?.ToString();
                        break;
                    case SemanticConventions.AttributeMicrosoftSessionId:
                        telemetryItem.Tags[ContextTagKeys.AiSessionId.ToString()] = tag.Value?.ToString().Truncate(SchemaConstants.Tags_AiSessionId_MaxLength);
                        break;
                    case SemanticConventions.AttributeAiDeviceId:
                        telemetryItem.Tags[ContextTagKeys.AiDeviceId.ToString()] = tag.Value?.ToString().Truncate(SchemaConstants.Tags_AiDeviceId_MaxLength);
                        break;
                    case SemanticConventions.AttributeAiDeviceModel:
                        telemetryItem.Tags[ContextTagKeys.AiDeviceModel.ToString()] = tag.Value?.ToString().Truncate(SchemaConstants.Tags_AiDeviceModel_MaxLength);
                        break;
                    case SemanticConventions.AttributeAiDeviceType:
                        telemetryItem.Tags[ContextTagKeys.AiDeviceType.ToString()] = tag.Value?.ToString().Truncate(SchemaConstants.Tags_AiDeviceType_MaxLength);
                        break;
                    case SemanticConventions.AttributeAiDeviceOsVersion:
                        telemetryItem.Tags[ContextTagKeys.AiDeviceOsVersion.ToString()] = tag.Value?.ToString().Truncate(SchemaConstants.Tags_AiDeviceOsVersion_MaxLength);
                        break;
                    case SemanticConventions.AttributeMicrosoftSyntheticSource:
                        telemetryItem.Tags[ContextTagKeys.AiOperationSyntheticSource.ToString()] = tag.Value?.ToString().Truncate(SchemaConstants.Tags_AiOperationSyntheticSource_MaxLength);
                        break;
                    case SemanticConventions.AttributeMicrosoftUserAccountId:
                        telemetryItem.Tags[ContextTagKeys.AiUserAccountId.ToString()] = tag.Value?.ToString().Truncate(SchemaConstants.Tags_AiUserAccountId_MaxLength);
                        break;
                }
            }

            var locationIp = microsoftClientIp ?? clientAddress;
            if (locationIp != null)
            {
                telemetryItem.Tags[ContextTagKeys.AiLocationIp.ToString()] = locationIp;
            }
        }
    }
}
