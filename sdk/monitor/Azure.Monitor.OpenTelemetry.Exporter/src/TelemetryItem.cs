// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Azure.Core;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class TelemetryItem
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";
        private static readonly IReadOnlyDictionary<TelemetryType, string> s_telemetryItem_Name_Mapping = new Dictionary<TelemetryType, string>
        {
            [TelemetryType.Request] = "Request",
            [TelemetryType.Dependency] = "RemoteDependency",
        };

        public TelemetryItem(Activity activity, ref TagEnumerationState monitorTags)
        {
            Name = s_telemetryItem_Name_Mapping[activity.GetTelemetryType()];
            Time = FormatUtcTimestamp(activity.StartTimeUtc);
            Tags = new ChangeTrackingDictionary<string, string>();

            if (activity.ParentSpanId != default)
            {
                Tags[ContextTagKeys.AiOperationParentId.ToString()] = activity.ParentSpanId.ToHexString();
            }

            Tags[ContextTagKeys.AiOperationId.ToString()] = activity.TraceId.ToHexString();
            // todo: update swagger to include this key.
            Tags["ai.user.userAgent"] = AzMonList.GetTagValue(ref monitorTags.MappedTags, SemanticConventions.AttributeHttpUserAgent)?.ToString();

            // we only have mapping for server spans
            // todo: non-server spans
            if (activity.Kind == ActivityKind.Server)
            {
                Tags[ContextTagKeys.AiOperationName.ToString()] = TraceHelper.GetOperationName(activity, ref monitorTags.MappedTags);
                Tags[ContextTagKeys.AiLocationIp.ToString()] = TraceHelper.GetLocationIp(ref monitorTags.MappedTags);
            }

            Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.s_sdkVersion;
        }

        public TelemetryItem (LogRecord logRecord)
        {
            Name = logRecord.Exception != null ? "Exception" : "Message";
            Time = FormatUtcTimestamp(logRecord.Timestamp);
            Tags = new ChangeTrackingDictionary<string, string>();

            if (logRecord.TraceId != default)
            {
                Tags[ContextTagKeys.AiOperationId.ToString()] = logRecord.TraceId.ToHexString();
            }

            if (logRecord.SpanId != default)
            {
                Tags[ContextTagKeys.AiOperationParentId.ToString()] = logRecord.SpanId.ToHexString();
            }

            Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.s_sdkVersion;
        }

        internal void SetResource(string roleName, string roleInstance)
        {
            Tags[ContextTagKeys.AiCloudRole.ToString()] = roleName;
            Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = roleInstance;
        }

        internal static string FormatUtcTimestamp(System.DateTime utcTimestamp)
        {
            return utcTimestamp.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
        }
    }
}
