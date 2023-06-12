// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class ResourceExtensions
    {
        private const string s_AiSdkPrefixKey = "ai.sdk.prefix";
        private const int Version = 2;

        internal static AzureMonitorResource? CreateAzureMonitorResource(this Resource resource, string? instrumentationKey = null)
        {
            if (resource == null)
            {
                return null;
            }

            AzureMonitorResource azureMonitorResource = new AzureMonitorResource();
            MetricsData? metricsData = null;
            string? serviceName = null;
            string? serviceNamespace = null;

            if (instrumentationKey != null && resource.Attributes.Count() > 0)
            {
                metricsData = new MetricsData(Version);
            }

            foreach (var attribute in resource.Attributes)
            {
                switch (attribute.Key)
                {
                    case SemanticConventions.AttributeServiceName when attribute.Value is string _serviceName:
                        serviceName = _serviceName;
                        break;
                    case SemanticConventions.AttributeServiceNamespace when attribute.Value is string _serviceNamespace:
                        serviceNamespace = $"[{_serviceNamespace}]";
                        break;
                    case SemanticConventions.AttributeServiceInstance when attribute.Value is string _serviceInstance:
                        azureMonitorResource.RoleInstance = _serviceInstance;
                        break;
                    case s_AiSdkPrefixKey when attribute.Value is string _aiSdkPrefixValue:
                        SdkVersionUtils.SdkVersionPrefix = _aiSdkPrefixValue;
                        continue;
                }

                if (metricsData != null && attribute.Key.Length <= SchemaConstants.MetricsData_Properties_MaxKeyLength && attribute.Value != null)
                {
                    // Note: if Key exceeds MaxLength or if Value is null, the entire KVP will be dropped.
                    metricsData.Properties.Add(new KeyValuePair<string, string>(attribute.Key, attribute.Value.ToString().Truncate(SchemaConstants.MetricsData_Properties_MaxValueLength) ?? "null"));
                }
            }

            // TODO: Check if service.name as unknown_service should be sent.
            if (serviceName != null && serviceNamespace != null)
            {
                azureMonitorResource.RoleName = string.Concat(serviceNamespace, "/", serviceName);
            }
            else
            {
                azureMonitorResource.RoleName = serviceName;
            }

            if (azureMonitorResource.RoleInstance == null)
            {
                try
                {
                    azureMonitorResource.RoleInstance = Dns.GetHostName();
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.WriteError("ErrorInitializingRoleInstanceToHostName", ex);
                }
            }

            if (metricsData != null)
            {
                azureMonitorResource.MetricTelemetry = new TelemetryItem(DateTime.UtcNow, azureMonitorResource, instrumentationKey!)
                {
                    Data = new MonitorBase
                    {
                        BaseType = "MetricData",
                        BaseData = metricsData
                    }
                };
            }

            return azureMonitorResource;
        }
    }
}
