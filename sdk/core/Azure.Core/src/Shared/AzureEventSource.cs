// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Azure.Core.Diagnostics
{
    internal abstract class AzureEventSource: EventSource
    {
        private static string[] MainEventSourceTraits =
        {
            AzureEventSourceListener.TraitName,
            AzureEventSourceListener.TraitValue
        };

        protected AzureEventSource(string eventSourceName): base(
            DeduplicateName(eventSourceName),
            EventSourceSettings.Default,
            MainEventSourceTraits
        )
        {
        }

        private static string DeduplicateName(string eventSourceName)
        {
            HashSet<string> namesInUse = new();
            foreach (var source in GetSources())
            {
                namesInUse.Add(source.Name);
            }

            if (!namesInUse.Contains(eventSourceName))
            {
                return eventSourceName;
            }

            int i = 1;
            while (true)
            {
                var candidate = $"{eventSourceName}-{i}";
                if (!namesInUse.Contains(candidate))
                {
                    return candidate;
                }
                i++;
            }
        }
    }
}