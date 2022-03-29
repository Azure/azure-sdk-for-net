// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Globalization;
using Azure.Core;
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
            Name = TraceHelper.GetOperationName(activity, ref monitorTags.MappedTags);
            Duration = activity.Duration.ToString("c", CultureInfo.InvariantCulture);
            Success = activity.GetStatus().StatusCode != StatusCode.Error;
            ResponseCode = AzMonList.GetTagValue(ref monitorTags.MappedTags, SemanticConventions.AttributeHttpStatusCode)?.ToString() ?? "0";
            Url = url;

            Properties = new ChangeTrackingDictionary<string, string>();
            Measurements = new ChangeTrackingDictionary<string, double>();

            TraceHelper.AddActivityLinksToProperties(activity.Links, ref monitorTags.UnMappedTags);
            TraceHelper.AddPropertiesToTelemetry(Properties, ref monitorTags.UnMappedTags);
        }
    }
}
