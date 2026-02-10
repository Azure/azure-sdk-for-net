// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace Azure.Core.Diagnostics
{
    internal abstract class AzureEventSource: EventSource
    {
        private protected const string EventSourceRequiresUnreferencedCodeMessage = "EventSource will serialize the whole object graph. Trimmer will not safely handle this case because properties may be trimmed. This can be suppressed if the object is a primitive type";
        private protected const string EventSourceSuppressMessage = "Parameters to this method are primitive and are trimmer safe.";

        private const string SharedDataKey = "_AzureEventSourceNamesInUse";
        private static readonly HashSet<string> NamesInUse;

#pragma warning disable CA1810 // Use static initializer
        static AzureEventSource()
#pragma warning restore CA1810
        {
            // It's important for this code to run in a static constructor because runtime guarantees that
            // a single instance is executed at a time
            // This gives us a chance to store a shared hashset in the global dictionary without a race
            var namesInUse = AppDomain.CurrentDomain.GetData(SharedDataKey) as HashSet<string>;
            if (namesInUse == null)
            {
                namesInUse = new HashSet<string>();
                AppDomain.CurrentDomain.SetData(SharedDataKey, namesInUse);
            }

            NamesInUse = namesInUse;
        }

        private static readonly string[] MainEventSourceTraits =
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

        // The name de-duplication is required for the case where multiple versions of the same assembly are loaded
        // in different assembly load contexts
        private static string DeduplicateName(string eventSourceName)
        {
            try
            {
                lock (NamesInUse)
                {
                    // pick up existing EventSources that might not participate in this logic
                    foreach (var source in GetSources())
                    {
                        NamesInUse.Add(source.Name);
                    }

                    if (!NamesInUse.Contains(eventSourceName))
                    {
                        NamesInUse.Add(eventSourceName);
                        return eventSourceName;
                    }

                    int i = 1;
                    while (true)
                    {
                        var candidate = $"{eventSourceName}-{i}";
                        if (!NamesInUse.Contains(candidate))
                        {
                            NamesInUse.Add(candidate);
                            return candidate;
                        }

                        i++;
                    }
                }
            }
            // GetSources() is not supported on some platforms
            catch (NotImplementedException) { }

            return eventSourceName;
        }
    }
}