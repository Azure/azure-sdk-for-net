// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class ResourceParser
    {
        internal string RoleName { get; private set; }

        internal string RoleInstance { get; private set; }

        internal void UpdateRoleNameAndInstance(Resource resource)
        {
            if (RoleName != null || RoleInstance != null)
            {
                return;
            }

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
                    serviceNamespace = attribute.Value.ToString();
                }
                else if (attribute.Key == SemanticConventions.AttributeServiceInstance && attribute.Value is string)
                {
                    RoleInstance = attribute.Value.ToString();
                }
            }

            if (serviceName != null && serviceNamespace != null)
            {
                RoleName = string.Concat(serviceNamespace, ".", serviceName);
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
                    AzureMonitorExporterEventSource.Log.Write($"ErrorInitializingRoleInstanceToHostName{EventLevelSuffix.Error}", $"{ex.ToInvariantString()}");
                }
            }
        }
    }
}
