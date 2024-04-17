// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace System.ClientModel.Internal;

internal abstract class ClientEventSource : EventSource
{
    private const string SharedDataKey = "_ClientModelEventSourceNamesInUse";
    private static readonly HashSet<string> NamesInUse;

#pragma warning disable CA1810 // Use static initializer
    static ClientEventSource()
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

    protected ClientEventSource(string eventSourceName) : base(eventSourceName)
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
