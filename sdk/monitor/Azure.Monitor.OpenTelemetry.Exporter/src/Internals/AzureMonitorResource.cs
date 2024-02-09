// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class AzureMonitorResource
    {
        internal string? RoleName { get; set; }

        internal string? RoleInstance { get; set; }

        internal MonitorBase? MonitorBaseData { get; set; }

        internal List<KeyValuePair<string, object>> UserDefinedAttributes { get; set; } = new();

        internal void CopyUserDefinedAttributes(
            IDictionary<string, string> properties)
        {
            foreach (var userDefinedTag in UserDefinedAttributes)
            {
                // Note: if Key exceeds MaxLength or if Value is null, the entire KVP will be dropped.
                if (userDefinedTag.Key.Length <= SchemaConstants.MessageData_Properties_MaxKeyLength)
                {
                    var value = userDefinedTag.Value?.ToString();

                    if (value is null)
                    {
                        continue;
                    }

                    properties.Add(userDefinedTag.Key, value);
                }
            }
        }
    }
}
