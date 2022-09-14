// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class TelemetryItem
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";

        public TelemetryItem(string name, Activity activity, ref TagEnumerationState monitorTags, string roleName, string roleInstance, string instrumentationKey) :
            this(name, FormatUtcTimestamp(activity.StartTimeUtc))
        {
            // TODO: Move "Exception" to const/enum.
            if (name == "Exception")
            {
                Tags[ContextTagKeys.AiOperationParentId.ToString()] = activity.SpanId.ToHexString();
            }
            else if (activity.ParentSpanId != default)
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

            SetResourceSdkVersionAndIkey(roleName, roleInstance, instrumentationKey);
        }

        public TelemetryItem (LogRecord logRecord, string roleName, string roleInstance, string instrumentationKey) :
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
            SetResourceSdkVersionAndIkey(roleName, roleInstance, instrumentationKey);
        }

        public TelemetryItem(DateTime time, string roleName, string roleInstance, string instrumentationKey) : this("Metric", FormatUtcTimestamp(time))
        {
            SetResourceSdkVersionAndIkey(roleName, roleInstance, instrumentationKey);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetResourceSdkVersionAndIkey(string roleName, string roleInstance, string instrumentationKey)
        {
            InstrumentationKey = instrumentationKey;
            Tags[ContextTagKeys.AiCloudRole.ToString()] = roleName;
            Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = roleInstance;
            Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.s_sdkVersion;
        }

        internal static string FormatUtcTimestamp(System.DateTime utcTimestamp)
        {
            return utcTimestamp.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
        }
    }
}
