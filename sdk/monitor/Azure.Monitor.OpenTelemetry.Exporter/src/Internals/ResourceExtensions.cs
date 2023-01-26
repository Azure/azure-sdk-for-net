// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class ResourceExtensions
    {
        internal static AzureMonitorResource? UpdateRoleNameAndInstance(this Resource resource)
        {
            if (resource == null)
            {
                return null;
            }

            AzureMonitorResource resourceParser = new AzureMonitorResource();
            string? serviceName = null;
            string? serviceNamespace = null;

            foreach (var attribute in resource.Attributes)
            {
                if (attribute.Key == SemanticConventions.AttributeServiceName && attribute.Value is string)
                {
                    serviceName = attribute.Value.ToString();
                }
                else if (attribute.Key == SemanticConventions.AttributeServiceNamespace && attribute.Value is string)
                {
                    serviceNamespace = "[" + attribute.Value.ToString() + "]";
                }
                else if (attribute.Key == SemanticConventions.AttributeServiceInstance && attribute.Value is string)
                {
                    resourceParser.RoleInstance = attribute.Value.ToString();
                }
            }

            // TODO: Check if service.name as unknown_service should be sent.
            if (serviceName != null && serviceNamespace != null)
            {
                resourceParser.RoleName = string.Concat(serviceNamespace, "/", serviceName);
            }
            else
            {
                resourceParser.RoleName = serviceName;
            }

            if (resourceParser.RoleInstance == null)
            {
                try
                {
                    resourceParser.RoleInstance = Dns.GetHostName();
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.WriteError("ErrorInitializingRoleInstanceToHostName", ex);
                }
            }

            return resourceParser;
        }
    }
}
