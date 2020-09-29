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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

            string kind = null;

            switch (activityKind)
            {
                case ActivityKind.Internal:
                    kind = "InProc";
                    break;
                case ActivityKind.Producer:
                    kind = "Queue Message";
                    break;
                default:
                    break;
            }

            switch (component)
            {
                case "eventhubs":
                case "Microsoft.EventHub":
                    type = kind == null ? RemoteDependencyConstants.AzureEventHubs : string.Concat(kind, " | ", RemoteDependencyConstants.AzureEventHubs);
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
                    type = kind == null ? component : string.Concat(kind, " | ", component);
                    break;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetMessagingUrl(Dictionary<string, string> tags)
        {
            if (tags == null)
            {
                return null;
            }

            tags.TryGetValue(SemanticConventions.AttributeMessagingUrl, out var url);
            return url;
        }
    }
}
