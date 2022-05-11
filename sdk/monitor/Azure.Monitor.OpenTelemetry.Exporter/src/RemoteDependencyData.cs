// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Azure.Core;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class RemoteDependencyData
    {
        // https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/semantic_conventions/database.md#connection-level-attributes
        internal static readonly HashSet<string> s_sqlDbs = new HashSet<string>() { "mssql" };

        public RemoteDependencyData(int version, Activity activity, ref TagEnumerationState monitorTags) : base(version)
        {
            string httpUrl = null;
            string dependencyName;

            if (monitorTags.activityType == OperationType.Http)
            {
                httpUrl = monitorTags.MappedTags.GetDependencyUrl();
                dependencyName = monitorTags.MappedTags.GetHttpDependencyName(httpUrl) ?? activity.DisplayName;
            }
            else
            {
                dependencyName = activity.DisplayName;
            }

            Name = dependencyName;
            Id = activity.Context.SpanId.ToHexString();
            Duration = activity.Duration.ToString("c", CultureInfo.InvariantCulture);
            Success = activity.GetStatus().StatusCode != StatusCode.Error;

            switch (monitorTags.activityType)
            {
                case OperationType.Http:
                    Data = httpUrl;
                    Target = monitorTags.MappedTags.GetDependencyTarget(OperationType.Http);
                    Type = "Http";
                    ResultCode = AzMonList.GetTagValue(ref monitorTags.MappedTags, SemanticConventions.AttributeHttpStatusCode)?.ToString() ?? "0";
                    break;
                case OperationType.Db:
                    var depDataAndType = AzMonList.GetTagValues(ref monitorTags.MappedTags, SemanticConventions.AttributeDbStatement, SemanticConventions.AttributeDbSystem);
                    Data = depDataAndType[0]?.ToString();
                    Target = monitorTags.MappedTags.GetDbDependencyTarget();
                    Type = s_sqlDbs.Contains(depDataAndType[1]?.ToString()) ? "SQL" : depDataAndType[1]?.ToString();
                    break;
                case OperationType.Rpc:
                    var depInfo = AzMonList.GetTagValues(ref monitorTags.MappedTags, SemanticConventions.AttributeRpcService, SemanticConventions.AttributeRpcSystem, SemanticConventions.AttributeRpcStatus);
                    Data = depInfo[0]?.ToString();
                    Type = depInfo[1]?.ToString();
                    ResultCode = depInfo[2]?.ToString();
                    break;
                case OperationType.Messaging:
                    depDataAndType = AzMonList.GetTagValues(ref monitorTags.MappedTags, SemanticConventions.AttributeMessagingUrl, SemanticConventions.AttributeMessagingSystem, SemanticConventions.AttributeMessagingDestination);
                    Data = depDataAndType[0]?.ToString();
                    Type = GetMessagingType(activity, depDataAndType[1]?.ToString());
                    // just for demo: null checks not included
                    Target = depDataAndType[0]?.ToString() + "/" + depDataAndType[2]?.ToString();
                    break;
            }

            if (Type == null && activity.Kind == ActivityKind.Internal && activity.Parent != null)
            {
                Type = "InProc";
            }

            Properties = new ChangeTrackingDictionary<string, string>();
            Measurements = new ChangeTrackingDictionary<string, double>();

            TraceHelper.AddActivityLinksToProperties(activity.Links, ref monitorTags.UnMappedTags);
            TraceHelper.AddPropertiesToTelemetry(Properties, ref monitorTags.UnMappedTags);
        }

        // Question: Can this be used as general mapping for all messaging systems?
        private static string GetMessagingType(Activity activity, string messagingSystem)
        {
            if (!string.IsNullOrEmpty(messagingSystem))
            {
                switch (activity.Kind)
                {
                    case ActivityKind.Producer:
                        return "Queue Message | " + messagingSystem;
                    case ActivityKind.Client:
                        return messagingSystem;
                    case ActivityKind.Internal:
                        return "InProc | " + messagingSystem;
                }
            }

            return null;
        }
    }
}
