// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;

internal static class ResourceExtensions
{
    private const string DefaultServiceName = "unknown_service";

    internal static LiveMetricsResource? CreateAzureMonitorResource(this Resource resource, string? instrumentationKey = null)
    {
        if (resource == null)
        {
            return null;
        }

        LiveMetricsResource azureMonitorResource = new();
        AksResourceProcessor? aksResourceProcessor = null;
        string? serviceName = null;
        string? serviceNamespace = null;
        string? serviceInstance = null;
        bool? hasDefaultServiceName = null;

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
                default:
                    if (attribute.Key.StartsWith("k8s"))
                    {
                        aksResourceProcessor = aksResourceProcessor ?? new AksResourceProcessor();
                        aksResourceProcessor.MapAttributeToProperty(attribute);
                    }
                    break;
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
        catch (Exception)
        {
            // AzureMonitorExporterEventSource.Log.ErrorInitializingRoleInstanceToHostName(ex);
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

        return azureMonitorResource;
    }
}
