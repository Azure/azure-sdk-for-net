// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class TraceHelper
    {
        private const int Version = 2;
        private const int MaxlinksAllowed = 100;

        internal static (List<TelemetryItem> TelemetryItems, TelemetrySchemaTypeCounter TelemetrySchemaTypeCounter) OtelToAzureMonitorTrace(Batch<Activity> batchActivity, AzureMonitorResource? azureMonitorResource, string instrumentationKey, float sampleRate)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;
            var telemetrySchemaTypeCounter = new TelemetrySchemaTypeCounter();

            if (batchActivity.Count > 0 && azureMonitorResource?.MonitorBaseData != null)
            {
                var otelResourceMetricTelemetry = new TelemetryItem(DateTime.UtcNow, azureMonitorResource, instrumentationKey!, azureMonitorResource.MonitorBaseData);
                telemetryItems.Add(otelResourceMetricTelemetry);
            }

            foreach (var activity in batchActivity)
            {
                try
                {
                    var activityTagsProcessor = EnumerateActivityTags(activity);
                    telemetryItem = new TelemetryItem(activity, ref activityTagsProcessor, azureMonitorResource, instrumentationKey, sampleRate);

                    // Check for Exceptions events
                    if (activity.Events.Any())
                    {
                        AddTelemetryFromActivityEvents(activity, telemetryItem, telemetryItems, ref telemetrySchemaTypeCounter);
                    }

                    switch (activity.GetTelemetryType())
                    {
                        case TelemetryType.Request:
                            var requestData = new RequestData(Version, activity, ref activityTagsProcessor);
                            requestData.Name = telemetryItem.Tags.TryGetValue(ContextTagKeys.AiOperationName.ToString(), out var operationName) ? operationName.Truncate(SchemaConstants.RequestData_Name_MaxLength) : activity.DisplayName.Truncate(SchemaConstants.RequestData_Name_MaxLength);
                            telemetryItem.Data = new MonitorBase
                            {
                                BaseType = "RequestData",
                                BaseData = requestData,
                            };
                            telemetrySchemaTypeCounter._requestCount++;
                            break;
                        case TelemetryType.Dependency:
                            telemetryItem.Data = new MonitorBase
                            {
                                BaseType = "RemoteDependencyData",
                                BaseData = new RemoteDependencyData(Version, activity, ref activityTagsProcessor),
                            };
                            telemetrySchemaTypeCounter._dependencyCount++;
                            break;
                    }

                    activityTagsProcessor.Return();
                    telemetryItems.Add(telemetryItem);
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.FailedToConvertActivity(activity.Source.Name, activity.DisplayName, ex);
                }
            }

            return (telemetryItems, telemetrySchemaTypeCounter);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void AddPropertiesToTelemetry(IDictionary<string, string> destination, ref AzMonList UnMappedTags)
        {
            try
            {
                // TODO: Iterate only interested fields. Ref: https://github.com/Azure/azure-sdk-for-net/pull/14254#discussion_r470907560
                for (int i = 0; i < UnMappedTags.Length; i++)
                {
                    var tag = UnMappedTags[i];
                    AddKvpToDictionary(destination, tag);
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.ErrorAddingActivityTagsAsCustomProperties(ex);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void AddKvpToDictionary(IDictionary<string, string> destination, KeyValuePair<string, object?> keyValuePair)
        {
            if (keyValuePair.Key.Length <= SchemaConstants.KVP_MaxKeyLength && keyValuePair.Value != null)
            {
                // Note: if Key exceeds MaxLength or if Value is null, the entire KVP will be dropped.
                // In case of duplicate keys, only the first occurence will be exported.
#if NET
                destination.TryAdd(keyValuePair.Key, Convert.ToString(keyValuePair.Value, CultureInfo.InvariantCulture).Truncate(SchemaConstants.KVP_MaxValueLength) ?? "null");
#else
                if (!destination.ContainsKey(keyValuePair.Key))
                {
                    destination.Add(keyValuePair.Key, Convert.ToString(keyValuePair.Value, CultureInfo.InvariantCulture).Truncate(SchemaConstants.KVP_MaxValueLength) ?? "null");
                }
#endif
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void AddKvpToDictionary(IDictionary<string, string> destination, string key, string value)
        {
            if (key.Length <= SchemaConstants.KVP_MaxKeyLength && value != null)
            {
                // Note: if Key exceeds MaxLength or if Value is null, the entire KVP will be dropped.
                // In case of duplicate keys, only the first occurence will be exported.
#if NET
                destination.TryAdd(key, value.Truncate(SchemaConstants.KVP_MaxValueLength) ?? "null");
#else
                if (!destination.ContainsKey(key))
                {
                    destination.Add(key, value.Truncate(SchemaConstants.KVP_MaxValueLength) ?? "null");
                }
#endif
            }
        }

        /// <summary>
        /// Converts Activity Links to custom property with key as _MS.links.
        /// Value will be a JSON string formatted as [{"operation_Id":"{TraceId}","id":"{SpanId}"}].
        /// </summary>
        internal static void AddActivityLinksToProperties(Activity activity, ref AzMonList UnMappedTags)
        {
            string msLinks = "_MS.links";
            // max number of links that can fit in this json formatted string is 107. it is based on assumption that TraceId and SpanId will be of fixed length.
            // Keeping max at 100 for now.
            int maxLinks = MaxlinksAllowed;

            if (activity.Links != null && activity.Links.Any())
            {
                var linksJson = new StringBuilder();
                linksJson.Append('[');
                foreach (ref readonly var link in activity.EnumerateLinks())
                {
                    AddContextToMSLinks(linksJson, link);
                    maxLinks--;
                    if (maxLinks == 0)
                    {
                        if (MaxlinksAllowed < activity.Links.Count())
                        {
                            AzureMonitorExporterEventSource.Log.ActivityLinksIgnored(MaxlinksAllowed, activity.Source.Name, activity.DisplayName);
                        }
                        break;
                    }
                }

                if (linksJson.Length > 0)
                {
                    // trim trailing comma - json does not support it
                    linksJson.Remove(linksJson.Length - 1, 1);
                }

                linksJson.Append(']');

                AzMonList.Add(ref UnMappedTags, new KeyValuePair<string, object?>(msLinks, linksJson.ToString()));
            }
        }

        internal static ActivityTagsProcessor EnumerateActivityTags(Activity activity)
        {
            var activityTagsProcessor = new ActivityTagsProcessor();
            activityTagsProcessor.CategorizeTags(activity);
            return activityTagsProcessor;
        }

        internal static string GetOperationName(Activity activity, ref AzMonList MappedTags)
        {
            var httpMethod = AzMonList.GetTagValue(ref MappedTags, SemanticConventions.AttributeHttpMethod)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpMethod))
            {
                var httpRoute = AzMonList.GetTagValue(ref MappedTags, SemanticConventions.AttributeHttpRoute)?.ToString();

                // ASP.NET instrumentation assigns route as {controller}/{action}/{id} which would result in the same name for different operations.
                // To work around that we will use path from httpUrl.
                if (!string.IsNullOrWhiteSpace(httpRoute) && !httpRoute!.Contains("{controller}"))
                {
                    return $"{httpMethod} {httpRoute}";
                }

                var httpUrl = AzMonList.GetTagValue(ref MappedTags, SemanticConventions.AttributeHttpUrl)?.ToString();
                if (!string.IsNullOrWhiteSpace(httpUrl) && Uri.TryCreate(httpUrl!.ToString(), UriKind.RelativeOrAbsolute, out var uri) && uri.IsAbsoluteUri)
                {
                    return $"{httpMethod} {uri.AbsolutePath}";
                }
            }

            return activity.DisplayName;
        }

        internal static string GetOperationNameV2(Activity activity, ref AzMonList MappedTags)
        {
            var httpMethod = AzMonList.GetTagValue(ref MappedTags, SemanticConventions.AttributeHttpRequestMethod)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpMethod))
            {
                var httpRoute = AzMonList.GetTagValue(ref MappedTags, SemanticConventions.AttributeHttpRoute)?.ToString();

                // ASP.NET instrumentation assigns route as {controller}/{action}/{id} which would result in the same name for different operations.
                // To work around that we will use path from url.path.
                if (!string.IsNullOrWhiteSpace(httpRoute) && !httpRoute!.Contains("{controller}"))
                {
                    return $"{httpMethod} {httpRoute}";
                }

                var httpPath = AzMonList.GetTagValue(ref MappedTags, SemanticConventions.AttributeUrlPath)?.ToString();
                if (!string.IsNullOrWhiteSpace(httpPath))
                {
                    return $"{httpMethod} {httpPath}";
                }
            }

            return activity.DisplayName;
        }

        private static void AddTelemetryFromActivityEvents(Activity activity, TelemetryItem telemetryItem, List<TelemetryItem> telemetryItems, ref TelemetrySchemaTypeCounter telemetrySchemaTypeCounter)
        {
            foreach (ref readonly var @event in activity.EnumerateEvents())
            {
                try
                {
                    if (@event.Name == SemanticConventions.AttributeExceptionEventName)
                    {
                        var exceptionData = GetExceptionDataDetailsOnTelemetryItem(@event);
                        if (exceptionData != null)
                        {
                            var exceptionTelemetryItem = new TelemetryItem("Exception", telemetryItem, activity.SpanId, activity.Kind, @event.Timestamp);
                            exceptionTelemetryItem.Data = exceptionData;
                            telemetryItems.Add(exceptionTelemetryItem);
                            telemetrySchemaTypeCounter._exceptionCount++;
                        }
                    }
                    else
                    {
                        var messageData = GetTraceTelemetryData(@event);
                        if (messageData != null)
                        {
                            var traceTelemetryItem = new TelemetryItem("Message", telemetryItem, activity.SpanId, activity.Kind, @event.Timestamp);
                            traceTelemetryItem.Data = messageData;
                            telemetryItems.Add(traceTelemetryItem);
                            telemetrySchemaTypeCounter._traceCount++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.FailedToExtractActivityEvent(activity.Source.Name, activity.DisplayName, ex);
                }
            }
        }

        private static MonitorBase? GetTraceTelemetryData(ActivityEvent activityEvent)
        {
            if (activityEvent.Name == null)
            {
                return null;
            }

            var messageData = new MessageData(Version, activityEvent.Name);

            foreach (ref readonly var tag in activityEvent.EnumerateTagObjects())
            {
                if (tag.Value is Array arrayValue)
                {
                    AddKvpToDictionary(messageData.Properties, tag.Key, arrayValue.ToCommaDelimitedString());
                }
                else
                {
                    AddKvpToDictionary(messageData.Properties, tag);
                }
            }

            return new MonitorBase
            {
                BaseType = "MessageData",
                BaseData = messageData,
            };
        }

        private static MonitorBase? GetExceptionDataDetailsOnTelemetryItem(ActivityEvent activityEvent)
        {
            string? exceptionType = null;
            string? exceptionStackTrace = null;
            string? exceptionMessage = null;
            var properties = new Dictionary<string, string>();

            foreach (ref readonly var tag in activityEvent.EnumerateTagObjects())
            {
                // TODO: see if these can be cached
                if (tag.Key == SemanticConventions.AttributeExceptionType)
                {
                    exceptionType = tag.Value?.ToString();
                }
                else if (tag.Key == SemanticConventions.AttributeExceptionMessage)
                {
                    exceptionMessage = tag.Value?.ToString();
                }
                else if (tag.Key == SemanticConventions.AttributeExceptionStacktrace)
                {
                    exceptionStackTrace = tag.Value?.ToString();
                }
                else
                {
                    AddKvpToDictionary(properties, tag);
                }
            }

            if (string.IsNullOrEmpty(exceptionMessage) || exceptionType == null)
            {
                return null;
            }

            TelemetryExceptionDetails exceptionDetails = new(exceptionMessage.Truncate(SchemaConstants.ExceptionDetails_Message_MaxLength))
            {
                Stack = exceptionStackTrace.Truncate(SchemaConstants.ExceptionDetails_Stack_MaxLength),

                HasFullStack = exceptionStackTrace != null && (exceptionStackTrace.Length <= SchemaConstants.ExceptionDetails_Stack_MaxLength),

                // TODO: Update swagger schema to mandate typename.
                TypeName = exceptionType.Truncate(SchemaConstants.ExceptionDetails_TypeName_MaxLength),
            };

            List<TelemetryExceptionDetails> exceptions = new()
            {
                exceptionDetails
            };

            TelemetryExceptionData exceptionData = new(Version, exceptions, properties);

            return new MonitorBase
            {
                BaseType = "ExceptionData",
                BaseData = exceptionData,
            };
        }

        internal static void AddEnqueuedTimeToMeasurementsAndLinksToProperties(Activity activity, IDictionary<string, double> measurements, ref AzMonList UnMappedTags)
        {
            if (activity.Links != null && activity.Links.Any())
            {
                if (TryGetAverageQueueTimeWithLinks(activity, ref UnMappedTags, out long enqueuedTime))
                {
                    measurements["timeSinceEnqueued"] = enqueuedTime;
                }
            }
        }

        private static bool TryGetAverageQueueTimeWithLinks(Activity activity, ref AzMonList UnMappedTags, out long avgTimeInQueue)
        {
            avgTimeInQueue = 0;
            var linksCount = 0;
            DateTimeOffset startTime = activity.StartTimeUtc;
            long startEpochTime = startTime.ToUnixTimeMilliseconds();
            bool isEnqueuedTimeCalculated = true;

            string msLinks = "_MS.links";
            var linksJson = new StringBuilder();
            linksJson.Append('[');
            foreach (ref readonly var link in activity.EnumerateLinks())
            {
                long msgEnqueuedTime = 0;
                if (isEnqueuedTimeCalculated && !TryGetEnqueuedTime(link, out msgEnqueuedTime))
                {
                    // instrumentation does not consistently report enqueued time, ignoring whole span
                    isEnqueuedTimeCalculated = false;
                }
                if (isEnqueuedTimeCalculated)
                {
                    avgTimeInQueue += Math.Max(startEpochTime - msgEnqueuedTime, 0);
                }

                linksCount++;

                if (linksCount <= MaxlinksAllowed)
                {
                    AddContextToMSLinks(linksJson, link);
                }
            }

            if (linksJson.Length > 0)
            {
                // trim trailing comma - json does not support it
                linksJson.Remove(linksJson.Length - 1, 1);
            }
            linksJson.Append(']');
            AzMonList.Add(ref UnMappedTags, new KeyValuePair<string, object?>(msLinks, linksJson.ToString()));
            if (MaxlinksAllowed < linksCount)
            {
                AzureMonitorExporterEventSource.Log.ActivityLinksIgnored(MaxlinksAllowed, activity.Source.Name, activity.DisplayName);
            }

            if (isEnqueuedTimeCalculated)
            {
                avgTimeInQueue /= linksCount;
            }
            else
            {
                avgTimeInQueue = 0;
                return false;
            }

            return true;
        }

        private static bool TryGetEnqueuedTime(ActivityLink link, out long enqueuedTime)
        {
            enqueuedTime = 0;

            foreach (ref readonly var attribute in link.EnumerateTagObjects())
            {
                if (attribute.Key == "enqueuedTime")
                {
                    return long.TryParse(attribute.Value?.ToString(), out enqueuedTime);
                }
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void AddContextToMSLinks(StringBuilder linksJson, ActivityLink link)
        {
            linksJson
                .Append('{')
                .Append("\"operation_Id\":")
                .Append('\"')
                .Append(link.Context.TraceId.ToHexString())
                .Append('\"')
                .Append(',');
            linksJson
                .Append("\"id\":")
                .Append('\"')
                .Append(link.Context.SpanId.ToHexString())
                .Append('\"');
            linksJson
                .Append("},");
        }

        internal static string GetAzureSDKDependencyType(ActivityKind kind, string azureNamespace)
        {
            // TODO: see if the values can be cached to avoid allocation.
            if (kind == ActivityKind.Internal)
            {
                return $"InProc | {azureNamespace}";
            }
            else if (kind == ActivityKind.Producer)
            {
                return $"Queue Message | {azureNamespace}";
            }
            else
            {
                // The Azure SDK sets az.namespace with its resource provider information.
                // When ActivityKind is not internal and az.namespace is present, set the value of Type to az.namespace.
                return azureNamespace;
            }
        }
    }
}
