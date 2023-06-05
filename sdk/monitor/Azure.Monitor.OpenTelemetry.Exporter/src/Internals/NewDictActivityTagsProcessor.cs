// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal struct NewDictActivityTagsProcessor
    {
        private static readonly string[] semantics = {
            SemanticConventions.AttributeDbStatement,
            SemanticConventions.AttributeDbSystem,
            SemanticConventions.AttributeDbName,

            // required
            SemanticConventions.AttributeHttpMethod,
            SemanticConventions.AttributeHttpUrl,
            SemanticConventions.AttributeHttpStatusCode,
            SemanticConventions.AttributeHttpScheme,
            SemanticConventions.AttributeHttpHost,
            SemanticConventions.AttributeHttpHostPort,
            SemanticConventions.AttributeHttpTarget,
            SemanticConventions.AttributeHttpUserAgent,
            SemanticConventions.AttributeHttpClientIP,
            SemanticConventions.AttributeHttpRoute,

            // required
            SemanticConventions.AttributeAzureNameSpace,

            SemanticConventions.AttributePeerService,
            SemanticConventions.AttributeNetPeerName,
            SemanticConventions.AttributeNetPeerIp,
            SemanticConventions.AttributeNetPeerPort,
            SemanticConventions.AttributeNetTransport,
            SemanticConventions.AttributeNetHostIp,
            SemanticConventions.AttributeNetHostPort,
            SemanticConventions.AttributeNetHostName,
            SemanticConventions.AttributeComponent,
            "otel.status_code",
            "sampleRate",

            SemanticConventions.AttributeRpcService,
            // required
            SemanticConventions.AttributeRpcSystem,
            SemanticConventions.AttributeRpcStatus,

            // required
            SemanticConventions.AttributeFaasTrigger,
            SemanticConventions.AttributeFaasExecution,
            SemanticConventions.AttributeFaasColdStart,
            SemanticConventions.AttributeFaasDocumentCollection,
            SemanticConventions.AttributeFaasDocumentOperation,
            SemanticConventions.AttributeFaasDocumentTime,
            SemanticConventions.AttributeFaasDocumentName,
            SemanticConventions.AttributeFaasCron,
            SemanticConventions.AttributeFaasTime,

            SemanticConventions.AttributeEndpointAddress,
            // required
            SemanticConventions.AttributeMessagingSystem,
            SemanticConventions.AttributeMessagingDestination,
            SemanticConventions.AttributeMessagingDestinationKind,
            SemanticConventions.AttributeMessagingTempDestination,
            SemanticConventions.AttributeMessagingUrl
        };

        private static readonly HashSet<string> s_semanticsSet = new(semantics);

        private static IReadOnlyDictionary<string, OperationType> s_semanticTypeMapping = new Dictionary<string, OperationType>()
        {
            [SemanticConventions.AttributeHttpMethod] = OperationType.Http,
            [SemanticConventions.AttributeDbSystem] = OperationType.Db,
            [SemanticConventions.AttributeMessagingSystem] = OperationType.Messaging,
            [SemanticConventions.AttributeAzureNameSpace] = OperationType.Azure,
        };

        public AzMonList MappedTags;
        public AzMonList UnMappedTags;

        public OperationType activityType { get; private set; }

        public bool HasAzureNamespace { get; private set; } = false;

        public NewDictActivityTagsProcessor()
        {
            MappedTags = AzMonList.Initialize();
            UnMappedTags = AzMonList.Initialize();
        }

        public void CategorizeTags(Activity activity)
        {
            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                if (tag.Value == null)
                {
                    continue;
                }

                if (s_semanticsSet.Contains(tag.Key))
                {
                    AzMonList.Add(ref MappedTags, tag);
                    s_semanticTypeMapping.TryGetValue(tag.Key, out OperationType operationType);
                    activityType |= operationType;
                }
                else
                {
                    // If the tag value is an array, there is no need to check for semantics;
                    // directly add it to the Unmapped list.
                    if (tag.Value is Array array)
                    {
                        AzMonList.Add(ref UnMappedTags, new KeyValuePair<string, object?>(tag.Key, array.ToCommaDelimitedString()));
                        continue;
                    }

                    AzMonList.Add(ref UnMappedTags, tag);
                }
            }

            if ((activityType & OperationType.Azure) == OperationType.Azure)
            {
                HasAzureNamespace = true;
                activityType ^= OperationType.Azure;
            }
        }

        public void Return()
        {
            MappedTags.Return();
            UnMappedTags.Return();
        }
    }
}
