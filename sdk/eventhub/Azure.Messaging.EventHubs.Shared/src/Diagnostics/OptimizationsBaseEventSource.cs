// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Azure.Core.Diagnostics;

namespace Azure.Messaging.EventHubs.Diagnostics
{
    /*
    See: https://learn.microsoft.com/en-us/dotnet/core/diagnostics/eventsource-instrumentation#optimizing-performance-for-high-volume-events
    and https://learn.microsoft.com/en-us/dotnet/core/diagnostics/eventsource-instrumentation#eventsource-class-hierarchies

    EventSource methods: https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.tracing.eventsource?view=net-9.0
    */

    internal abstract class OptimizationsBaseEventSource : AzureEventSource
    {
        protected OptimizationsBaseEventSource(string eventSourceName) : base(eventSourceName)
        {
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            {
                var eventPayload = stackalloc EventData[4];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                WriteEventCore(eventId, 4, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       string arg5)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg5Ptr = arg5)
            {
                var eventPayload = stackalloc EventData[5];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = (arg5.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)arg5Ptr;

                WriteEventCore(eventId, 5, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       string arg5,
                                       string arg6)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg5Ptr = arg5)
            fixed (char* arg6Ptr = arg6)
            {
                var eventPayload = stackalloc EventData[6];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = (arg5.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)arg5Ptr;

                eventPayload[5].Size = (arg6.Length + 1) * sizeof(char);
                eventPayload[5].DataPointer = (IntPtr)arg6Ptr;

                WriteEventCore(eventId, 6, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       string arg5,
                                       string arg6,
                                       string arg7)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg5Ptr = arg5)
            fixed (char* arg6Ptr = arg6)
            fixed (char* arg7Ptr = arg7)
            {
                var eventPayload = stackalloc EventData[7];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = (arg5.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)arg5Ptr;

                eventPayload[5].Size = (arg6.Length + 1) * sizeof(char);
                eventPayload[5].DataPointer = (IntPtr)arg6Ptr;

                eventPayload[6].Size = (arg7.Length + 1) * sizeof(char);
                eventPayload[6].DataPointer = (IntPtr)arg7Ptr;

                WriteEventCore(eventId, 7, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       string arg5,
                                       string arg6,
                                       string arg7,
                                       string arg8)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg5Ptr = arg5)
            fixed (char* arg6Ptr = arg6)
            fixed (char* arg7Ptr = arg7)
            fixed (char* arg8Ptr = arg8)
            {
                var eventPayload = stackalloc EventData[8];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = (arg5.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)arg5Ptr;

                eventPayload[5].Size = (arg6.Length + 1) * sizeof(char);
                eventPayload[5].DataPointer = (IntPtr)arg6Ptr;

                eventPayload[6].Size = (arg7.Length + 1) * sizeof(char);
                eventPayload[6].DataPointer = (IntPtr)arg7Ptr;

                eventPayload[7].Size = (arg8.Length + 1) * sizeof(char);
                eventPayload[7].DataPointer = (IntPtr)arg8Ptr;

                WriteEventCore(eventId, 8, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       string arg5,
                                       string arg6,
                                       string arg7,
                                       string arg8,
                                       string arg9)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg5Ptr = arg5)
            fixed (char* arg6Ptr = arg6)
            fixed (char* arg7Ptr = arg7)
            fixed (char* arg8Ptr = arg8)
            fixed (char* arg9Ptr = arg9)
            {
                var eventPayload = stackalloc EventData[9];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = (arg5.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)arg5Ptr;

                eventPayload[5].Size = (arg6.Length + 1) * sizeof(char);
                eventPayload[5].DataPointer = (IntPtr)arg6Ptr;

                eventPayload[6].Size = (arg7.Length + 1) * sizeof(char);
                eventPayload[6].DataPointer = (IntPtr)arg7Ptr;

                eventPayload[7].Size = (arg8.Length + 1) * sizeof(char);
                eventPayload[7].DataPointer = (IntPtr)arg8Ptr;

                eventPayload[8].Size = (arg9.Length + 1) * sizeof(char);
                eventPayload[8].DataPointer = (IntPtr)arg9Ptr;

                WriteEventCore(eventId, 9, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       int arg4,
                                       double arg5)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            {
                var eventPayload = stackalloc EventData[5];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = Unsafe.SizeOf<int>();
                eventPayload[3].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg4);

                eventPayload[4].Size = Unsafe.SizeOf<double>();
                eventPayload[4].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg5);

                WriteEventCore(eventId, 5, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       int arg5,
                                       double arg6)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            {
                var eventPayload = stackalloc EventData[6];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = Unsafe.SizeOf<int>();
                eventPayload[4].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg5);

                eventPayload[5].Size = Unsafe.SizeOf<double>();
                eventPayload[5].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg6);

                WriteEventCore(eventId, 6, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       double arg5)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            {
                var eventPayload = stackalloc EventData[5];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = Unsafe.SizeOf<double>();
                eventPayload[4].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg5);

                WriteEventCore(eventId, 5, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       int arg3,
                                       int arg4)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            {
                var eventPayload = stackalloc EventData[4];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = Unsafe.SizeOf<int>();
                eventPayload[2].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg3);

                eventPayload[3].Size = Unsafe.SizeOf<int>();
                eventPayload[3].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg4);

                WriteEventCore(eventId, 4, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       int arg3,
                                       int arg4,
                                       double arg5,
                                       double arg6)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            {
                var eventPayload = stackalloc EventData[6];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = Unsafe.SizeOf<int>();
                eventPayload[2].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg3);

                eventPayload[3].Size = Unsafe.SizeOf<int>();
                eventPayload[3].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg4);

                eventPayload[4].Size = Unsafe.SizeOf<double>();
                eventPayload[4].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg5);

                eventPayload[5].Size = Unsafe.SizeOf<double>();
                eventPayload[5].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg6);

                WriteEventCore(eventId, 6, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       int arg3,
                                       string arg4)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg4Ptr = arg4)
            {
                var eventPayload = stackalloc EventData[4];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = Unsafe.SizeOf<int>();
                eventPayload[2].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg3);

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                WriteEventCore(eventId, 4, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       int arg3,
                                       string arg4,
                                       double arg5)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg4Ptr = arg4)
            {
                var eventPayload = stackalloc EventData[5];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = Unsafe.SizeOf<int>();
                eventPayload[2].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg3);

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = Unsafe.SizeOf<double>();
                eventPayload[4].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg5);

                WriteEventCore(eventId, 5, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       int arg1,
                                       string arg2,
                                       string arg3)
        {
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            {
                var eventPayload = stackalloc EventData[3];

                eventPayload[0].Size = Unsafe.SizeOf<int>();
                eventPayload[0].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg1);

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                WriteEventCore(eventId, 3, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       int arg3,
                                       double arg4)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            {
                var eventPayload = stackalloc EventData[4];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = Unsafe.SizeOf<int>();
                eventPayload[2].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg3);

                eventPayload[3].Size = Unsafe.SizeOf<double>();
                eventPayload[3].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg4);

                WriteEventCore(eventId, 4, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       int arg5,
                                       int arg6,
                                       double arg7,
                                       string arg8,
                                       string arg9,
                                       int arg10,
                                       double arg11)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg8Ptr = arg8)
            fixed (char* arg9Ptr = arg9)
            {
                var eventPayload = stackalloc EventData[11];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = Unsafe.SizeOf<int>();
                eventPayload[4].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg5);

                eventPayload[5].Size = Unsafe.SizeOf<int>();
                eventPayload[5].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg6);

                eventPayload[6].Size = Unsafe.SizeOf<double>();
                eventPayload[6].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg7);

                eventPayload[7].Size = (arg8.Length + 1) * sizeof(char);
                eventPayload[7].DataPointer = (IntPtr)arg8Ptr;

                eventPayload[8].Size = (arg9.Length + 1) * sizeof(char);
                eventPayload[8].DataPointer = (IntPtr)arg9Ptr;

                eventPayload[9].Size = Unsafe.SizeOf<int>();
                eventPayload[9].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg10);

                eventPayload[10].Size = Unsafe.SizeOf<double>();
                eventPayload[10].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg11);

                WriteEventCore(eventId, 11, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       long arg3,
                                       long arg4)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            {
                var eventPayload = stackalloc EventData[4];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = Unsafe.SizeOf<long>();
                eventPayload[2].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg3);

                eventPayload[3].Size = Unsafe.SizeOf<long>();
                eventPayload[3].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg4);

                WriteEventCore(eventId, 4, eventPayload);
            }
        }        // HashSet<string>, string

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       long arg3,
                                       short arg4,
                                       long arg5)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            {
                var eventPayload = stackalloc EventData[5];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = Unsafe.SizeOf<long>();
                eventPayload[2].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg3);

                eventPayload[3].Size = Unsafe.SizeOf<short>();
                eventPayload[3].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg4);

                eventPayload[4].Size = Unsafe.SizeOf<long>();
                eventPayload[4].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg5);

                WriteEventCore(eventId, 5, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       string arg5,
                                       int arg6)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg5Ptr = arg5)
            {
                var eventPayload = stackalloc EventData[6];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = (arg5.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)arg5Ptr;

                eventPayload[5].Size = Unsafe.SizeOf<int>();
                eventPayload[5].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg6);

                WriteEventCore(eventId, 6, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       int arg3,
                                       double arg4,
                                       double arg5)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            {
                var eventPayload = stackalloc EventData[5];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = Unsafe.SizeOf<int>();
                eventPayload[2].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg3);

                eventPayload[3].Size = Unsafe.SizeOf<double>();
                eventPayload[3].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg4);

                eventPayload[4].Size = Unsafe.SizeOf<double>();
                eventPayload[4].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg5);

                WriteEventCore(eventId, 5, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       double arg5,
                                       int arg6)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            {
                var eventPayload = stackalloc EventData[6];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = Unsafe.SizeOf<double>();
                eventPayload[4].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg5);

                eventPayload[5].Size = Unsafe.SizeOf<int>();
                eventPayload[5].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg6);

                WriteEventCore(eventId, 6, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       string arg5,
                                       int arg6,
                                       string arg7,
                                       string arg8)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg5Ptr = arg5)
            fixed (char* arg7Ptr = arg7)
            fixed (char* arg8Ptr = arg8)
            {
                var eventPayload = stackalloc EventData[8];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = (arg5.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)arg5Ptr;

                eventPayload[5].Size = Unsafe.SizeOf<int>();
                eventPayload[5].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg6);

                eventPayload[6].Size = (arg7.Length + 1) * sizeof(char);
                eventPayload[6].DataPointer = (IntPtr)arg7Ptr;

                eventPayload[7].Size = (arg8.Length + 1) * sizeof(char);
                eventPayload[7].DataPointer = (IntPtr)arg8Ptr;

                WriteEventCore(eventId, 8, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       string arg5,
                                       double arg6,
                                       int arg7)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg5Ptr = arg5)
            {
                var eventPayload = stackalloc EventData[7];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = (arg5.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)arg5Ptr;

                eventPayload[5].Size = Unsafe.SizeOf<double>();
                eventPayload[5].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg6);

                eventPayload[6].Size = Unsafe.SizeOf<int>();
                eventPayload[6].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg7);

                WriteEventCore(eventId, 7, eventPayload);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       double arg4)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            {
                var eventPayload = stackalloc EventData[4];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = Unsafe.SizeOf<double>();
                eventPayload[2].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg3);

                eventPayload[3].Size = Unsafe.SizeOf<double>();
                eventPayload[3].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg4);

                WriteEventCore(eventId, 4, eventPayload);
            }
        }
    }
}
