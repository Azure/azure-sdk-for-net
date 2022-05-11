// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    public class AzureSDKProcessor : BaseProcessor<Activity>
    {
        public override void OnEnd(Activity activity)
        {
            // Not perf friendly but shows the concept
            // Can be fixed for final PR
            foreach (var tag in activity.Tags)
            {
                // Need to check what all azure messaging systems come under this mapping
                // Right now only checking for eventhub.
                if (tag.Key == "az.namespace" && tag.Value == "Microsoft.EventHub")
                {
                    activity.SetTag(SemanticConventions.AttributeMessagingSystem, tag.Value?.ToString());
                    AddOtelSemanticConventions(activity);
                    break;
                }
            }
        }

        private static void AddOtelSemanticConventions(Activity activity)
        {
            foreach (var tag in activity.Tags)
            {
                if (tag.Key == "message_bus.destination")
                {
                    activity?.SetTag(SemanticConventions.AttributeMessagingDestination, tag.Value?.ToString());
                }

                if (tag.Key == "peer.address")
                {
                    activity?.SetTag(SemanticConventions.AttributeMessagingUrl, tag.Value?.ToString());
                }
            }
        }
    }
}
