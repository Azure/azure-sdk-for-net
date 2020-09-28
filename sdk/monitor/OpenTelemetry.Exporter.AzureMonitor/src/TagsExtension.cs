// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

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
            [SemanticConventions.AttributeHttpHostPort] = PartBType.Http,
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

        internal static PartBType ToAzureMonitorTags(this IEnumerable<KeyValuePair<string, object>> tagObjects, out Dictionary<string, string> partBTags, out Dictionary<string, string> partCTags)
        {
            if (tagObjects == null)
            {
                partBTags = null;
                partCTags = null;
                return PartBType.Unknown;
            }

            PartBType tempActivityType;
            PartBType activityType = PartBType.Unknown;
            partBTags = new Dictionary<string, string>();
            partCTags = new Dictionary<string, string>();

            foreach (var entry in tagObjects)
            {
                if (entry.Value is Array array)
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

                    partCTags.Add(entry.Key, sw.ToString());

                    continue;
                }

                if (entry.Value != null)
                {
                    if (!Part_B_Mapping.TryGetValue(entry.Key, out tempActivityType))
                    {
                        partCTags.Add(entry.Key, entry.Value.ToString());
                        continue;
                    }

                    if (activityType == PartBType.Unknown || activityType == PartBType.Net)
                    {
                        activityType = tempActivityType;
                    }

                    if (tempActivityType == activityType || tempActivityType == PartBType.Net)
                    {
                        partBTags.Add(entry.Key, entry.Value.ToString());
                    }
                    else
                    {
                        partCTags.Add(entry.Key, entry.Value.ToString());
                    }
                }
            }

            return activityType;
        }
    }
}
