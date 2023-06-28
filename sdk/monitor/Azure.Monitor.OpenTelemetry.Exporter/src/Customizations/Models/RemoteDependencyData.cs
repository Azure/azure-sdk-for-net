// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class RemoteDependencyData
    {
        // https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/semantic_conventions/database.md#connection-level-attributes
        internal static readonly HashSet<string?> s_sqlDbs = new HashSet<string?>() { "mssql" };

        public RemoteDependencyData(int version, Activity activity, ref ActivityTagsProcessor activityTagsProcessor) : base(version)
        {
            Properties = new ChangeTrackingDictionary<string, string>();
            Measurements = new ChangeTrackingDictionary<string, double>();

            string? httpUrl = null;
            string dependencyName;

            if (activityTagsProcessor.activityType == OperationType.Http)
            {
                httpUrl = activityTagsProcessor.MappedTags.GetDependencyUrl();
                dependencyName = activityTagsProcessor.MappedTags.GetHttpDependencyName(httpUrl) ?? activity.DisplayName;
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

            switch (activityTagsProcessor.activityType)
            {
                case OperationType.Http:
                    Data = httpUrl.Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
                    Target = activityTagsProcessor.MappedTags.GetHttpDependencyTarget().Truncate(SchemaConstants.RemoteDependencyData_Target_MaxLength);
                    Type = "Http";
                    ResultCode = AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpStatusCode)
                        ?.ToString().Truncate(SchemaConstants.RemoteDependencyData_ResultCode_MaxLength)
                        ?? "0";
                    break;
                case OperationType.Db:
                    var depDataAndType = AzMonList.GetTagValues(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeDbStatement, SemanticConventions.AttributeDbSystem);
                    Data = depDataAndType[0]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
                    var dbNameAndTarget = activityTagsProcessor.MappedTags.GetDbDependencyTargetAndName();
                    Target = dbNameAndTarget.DbTarget.Truncate(SchemaConstants.RemoteDependencyData_Target_MaxLength);

                    // special case for db.name
                    var sanitizedDbName = dbNameAndTarget.DbName.Truncate(SchemaConstants.KVP_MaxValueLength);
                    if (sanitizedDbName != null)
                    {
                        Properties.Add(SemanticConventions.AttributeDbName, sanitizedDbName);
                    }
                    Type = s_sqlDbs.Contains(depDataAndType[1]?.ToString()) ? "SQL" : depDataAndType[1]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Type_MaxLength);
                    break;
                case OperationType.Rpc:
                    var depInfo = AzMonList.GetTagValues(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeRpcService, SemanticConventions.AttributeRpcSystem, SemanticConventions.AttributeRpcStatus);
                    Data = depInfo[0]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
                    Type = depInfo[1]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Type_MaxLength);
                    ResultCode = depInfo[2]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_ResultCode_MaxLength);
                    break;
                case OperationType.Messaging:
                    depDataAndType = AzMonList.GetTagValues(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeMessagingUrl, SemanticConventions.AttributeMessagingSystem);
                    Data = depDataAndType[0]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
                    Type = depDataAndType[1]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Type_MaxLength);
                    break;
            }

            if (activityTagsProcessor.AzureNamespace != null)
            {
                if (activity.Kind == ActivityKind.Internal)
                {
                    Type = $"InProc | {activityTagsProcessor.AzureNamespace}";
                }
                else if (activity.Kind == ActivityKind.Producer)
                {
                    Type = $"Queue Message | {activityTagsProcessor.AzureNamespace}";
                }
                else
                {
                    // The Azure SDK sets az.namespace with its resource provider information.
                    // When ActivityKind is not internal and az.namespace is present, set the value of Type to az.namespace.
                    Type = activityTagsProcessor.AzureNamespace ?? Type;
                }
            }
            else if (activity.Kind == ActivityKind.Internal)
            {
                Type = "InProc";
            }

            TraceHelper.AddActivityLinksToProperties(activity, ref activityTagsProcessor.UnMappedTags);
            TraceHelper.AddPropertiesToTelemetry(Properties, ref activityTagsProcessor.UnMappedTags);
        }
    }
}
