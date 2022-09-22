// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Globalization;

using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class RequestData
    {
        public RequestData(int version, Activity activity, ref TagEnumerationState monitorTags) : base(version)
        {
            string url = null;

            switch (monitorTags.activityType)
            {
                case OperationType.Http:
                    url = monitorTags.MappedTags.GetRequestUrl();
                    break;
                case OperationType.Messaging:
                    url = AzMonList.GetTagValue(ref monitorTags.MappedTags, SemanticConventions.AttributeMessagingUrl)?.ToString();
                    break;
            }

            Id = activity.Context.SpanId.ToHexString();
            Name = TraceHelper.GetOperationName(activity, ref monitorTags.MappedTags).Truncate(SchemaConstants.RequestData_Name_MaxLength);
            Duration = activity.Duration < SchemaConstants.RequestData_Duration_LessThanDays
                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                : SchemaConstants.Duration_MaxValue;
            Success = activity.Status != ActivityStatusCode.Error;
            ResponseCode = AzMonList.GetTagValue(ref monitorTags.MappedTags, SemanticConventions.AttributeHttpStatusCode)
                ?.ToString().Truncate(SchemaConstants.RequestData_ResponseCode_MaxLength)
                ?? "0";
            Url = url.Truncate(SchemaConstants.RequestData_Url_MaxLength);

            Properties = new ChangeTrackingDictionary<string, string>();
            Measurements = new ChangeTrackingDictionary<string, double>();

            TraceHelper.AddActivityLinksToProperties(activity.Links, ref monitorTags.UnMappedTags);
            TraceHelper.AddPropertiesToTelemetry(Properties, ref monitorTags.UnMappedTags);
        }
    }
}
