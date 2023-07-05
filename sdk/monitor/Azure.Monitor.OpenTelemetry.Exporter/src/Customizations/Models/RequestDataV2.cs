// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Globalization;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class RequestData
    {
        public RequestData(int version, Activity activity, ref ActivityTagsProcessor activityTagsProcessor, string schemaVersion) : base(version)
        {
            string? url = null;

            if (activityTagsProcessor.activityType.HasFlag(OperationType.Http))
            {
                url = activityTagsProcessor.MappedTags.GetV2RequestUrl();
            }

            Id = activity.Context.SpanId.ToHexString();
            Name = TraceHelper.GetV2OperationName(activity, url, ref activityTagsProcessor.MappedTags).Truncate(SchemaConstants.RequestData_Name_MaxLength);
            Duration = activity.Duration < SchemaConstants.RequestData_Duration_LessThanDays
                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                : SchemaConstants.Duration_MaxValue;
            ResponseCode = AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpResponseStatusCode)
                ?.ToString().Truncate(SchemaConstants.RequestData_ResponseCode_MaxLength)
                ?? "0";

            Success = IsSuccess(activity, ResponseCode, activityTagsProcessor.activityType);

            Url = url.Truncate(SchemaConstants.RequestData_Url_MaxLength);
            Properties = new ChangeTrackingDictionary<string, string>();
            Measurements = new ChangeTrackingDictionary<string, double>();

            if (activity.Kind == ActivityKind.Consumer)
            {
                TraceHelper.AddEnqueuedTimeToMeasurementsAndLinksToProperties(activity, Measurements, ref activityTagsProcessor.UnMappedTags);
            }
            else
            {
                TraceHelper.AddActivityLinksToProperties(activity, ref activityTagsProcessor.UnMappedTags);
            }

            TraceHelper.AddPropertiesToTelemetry(Properties, ref activityTagsProcessor.UnMappedTags);
        }
    }
}
