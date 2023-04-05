// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class ResourceExtensions
    {
        private const string s_AiSdkPrefixKey = "ai.sdk.prefix";

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
                switch (attribute.Key)
                {
                    case SemanticConventions.AttributeServiceName when attribute.Value is string _serviceName:
                        serviceName = _serviceName;
                        break;
                    case SemanticConventions.AttributeServiceNamespace when attribute.Value is string _serviceNamespace:
                        serviceNamespace = $"[{_serviceNamespace}]";
                        break;
                    case SemanticConventions.AttributeServiceInstance when attribute.Value is string _serviceInstance:
                        resourceParser.RoleInstance = _serviceInstance;
                        break;
                    case s_AiSdkPrefixKey:
                        SdkVersionUtils.SdkVersionPrefix = attribute.Value.ToString();
                        break;
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
