// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal class ComponentHelper
    {
        private const string ehInProcKind = "InProc | Azure Event Hubs";
        private const string ehQueueKind = "Queue Message | Azure Event Hubs";
        private const string inProcKind = "InProc | ";
        private const string queueKind = "Queue Message | ";

        internal static void ExtractComponentProperties(Dictionary<string, string> tags, ActivityKind activityKind, out string type, out string sourceOrTarget)
        {
            sourceOrTarget = null;
            type = null;

            if (!tags.TryGetValue(SemanticConventions.AttributeAzureNameSpace, out var component))
            {
                tags.TryGetValue(SemanticConventions.AttributeComponent, out component);
            }

            if (component == null)
            {
                return;
            }

            switch (component)
            {
                case "eventhubs":
                case "Microsoft.EventHub":
                    type = activityKind switch
                    {
                        ActivityKind.Internal => ehInProcKind,
                        ActivityKind.Producer => ehQueueKind,
                        _ => RemoteDependencyConstants.AzureEventHubs,
                    };
                    tags.TryGetValue(SemanticConventions.AttributeEndpointAddress, out var endpoint);
                    tags.TryGetValue(SemanticConventions.AttributeMessageBusDestination, out var queueName);

                    if (endpoint == null || queueName == null)
                    {
                        return;
                    }

                    // Target uniquely identifies the resource, we use both: queueName and endpoint
                    // with schema used for SQL-dependencies
                    string separator = "/";
                    if (endpoint.EndsWith(separator, StringComparison.Ordinal))
                    {
                        separator = string.Empty;
                    }

                    sourceOrTarget = string.Concat(endpoint, separator, queueName);

                    break;
                default:
                    type = activityKind switch
                    {
                        ActivityKind.Internal => inProcKind + component,
                        ActivityKind.Producer => queueKind + component,
                        _ => component,
                    };
                    break;
            }
        }
    }
}
