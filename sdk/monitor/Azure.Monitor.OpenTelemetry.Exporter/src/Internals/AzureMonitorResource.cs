// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class AzureMonitorResource
    {
        public AzureMonitorResource()
        {
        }

        public AzureMonitorResource(
            string? roleName,
            string? roleInstance,
            string? serviceVersion,
            MonitorBase? monitorBaseData)
        {
            RoleName = roleName;
            RoleName_Truncated = roleName.Truncate(SchemaConstants.Tags_AiCloudRole_MaxLength);
            RoleInstance = roleInstance;
            RoleInstance_Truncated = roleInstance.Truncate(SchemaConstants.Tags_AiCloudRoleInstance_MaxLength);
            ServiceVersion_Truncated = serviceVersion.Truncate(SchemaConstants.Tags_AiApplicationVer_MaxLength);
            MonitorBaseData = monitorBaseData;
        }

        internal string? RoleName { get; }
        internal string? RoleName_Truncated { get; }

        internal string? RoleInstance { get; }
        internal string? RoleInstance_Truncated { get; }

        internal string? ServiceVersion_Truncated { get; }

        internal MonitorBase? MonitorBaseData { get; }
    }
}
