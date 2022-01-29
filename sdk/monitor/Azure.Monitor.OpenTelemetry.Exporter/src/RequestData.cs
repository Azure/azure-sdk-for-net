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
                case PartBType.Http:
                    url = monitorTags.PartBTags.GetRequestUrl();
                    break;
                case PartBType.Messaging:
                    url = AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeMessagingUrl)?.ToString();
                    break;
            }

            Id = activity.Context.SpanId.ToHexString();
            Name = TelemetryItem.GetOperationName(activity, ref monitorTags.PartBTags);
            Duration = activity.Duration.ToString("c", CultureInfo.InvariantCulture);
            Success = activity.GetStatus().StatusCode != StatusCode.Error;
            ResponseCode = AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeHttpStatusCode)?.ToString() ?? "0";
            Url = url;

            Properties = new ChangeTrackingDictionary<string, string>();
            Measurements = new ChangeTrackingDictionary<string, double>();

            TraceHelper.AddActivityLinksToPartCTags(activity.Links, ref monitorTags.PartCTags);
            TraceHelper.AddPropertiesToTelemetry(Properties, ref monitorTags.PartCTags);
        }
    }
}
