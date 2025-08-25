// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Core.Perf;

/// <summary>
/// Custom event source for Azure Core logging.
/// </summary>
internal class CustomEventSource : AzureEventSource
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomEventSource"/> class.
    /// </summary>
    public CustomEventSource() : base("Azure-Core") { }

    /// <summary>
    /// Logs a request with the old method.
    /// </summary>
    /// <param name="strParam">The string parameter.</param>
    /// <param name="intParam">The integer parameter.</param>
    /// <param name="doubleParam">The double parameter.</param>
    /// <param name="bytesParam">The byte array parameter.</param>
    [Event(1, Level = EventLevel.Informational)]
    public void RequestOld(string strParam, int intParam, double doubleParam, byte[] bytesParam)
    {
        WriteEvent(1, strParam, intParam, doubleParam, bytesParam);
    }

    /// <summary>
    /// Logs a request with the new method.
    /// </summary>
    /// <param name="strParam">The string parameter.</param>
    /// <param name="intParam">The integer parameter.</param>
    /// <param name="doubleParam">The double parameter.</param>
    /// <param name="bytesParam">The byte array parameter.</param>
    [Event(2, Level = EventLevel.Informational)]
    public void RequestNew(string strParam, int intParam, double doubleParam, byte[] bytesParam)
    {
        WriteEventNew(2, strParam, intParam, doubleParam, bytesParam);
    }

    /// <summary>
    /// Writes an event with the new method.
    /// </summary>
    /// <param name="eventId">The event ID.</param>
    /// <param name="arg0">The string argument.</param>
    /// <param name="arg1">The integer parameter.</param>
    /// <param name="arg2">The double parameter.</param>
    /// <param name="arg3">The byte array parameter.</param>
    private unsafe void WriteEventNew(int eventId, string arg0, int arg1, double arg2, byte[] arg3)
    {
        if (!IsEnabled())
        {
            return;
        }

        arg0 ??= string.Empty;
        fixed (char* arg0Ptr = arg0)
        {
            EventData* data = stackalloc EventData[5];
            data[0].DataPointer = (IntPtr)arg0Ptr;
            data[0].Size = (arg0.Length + 1) * 2;
            data[1].DataPointer = (IntPtr)(&arg1);
            data[1].Size = 4;
            data[2].DataPointer = (IntPtr)(&arg2);
            data[2].Size = 8;

            var blobSize = arg3.Length;
            fixed (byte* blob = &arg3[0])
            {
                data[3].DataPointer = (IntPtr)(&blobSize);
                data[3].Size = 4;
                data[4].DataPointer = (IntPtr)blob;
                data[4].Size = blobSize;
                WriteEventCore(eventId, 4, data);
            }
        }
    }
}
