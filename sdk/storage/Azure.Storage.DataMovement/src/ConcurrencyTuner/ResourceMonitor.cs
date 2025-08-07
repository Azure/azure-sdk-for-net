// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using static Azure.Storage.DataMovement.ResourceMonitor.MacMemory;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// CPU usage is a measure of how much processing power a process is using over a period of time. To calculate this,
    /// you need to know how much CPU time the process has consumed during a specific interval.
    ///
    /// In order to perform a cpu monitor without requiring large
    /// amounts of permissions from the user, we can do a pseudo monitor
    /// where with poll the CPU to see how it does with a simple wait task.
    ///
    /// Loosely adapted from (using the concepts): https://mattwarren.org/2014/06/18/measuring-the-impact-of-the-net-garbage-collector/
    ///
    /// TODO: consider using System.Diagnostics.PerformanceCounter to keep track
    /// of the performance however it takes elevated permissions. We may consider
    /// using that instead if the application has elevated permissions.
    ///
    /// A lot of computations were taken from the azcopy cpuMonitor
    /// </summary>
    internal class ResourceMonitor
    {
        #region private fields and properties
        private Task _monitoringWorker;
        //private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _monitoringInterval;
        private double _previousProcessorTime = 0;
        private double _currentProcessorTime = 0;
        private int _coreCount = Environment.ProcessorCount;
        private CancellationToken _cancellationToken;
        private Process CurrentProcess
        {
            get
            {
                return Process.GetCurrentProcess();
            }
        }
        #endregion

        #region internal fields and properties
        /// <summary>
        /// CPUContentionExists returns true if demand for CPU capacity is affecting
        /// the ability of our GoRoutines to run when they want to run
        /// </summary>

        internal bool ContentionExists { get; private set; }

        /// <summary>
        /// CpuUsage represents the amount of CPU used as a float between 0 and 1
        /// </summary>
        internal float CpuUsage { get; private set; }

        /// <summary>
        /// MemoryUsage returns the number of bytes of memory currently being used by the process.
        /// This is the same amount of memory that appears in the task manager
        /// </summary>

        internal double MemoryUsage { get; private set; }

        /// <summary>
        /// IsRunning returns a boolean on whether the ResourceMonitor is running
        /// </summary>
        internal bool IsRunning { get; private set; }
        #endregion
        ///
        public ResourceMonitor(TimeSpan monitoringInterval = default)
        {
            if (monitoringInterval < TimeSpan.FromMilliseconds(0))
            {
                throw new ArgumentOutOfRangeException(nameof(monitoringInterval), "Value cannot be less than 0.");
            }
            _monitoringInterval = monitoringInterval == TimeSpan.FromSeconds(0) ? TimeSpan.FromMilliseconds(1000) : monitoringInterval;
        }

        /// <summary>
        /// Does the computations to determine if the CPU is a contention in why things are slow.
        ///
        /// Each tick is equal to 100 nanoseconds
        /// TODO: when upgrade to .NET 7 comes, we can use the TimeSpan.Nanoseconds
        ///
        /// TODO: remove magic numbers
        /// </summary>
        internal async Task CalibrateComputation(CancellationToken cancellationToken)
        {
            bool oldIsSlow = false;

            Channel<TimeSpan> durations = Channel.CreateBounded<TimeSpan>(1000);

            // TODO: remove size once the Channels.Count feature comes out.
            int valuesInWindowCount = 0;
            Channel<bool> valuesInWindow = Channel.CreateBounded<bool>(100);

            int rollingCount = 0;
            // sleep for this long each time we probe for busy-ness of CPU
            TimeSpan waitTime = TimeSpan.FromMilliseconds(333);

            // keep track of this many recent samples
            long windowSize = Convert.ToInt64(TimeSpan.FromSeconds(5).TotalMilliseconds / waitTime.TotalMilliseconds);

            // a sample is considered slow if its this many times greater than the baseline (or more)
            float thresholdMultiplier = 50;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // testing indicates we need a lower threshold here, but not on Linux (since the lower number gives too many false alarms there)
                thresholdMultiplier = 10;
            }

            // run a separate loop to do the probes/measurements
            _monitoringWorker = MonitoringWorker(waitTime, durations, cancellationToken);
            _monitoringWorker.Start();

            // discard first value, it doesn't seem very reliable
            await durations.Reader.ReadAsync(cancellationToken).ConfigureAwait(false);

            // get the next 3 and average them, as our baseline. We chose 3 somewhat arbitrarily
            long firstSpan = 0;// get next duration.
            long secondSpan = 0;
            long thirdSpan = 0;

            float baselineAverageNs = (firstSpan + secondSpan + thirdSpan) / 3;

            //close(calibrationDone)

            // loop and monitor
            while (!cancellationToken.IsCancellationRequested)
            {
                while (await durations.Reader.WaitToReadAsync(cancellationToken).ConfigureAwait(false))
                {
                    TimeSpan duration = await durations.Reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                    // it took us over x times longer than normal to wake from sleep
                    bool latestWasSlow = (duration.Ticks * 100) > thresholdMultiplier * baselineAverageNs;

                    // maintain count of slow ones in the last "windowSize" intervals
                    valuesInWindowCount++;
                    await valuesInWindow.Writer.WriteAsync(latestWasSlow, cancellationToken).ConfigureAwait(false);

                    if (latestWasSlow)
                    {
                        rollingCount++;
                    }
                    else if (valuesInWindowCount > windowSize)
                    {
                        bool oldWasSlow = await valuesInWindow.Reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        if (oldWasSlow)
                        {
                            rollingCount--;
                        }
                    }

                    // If lots of our recent samples passed the threshold for "slow", then assume that we are indeed generally slow
                    bool isGenerallySlow = rollingCount >= (windowSize / 2);
                    if (isGenerallySlow != oldIsSlow)
                    {
                        ContentionExists = true;
                    }
                }
            }
        }

        internal void StartMonitoring(CancellationToken cancellationToken)
        {
            if (IsRunning)
                return;

            IsRunning = true;
            // _cancellationToken is set for the MonitorResourceUsage loop
            // cancellationToken is used to cancel the callback
            _cancellationToken = cancellationToken;
            Task.Run(() => MonitorResourceUsage(), cancellationToken);
        }

        // Removing the stopMonitoring method. This will be handled by the TransferManager
        // when the Transfer Manager calls `.Cancel()` on the cancellationTokenSource
        //internal void StopMonitoring()
        //{
        //    if (!IsRunning)
        //        return;

        //    IsRunning = false;
        //    _cancellationTokenSource.Cancel();
        //}

        private static async Task MonitoringWorker(
            TimeSpan waitTime,
            ChannelWriter<TimeSpan> durationWriter,
            CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                DateTimeOffset start = DateTimeOffset.UtcNow;

                Thread.Sleep(waitTime);

                DateTimeOffset endTime = DateTimeOffset.UtcNow;

                // how much longer than expected did it take for us to wake up?
                // This is assumed to be time in which we were ready to run, but we couldn't run, because something else was busy on the
                // CPU.
                TimeSpan diffFromStart = endTime.Subtract(start);
                TimeSpan excessTime = diffFromStart.Subtract(waitTime);

                await durationWriter.WriteAsync(excessTime, cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task MonitorResourceUsage()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                // Calling Refresh forces the Process object to update its cached information with current values from the OS.
                CurrentProcess.Refresh();

                CalculateCpuUsage();
                CalculateMemoryUsage();
                await Task.Delay(_monitoringInterval, _cancellationToken).ConfigureAwait(false);
            }
        }

        private void CalculateCpuUsage()
        {
            // using process would work on all old and new frameworks
            // https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.process.getcurrentprocess?view=net-9.0#system-diagnostics-process-getcurrentprocess

            _currentProcessorTime = CurrentProcess.TotalProcessorTime.TotalMilliseconds;

            // CPU Usage = ((Current CPU Time - Previous CPU Time)/ (Time Elapsed * Number of Cores))
            // Process.TotalProcessorTime.TotalMilliseconds returns the processing time across all processors
            // Environment.ProcessorCount returns then total number of cores (which includes physical cores plus hyper
            // threaded cores
            CpuUsage = (float)(_currentProcessorTime - _previousProcessorTime) / (float)(_monitoringInterval.TotalMilliseconds * _coreCount);
            _previousProcessorTime = _currentProcessorTime;
        }

        private void CalculateMemoryUsage()
        {
            // https://stackoverflow.com/questions/16402036/anomalies-with-using-process-workingset64-to-measure-memory-usage
            // https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.process.workingset64?view=net-9.0
            // long currentMemoryUsage = CurrentProcess.WorkingSet64;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Apparently this is a known issue in .NET
                // https://github.com/dotnet/runtime/issues/105665

                int pid = Process.GetCurrentProcess().Id;
                ProcTaskInfo taskInfo = GetProcessTaskInfo(pid);

                double mem = taskInfo.pti_resident_size;
                if (mem > 0)
                {
                    MemoryUsage = mem;
                } else
                {
                    MemoryUsage = (double)CurrentProcess.WorkingSet64;
                }

                MemoryUsage = taskInfo.pti_resident_size;
            }
            else
            {
                // This is the memory that is shown in the task manager in Windows and Linux
                // https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.process.privatememorysize64?view=net-9.0
                MemoryUsage = CurrentProcess.PrivateMemorySize64;
            }
        }
        internal class MacMemory
        {
            // libproc is a shared library in the macOS derived from Darwin. The earliest version of MacOS using
            // Darwin is OSX 10 (Cheetah)
            // https://en.wikipedia.org/wiki/MacOS_version_history

            [DllImport("libproc", SetLastError = true)]
            private static extern int proc_pidinfo(int pid, int flavor, ulong arg, IntPtr buffer, int buffersize);

            // These `int`s are ordinal, 4 provides information about the current process
            // https://gist.github.com/nguyen-phillip/de66b0ea2144e20ddd844c41c9d93eb9

            private const int PROC_PIDTASKINFO = 4;

            [StructLayout(LayoutKind.Sequential)]
            internal struct ProcTaskInfo
            {
                public ulong pti_virtual_size; // The total virtual memory size used by the process.
                public ulong pti_resident_size; // The portion of physical memory occupied by a process.
                public ulong pti_total_user; // The total amount of time the process has spent in user mode.
                public ulong pti_total_system; // The total amount of time the process has spent in kernel mode.
                public ulong pti_threads_user; // The total amount of time all threads have spent in user mode.
                public ulong pti_threads_system; // The total amount of time all threads have spent in kernel mode.
                public int pti_policy; // The scheduling policy used for the process.
                public int pti_faults; // The number of page faults generated by the process.
                public int pti_pageins; // The number of times pages have been paged in from disk.
                public int pti_cow_faults;
                public int pti_messages_sent;
                public int pti_messages_received;
                public int pti_syscalls_mach;
                public int pti_syscalls_unix;
                public int pti_csw;
                public int pti_threadnum; // The number of threads in the process.
                public int pti_numrunning; // The number of running threads.
                public int pti_priority; // The priority of the process.
            }

            internal static ProcTaskInfo GetProcessTaskInfo(int pid)
            {
                ProcTaskInfo taskInfo = new ProcTaskInfo();
                // Next two functions are used to allocate unmanaged memory
                // proc_pidinfo requires unmanaged memory because managed memory is subject to garbage collection
                int size = Marshal.SizeOf(taskInfo);
                IntPtr buffer = Marshal.AllocHGlobal(size);

                try
                {
                    int result = proc_pidinfo(pid, PROC_PIDTASKINFO, 0, buffer, size);
                    if (result > 0)
                    {
                        taskInfo = Marshal.PtrToStructure<ProcTaskInfo>(buffer);
                    }
                    else
                    {
                        throw new InvalidOperationException("Failed to retrieve process information.");
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
                return taskInfo;
            }
        }
    }
}
