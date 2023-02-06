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

        [NonEvent]
        protected unsafe void WriteEvent(int eventId, string? arg0, double arg1)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            {
                EventData* data = stackalloc EventData[2];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)(&arg1);
                data[1].Size = 8;
                WriteEventCore(eventId, 2, data);
            }
        }

        [NonEvent]
        protected unsafe void WriteEvent(int eventId, string? arg0, byte[]? arg1)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            {
                EventData* data = stackalloc EventData[3];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;

                if (arg1 == null || arg1.Length == 0)
                {
                    var blobSize = 0;
                    data[1].DataPointer = (IntPtr)(&blobSize);
                    data[1].Size = 4;
                    data[2].DataPointer = (IntPtr)(&blobSize); // valid address instead of empty content
                    data[2].Size = 0;
                }
                else
                {
                    var blobSize = arg1.Length;
                    fixed (byte* blob = &arg1[0])
                    {
                        data[1].DataPointer = (IntPtr)(&blobSize);
                        data[1].Size = 4;
                        data[2].DataPointer = (IntPtr)blob;
                        data[2].Size = blobSize;
                    }
                }

                WriteEventCore(eventId, 3, data);
            }
        }

        [NonEvent]
        protected unsafe void WriteEvent(int eventId, string? arg0, int arg1, double arg2)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            {
                EventData* data = stackalloc EventData[3];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)(&arg1);
                data[1].Size = 4;
                data[2].DataPointer = (IntPtr)(&arg2);
                data[2].Size = 8;
                WriteEventCore(eventId, 3, data);
            }
        }

        [NonEvent]
        protected unsafe void WriteEvent(int eventId, string? arg0, int arg1, string? arg2)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            arg2 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            fixed (char* arg2Ptr = arg2)
            {
                EventData* data = stackalloc EventData[3];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)(&arg1);
                data[1].Size = 4;
                data[2].DataPointer = (IntPtr)arg2Ptr;
                data[2].Size = (arg2.Length + 1) * 2;
                WriteEventCore(eventId, 3, data);
            }
        }

        [NonEvent]
        protected unsafe void WriteEvent(int eventId, string? arg0, int arg1, byte[]? arg2)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            {
                EventData* data = stackalloc EventData[4];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)(&arg1);
                data[1].Size = 4;

                if (arg2 == null || arg2.Length == 0)
                {
                    var blobSize = 0;
                    data[2].DataPointer = (IntPtr)(&blobSize);
                    data[2].Size = 4;
                    data[3].DataPointer = (IntPtr)(&blobSize); // valid address instead of empty content
                    data[3].Size = 0;
                }
                else
                {
                    var blobSize = arg2.Length;
                    fixed (byte* blob = &arg2[0])
                    {
                        data[2].DataPointer = (IntPtr)(&blobSize);
                        data[2].Size = 4;
                        data[3].DataPointer = (IntPtr)blob;
                        data[3].Size = blobSize;
                    }
                }

                WriteEventCore(eventId, 4, data);
            }
        }

        [NonEvent]
        protected unsafe void WriteEvent(int eventId, string? arg0, string? arg1, string? arg2, int arg3)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            arg1 ??= string.Empty;
            arg2 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            {
                EventData* data = stackalloc EventData[4];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)arg1Ptr;
                data[1].Size = (arg1.Length + 1) * 2;
                data[2].DataPointer = (IntPtr)arg2Ptr;
                data[2].Size = (arg2.Length + 1) * 2;
                data[3].DataPointer = (IntPtr)(&arg3);
                data[3].Size = 4;
                WriteEventCore(eventId, 4, data);
            }
        }

        [NonEvent]
        protected unsafe void WriteEvent(int eventId, string? arg0, int arg1, string? arg2, string? arg3, double arg4)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            arg2 ??= string.Empty;
            arg3 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            {
                EventData* data = stackalloc EventData[5];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)(&arg1);
                data[1].Size = 4;
                data[2].DataPointer = (IntPtr)arg2Ptr;
                data[2].Size = (arg2.Length + 1) * 2;
                data[3].DataPointer = (IntPtr)arg3Ptr;
                data[3].Size = (arg3.Length + 1) * 2;
                data[4].DataPointer = (IntPtr)(&arg4);
                data[4].Size = 8;
                WriteEventCore(eventId, 5, data);
            }
        }

        [NonEvent]
        protected unsafe void WriteEvent(int eventId, string? arg0, string? arg1, string? arg2, string? arg3, string? arg4)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            arg1 ??= string.Empty;
            arg2 ??= string.Empty;
            arg3 ??= string.Empty;
            arg4 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            {
                EventData* data = stackalloc EventData[5];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)arg1Ptr;
                data[1].Size = (arg1.Length + 1) * 2;
                data[2].DataPointer = (IntPtr)arg2Ptr;
                data[2].Size = (arg2.Length + 1) * 2;
                data[3].DataPointer = (IntPtr)arg3Ptr;
                data[3].Size = (arg3.Length + 1) * 2;
                data[4].DataPointer = (IntPtr)arg4Ptr;
                data[4].Size = (arg4.Length + 1) * 2;
                WriteEventCore(eventId, 5, data);
            }
        }
    }
}