// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// Part A are the common data that apply to OTel Trace, OTel Logs and OTel Metrics.
    /// </summary>
    internal class TelemetryPartA
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";
        private static readonly IReadOnlyDictionary<TelemetryType, string> PartA_Name_Mapping = new Dictionary<TelemetryType, string>
        {
            [TelemetryType.Request] = "Request",
            [TelemetryType.Dependency] = "RemoteDependency",
            [TelemetryType.Message] = "Message",
            [TelemetryType.Event] = "Event",
        };

        internal static string RoleName { get; set; }

        internal static string RoleInstance { get; set; }

        internal static TelemetryItem GetTelemetryItem(Activity activity, ref TagEnumerationState monitorTags, Resource resource, string instrumentationKey)
        {
            TelemetryItem telemetryItem = new TelemetryItem(PartA_Name_Mapping[activity.GetTelemetryType()], FormatUtcTimestamp(activity.StartTimeUtc))
            {
                InstrumentationKey = instrumentationKey
            };

            InitRoleInfo(resource);

            if (activity.ParentSpanId != default)
            {
                telemetryItem.Tags[ContextTagKeys.AiOperationParentId.ToString()] = activity.ParentSpanId.ToHexString();
            }

            telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()] = RoleName;
            telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = RoleInstance;
            telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()] = activity.TraceId.ToHexString();
            // todo: update swagger to include this key.
            telemetryItem.Tags["ai.user.userAgent"] = AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeHttpUserAgent)?.ToString();

            // we only have mapping for server spans
            // todo: non-server spans
            if (activity.Kind == ActivityKind.Server)
            {
                telemetryItem.Tags[ContextTagKeys.AiOperationName.ToString()] = GetOperationName(activity, ref monitorTags.PartBTags);
                telemetryItem.Tags[ContextTagKeys.AiLocationIp.ToString()] = GetLocationIp(ref monitorTags.PartBTags);
            }

            telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.SdkVersion;

            return telemetryItem;
        }

        internal static string GetOperationName(Activity activity, ref AzMonList partBTags)
        {
            var httpMethod = AzMonList.GetTagValue(ref partBTags, SemanticConventions.AttributeHttpMethod)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpMethod))
            {
                var httpRoute = AzMonList.GetTagValue(ref partBTags, SemanticConventions.AttributeHttpRoute)?.ToString();
                // ASP.NET instrumentation assigns route as {controller}/{action}/{id} which would result in the same name for different operations.
                // To work around that we will use path from httpUrl.
                if (!string.IsNullOrWhiteSpace(httpRoute) && !httpRoute.Contains("{controller}"))
                {
                    return $"{httpMethod} {httpRoute}";
                }
                var httpUrl = AzMonList.GetTagValue(ref partBTags, SemanticConventions.AttributeHttpUrl)?.ToString();
                if (!string.IsNullOrWhiteSpace(httpUrl) && Uri.TryCreate(httpUrl.ToString(), UriKind.RelativeOrAbsolute, out var uri) && uri.IsAbsoluteUri)
                {
                    return $"{httpMethod} {uri.AbsolutePath}";
                }
            }

            return activity.DisplayName;
        }

        private static string GetLocationIp(ref AzMonList partBTags)
        {
            var httpClientIp = AzMonList.GetTagValue(ref partBTags, SemanticConventions.AttributeHttpClientIP)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpClientIp))
            {
                return httpClientIp;
            }

            return AzMonList.GetTagValue(ref partBTags, SemanticConventions.AttributeNetPeerIp)?.ToString();
        }

        internal static TelemetryItem GetTelemetryItem(LogRecord logRecord, Resource resource, string instrumentationKey)
        {
            var name = PartA_Name_Mapping[TelemetryType.Message];
            var time = FormatUtcTimestamp(logRecord.Timestamp);

            TelemetryItem telemetryItem = new TelemetryItem(name, time)
            {
                InstrumentationKey = instrumentationKey
            };

            InitRoleInfo(resource);
            telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()] = RoleName;
            telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = RoleInstance;

            if (logRecord.TraceId != default)
            {
                telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()] = logRecord.TraceId.ToHexString();
            }

            if (logRecord.SpanId != default)
            {
                telemetryItem.Tags[ContextTagKeys.AiOperationParentId.ToString()] = logRecord.SpanId.ToHexString();
            }

            telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.SdkVersion;

            return telemetryItem;
        }

        internal static void InitRoleInfo(Resource resource)
        {
            if (RoleName != null || RoleInstance != null)
            {
                return;
            }

            if (resource == null)
            {
                return;
            }

            string serviceName = null;
            string serviceNamespace = null;

            foreach (var attribute in resource.Attributes)
            {
                if (attribute.Key == SemanticConventions.AttributeServiceName && attribute.Value is string)
                {
                    serviceName = attribute.Value.ToString();
                }
                else if (attribute.Key == SemanticConventions.AttributeServiceNamespace && attribute.Value is string)
                {
                    serviceNamespace = attribute.Value.ToString();
                }
                else if (attribute.Key == SemanticConventions.AttributeServiceInstance && attribute.Value is string)
                {
                    RoleInstance = attribute.Value.ToString();
                }
            }

            if (serviceName != null && serviceNamespace != null)
            {
                RoleName = string.Concat(serviceNamespace, ".", serviceName);
            }
            else
            {
                RoleName = serviceName;
            }

            if (RoleInstance == null)
            {
                try
                {
                    RoleInstance = Dns.GetHostName();
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.Write($"ErrorInitializingRoleInstanceToHostName{EventLevelSuffix.Error}", $"{ex.ToInvariantString()}");
                }
            }
        }

        internal static string FormatUtcTimestamp(System.DateTime utcTimestamp)
        {
            return utcTimestamp.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
        }
    }
}
