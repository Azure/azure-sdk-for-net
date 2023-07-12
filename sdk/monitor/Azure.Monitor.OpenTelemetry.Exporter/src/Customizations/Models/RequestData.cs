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
        public RequestData(int version, Activity activity, ref ActivityTagsProcessor activityTagsProcessor) : base(version)
        {
            string? responseCode = null;
            Properties = new ChangeTrackingDictionary<string, string>();
            Measurements = new ChangeTrackingDictionary<string, double>();

            switch (activityTagsProcessor.activityType)
            {
                case OperationType.Http | OperationType.V2:
                    SetHttpV2RequestPropertiesAndResponseCode(activity, ref activityTagsProcessor.MappedTags, out responseCode);
                    break;
                case OperationType.Http:
                    SetHttpRequestPropertiesAndResponseCode(activity, ref activityTagsProcessor.MappedTags, out responseCode);
                    break;
                case OperationType.Messaging:
                    SetMessagingRequestProperties(activity, ref activityTagsProcessor.MappedTags);
                    break;
            }

            Id = activity.Context.SpanId.ToHexString();
            Name = Name ?? activity.DisplayName;
            Duration = activity.Duration < SchemaConstants.RequestData_Duration_LessThanDays
                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                : SchemaConstants.Duration_MaxValue;
            ResponseCode = responseCode ?? "0";

            Success = IsSuccess(activity, ResponseCode, activityTagsProcessor.activityType);

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

        internal static bool IsSuccess(Activity activity, string? responseCode, OperationType operationType)
        {
            if (operationType.HasFlag(OperationType.Http)
                && responseCode != null
                && int.TryParse(responseCode, out int statusCode))
            {
                bool isSuccessStatusCode = statusCode != 0 && statusCode < 400;
                return activity.Status != ActivityStatusCode.Error && isSuccessStatusCode;
            }
            else
            {
                return activity.Status != ActivityStatusCode.Error;
            }
        }

        private void SetHttpRequestPropertiesAndResponseCode(Activity activity, ref AzMonList httpTagObjects, out string responseCode)
        {
            Url = httpTagObjects.GetRequestUrl().Truncate(SchemaConstants.RequestData_Url_MaxLength);
            Name = TraceHelper.GetOperationName(activity, ref httpTagObjects).Truncate(SchemaConstants.RequestData_Name_MaxLength);
            responseCode = AzMonList.GetTagValue(ref httpTagObjects, SemanticConventions.AttributeHttpStatusCode)
                                                ?.ToString().Truncate(SchemaConstants.RequestData_ResponseCode_MaxLength)
                                                ?? "0";
        }

        private void SetHttpV2RequestPropertiesAndResponseCode(Activity activity, ref AzMonList httpTagObjects, out string responseCode)
        {
            Url = httpTagObjects.GetNewSchemaRequestUrl().Truncate(SchemaConstants.RequestData_Url_MaxLength);
            Name = TraceHelper.GetNewSchemaOperationName(activity, Url, ref httpTagObjects).Truncate(SchemaConstants.RequestData_Name_MaxLength);
            responseCode = AzMonList.GetTagValue(ref httpTagObjects, SemanticConventions.AttributeHttpResponseStatusCode)
                                    ?.ToString().Truncate(SchemaConstants.RequestData_ResponseCode_MaxLength)
                                    ?? "0";
        }

        private void SetMessagingRequestProperties(Activity activity, ref AzMonList messagingTagObjects)
        {
            Url = AzMonList.GetTagValue(ref messagingTagObjects, SemanticConventions.AttributeMessagingUrl)?.ToString().Truncate(SchemaConstants.RequestData_Url_MaxLength);
            Name = activity.DisplayName;
        }
    }
}
