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
        public TelemetryItem(Activity activity, ref ActivityTagsProcessor activityTagsProcessor, AzureMonitorResource? resource, string instrumentationKey) :
            this(activity.GetTelemetryType() == TelemetryType.Request ? "Request" : "RemoteDependency", FormatUtcTimestamp(activity.StartTimeUtc))
        {
            if (activity.ParentSpanId != default)
            {
                Tags[ContextTagKeys.AiOperationParentId.ToString()] = activity.ParentSpanId.ToHexString();
            }

            Tags[ContextTagKeys.AiOperationId.ToString()] = activity.TraceId.ToHexString();

            if (activity.GetTelemetryType() == TelemetryType.Request)
            {
                if (activityTagsProcessor.activityType.HasFlag(OperationType.V2))
                {
                    Tags[ContextTagKeys.AiOperationName.ToString()] = TraceHelper.GetOperationNameV2(activity, ref activityTagsProcessor.MappedTags);
                }
                else if (activityTagsProcessor.activityType.HasFlag(OperationType.Http))
                {
                    Tags[ContextTagKeys.AiOperationName.ToString()] = TraceHelper.GetOperationName(activity, ref activityTagsProcessor.MappedTags);
                }
                else
                {
                    Tags[ContextTagKeys.AiOperationName.ToString()] = activity.DisplayName;
                }

                // Set ip in case of server spans only.
                if (activity.Kind == ActivityKind.Server)
                {
                    var locationIp = TraceHelper.GetLocationIp(ref activityTagsProcessor.MappedTags);
                    if (locationIp != null)
                    {
                        Tags[ContextTagKeys.AiLocationIp.ToString()] = locationIp;
                    }
                }
            }

            var userAgent = AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeUserAgentOriginal)?.ToString()
                ?? AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpUserAgent)?.ToString();

            if (userAgent != null)
            {
                // todo: update swagger to include this key.
                Tags["ai.user.userAgent"] = userAgent;
            }

            SetAuthenticatedUserId(ref activityTagsProcessor);
            SetResourceSdkVersionAndIkey(resource, instrumentationKey);
            if (AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, "sampleRate") is float sampleRate)
            {
                SampleRate = sampleRate;
            }
        }

        public TelemetryItem(string name, TelemetryItem telemetryItem, ActivitySpanId activitySpanId, ActivityKind kind, DateTimeOffset activityEventTimeStamp) :
                        this(name, FormatUtcTimestamp(activityEventTimeStamp.DateTime))
        {
            Tags[ContextTagKeys.AiOperationParentId.ToString()] = activitySpanId.ToHexString();
            Tags[ContextTagKeys.AiOperationId.ToString()] = telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()];

            if (telemetryItem.Tags.TryGetValue("ai.user.userAgent", out string? userAgent))
            {
                // todo: update swagger to include this key.
                Tags["ai.user.userAgent"] = userAgent;
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetAuthenticatedUserId(ref ActivityTagsProcessor activityTagsProcessor)
        {
            if (activityTagsProcessor.EndUserId != null)
            {
                Tags[ContextTagKeys.AiUserAuthUserId.ToString()] = activityTagsProcessor.EndUserId;
            }
        }
    }
}
