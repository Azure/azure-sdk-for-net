// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal struct ActivityTagsProcessorNew
    {
        internal static readonly HashSet<string> s_semantics = new HashSet<string>{
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
            SemanticConventions.AttributeMessagingUrl,

            // Others
            SemanticConventions.AttributeEnduserId
        };

        public AzMonList MappedTags;

        public OperationType activityType { get; private set; }

        public string? AzureNamespace { get; private set; } = null;

        public string? EndUserId { get; private set; } = null;

        public ActivityTagsProcessorNew()
        {
            MappedTags = AzMonList.Initialize();
        }

        public void CategorizeTags(Activity activity)
        {
            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                if (tag.Value == null)
                {
                    continue;
                }

                if (s_semantics.Contains(tag.Key))
                {
                    switch (tag.Key)
                    {
                        case SemanticConventions.AttributeHttpMethod:
                            activityType = OperationType.Http;
                            break;
                        case SemanticConventions.AttributeDbSystem:
                            activityType = OperationType.Db;
                            break;
                        case SemanticConventions.AttributeMessagingSystem:
                            activityType = OperationType.Messaging;
                            break;
                        case SemanticConventions.AttributeAzureNameSpace:
                            AzureNamespace = tag.Value.ToString();
                            break;
                        case SemanticConventions.AttributeEnduserId:
                            EndUserId = tag.Value.ToString();
                            continue;
                    }

                    AzMonList.Add(ref MappedTags, tag);
                }
            }
        }

        public void Return()
        {
            MappedTags.Return();
        }
    }
}
