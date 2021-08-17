// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

using Microsoft.Extensions.Logging;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using System.Text;
using System.Linq;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// Part B are the Azure Monitor domain specific schemas.
    /// These properties are unique to individual telemetry types.
    /// For example, Request telemetry has Url and Message telemetry has Severity Level.
    /// </summary>
    internal class TelemetryPartB
    {
        private const int MaxlinksAllowed = 100;

        // https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/semantic_conventions/database.md#connection-level-attributes
        internal static readonly HashSet<string> SqlDbs = new HashSet<string>() {"mssql"};

        internal static RequestData GetRequestData(Activity activity)
        {
            string url = null;
            var monitorTags = EnumerateActivityTags(activity);

            AddActivityLinksToPartCTags(activity.Links, ref monitorTags.PartCTags);

            switch (monitorTags.activityType)
            {
                case PartBType.Http:
                    url = monitorTags.PartBTags.GetRequestUrl();
                    break;
                case PartBType.Messaging:
                    url = AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeMessagingUrl)?.ToString();
                    break;
            }

            var statusCode = AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeHttpStatusCode)?.ToString() ?? "0";
            var success = activity.GetStatus() != Status.Error;
            var request = new RequestData(2, activity.Context.SpanId.ToHexString(), activity.Duration.ToString("c", CultureInfo.InvariantCulture), success, statusCode)
            {
                Name = activity.DisplayName,
                Url = url,
            };

            AddPropertiesToTelemetry(request.Properties, ref monitorTags.PartCTags);

            return request;
        }

        internal static RemoteDependencyData GetRemoteDependencyData(Activity activity)
        {
            var monitorTags = EnumerateActivityTags(activity);

            AddActivityLinksToPartCTags(activity.Links, ref monitorTags.PartCTags);

            var dependency = new RemoteDependencyData(2, activity.DisplayName, activity.Duration.ToString("c", CultureInfo.InvariantCulture))
            {
                Id = activity.Context.SpanId.ToHexString(),
                Success = activity.GetStatus() != Status.Error
            };

            switch (monitorTags.activityType)
            {
                case PartBType.Http:
                    dependency.Data = monitorTags.PartBTags.GetDependencyUrl();
                    dependency.Target = monitorTags.PartBTags.GetDependencyTarget(PartBType.Http);
                    dependency.Type = "Http";
                    dependency.ResultCode = AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeHttpStatusCode)?.ToString() ?? "0";
                    break;
                case PartBType.Db:
                    var depDataAndType = AzMonList.GetTagValues(ref monitorTags.PartBTags, SemanticConventions.AttributeDbStatement, SemanticConventions.AttributeDbSystem);
                    dependency.Data = depDataAndType[0]?.ToString();
                    dependency.Target = monitorTags.PartBTags.GetDependencyTarget(PartBType.Db);
                    dependency.Type = SqlDbs.Contains(depDataAndType[1]?.ToString()) ? "SQL" : depDataAndType[1]?.ToString();
                    break;
                case PartBType.Rpc:
                    var depInfo = AzMonList.GetTagValues(ref monitorTags.PartBTags, SemanticConventions.AttributeRpcService, SemanticConventions.AttributeRpcSystem, SemanticConventions.AttributeRpcStatus);
                    dependency.Data = depInfo[0]?.ToString();
                    dependency.Type = depInfo[1]?.ToString();
                    dependency.ResultCode = depInfo[2]?.ToString();
                    break;
                case PartBType.Messaging:
                    depDataAndType = AzMonList.GetTagValues(ref monitorTags.PartBTags, SemanticConventions.AttributeMessagingUrl, SemanticConventions.AttributeMessagingSystem);
                    dependency.Data = depDataAndType[0]?.ToString();
                    dependency.Type = depDataAndType[1]?.ToString();
                    break;
            }

            AddPropertiesToTelemetry(dependency.Properties, ref monitorTags.PartCTags);

            return dependency;
        }

        internal static MessageData GetMessageData(LogRecord logRecord)
        {
            return new MessageData(version: 2, message: logRecord.State.ToString())
            {
                SeverityLevel = GetSeverityLevel(logRecord.LogLevel),
            };
        }

        private static TagEnumerationState EnumerateActivityTags(Activity activity)
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            monitorTags.ForEach(activity.TagObjects);
            return monitorTags;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void AddPropertiesToTelemetry(IDictionary<string, string> destination, ref AzMonList PartCTags)
        {
            // TODO: Iterate only interested fields. Ref: https://github.com/Azure/azure-sdk-for-net/pull/14254#discussion_r470907560
            for (int i = 0; i < PartCTags.Length; i++)
            {
                destination.Add(PartCTags[i].Key, PartCTags[i].Value?.ToString());
            }
        }

        /// <summary>
        /// Converts Activity Links to custom property with key as _MS.links.
        /// Value will be a JSON string formatted as [{"operation_Id":"{TraceId}","id":"{SpanId}"}].
        /// </summary>
        private static void AddActivityLinksToPartCTags(IEnumerable<ActivityLink> links, ref AzMonList PartCTags)
        {
            string msLinks = "_MS.links";
            // max number of links that can fit in this json formatted string is 107. it is based on assumption that traceid and spanid will be of fixed length.
            // Keeping max at 100 for now.
            int maxLinks = MaxlinksAllowed;

            if (links != null && links.Any())
            {
                var linksJson = new StringBuilder();
                linksJson.Append('[');
                foreach (var link in links)
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
                        if (MaxlinksAllowed < links.Count())
                        {
                            AzureMonitorExporterEventSource.Log.Write($"ActivityLinksIgnored{EventLevelSuffix.Informational}", $"Max count of {MaxlinksAllowed} has reached.");
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

                AzMonList.Add(ref PartCTags, new KeyValuePair<string, object>(msLinks, linksJson.ToString()));
            }
        }

        /// <summary>
        /// Converts the <see cref="LogRecord.LogLevel"/> into corresponding Azure Monitor <see cref="SeverityLevel"/>.
        /// </summary>
        private static SeverityLevel GetSeverityLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                    return SeverityLevel.Critical;
                case LogLevel.Error:
                    return SeverityLevel.Error;
                case LogLevel.Warning:
                    return SeverityLevel.Warning;
                case LogLevel.Information:
                    return SeverityLevel.Information;
                case LogLevel.Debug:
                case LogLevel.Trace:
                default:
                    return SeverityLevel.Verbose;
            }
        }
    }
}
