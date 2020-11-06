// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Models;

using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
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

        private static readonly IReadOnlyDictionary<string, PartBType> Part_B_Mapping = new Dictionary<string, PartBType>()
        {
            [SemanticConventions.AttributeDbSystem] = PartBType.Db,
            [SemanticConventions.AttributeDbConnectionString] = PartBType.Db,
            [SemanticConventions.AttributeDbUser] = PartBType.Db,

            [SemanticConventions.AttributeHttpMethod] = PartBType.Http,
            [SemanticConventions.AttributeHttpUrl] = PartBType.Http,
            [SemanticConventions.AttributeHttpStatusCode] = PartBType.Http,
            [SemanticConventions.AttributeHttpScheme] = PartBType.Http,
            [SemanticConventions.AttributeHttpHost] = PartBType.Http,
            [SemanticConventions.AttributeHttpHostPort] = PartBType.Http,
            [SemanticConventions.AttributeHttpTarget] = PartBType.Http,

            [SemanticConventions.AttributeNetPeerName] = PartBType.Common,
            [SemanticConventions.AttributeNetPeerIp] = PartBType.Common,
            [SemanticConventions.AttributeNetPeerPort] = PartBType.Common,
            [SemanticConventions.AttributeNetTransport] = PartBType.Common,
            [SemanticConventions.AttributeNetHostIp] = PartBType.Common,
            [SemanticConventions.AttributeNetHostPort] = PartBType.Common,
            [SemanticConventions.AttributeNetHostName] = PartBType.Common,
            [SemanticConventions.AttributeComponent] = PartBType.Common,

            [SemanticConventions.AttributeRpcSystem] = PartBType.Rpc,
            [SemanticConventions.AttributeRpcService] = PartBType.Rpc,
            [SemanticConventions.AttributeRpcMethod] = PartBType.Rpc,

            [SemanticConventions.AttributeFaasTrigger] = PartBType.FaaS,
            [SemanticConventions.AttributeFaasExecution] = PartBType.FaaS,
            [SemanticConventions.AttributeFaasColdStart] = PartBType.FaaS,
            [SemanticConventions.AttributeFaasDocumentCollection] = PartBType.FaaS,
            [SemanticConventions.AttributeFaasDocumentOperation] = PartBType.FaaS,
            [SemanticConventions.AttributeFaasDocumentTime] = PartBType.FaaS,
            [SemanticConventions.AttributeFaasDocumentName] = PartBType.FaaS,
            [SemanticConventions.AttributeFaasCron] = PartBType.FaaS,
            [SemanticConventions.AttributeFaasTime] = PartBType.FaaS,

            [SemanticConventions.AttributeAzureNameSpace] = PartBType.Azure,
            [SemanticConventions.AttributeEndpointAddress] = PartBType.Azure,
            [SemanticConventions.AttributeMessageBusDestination] = PartBType.Azure,

            [SemanticConventions.AttributeMessagingSystem] = PartBType.Messaging,
            [SemanticConventions.AttributeMessagingDestination] = PartBType.Messaging,
            [SemanticConventions.AttributeMessagingDestinationKind] = PartBType.Messaging,
            [SemanticConventions.AttributeMessagingTempDestination] = PartBType.Messaging,
            [SemanticConventions.AttributeMessagingUrl] = PartBType.Messaging
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
            var monitorTags = new TagEnumerationState
            {
                PartBTags = PooledList<KeyValuePair<string, object>>.Create(),
                PartCTags = PooledList<KeyValuePair<string, object>>.Create()
            };

            activity.EnumerateTags(ref monitorTags);

            MonitorBase telemetry = new MonitorBase
            {
                BaseType = Telemetry_Base_Type_Mapping[telemetryType]
            };

            if (telemetryType == TelemetryType.Request)
            {
                var url = activity.Kind == ActivityKind.Server ? monitorTags.PartBTags.GetUrl() : monitorTags.PartBTags.GetMessagingUrl();
                var statusCode = monitorTags.PartBTags.GetHttpStatusCode();
                var success = HttpHelper.GetSuccessFromHttpStatusCode(statusCode);
                var request = new RequestData(2, activity.Context.SpanId.ToHexString(), activity.Duration.ToString("c", CultureInfo.InvariantCulture), success, statusCode)
                {
                    Name = activity.DisplayName,
                    Url = url,
                    // TODO: Handle request.source.
                };

                // TODO: Handle activity.TagObjects, extract well-known tags
                AddPropertiesToTelemetry(request.Properties, monitorTags.PartCTags);
                telemetry.BaseData = request;
            }
            else if (telemetryType == TelemetryType.Dependency)
            {
                var dependency = new RemoteDependencyData(2, activity.DisplayName, activity.Duration.ToString("c", CultureInfo.InvariantCulture))
                {
                    Id = activity.Context.SpanId.ToHexString()
                };

                if (monitorTags.activityType == PartBType.Http)
                {
                    dependency.Data = HttpHelper.GetUrl(monitorTags.PartBTags);
                    dependency.Type = "HTTP"; // TODO: Parse for storage / SB.
                    var statusCode = HttpHelper.GetHttpStatusCode(monitorTags.PartBTags);
                    dependency.ResultCode = statusCode;
                    dependency.Success = HttpHelper.GetSuccessFromHttpStatusCode(statusCode);
                }

                // TODO: Handle dependency.target.
                AddPropertiesToTelemetry(dependency.Properties, monitorTags.PartCTags);
                telemetry.BaseData = dependency;
            }

            return telemetry;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void AddPropertiesToTelemetry(IDictionary<string, string> destination, PooledList<KeyValuePair<string, object>> PartCTags)
        {
            // TODO: Iterate only interested fields. Ref: https://github.com/Azure/azure-sdk-for-net/pull/14254#discussion_r470907560
            foreach (var tag in PartCTags)
            {
                destination.Add(tag.Key, tag.Value?.ToString());
            }
        }

        internal struct TagEnumerationState : IActivityEnumerator<KeyValuePair<string, object>>
        {
            public PooledList<KeyValuePair<string, object>> PartBTags;
            public PooledList<KeyValuePair<string, object>> PartCTags;

            private PartBType tempActivityType;
            public PartBType activityType;

            public bool ForEach(KeyValuePair<string, object> activityTag)
            {
                if (activityTag.Value == null)
                {
                    return true;
                }

                if (activityTag.Value is Array array)
                {
                    StringBuilder sw = new StringBuilder();
                    foreach (var item in array)
                    {
                        // TODO: Consider changing it to JSon array.
                        if (item != null)
                        {
                            sw.Append(item);
                            sw.Append(',');
                        }
                    }

                    if (sw.Length > 0)
                    {
                        sw.Length--;
                    }

                    PooledList<KeyValuePair<string, object>>.Add(ref PartCTags, new KeyValuePair<string, object>(activityTag.Key, sw.ToString()));
                    return true;
                }

                if (!Part_B_Mapping.TryGetValue(activityTag.Key, out tempActivityType))
                {
                    PooledList<KeyValuePair<string, object>>.Add(ref PartCTags, activityTag);
                    return true;
                }

                if (activityType == PartBType.Unknown || activityType == PartBType.Common)
                {
                    activityType = tempActivityType;
                }

                if (tempActivityType == activityType || tempActivityType == PartBType.Common)
                {
                    PooledList<KeyValuePair<string, object>>.Add(ref PartBTags, activityTag);
                }
                else
                {
                    PooledList<KeyValuePair<string, object>>.Add(ref PartCTags, activityTag);
                }

                return true;
            }
        }
    }
}
