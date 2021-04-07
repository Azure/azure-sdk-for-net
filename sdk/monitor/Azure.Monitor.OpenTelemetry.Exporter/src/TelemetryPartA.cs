// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

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
        private static readonly IReadOnlyDictionary<TelemetryType, string> PartA_Name_Mapping = new Dictionary<TelemetryType, string>
        {
            [TelemetryType.Request] = "Request",
            [TelemetryType.Dependency] = "RemoteDependency",
            [TelemetryType.Message] = "Message",
            [TelemetryType.Event] = "Event",
        };

        internal static string RoleName { get; set; }

        internal static string RoleInstance { get; set; }

        internal static TelemetryItem GetTelemetryItem(Activity activity, Resource resource, string instrumentationKey)
        {
            TelemetryItem telemetryItem = new TelemetryItem(PartA_Name_Mapping[activity.GetTelemetryType()], activity.StartTimeUtc.ToString(CultureInfo.InvariantCulture))
            {
                InstrumentationKey = instrumentationKey
            };

            InitRoleInfo(resource);
            telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()] = RoleName;
            telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = RoleInstance;
            telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()] = activity.TraceId.ToHexString();

            if (activity.Parent != null)
            {
                telemetryItem.Tags[ContextTagKeys.AiOperationParentId.ToString()] = activity.Parent.SpanId.ToHexString();
            }

            telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.SdkVersion;

            return telemetryItem;
        }

        internal static TelemetryItem GetTelemetryItem(LogRecord logRecord, string instrumentationKey)
        {
            var name = PartA_Name_Mapping[TelemetryType.Message];
            var time = logRecord.Timestamp.ToString(CultureInfo.InvariantCulture);

            TelemetryItem telemetryItem = new TelemetryItem(name, time)
            {
                InstrumentationKey = instrumentationKey
            };

            // TODO: I WAS TOLD THIS MIGHT BE CHANGING. IGNORING FOR NOW.
            //InitRoleInfo(activity);
            //telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()] = RoleName;
            //telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = RoleInstance;

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
        }
    }
}
