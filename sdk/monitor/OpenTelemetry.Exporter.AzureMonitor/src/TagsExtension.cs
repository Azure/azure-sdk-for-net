// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal static class TagsExtension
    {
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
            [SemanticConventions.AttributeHttpTarget] = PartBType.Http,

            [SemanticConventions.AttributeNetPeerName] = PartBType.Net,
            [SemanticConventions.AttributeNetPeerIp] = PartBType.Net,
            [SemanticConventions.AttributeNetPeerPort] = PartBType.Net,
            [SemanticConventions.AttributeNetTransport] = PartBType.Net,
            [SemanticConventions.AttributeNetHostIp] = PartBType.Net,
            [SemanticConventions.AttributeNetHostPort] = PartBType.Net,
            [SemanticConventions.AttributeNetHostName] = PartBType.Net,

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

            [SemanticConventions.AttributeMessagingSystem] = PartBType.Messaging,
            [SemanticConventions.AttributeMessagingDestination] = PartBType.Messaging,
            [SemanticConventions.AttributeMessagingDestinationKind] = PartBType.Messaging,
            [SemanticConventions.AttributeMessagingTempDestination] = PartBType.Messaging,
            [SemanticConventions.AttributeMessagingUrl] = PartBType.Messaging
        };

        internal static Dictionary<string, string> ToAzureMonitorTags(this IEnumerable<KeyValuePair<string, string>> tags, out PartBType activityType)
        {
            Dictionary<string, string> partBTags = new Dictionary<string, string>();
            activityType = PartBType.Unknown;

            foreach (var entry in tags)
            {
                // TODO: May need to store unknown to write to properties as Part C
                if ((activityType == PartBType.Unknown || activityType == PartBType.Net) && !Part_B_Mapping.TryGetValue(entry.Key, out activityType))
                {
                    if (activityType == PartBType.Net)
                    {
                        partBTags.Add(entry.Key, entry.Value);
                        activityType = PartBType.Unknown;
                    }

                    continue;
                }

                if (Part_B_Mapping.TryGetValue(entry.Key, out var tempActivityType) && (tempActivityType == activityType || tempActivityType == PartBType.Net))
                {
                    partBTags.Add(entry.Key, entry.Value);
                }
            }

            return partBTags;
        }

    }
}
