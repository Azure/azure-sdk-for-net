// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;

using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class TelemetryItem
    {
        private static volatile string? s_cloudRoleNameOverride;
        private static volatile string? s_cloudRoleInstanceOverride;
        private static volatile string? s_componentVersionOverride;

        public TelemetryItem(Activity activity, ref ActivityTagsProcessor activityTagsProcessor, AzureMonitorResource? resource, string instrumentationKey, float sampleRate) :
            this(activity.GetTelemetryType() == TelemetryType.Request ? "Request" : "RemoteDependency", FormatUtcTimestamp(activity.StartTimeUtc))
        {
            if (activity.ParentSpanId != default)
            {
                Tags[ContextTagKeys.AiOperationParentId.ToString()] = activity.ParentSpanId.ToHexString();
            }

            Tags[ContextTagKeys.AiOperationId.ToString()] = activity.TraceId.ToHexString();

            string? microsoftClientIp = AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeMicrosoftClientIp)?.ToString();

            // Check for microsoft.operation_name override (applies to both request and dependency)
            string? overrideOperationName = activityTagsProcessor.HasOverrideAttributes
                ? AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeMicrosoftOperationName)?.ToString()
                : null;

            if (activity.GetTelemetryType() == TelemetryType.Request)
            {
                if (!string.IsNullOrEmpty(overrideOperationName))
                {
                    Tags[ContextTagKeys.AiOperationName.ToString()] = overrideOperationName.Truncate(SchemaConstants.Tags_AiOperationName_MaxLength);
                }
                else if (activityTagsProcessor.activityType.HasFlag(OperationType.V2))
                {
                    Tags[ContextTagKeys.AiOperationName.ToString()] = TraceHelper.GetOperationNameV2(activity, ref activityTagsProcessor.MappedTags).Truncate(SchemaConstants.Tags_AiOperationName_MaxLength);
                }
                else if (activityTagsProcessor.activityType.HasFlag(OperationType.Http))
                {
                    Tags[ContextTagKeys.AiOperationName.ToString()] = TraceHelper.GetOperationName(activity, ref activityTagsProcessor.MappedTags).Truncate(SchemaConstants.Tags_AiOperationName_MaxLength);
                }
                else
                {
                    Tags[ContextTagKeys.AiOperationName.ToString()] = activity.DisplayName.Truncate(SchemaConstants.Tags_AiOperationName_MaxLength);
                }

                if (activity.Kind == ActivityKind.Server)
                {
                    var locationIp = microsoftClientIp ??
                                     AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeClientAddress)?.ToString();

                    if (locationIp != null)
                    {
                        Tags[ContextTagKeys.AiLocationIp.ToString()] = locationIp;
                    }
                }
            }
            else // dependency
            {
                if (!string.IsNullOrEmpty(overrideOperationName))
                {
                    Tags[ContextTagKeys.AiOperationName.ToString()] = overrideOperationName.Truncate(SchemaConstants.Tags_AiOperationName_MaxLength);
                }

                if (microsoftClientIp != null)
                {
                    Tags[ContextTagKeys.AiLocationIp.ToString()] = microsoftClientIp;
                }
            }

            var userAgent = AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeUserAgentOriginal)?.ToString()
                ?? AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpUserAgent)?.ToString();

            if (userAgent != null)
            {
                // todo: update swagger to include this key.
                Tags["ai.user.userAgent"] = userAgent;
            }

            SetUserIdAndAuthenticatedUserId(ref activityTagsProcessor);

            if (activityTagsProcessor.HasOverrideAttributes)
            {
                SetOverrideContextTags(ref activityTagsProcessor);
            }

            SetResourceSdkVersionAndIkey(resource, instrumentationKey);

            if (sampleRate != 100f)
            {
                SampleRate = sampleRate;
            }
        }

        public TelemetryItem(string name, TelemetryItem telemetryItem, ActivitySpanId activitySpanId, ActivityKind kind, DateTimeOffset activityEventTimeStamp) :
                        this(name, FormatUtcTimestamp(activityEventTimeStamp.DateTime))
        {
            Tags[ContextTagKeys.AiOperationParentId.ToString()] = activitySpanId.ToHexString();
            Tags[ContextTagKeys.AiOperationId.ToString()] = telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()];

            // Copy user agent from the parent TelemetryItem created by the Activity constructor,
            // where it was set from ActivityTagsProcessor.MappedTags.
            if (telemetryItem.Tags.TryGetValue("ai.user.userAgent", out string? userAgent))
            {
                // todo: update swagger to include this key.
                Tags["ai.user.userAgent"] = userAgent;
            }

            Tags[ContextTagKeys.AiCloudRole.ToString()] = telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()].Truncate(SchemaConstants.Tags_AiCloudRole_MaxLength);
            Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()].Truncate(SchemaConstants.Tags_AiCloudRoleInstance_MaxLength);
            Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.s_sdkVersion.Truncate(SchemaConstants.Tags_AiInternalSdkVersion_MaxLength);
            Tags[ContextTagKeys.AiApplicationVer.ToString()] = telemetryItem.Tags[ContextTagKeys.AiApplicationVer.ToString()].Truncate(SchemaConstants.Tags_AiApplicationVer_MaxLength);
            CopyTagIfPresent(telemetryItem, ContextTagKeys.AiSessionId.ToString());
            CopyTagIfPresent(telemetryItem, ContextTagKeys.AiDeviceId.ToString());
            CopyTagIfPresent(telemetryItem, ContextTagKeys.AiDeviceModel.ToString());
            CopyTagIfPresent(telemetryItem, ContextTagKeys.AiDeviceType.ToString());
            CopyTagIfPresent(telemetryItem, ContextTagKeys.AiDeviceOSVersion.ToString());
            CopyTagIfPresent(telemetryItem, ContextTagKeys.AiOperationSyntheticSource.ToString());
            CopyTagIfPresent(telemetryItem, ContextTagKeys.AiUserAccountId.ToString());
            InstrumentationKey = telemetryItem.InstrumentationKey;

            if (telemetryItem.SampleRate != 100f)
            {
                SampleRate = telemetryItem.SampleRate;
            }
        }

        public TelemetryItem (string name, LogRecord logRecord, AzureMonitorResource? resource, string instrumentationKey, LogContextInfo logContext) :
            this(name, FormatUtcTimestamp(logRecord.Timestamp), logRecord, resource, instrumentationKey, logContext)
        {
        }

        public TelemetryItem(string name, DateTimeOffset envelopeTime, LogRecord logRecord, AzureMonitorResource? resource, string instrumentationKey, LogContextInfo logContext) :
            this(name, envelopeTime)
        {
            if (logRecord.TraceId != default)
            {
                Tags[ContextTagKeys.AiOperationId.ToString()] = logRecord.TraceId.ToHexString();
            }

            if (logRecord.SpanId != default)
            {
                Tags[ContextTagKeys.AiOperationParentId.ToString()] = logRecord.SpanId.ToHexString();
            }

            if (logContext.HasValues)
            {
                if (logContext.MicrosoftClientIp != null)
                {
                    Tags[ContextTagKeys.AiLocationIp.ToString()] = logContext.MicrosoftClientIp;
                }

                if (logContext.EndUserPseudoId != null)
                {
                    Tags[ContextTagKeys.AiUserId.ToString()] = logContext.EndUserPseudoId.Truncate(SchemaConstants.Tags_AiUserId_MaxLength);
                }

                if (logContext.EndUserId != null)
                {
                    Tags[ContextTagKeys.AiUserAuthUserId.ToString()] = logContext.EndUserId.Truncate(SchemaConstants.Tags_AiUserAuthUserId_MaxLength);
                }

                if (logContext.UserAgent != null)
                {
                    // todo: update swagger to include this key.
                    Tags["ai.user.userAgent"] = logContext.UserAgent;
                }

                if (logContext.OperationName != null)
                {
                    Tags[ContextTagKeys.AiOperationName.ToString()] = logContext.OperationName.Truncate(SchemaConstants.Tags_AiOperationName_MaxLength);
                }

                if (logContext.SessionId != null)
                {
                    Tags[ContextTagKeys.AiSessionId.ToString()] = logContext.SessionId.Truncate(SchemaConstants.Tags_AiSessionId_MaxLength);
                }

                if (logContext.DeviceId != null)
                {
                    Tags[ContextTagKeys.AiDeviceId.ToString()] = logContext.DeviceId.Truncate(SchemaConstants.Tags_AiDeviceId_MaxLength);
                }

                if (logContext.DeviceModel != null)
                {
                    Tags[ContextTagKeys.AiDeviceModel.ToString()] = logContext.DeviceModel.Truncate(SchemaConstants.Tags_AiDeviceModel_MaxLength);
                }

                if (logContext.DeviceType != null)
                {
                    Tags[ContextTagKeys.AiDeviceType.ToString()] = logContext.DeviceType.Truncate(SchemaConstants.Tags_AiDeviceType_MaxLength);
                }

                if (logContext.DeviceOsVersion != null)
                {
                    Tags[ContextTagKeys.AiDeviceOSVersion.ToString()] = logContext.DeviceOsVersion.Truncate(SchemaConstants.Tags_AiDeviceOsVersion_MaxLength);
                }

                if (logContext.SyntheticSource != null)
                {
                    Tags[ContextTagKeys.AiOperationSyntheticSource.ToString()] = logContext.SyntheticSource.Truncate(SchemaConstants.Tags_AiOperationSyntheticSource_MaxLength);
                }

                if (logContext.UserAccountId != null)
                {
                    Tags[ContextTagKeys.AiUserAccountId.ToString()] = logContext.UserAccountId.Truncate(SchemaConstants.Tags_AiUserAccountId_MaxLength);
                }
            }

            InstrumentationKey = instrumentationKey;
            SetResourceSdkVersionAndIkey(resource, instrumentationKey);
        }

        public TelemetryItem(DateTime time, AzureMonitorResource? resource, string instrumentationKey) : this("Metric", FormatUtcTimestamp(time))
        {
            SetResourceSdkVersionAndIkey(resource, instrumentationKey);
        }

        public TelemetryItem(DateTime time, AzureMonitorResource? resource, string instrumentationKey, MonitorBase monitorBaseData) : this(time, resource, instrumentationKey)
        {
            Data = monitorBaseData;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetResourceSdkVersionAndIkey(AzureMonitorResource? resource, string instrumentationKey)
        {
            InstrumentationKey = instrumentationKey;
            Tags[ContextTagKeys.AiCloudRole.ToString()] = resource?.RoleName_Truncated;
            Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = resource?.RoleInstance_Truncated;
            Tags[ContextTagKeys.AiApplicationVer.ToString()] = resource?.ServiceVersion_Truncated;
            Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.s_sdkVersion.Truncate(SchemaConstants.Tags_AiInternalSdkVersion_MaxLength);

            var roleName = s_cloudRoleNameOverride ?? (s_cloudRoleNameOverride = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_CLOUD_ROLE_NAME) ?? string.Empty);
            if (roleName.Length > 0)
            {
                Tags[ContextTagKeys.AiCloudRole.ToString()] = roleName.Truncate(SchemaConstants.Tags_AiCloudRole_MaxLength);
            }

            var roleInstance = s_cloudRoleInstanceOverride ?? (s_cloudRoleInstanceOverride = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_CLOUD_ROLE_INSTANCE) ?? string.Empty);
            if (roleInstance.Length > 0)
            {
                Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = roleInstance.Truncate(SchemaConstants.Tags_AiCloudRoleInstance_MaxLength);
            }

            var componentVersion = s_componentVersionOverride ?? (s_componentVersionOverride = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_COMPONENT_VERSION) ?? string.Empty);
            if (componentVersion.Length > 0)
            {
                Tags[ContextTagKeys.AiApplicationVer.ToString()] = componentVersion.Truncate(SchemaConstants.Tags_AiApplicationVer_MaxLength);
            }
        }

        /// <summary>
        /// Resets the cached environment variable overrides. For testing only.
        /// </summary>
        internal static void ResetEnvironmentVariableOverrides()
        {
            s_cloudRoleNameOverride = null;
            s_cloudRoleInstanceOverride = null;
            s_componentVersionOverride = null;
        }

        internal static DateTimeOffset FormatUtcTimestamp(System.DateTime utcTimestamp)
        {
            return DateTime.SpecifyKind(utcTimestamp, DateTimeKind.Utc);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CopyTagIfPresent(TelemetryItem source, string key)
        {
            if (source.Tags.TryGetValue(key, out string? value) && value != null)
            {
                Tags[key] = value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetUserIdAndAuthenticatedUserId(ref ActivityTagsProcessor activityTagsProcessor)
        {
            if (activityTagsProcessor.EndUserId != null)
            {
                Tags[ContextTagKeys.AiUserAuthUserId.ToString()] = activityTagsProcessor.EndUserId.Truncate(SchemaConstants.Tags_AiUserAuthUserId_MaxLength);
            }

            if (activityTagsProcessor.EndUserPseudoId != null)
            {
                Tags[ContextTagKeys.AiUserId.ToString()] = activityTagsProcessor.EndUserPseudoId.Truncate(SchemaConstants.Tags_AiUserId_MaxLength);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetOverrideContextTags(ref ActivityTagsProcessor activityTagsProcessor)
        {
            SetTagFromMappedTags(ref activityTagsProcessor, SemanticConventions.AttributeMicrosoftSessionId, ContextTagKeys.AiSessionId, SchemaConstants.Tags_AiSessionId_MaxLength);
            SetTagFromMappedTags(ref activityTagsProcessor, SemanticConventions.AttributeAiDeviceId, ContextTagKeys.AiDeviceId, SchemaConstants.Tags_AiDeviceId_MaxLength);
            SetTagFromMappedTags(ref activityTagsProcessor, SemanticConventions.AttributeAiDeviceModel, ContextTagKeys.AiDeviceModel, SchemaConstants.Tags_AiDeviceModel_MaxLength);
            SetTagFromMappedTags(ref activityTagsProcessor, SemanticConventions.AttributeAiDeviceType, ContextTagKeys.AiDeviceType, SchemaConstants.Tags_AiDeviceType_MaxLength);
            SetTagFromMappedTags(ref activityTagsProcessor, SemanticConventions.AttributeAiDeviceOsVersion, ContextTagKeys.AiDeviceOSVersion, SchemaConstants.Tags_AiDeviceOsVersion_MaxLength);
            SetTagFromMappedTags(ref activityTagsProcessor, SemanticConventions.AttributeMicrosoftSyntheticSource, ContextTagKeys.AiOperationSyntheticSource, SchemaConstants.Tags_AiOperationSyntheticSource_MaxLength);
            SetTagFromMappedTags(ref activityTagsProcessor, SemanticConventions.AttributeMicrosoftUserAccountId, ContextTagKeys.AiUserAccountId, SchemaConstants.Tags_AiUserAccountId_MaxLength);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetTagFromMappedTags(ref ActivityTagsProcessor activityTagsProcessor, string attributeKey, ContextTagKeys contextTagKey, int maxLength)
        {
            var value = AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, attributeKey)?.ToString();
            if (value != null)
            {
                Tags[contextTagKey.ToString()] = value.Truncate(maxLength);
            }
        }
    }
}
