// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals;

internal static class ResourceExtensions
{
    private const string AiSdkPrefixKey = "ai.sdk.prefix";
    private const string TelemetryDistroNameKey = "telemetry.distro.name";
    private const string DefaultServiceName = "unknown_service";
    private const int Version = 2;

    internal static AzureMonitorResource? CreateAzureMonitorResource(this Resource resource, string? instrumentationKey = null)
    {
        if (resource == null)
        {
            return null;
        }

        AzureMonitorResource azureMonitorResource = new AzureMonitorResource();
        MetricsData? metricsData = null;
        AksResourceProcessor? aksResourceProcessor = null;
        string? serviceName = null;
        string? serviceNamespace = null;
        string? serviceInstance = null;
        bool? hasDefaultServiceName = null;

        if (instrumentationKey != null && resource.Attributes.Any())
        {
            metricsData = new MetricsData(Version);
        }

        foreach (var attribute in resource.Attributes)
        {
            switch (attribute.Key)
            {
                case SemanticConventions.AttributeServiceName when attribute.Value is string _serviceName:
                    serviceName = _serviceName;
                    if (serviceName.StartsWith(DefaultServiceName))
                    {
                        hasDefaultServiceName = true;
                        break;
                    }

                    hasDefaultServiceName = false;
                    break;
                case SemanticConventions.AttributeServiceNamespace when attribute.Value is string _serviceNamespace:
                    serviceNamespace = $"[{_serviceNamespace}]";
                    break;
                case SemanticConventions.AttributeServiceInstance when attribute.Value is string _serviceInstance:
                    serviceInstance = _serviceInstance;
                    break;
                case AiSdkPrefixKey when attribute.Value is string _aiSdkPrefixValue:
                    SdkVersionUtils.SdkVersionPrefix = _aiSdkPrefixValue;
                    continue;
                case TelemetryDistroNameKey when attribute.Value is string _aiSdkDistroValue:
                    if (_aiSdkDistroValue == "Azure.Monitor.OpenTelemetry.AspNetCore")
                    {
                        SdkVersionUtils.IsDistro = true;
                    }
                    break;
                default:
                    if (attribute.Key.StartsWith("k8s"))
                    {
                        aksResourceProcessor = aksResourceProcessor ?? new AksResourceProcessor();
                        aksResourceProcessor.MapAttributeToProperty(attribute);
                    }
                    break;
            }

            if (metricsData != null && attribute.Key.Length <= SchemaConstants.MetricsData_Properties_MaxKeyLength && attribute.Value != null)
            {
                // Note: if Key exceeds MaxLength or if Value is null, the entire KVP will be dropped.
                metricsData.Properties.Add(new KeyValuePair<string, string>(attribute.Key, attribute.Value.ToString().Truncate(SchemaConstants.MetricsData_Properties_MaxValueLength) ?? "null"));
            }
        }

        // TODO: Check if service.name as unknown_service should be sent.
        // (2023-07) we need to drop the "unknown_service."
        if (serviceName != null && serviceNamespace != null)
        {
            azureMonitorResource.RoleName = string.Concat(serviceNamespace, "/", serviceName);
        }
        else
        {
            azureMonitorResource.RoleName = serviceName;
        }

        try
        {
            azureMonitorResource.RoleInstance = serviceInstance ?? Dns.GetHostName();
        }
        catch (Exception ex)
        {
            AzureMonitorExporterEventSource.Log.ErrorInitializingRoleInstanceToHostName(ex);
        }

        if (aksResourceProcessor != null)
        {
            var aksRoleName = aksResourceProcessor.GetRoleName();
            var aksRoleInstanceName = aksResourceProcessor.GetRoleInstance();

            if (hasDefaultServiceName != false && aksRoleName != null)
            {
                azureMonitorResource.RoleName = aksRoleName;
            }

            if (serviceInstance == null && aksRoleInstanceName != null)
            {
                azureMonitorResource.RoleInstance = aksRoleInstanceName;
            }
        }

        bool shouldReportMetricTelemetry = false;
        try
        {
            var exportResource = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.EXPORT_RESOURCE_METRIC);
            if (exportResource != null && exportResource.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                shouldReportMetricTelemetry = true;
            }
        }
        catch
        {
        }

        if (shouldReportMetricTelemetry && metricsData != null)
        {
            azureMonitorResource.MonitorBaseData = new MonitorBase
            {
                BaseType = "MetricData",
                BaseData = metricsData
            };
        }

        return azureMonitorResource;
    }
}
