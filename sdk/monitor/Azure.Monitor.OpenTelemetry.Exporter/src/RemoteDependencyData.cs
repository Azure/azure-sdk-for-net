// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        internal static readonly HashSet<string> SqlDbs = new HashSet<string>() { "mssql" };

        public RemoteDependencyData(int version, Activity activity, ref TagEnumerationState monitorTags) : base(version)
        {
            string httpUrl = null;
            string dependencyName;

            if (monitorTags.activityType == PartBType.Http)
            {
                httpUrl = monitorTags.PartBTags.GetDependencyUrl();
                dependencyName = monitorTags.PartBTags.GetHttpDependencyName(httpUrl) ?? activity.DisplayName;
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
                case PartBType.Http:
                    Data = httpUrl;
                    Target = monitorTags.PartBTags.GetDependencyTarget(PartBType.Http);
                    Type = "Http";
                    ResultCode = AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeHttpStatusCode)?.ToString() ?? "0";
                    break;
                case PartBType.Db:
                    var depDataAndType = AzMonList.GetTagValues(ref monitorTags.PartBTags, SemanticConventions.AttributeDbStatement, SemanticConventions.AttributeDbSystem);
                    Data = depDataAndType[0]?.ToString();
                    Target = monitorTags.PartBTags.GetDbDependencyTarget();
                    Type = SqlDbs.Contains(depDataAndType[1]?.ToString()) ? "SQL" : depDataAndType[1]?.ToString();
                    break;
                case PartBType.Rpc:
                    var depInfo = AzMonList.GetTagValues(ref monitorTags.PartBTags, SemanticConventions.AttributeRpcService, SemanticConventions.AttributeRpcSystem, SemanticConventions.AttributeRpcStatus);
                    Data = depInfo[0]?.ToString();
                    Type = depInfo[1]?.ToString();
                    ResultCode = depInfo[2]?.ToString();
                    break;
                case PartBType.Messaging:
                    depDataAndType = AzMonList.GetTagValues(ref monitorTags.PartBTags, SemanticConventions.AttributeMessagingUrl, SemanticConventions.AttributeMessagingSystem);
                    Data = depDataAndType[0]?.ToString();
                    Type = depDataAndType[1]?.ToString();
                    break;
            }

            if (activity.Kind == ActivityKind.Internal && activity.Parent != null)
            {
                Type = "InProc";
            }

            Properties = new ChangeTrackingDictionary<string, string>();
            Measurements = new ChangeTrackingDictionary<string, double>();

            TraceHelper.AddActivityLinksToPartCTags(activity.Links, ref monitorTags.PartCTags);
            TraceHelper.AddPropertiesToTelemetry(Properties, ref monitorTags.PartCTags);
        }
    }
}
