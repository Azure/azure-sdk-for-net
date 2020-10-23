// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

using Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Microsoft.Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// This class is responsible for converting an OpenTelemetry <see cref="Batch{T}"/> of <see cref="Activity"/>
    /// into a collection of <see cref="TelemetryItem"/> for Azure Monitor.
    /// </summary>
    internal static class AzureMonitorConverter
    {
        private static readonly IReadOnlyDictionary<TelemetryType, string> Telemetry_Base_Type_Mapping = new Dictionary<TelemetryType, string>
        {
            [TelemetryType.Request] = "RequestData",
            [TelemetryType.Dependency] = "RemoteDependencyData",
            [TelemetryType.Message] = "MessageData",
            [TelemetryType.Event] = "EventData",
        };

        private static readonly IReadOnlyDictionary<TelemetryType, string> PartA_Name_Mapping = new Dictionary<TelemetryType, string>
        {
            [TelemetryType.Request] = "Request",
            [TelemetryType.Dependency] = "RemoteDependency",
            [TelemetryType.Message] = "Message",
            [TelemetryType.Event] = "Event",
        };

        internal static List<TelemetryItem> Convert(Batch<Activity> batchActivity, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var activity in batchActivity)
            {
                telemetryItem = GeneratePartAEnvelope(activity);
                telemetryItem.InstrumentationKey = instrumentationKey;
                telemetryItem.Data = GenerateTelemetryData(activity);
                telemetryItems.Add(telemetryItem);
            }

            return telemetryItems;
        }

        internal static TelemetryItem GeneratePartAEnvelope(Activity activity)
        {
            TelemetryItem telemetryItem = new TelemetryItem(PartA_Name_Mapping[activity.GetTelemetryType()], activity.StartTimeUtc.ToString(CultureInfo.InvariantCulture));
            ExtractRoleInfo(activity.GetResource(), out var roleName, out var roleInstance);
            telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()] = roleName;
            telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()] = roleInstance;
            telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()] = activity.TraceId.ToHexString();
            if (activity.Parent != null)
            {
                telemetryItem.Tags[ContextTagKeys.AiOperationParentId.ToString()] = activity.Parent.SpanId.ToHexString();
            }
            // TODO: Handle exception
            telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.SdkVersion;

            return telemetryItem;
        }

        internal static void ExtractRoleInfo(Resource resource, out string roleName, out string roleInstance)
        {
            if (resource == null)
            {
                roleName = null;
                roleInstance = null;
                return;
            }

            string serviceName = null;
            string serviceNamespace = null;
            roleInstance = null;

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
                    roleInstance = attribute.Value.ToString();
                }
            }

            if (serviceName != null && serviceNamespace != null)
            {
                roleName = string.Concat(serviceNamespace, ".", serviceName);
            }
            else
            {
                roleName = serviceName;
            }
        }

        private static MonitorBase GenerateTelemetryData(Activity activity)
        {
            var telemetryType = activity.GetTelemetryType();
            var activityType = activity.TagObjects.ToAzureMonitorTags(out var partBTags, out var PartCTags);
            MonitorBase telemetry = new MonitorBase
            {
                BaseType = Telemetry_Base_Type_Mapping[telemetryType]
            };

            if (telemetryType == TelemetryType.Request)
            {
                var url = activity.Kind == ActivityKind.Server ? HttpHelper.GetUrl(partBTags) : GetMessagingUrl(partBTags);
                var statusCode = HttpHelper.GetHttpStatusCode(partBTags);
                var success = HttpHelper.GetSuccessFromHttpStatusCode(statusCode);
                var request = new RequestData(2, activity.Context.SpanId.ToHexString(), activity.Duration.ToString("c", CultureInfo.InvariantCulture), success, statusCode)
                {
                    Name = activity.DisplayName,
                    Url = url,
                    // TODO: Handle request.source.
                };

                // TODO: Handle activity.TagObjects, extract well-known tags
                AddPropertiesToTelemetry(request.Properties, PartCTags);
                telemetry.BaseData = request;
            }
            else if (telemetryType == TelemetryType.Dependency)
            {
                var dependency = new RemoteDependencyData(2, activity.DisplayName, activity.Duration.ToString("c", CultureInfo.InvariantCulture))
                {
                    Id = activity.Context.SpanId.ToHexString()
                };

                // TODO: Handle activity.TagObjects
                // ExtractPropertiesFromTags(dependency.Properties, activity.Tags);

                if (activityType == PartBType.Http)
                {
                    dependency.Data = HttpHelper.GetUrl(partBTags);
                    dependency.Type = "HTTP"; // TODO: Parse for storage / SB.
                    var statusCode = HttpHelper.GetHttpStatusCode(partBTags);
                    dependency.ResultCode = statusCode;
                    dependency.Success = HttpHelper.GetSuccessFromHttpStatusCode(statusCode);
                }

                // TODO: Handle dependency.target.
                AddPropertiesToTelemetry(dependency.Properties, PartCTags);
                telemetry.BaseData = dependency;
            }

            return telemetry;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetMessagingUrl(Dictionary<string, string> tags)
        {
            if (tags != null && tags.TryGetValue(SemanticConventions.AttributeMessagingUrl, out var url))
            {
                return url;
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void AddPropertiesToTelemetry(IDictionary<string, string> destination, IEnumerable<KeyValuePair<string, string>> PartCTags)
        {
            // TODO: Iterate only interested fields. Ref: https://github.com/Azure/azure-sdk-for-net/pull/14254#discussion_r470907560
            foreach (var tag in PartCTags)
            {
                destination.Add(tag);
            }
        }
    }
}
