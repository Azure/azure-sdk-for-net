// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal static class TraceHelper
    {
        private const int version = 2;
        private const int MaxlinksAllowed = 100;

        internal static List<TelemetryItem> OtelToAzureMonitorTrace(Batch<Activity> batchActivity, string roleName, string roleInstance, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var activity in batchActivity)
            {
                MonitorBase telemetryData = new MonitorBase();
                var monitorTags = TraceHelper.EnumerateActivityTags(activity);
                telemetryItem = new TelemetryItem(activity, ref monitorTags);
                telemetryItem.InstrumentationKey = instrumentationKey;
                telemetryItem.SetResource(roleName, roleInstance);

                switch (activity.GetTelemetryType())
                {
                    case TelemetryType.Request:
                        telemetryData.BaseType = "RequestData";
                        telemetryData.BaseData = new RequestData(version, activity, ref monitorTags);
                        break;
                    case TelemetryType.Dependency:
                        telemetryData.BaseType = "RemoteDependencyData";
                        telemetryData.BaseData = new RemoteDependencyData(version, activity, ref monitorTags);
                        break;
                }

                telemetryItem.Data = telemetryData;
                telemetryItems.Add(telemetryItem);
            }

            return telemetryItems;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void AddPropertiesToTelemetry(IDictionary<string, string> destination, ref AzMonList PartCTags)
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
        internal static void AddActivityLinksToPartCTags(IEnumerable<ActivityLink> links, ref AzMonList PartCTags)
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

        internal static TagEnumerationState EnumerateActivityTags(Activity activity)
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            monitorTags.ForEach(activity.TagObjects);
            return monitorTags;
        }
    }
}
