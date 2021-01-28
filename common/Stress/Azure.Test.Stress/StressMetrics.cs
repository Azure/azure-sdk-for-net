// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Diagnostics;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Azure.Test.Stress
{
    public class StressMetrics
    {
        // Timing
        public DateTime StartTime { get; } = DateTime.Now;
        public DateTime CurrentTime => DateTime.Now;
        public DateTime EndTime => StartTime + Duration;
        public TimeSpan Duration { get; set; }
        private TimeSpan RawRemaining => Duration - (CurrentTime - StartTime);
        public TimeSpan Remaining => (RawRemaining > TimeSpan.Zero) ? RawRemaining : TimeSpan.Zero;

        // CPU
        public TimeSpan TotalProcessorTime;

        // Memory
        public long MemorySamples;
        public long MemorySum;
        public long CurrentMemory;
        public long AverageMemory => Interlocked.Read(ref MemorySum) / Interlocked.Read(ref MemorySamples);
        public long PeakMemory;
        public long Gen0Collections;
        public long Gen1Collections;
        public long Gen2Collections;

        // Exceptions
        public ConcurrentQueue<Exception> Exceptions { get; } = new ConcurrentQueue<Exception>();

        // Events
        private AzureEventSourceListener _eventListener;
        public ConcurrentQueue<(EventWrittenEventArgs EventArgs, string Message)> Events { get; }
            = new ConcurrentQueue<(EventWrittenEventArgs EventArgs, string Message)>();

        // Options
        internal StressOptions Options { get; set; }

        // Private
        private Thread _updateCpuMemoryThread;
        private CancellationTokenSource _updateCpuMemoryCts;

        protected virtual void ProcessEvent(EventWrittenEventArgs eventArgs, string message)
        {
            Events.Enqueue((EventArgs: eventArgs, Message: message));
        }

        internal void StartAutoUpdate()
        {
            _eventListener = new AzureEventSourceListener((eventArgs, message) =>
            {
                ProcessEvent(eventArgs, message);
            },
            level: Options.EventLevel);

            _updateCpuMemoryCts = new CancellationTokenSource();
            _updateCpuMemoryThread = UpdateCpuMemory(_updateCpuMemoryCts.Token);
        }

        internal void StopAutoUpdate()
        {
            _eventListener.Dispose();
            _eventListener = null;

            _updateCpuMemoryCts.Cancel();
            _updateCpuMemoryThread.Join();
        }

        // Run in dedicated thread to ensure this thread has priority and never fails to run to due ThreadPool starvation.
        private Thread UpdateCpuMemory(CancellationToken token)
        {
            // Update once synchronously, to ensure values are initialized before first status output.
            UpdateCpuMemory();

            var thread = new Thread(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        Sleep(TimeSpan.FromSeconds(1), token);
                    }
                    catch (OperationCanceledException)
                    {
                    }

                    UpdateCpuMemory();
                }
            });

            thread.Start();

            return thread;
        }

        private void UpdateCpuMemory()
        {
            var memory = GC.GetTotalMemory(false);

            Interlocked.Increment(ref MemorySamples);
            Interlocked.Add(ref MemorySum, memory);
            Interlocked.Exchange(ref CurrentMemory, memory); ;
            Interlocked.Exchange(ref Gen0Collections, GC.CollectionCount(0));
            Interlocked.Exchange(ref Gen1Collections, GC.CollectionCount(1));
            Interlocked.Exchange(ref Gen2Collections, GC.CollectionCount(2));

            if (memory > Interlocked.Read(ref PeakMemory))
            {
                Interlocked.Exchange(ref PeakMemory, memory);
            }

            TotalProcessorTime = Process.GetCurrentProcess().TotalProcessorTime;
        }

        private static void Sleep(TimeSpan timeout, CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            while (sw.Elapsed < timeout)
            {
                if (token.IsCancellationRequested)
                {
                    // Simulate behavior of Task.Delay(TimeSpan, CancellationToken)
                    throw new OperationCanceledException();
                }

                Thread.Sleep(TimeSpan.FromMilliseconds(10));
            }
        }

        public override string ToString()
        {
            var data = new List<(string Key, object Value)>();

            // Timing
            data.Add(("Start", $"{StartTime:G}"));
            data.Add(("Current", $"{CurrentTime:G}"));
            data.Add(("End", $"{EndTime:G}"));

            // CPU
            data.Add(("TotalProcessorTime", TotalProcessorTime.ToString()));

            // Memory
            data.Add(("Current Memory", FormatBytes(Interlocked.Read(ref CurrentMemory))));
            data.Add(("Average Memory", FormatBytes(AverageMemory)));
            data.Add(("Peak Memory", FormatBytes(Interlocked.Read(ref PeakMemory))));
            data.Add(("GC Gen 0 Collections", Interlocked.Read(ref Gen0Collections)));
            data.Add(("GC Gen 1 Collections", Interlocked.Read(ref Gen1Collections)));
            data.Add(("GC Gen 2 Collections", Interlocked.Read(ref Gen2Collections)));

            // Exceptions
            data.Add(("Total Exceptions", Exceptions.Count));
            foreach (var g in Exceptions.GroupBy(e => e.GetType()).OrderBy(g => g.Key.Name))
            {
                data.Add((g.Key.Name, g.Count()));
            }

            // Events
            data.Add(("Total Events", Events.Count));
            foreach (var g in Events.GroupBy(e => $"{e.EventArgs.EventSource.Name}::{e.EventArgs.EventName}").OrderBy(g => g.Key))
            {
                data.Add((g.Key, g.Count()));
            }

            var allMembers = this.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
            var baseMemberNames = typeof(StressMetrics).GetMembers(BindingFlags.Public | BindingFlags.Instance).Select(m => m.Name);
            var derivedMembers = allMembers.Where(m => !baseMemberNames.Contains(m.Name));

            foreach (var member in derivedMembers.OrderBy(m => m.Name))
            {
                switch (member)
                {
                    case FieldInfo f:
                        data.Add((f.Name, f.GetValue(this).ToString()));
                        break;
                    case PropertyInfo p:
                        data.Add((p.Name, p.GetValue(this).ToString()));
                        break;
                    default:
                        break;
                }
            }

            return FormatTable(data);
        }

        private static string FormatBytes(long bytes)
        {
            const long scale = 1024;

            var orders = new string[] { "TB", "MB", "KB", "bytes" };
            var max = (long)Math.Pow(scale, (orders.Length - 1));

            foreach (string order in orders)
            {
                if (bytes > max)
                {
                    return string.Format("{0:n2} {1}", Decimal.Divide(bytes, max), order);
                }

                max /= scale;
            }

            return "0 bytes";
        }

        private static string FormatTable(IEnumerable<(string Key, object Value)> data)
        {
            var sb = new StringBuilder();

            var longestKeyLength = data.Select(v => v.Key).OrderByDescending(k => k.Length).First().Length;
            const int padding = 4;

            foreach (var kvp in data)
            {
                sb.Append(kvp.Key);
                sb.Append(':');
                for (var i = kvp.Key.Length + 1; i < longestKeyLength + padding + 1; i++)
                {
                    sb.Append(' ');
                }
                sb.Append(kvp.Value);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
