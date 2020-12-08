// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using OpenTelemetry.Trace;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal struct TagEnumerationState : IActivityEnumerator<KeyValuePair<string, object>>
    {
        private static readonly IReadOnlyDictionary<string, PartBType> Part_B_Mapping = new Dictionary<string, PartBType>()
        {
            [SemanticConventions.AttributeDbStatement] = PartBType.Db,
            [SemanticConventions.AttributeDbSystem] = PartBType.Db,

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

            [SemanticConventions.AttributeRpcService] = PartBType.Rpc,
            [SemanticConventions.AttributeRpcSystem] = PartBType.Rpc,
            [SemanticConventions.AttributeRpcStatus] = PartBType.Rpc,

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
            [SemanticConventions.AttributeMessageBusDestination] = PartBType.Azure,

            [SemanticConventions.AttributeEndpointAddress] = PartBType.Messaging,
            [SemanticConventions.AttributeMessagingSystem] = PartBType.Messaging,
            [SemanticConventions.AttributeMessagingDestination] = PartBType.Messaging,
            [SemanticConventions.AttributeMessagingDestinationKind] = PartBType.Messaging,
            [SemanticConventions.AttributeMessagingTempDestination] = PartBType.Messaging,
            [SemanticConventions.AttributeMessagingUrl] = PartBType.Messaging
        };

        public AzMonList PartBTags;
        public AzMonList PartCTags;

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

                AzMonList.Add(ref PartCTags, new KeyValuePair<string, object>(activityTag.Key, sw.ToString()));
                return true;
            }

            if (!Part_B_Mapping.TryGetValue(activityTag.Key, out tempActivityType))
            {
                AzMonList.Add(ref PartCTags, activityTag);
                return true;
            }

            if (activityType == PartBType.Unknown || activityType == PartBType.Common)
            {
                activityType = tempActivityType;
            }

            if (tempActivityType == activityType || tempActivityType == PartBType.Common)
            {
                AzMonList.Add(ref PartBTags, activityTag);
            }
            else
            {
                AzMonList.Add(ref PartCTags, activityTag);
            }

            return true;
        }
    }
}
