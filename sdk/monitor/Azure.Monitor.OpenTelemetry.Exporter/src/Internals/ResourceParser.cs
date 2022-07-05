// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class ResourceParser
    {
        internal string RoleName { get; private set; }

        internal string RoleInstance { get; private set; }

        internal void UpdateRoleNameAndInstance(Resource resource)
        {
            if (resource == null)
            {
                return;
            }

            string serviceName = null;
            string serviceNamespace = null;

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
                    RoleInstance = attribute.Value.ToString();
                }
            }

            // TODO: Check if service.name as unknown_service should be sent.
            if (serviceName != null && serviceNamespace != null)
            {
                RoleName = string.Concat(serviceNamespace, "/", serviceName);
            }
            else
            {
                RoleName = serviceName;
            }

            if (RoleInstance == null)
            {
                try
                {
                    RoleInstance = Dns.GetHostName();
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.WriteError("ErrorInitializingRoleInstanceToHostName", ex);
                }
            }

            // Race condition is not taken in to account here
            // If the exporters have different resources
            // only one of them will be used.
            // Also, no statsbeat can be sent before the first export
            // as the resource is initialized at that time.
            // This will cause Statsbeat static constructor to be executed
            // which may fail if the options are not properly configured for exporter
            try
            {
                if (StatsBeat.s_roleName == null && StatsBeat.s_roleInstance == null)
                {
                    StatsBeat.s_roleInstance = RoleInstance;
                    StatsBeat.s_roleName = RoleName;
                }
            }
            catch (Exception)
            {
                // ignore?
            }
        }
    }
}
