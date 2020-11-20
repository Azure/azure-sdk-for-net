// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using OpenTelemetry.Trace;
using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Models;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    /// <summary>
    /// Part B are the Azure Monitor domain specific schemas.
    /// These properties are unique to individual telemetry types.
    /// For example, Request telemetry has Url and Message telemetry has Severity Level.
    /// </summary>
    internal class TelemetryPartB
    {
        internal static RequestData GetRequestData(Activity activity)
        {
            string url = null;
            string urlAuthority = null;
            var monitorTags = EnumerateActivityTags(activity);

            switch (monitorTags.activityType)
            {
                case PartBType.Http:
                    monitorTags.PartBTags.GenerateUrlAndAuthority(out url, out urlAuthority);
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
                Source = urlAuthority
            };

            AddPropertiesToTelemetry(request.Properties, ref monitorTags.PartCTags);

            return request;
        }

        internal static RemoteDependencyData GetRemoteDependencyData(Activity activity)
        {
            var monitorTags = EnumerateActivityTags(activity);

            var dependency = new RemoteDependencyData(2, activity.DisplayName, activity.Duration.ToString("c", CultureInfo.InvariantCulture))
            {
                Id = activity.Context.SpanId.ToHexString(),
                Success = activity.GetStatus() != Status.Error
            };

            switch (monitorTags.activityType)
            {
                case PartBType.Http:
                    monitorTags.PartBTags.GenerateUrlAndAuthority(out var url, out var urlAuthority);
                    dependency.Data = url;
                    dependency.Target = urlAuthority;
                    dependency.Type = "Http";
                    dependency.ResultCode = AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeHttpStatusCode)?.ToString() ?? "0";
                    break;
                case PartBType.Db:
                    var depDataAndType = AzMonList.GetTagValues(ref monitorTags.PartBTags, SemanticConventions.AttributeDbStatement, SemanticConventions.AttributeDbSystem);
                    dependency.Data = depDataAndType[0]?.ToString();
                    dependency.Type = depDataAndType[1]?.ToString();
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

        private static TagEnumerationState EnumerateActivityTags(Activity activity)
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            activity.EnumerateTags(ref monitorTags);
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
    }
}
