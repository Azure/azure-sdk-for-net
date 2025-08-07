// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.DataCollection;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal struct LiveMetricsTagsProcessor
    {
        private static readonly HashSet<string> s_semanticsSet = new()
        {
            SemanticConventions.AttributeDbStatement,
            SemanticConventions.AttributeDbSystem,
            SemanticConventions.AttributeDbName,
            SemanticConventions.AttributePeerService,

            // required - HTTP V2
            SemanticConventions.AttributeHttpRequestMethod,
            SemanticConventions.AttributeHttpResponseStatusCode,
            SemanticConventions.AttributeUrlFull,

            // required - Messaging
            SemanticConventions.AttributeMessagingSystem,
        };

        public AzMonList Tags;

        public LiveMetricsTagsProcessor()
        {
            Tags = AzMonList.Initialize();
        }

        public OperationType ActivityType { get; set; }

        public void CategorizeTagsAndAddProperties(Activity activity, DocumentIngress documentIngress)
        {
            int tagCount = 0;

            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                if (tag.Value == null)
                {
                    continue;
                }

                if (s_semanticsSet.Contains(tag.Key))
                {
                    switch (tag.Key)
                    {
                        case SemanticConventions.AttributeHttpRequestMethod:
                            ActivityType = OperationType.Http;
                            break;
                        case SemanticConventions.AttributeDbSystem:
                            ActivityType = OperationType.Db;
                            break;
                        case SemanticConventions.AttributeMessagingSystem:
                            ActivityType = OperationType.Messaging;
                            break;
                    }

                    AzMonList.Add(ref Tags, tag);
                }
                else if (tagCount < DocumentHelper.MaxPropertiesCount)
                {
                    documentIngress.Properties.Add(new KeyValuePairString(tag.Key, tag.Value.ToString()));
                    tagCount++;
                }
            }
        }

        public readonly void Return()
        {
            Tags.Return();
        }
    }
}
