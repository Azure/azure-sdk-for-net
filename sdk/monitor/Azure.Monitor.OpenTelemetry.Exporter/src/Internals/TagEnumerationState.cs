// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal struct TagEnumerationState
    {
        private static readonly IReadOnlyDictionary<string, OperationType> s_part_B_Mapping = new Dictionary<string, OperationType>()
        {
            [SemanticConventions.AttributeDbStatement] = OperationType.Db,
            [SemanticConventions.AttributeDbSystem] = OperationType.Db,
            [SemanticConventions.AttributeDbName] = OperationType.Db,

            [SemanticConventions.AttributeHttpMethod] = OperationType.Http,
            [SemanticConventions.AttributeHttpUrl] = OperationType.Http,
            [SemanticConventions.AttributeHttpStatusCode] = OperationType.Http,
            [SemanticConventions.AttributeHttpScheme] = OperationType.Http,
            [SemanticConventions.AttributeHttpHost] = OperationType.Http,
            [SemanticConventions.AttributeHttpHostPort] = OperationType.Http,
            [SemanticConventions.AttributeHttpTarget] = OperationType.Http,
            [SemanticConventions.AttributeHttpUserAgent] = OperationType.Http,
            [SemanticConventions.AttributeHttpClientIP] = OperationType.Http,
            [SemanticConventions.AttributeHttpRoute] = OperationType.Http,

            [SemanticConventions.AttributePeerService] = OperationType.Common,
            [SemanticConventions.AttributeNetPeerName] = OperationType.Common,
            [SemanticConventions.AttributeNetPeerIp] = OperationType.Common,
            [SemanticConventions.AttributeNetPeerPort] = OperationType.Common,
            [SemanticConventions.AttributeNetTransport] = OperationType.Common,
            [SemanticConventions.AttributeNetHostIp] = OperationType.Common,
            [SemanticConventions.AttributeNetHostPort] = OperationType.Common,
            [SemanticConventions.AttributeNetHostName] = OperationType.Common,
            [SemanticConventions.AttributeComponent] = OperationType.Common,
            ["otel.status_code"] = OperationType.Common,
            ["sampleRate"] = OperationType.Common,

            [SemanticConventions.AttributeRpcService] = OperationType.Rpc,
            [SemanticConventions.AttributeRpcSystem] = OperationType.Rpc,
            [SemanticConventions.AttributeRpcStatus] = OperationType.Rpc,

            [SemanticConventions.AttributeFaasTrigger] = OperationType.FaaS,
            [SemanticConventions.AttributeFaasExecution] = OperationType.FaaS,
            [SemanticConventions.AttributeFaasColdStart] = OperationType.FaaS,
            [SemanticConventions.AttributeFaasDocumentCollection] = OperationType.FaaS,
            [SemanticConventions.AttributeFaasDocumentOperation] = OperationType.FaaS,
            [SemanticConventions.AttributeFaasDocumentTime] = OperationType.FaaS,
            [SemanticConventions.AttributeFaasDocumentName] = OperationType.FaaS,
            [SemanticConventions.AttributeFaasCron] = OperationType.FaaS,
            [SemanticConventions.AttributeFaasTime] = OperationType.FaaS,

            [SemanticConventions.AttributeEndpointAddress] = OperationType.Messaging,
            [SemanticConventions.AttributeMessagingSystem] = OperationType.Messaging,
            [SemanticConventions.AttributeMessagingDestination] = OperationType.Messaging,
            [SemanticConventions.AttributeMessagingDestinationKind] = OperationType.Messaging,
            [SemanticConventions.AttributeMessagingTempDestination] = OperationType.Messaging,
            [SemanticConventions.AttributeMessagingUrl] = OperationType.Messaging
        };

        public AzMonList MappedTags;
        public AzMonList UnMappedTags;

        private OperationType _tempActivityType;
        public OperationType activityType;

        public void ForEach(IEnumerable<KeyValuePair<string, object?>> activityTags)
        {
            foreach (KeyValuePair<string, object?> activityTag in activityTags)
            {
                if (activityTag.Value == null)
                {
                    continue;
                }

                if (activityTag.Value is Array array)
                {
                    AzMonList.Add(ref UnMappedTags, new KeyValuePair<string, object?>(activityTag.Key, array.ToCommaDelimitedString()));
                    continue;
                }

                if (!s_part_B_Mapping.TryGetValue(activityTag.Key, out _tempActivityType))
                {
                    AzMonList.Add(ref UnMappedTags, activityTag);
                    continue;
                }

                if (activityType == OperationType.Unknown || activityType == OperationType.Common)
                {
                    activityType = _tempActivityType;
                }

                if (_tempActivityType == activityType || _tempActivityType == OperationType.Common)
                {
                    AzMonList.Add(ref MappedTags, activityTag);
                }
                else
                {
                    AzMonList.Add(ref UnMappedTags, activityTag);
                }
            }
        }

        public void Return()
        {
            MappedTags.Return();
            UnMappedTags.Return();
        }
    }
}
