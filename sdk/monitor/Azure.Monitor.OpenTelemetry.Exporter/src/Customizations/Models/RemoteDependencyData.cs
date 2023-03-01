// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class RemoteDependencyData
    {
        // https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/semantic_conventions/database.md#connection-level-attributes
        internal static readonly HashSet<string> s_sqlDbs = new HashSet<string>() { "mssql" };

        public RemoteDependencyData(int version, Activity activity, ref TagEnumerationState monitorTags) : base(version)
        {
            string httpUrl = null;
            string dependencyName;

            if (monitorTags.activityType == OperationType.Http)
            {
                httpUrl = monitorTags.MappedTags.GetDependencyUrl();
                dependencyName = monitorTags.MappedTags.GetHttpDependencyName(httpUrl) ?? activity.DisplayName;
            }
            else
            {
                dependencyName = activity.DisplayName;
            }

            Name = dependencyName.Truncate(SchemaConstants.RemoteDependencyData_Name_MaxLength);
            Id = activity.Context.SpanId.ToHexString();
            Duration = activity.Duration < SchemaConstants.RemoteDependencyData_Duration_LessThanDays
                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                : SchemaConstants.Duration_MaxValue;
            Success = activity.Status != ActivityStatusCode.Error;

            switch (monitorTags.activityType)
            {
                case OperationType.Http:
                    Data = httpUrl.Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
                    Target = monitorTags.MappedTags.GetHttpDependencyTarget().Truncate(SchemaConstants.RemoteDependencyData_Target_MaxLength);
                    Type = "Http";
                    ResultCode = AzMonList.GetTagValue(ref monitorTags.MappedTags, SemanticConventions.AttributeHttpStatusCode)
                        ?.ToString().Truncate(SchemaConstants.RemoteDependencyData_ResultCode_MaxLength)
                        ?? "0";
                    break;
                case OperationType.Db:
                    var depDataAndType = AzMonList.GetTagValues(ref monitorTags.MappedTags, SemanticConventions.AttributeDbStatement, SemanticConventions.AttributeDbSystem);
                    Data = depDataAndType[0]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
                    Target = monitorTags.MappedTags.GetDbDependencyTarget().Truncate(SchemaConstants.RemoteDependencyData_Target_MaxLength);
                    Type = s_sqlDbs.Contains(depDataAndType[1]?.ToString()) ? "SQL" : depDataAndType[1]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Type_MaxLength);
                    break;
                case OperationType.Rpc:
                    var depInfo = AzMonList.GetTagValues(ref monitorTags.MappedTags, SemanticConventions.AttributeRpcService, SemanticConventions.AttributeRpcSystem, SemanticConventions.AttributeRpcStatus);
                    Data = depInfo[0]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
                    Type = depInfo[1]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Type_MaxLength);
                    ResultCode = depInfo[2]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_ResultCode_MaxLength);
                    break;
                case OperationType.Messaging:
                    depDataAndType = AzMonList.GetTagValues(ref monitorTags.MappedTags, SemanticConventions.AttributeMessagingUrl, SemanticConventions.AttributeMessagingSystem);
                    Data = depDataAndType[0]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
                    Type = depDataAndType[1]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Type_MaxLength);
                    break;
            }

            if (activity.Kind == ActivityKind.Internal && activity.Parent != null)
            {
                Type = "InProc";
            }

            Properties = new ChangeTrackingDictionary<string, string>();
            Measurements = new ChangeTrackingDictionary<string, double>();

            TraceHelper.AddActivityLinksToProperties(activity, ref monitorTags.UnMappedTags);
            TraceHelper.AddPropertiesToTelemetry(Properties, ref monitorTags.UnMappedTags);
        }
    }
}
