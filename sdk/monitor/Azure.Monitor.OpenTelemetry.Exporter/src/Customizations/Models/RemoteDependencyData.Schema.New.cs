// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Globalization;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models;

internal partial class RemoteDependencyData
{
    public RemoteDependencyData(int version, Activity activity, ref ActivityTagsProcessor activityTagsProcessor, string schemaVersion) : base(version)
    {
        Properties = new ChangeTrackingDictionary<string, string>();
        Measurements = new ChangeTrackingDictionary<string, double>();

        string? httpUrl = null;
        string dependencyName;

        if (activityTagsProcessor.activityType.HasFlag(OperationType.Http))
        {
            httpUrl = AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeUrlFull)?.ToString();
            dependencyName = activityTagsProcessor.MappedTags.GetNewSchemaHttpDependencyName(httpUrl) ?? activity.DisplayName;
            Data = httpUrl.Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
            Target = activityTagsProcessor.MappedTags.GetNewSchemaHttpDependencyTarget().Truncate(SchemaConstants.RemoteDependencyData_Target_MaxLength);
            Type = "Http";
            ResultCode = AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpResponseStatusCode)
                ?.ToString().Truncate(SchemaConstants.RemoteDependencyData_ResultCode_MaxLength)
                ?? "0";
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

        // TODO: Other operation types.

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
