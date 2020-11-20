// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Models;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
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

        internal static string RoleName { get; set; } = null;

        internal static string RoleInstance { get; set; } = null;

        internal static TelemetryItem GetTelemetryItem(Activity activity, string instrumentationKey)
        {
            TelemetryItem telemetryItem = new TelemetryItem(PartA_Name_Mapping[activity.GetTelemetryType()], activity.StartTimeUtc.ToString(CultureInfo.InvariantCulture))
            {
                InstrumentationKey = instrumentationKey
            };

            InitRoleInfo(activity);
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

        internal static void InitRoleInfo(Activity activity)
        {
            if (RoleName != null || RoleInstance != null)
            {
                return;
            }

            var resource = activity.GetResource();

            if (resource == null)
            {
                return;
            }

            string serviceName = null;
            string serviceNamespace = null;

            foreach (var attribute in resource.Attributes)
            {
                if (attribute.Key == Resource.ServiceNameKey && attribute.Value is string)
                {
                    serviceName = attribute.Value.ToString();
                }
                else if (attribute.Key == Resource.ServiceNamespaceKey && attribute.Value is string)
                {
                    serviceNamespace = attribute.Value.ToString();
                }
                else if (attribute.Key == Resource.ServiceInstanceIdKey && attribute.Value is string)
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
