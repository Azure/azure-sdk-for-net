// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class TelemetryItem
    {
        public TelemetryItem(Activity activity, ref TagEnumerationState monitorTags, AzureMonitorResource? resource, string instrumentationKey) :
            this(activity.GetTelemetryType() == TelemetryType.Request ? "Request" : "RemoteDependency", FormatUtcTimestamp(activity.StartTimeUtc))
        {
            if (activity.ParentSpanId != default)
            {
                Tags[ContextTagKeys.AiOperationParentId.ToString()] = activity.ParentSpanId.ToHexString();
            }

            Tags[ContextTagKeys.AiOperationId.ToString()] = activity.TraceId.ToHexString();

            var userAgent = AzMonList.GetTagValue(ref monitorTags.MappedTags, SemanticConventions.AttributeHttpUserAgent)?.ToString();

            if (userAgent != null)
            {
                // todo: update swagger to include this key.
                Tags["ai.user.userAgent"] = userAgent;
            }

            // we only have mapping for server spans
            // todo: non-server spans
            if (activity.Kind == ActivityKind.Server)
            {
                Tags[ContextTagKeys.AiOperationName.ToString()] = TraceHelper.GetOperationName(activity, ref monitorTags.MappedTags);
                Tags[ContextTagKeys.AiLocationIp.ToString()] = TraceHelper.GetLocationIp(ref monitorTags.MappedTags);
            }

            SetResourceSdkVersionAndIkey(resource, instrumentationKey);
            if (AzMonList.GetTagValue(ref monitorTags.MappedTags, "sampleRate") is float sampleRate)
            {
                SampleRate = sampleRate;
            }
        }

        public TelemetryItem(string name, TelemetryItem telemetryItem, ActivitySpanId activitySpanId, ActivityKind kind, DateTimeOffset activityEventTimeStamp) :
                        this(name, FormatUtcTimestamp(activityEventTimeStamp.DateTime))
        {
            Tags[ContextTagKeys.AiOperationParentId.ToString()] = activitySpanId.ToHexString();
            Tags[ContextTagKeys.AiOperationId.ToString()] = telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()];

            if (telemetryItem.Tags.TryGetValue("ai.user.userAgent", out string userAgent))
            {
                // todo: update swagger to include this key.
                Tags["ai.user.userAgent"] = userAgent;
            }

            // we only have mapping for server spans
            // todo: non-server spans
            if (kind == ActivityKind.Server)
            {
                Tags[ContextTagKeys.AiOperationName.ToString()] = telemetryItem.Tags[ContextTagKeys.AiOperationName.ToString()];
                Tags[ContextTagKeys.AiLocationIp.ToString()] = telemetryItem.Tags[ContextTagKeys.AiLocationIp.ToString()];
            }

            Tags[ContextTagKeys.AiCloudRole.ToString()] = telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()];
            Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()];
            Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.s_sdkVersion;
            InstrumentationKey = telemetryItem.InstrumentationKey;
            SampleRate = telemetryItem.SampleRate;
        }

        public TelemetryItem (LogRecord logRecord, AzureMonitorResource? resource, string instrumentationKey) :
            this(logRecord.Exception != null ? "Exception" : "Message", FormatUtcTimestamp(logRecord.Timestamp))
        {
            if (logRecord.TraceId != default)
            {
                Tags[ContextTagKeys.AiOperationId.ToString()] = logRecord.TraceId.ToHexString();
            }

            if (logRecord.SpanId != default)
            {
                Tags[ContextTagKeys.AiOperationParentId.ToString()] = logRecord.SpanId.ToHexString();
            }

            InstrumentationKey = instrumentationKey;
            SetResourceSdkVersionAndIkey(resource, instrumentationKey);
        }

        public TelemetryItem(DateTime time, AzureMonitorResource? resource, string instrumentationKey) : this("Metric", FormatUtcTimestamp(time))
        {
            SetResourceSdkVersionAndIkey(resource, instrumentationKey);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetResourceSdkVersionAndIkey(AzureMonitorResource? resource, string instrumentationKey)
        {
            InstrumentationKey = instrumentationKey;
            Tags[ContextTagKeys.AiCloudRole.ToString()] = resource?.RoleName;
            Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = resource?.RoleInstance;
            Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.s_sdkVersion;
        }

        internal static DateTimeOffset FormatUtcTimestamp(System.DateTime utcTimestamp)
        {
            return DateTime.SpecifyKind(utcTimestamp, DateTimeKind.Utc);
        }
    }
}
