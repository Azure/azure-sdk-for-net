// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal struct ActivityTagsProcessor
    {
        private static readonly IReadOnlyDictionary<string, OperationType> s_semanticTypeMapping = new Dictionary<string, OperationType>()
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

            [SemanticConventions.AttributeAzureNameSpace] = OperationType.Azure,

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

        public OperationType activityType { get; private set; }

        public bool HasAzureNameSpace { get; private set; } = false;

        public ActivityTagsProcessor()
        {
            MappedTags = AzMonList.Initialize();
            UnMappedTags = AzMonList.Initialize();
        }

        public void CategorizeTags(Activity activity)
        {
            OperationType previousActivityType = OperationType.Unknown;
            OperationType _currentActivityType;

            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                if (tag.Value == null)
                {
                    continue;
                }

                // If the tag value is an array, there is no need to check for semantics; directly add it to the Unmapped list.
                if (tag.Value is Array array)
                {
                    AzMonList.Add(ref UnMappedTags, new KeyValuePair<string, object?>(tag.Key, array.ToCommaDelimitedString()));
                    continue;
                }

                // Check if tag.Key is not found in the s_semanticTypeMapping dictionary.
                // If not found, the tag is added to the UnMappedTags list and continues to the next iteration.
                if (!s_semanticTypeMapping.TryGetValue(tag.Key, out _currentActivityType))
                {
                    AzMonList.Add(ref UnMappedTags, tag);
                    continue;
                }

                // If the _currentActivityType is OperationType.Common, add the tag to the MappedTags list,
                // and then continue to the next iteration.
                if (_currentActivityType == OperationType.Common)
                {
                    AzMonList.Add(ref MappedTags, tag);
                    continue;
                }

                // Handle special case for Azure namespace to avoid unnecessary iteration by setting HasAzureNameSpace.
                // Execution is expected to be fast as the enum is checked.
                if (_currentActivityType == OperationType.Azure)
                {
                    HasAzureNameSpace = true;

                    // For Dependency telemetry, azure namespace set as type, so need to set in properties.
                    // Hence adding to MappedTags.
                    if (activity.GetTelemetryType() == TelemetryType.Dependency)
                    {
                        AzMonList.Add(ref MappedTags, tag);
                    }
                    else
                    {
                        // For request telemetry, azure namespace is not processed and should be included in the properties.
                        AzMonList.Add(ref UnMappedTags, tag);
                    }

                    continue;
                }

                // If the current and previous activity types are the same or the previous activity type is unknown (initialized value),
                // set activityType to _currentActivityType and add the tag to the MappedTags list.
                // This ensures that we track semantics of the same type. For example, if HTTP and SQL sematic tags are mixed,
                // whichever comes first in the tags list wins, and mapping happens for that type.
                if (_currentActivityType == previousActivityType || previousActivityType == OperationType.Unknown)
                {
                    activityType = _currentActivityType;
                    AzMonList.Add(ref MappedTags, tag);
                }
                else
                {
                    AzMonList.Add(ref UnMappedTags, tag);
                }

                previousActivityType = _currentActivityType;
            }
        }

        public void Return()
        {
            MappedTags.Return();
            UnMappedTags.Return();
        }
    }
}
