﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class TraceHelper
    {
        private const int Version = 2;
        private const int MaxlinksAllowed = 100;

        internal static List<TelemetryItem> OtelToAzureMonitorTrace(Batch<Activity> batchActivity, AzureMonitorResource? azureMonitorResource, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var activity in batchActivity)
            {
                try
                {
                    var activityTagsProcessor = EnumerateActivityTags(activity);
                    telemetryItem = new TelemetryItem(activity, ref activityTagsProcessor, azureMonitorResource, instrumentationKey);

                    // Check for Exceptions events
                    if (activity.Events.Any())
                    {
                        AddTelemetryFromActivityEvents(activity, telemetryItem, telemetryItems);
                    }

                    switch (activity.GetTelemetryType())
                    {
                        case TelemetryType.Request:
                            telemetryItem.Data = new MonitorBase
                            {
                                BaseType = "RequestData",
                                BaseData = new RequestData(Version, activity, ref activityTagsProcessor),
                            };
                            break;
                        case TelemetryType.Dependency:
                            telemetryItem.Data = new MonitorBase
                            {
                                BaseType = "RemoteDependencyData",
                                BaseData = new RemoteDependencyData(Version, activity, ref activityTagsProcessor),
                            };
                            break;
                    }

                    activityTagsProcessor.Return();
                    telemetryItems.Add(telemetryItem);
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.WriteError("FailedToConvertActivity", ex);
                }
            }

            return telemetryItems;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void AddPropertiesToTelemetry(IDictionary<string, string> destination, ref AzMonList UnMappedTags)
        {
            // TODO: Iterate only interested fields. Ref: https://github.com/Azure/azure-sdk-for-net/pull/14254#discussion_r470907560
            for (int i = 0; i < UnMappedTags.Length; i++)
            {
                var tag = UnMappedTags[i];
                if (tag.Key.Length <= SchemaConstants.KVP_MaxKeyLength && tag.Value != null)
                {
                    // Note: if Key exceeds MaxLength or if Value is null, the entire KVP will be dropped.

                    destination.Add(tag.Key, tag.Value.ToString().Truncate(SchemaConstants.KVP_MaxValueLength) ?? "null");
                }
            }
        }

        /// <summary>
        /// Converts Activity Links to custom property with key as _MS.links.
        /// Value will be a JSON string formatted as [{"operation_Id":"{TraceId}","id":"{SpanId}"}].
        /// </summary>
        internal static void AddActivityLinksToProperties(Activity activity, ref AzMonList UnMappedTags)
        {
            string msLinks = "_MS.links";
            // max number of links that can fit in this json formatted string is 107. it is based on assumption that traceid and spanid will be of fixed length.
            // Keeping max at 100 for now.
            int maxLinks = MaxlinksAllowed;

            if (activity.Links != null && activity.Links.Any())
            {
                var linksJson = new StringBuilder();
                linksJson.Append('[');
                foreach (var link in activity.EnumerateLinks())
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
                    linksJson.Append("},");

                    maxLinks--;
                    if (maxLinks == 0)
                    {
                        if (MaxlinksAllowed < activity.Links.Count())
                        {
                            AzureMonitorExporterEventSource.Log.WriteInformational("ActivityLinksIgnored", $"Max count of {MaxlinksAllowed} has reached.");
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

        internal static string? GetLocationIp(ref AzMonList MappedTags)
        {
            var httpClientIp = AzMonList.GetTagValue(ref MappedTags, SemanticConventions.AttributeHttpClientIP)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpClientIp))
            {
                return httpClientIp;
            }

            return AzMonList.GetTagValue(ref MappedTags, SemanticConventions.AttributeNetPeerIp)?.ToString();
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

        private static void AddTelemetryFromActivityEvents(Activity activity, TelemetryItem telemetryItem, List<TelemetryItem> telemetryItems)
        {
            foreach (var evnt in activity.EnumerateEvents())
            {
                try
                {
                    if (evnt.Name == SemanticConventions.AttributeExceptionEventName)
                    {
                        var exceptionData = GetExceptionDataDetailsOnTelemetryItem(evnt);
                        if (exceptionData != null)
                        {
                            var exceptionTelemetryItem = new TelemetryItem("Exception", telemetryItem, activity.SpanId, activity.Kind, evnt.Timestamp);
                            exceptionTelemetryItem.Data = exceptionData;
                            telemetryItems.Add(exceptionTelemetryItem);
                        }
                    }
                    else
                    {
                        var messageData = GetTraceTelemetryData(evnt);
                        if (messageData != null)
                        {
                            var traceTelemetryItem = new TelemetryItem("Message", telemetryItem, activity.SpanId, activity.Kind, evnt.Timestamp);
                            traceTelemetryItem.Data = messageData;
                            telemetryItems.Add(traceTelemetryItem);
                        }
                    }
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.WriteError("FailedToExtractActivityEvent", ex);
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

            foreach (var tag in activityEvent.EnumerateTagObjects())
            {
                if (tag.Value is Array arrayValue)
                {
                    messageData.Properties.Add(tag.Key, arrayValue.ToCommaDelimitedString());
                }
                else
                {
                    messageData.Properties.Add(tag.Key, tag.Value?.ToString());
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

            foreach (var tag in activityEvent.EnumerateTagObjects())
            {
                // TODO: see if these can be cached
                if (tag.Key == SemanticConventions.AttributeExceptionType)
                {
                    exceptionType = tag.Value?.ToString();
                    continue;
                }
                if (tag.Key == SemanticConventions.AttributeExceptionMessage)
                {
                    exceptionMessage = tag.Value?.ToString();
                    continue;
                }
                if (tag.Key == SemanticConventions.AttributeExceptionStacktrace)
                {
                    exceptionStackTrace = tag.Value?.ToString();
                    continue;
                }
            }

            if (exceptionMessage == null || exceptionType == null)
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

            TelemetryExceptionData exceptionData = new(Version, exceptions);

            return new MonitorBase
            {
                BaseType = "ExceptionData",
                BaseData = exceptionData,
            };
        }
    }
}
