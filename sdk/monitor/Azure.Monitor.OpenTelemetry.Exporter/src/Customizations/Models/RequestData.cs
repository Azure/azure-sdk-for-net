// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System.Diagnostics;
using System.Globalization;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

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
            ResponseCode = AzMonList.GetTagValue(ref monitorTags.MappedTags, SemanticConventions.AttributeHttpStatusCode)
                ?.ToString().Truncate(SchemaConstants.RequestData_ResponseCode_MaxLength)
                ?? "0";

            Success = isSuccess(activity, ResponseCode, monitorTags.activityType);

            Url = url.Truncate(SchemaConstants.RequestData_Url_MaxLength);
            Properties = new ChangeTrackingDictionary<string, string>();
            Measurements = new ChangeTrackingDictionary<string, double>();

            TraceHelper.AddActivityLinksToProperties(activity, ref monitorTags.UnMappedTags);
            TraceHelper.AddPropertiesToTelemetry(Properties, ref monitorTags.UnMappedTags);
        }

        internal static bool isSuccess(Activity activity, string responseCode, OperationType operationType)
        {
            if (operationType == OperationType.Http && int.TryParse(responseCode, out int statusCode))
            {
                bool isSuccessStatusCode = statusCode != 0 && statusCode < 400;
                return activity.Status != ActivityStatusCode.Error && isSuccessStatusCode;
            }
            else
            {
                return activity.Status != ActivityStatusCode.Error;
            }
        }
    }
}
