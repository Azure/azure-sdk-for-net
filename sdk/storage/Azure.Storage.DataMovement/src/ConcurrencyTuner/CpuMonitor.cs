// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

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
    internal class CpuMonitor : ICpuMonitor
    {
        private Task _monitoringWorker;
        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _monitoringInterval;

        public float CpuUsage { get; private set; }
        public bool IsRunning { get; private set; }
        private double PreviousProcessorTime { get; set; } = 0;
        private double CurrentProcessorTime { get; set; }
        private int CoreCount { get; } = Environment.ProcessorCount;

        private Process CurrentProcess
        {
            get
            {
                return Process.GetCurrentProcess();
            }
        }

        /// <summary>
        /// CPUContentionExists returns true if demand for CPU capacity is affecting
        /// the ability of our GoRoutines to run when they want to run
        /// </summary>

        public bool ContentionExists { get; private set; }

        public double MemoryUsage { get; private set; }

        /// <summary>
        /// Initalizes the CPU monitor.
        ///
        /// This should be called early on in the job transfers.
        /// </summary>
        ///
        public CpuMonitor() { }

        /// <summary>
        /// Initalizes the CPU monitor.
        ///
        /// This should be called early on in the job transfers.
        /// Monitoring intervals below 100 Milliseconds are likely to give 0 readings.
        /// Monitoring intervals should be above 1000 Milliseconds to be able to get readings
        /// </summary>
        ///

        public CpuMonitor(TimeSpan monitoringInterval)
        {
            _monitoringInterval = monitoringInterval;
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

        public void StartMonitoring()
        {
            if (IsRunning)
                return;

            IsRunning = true;
            // One cancellation token so that each thread is cancelled
            _cancellationTokenSource = new CancellationTokenSource();

            // Running each monitor on its own thread because they are not dependent on each other.
            // If they were dependent on each other, then I could run it like this:
            // Task.Run(async () =>
            //{
            //    await MonitorCpuUsage(_cancellationTokenSource.Token).ConfigureAwait(false);
            //    await MonitorMemoryUsage(_cancellationTokenSource.Token).ConfigureAwait(false);
            //});

            Task.Run(() => MonitorCpuUsage(_cancellationTokenSource.Token));
            Task.Run(() => MonitorMemoryUsage(_cancellationTokenSource.Token));
        }

        public void StopMonitoring()
        {
            if (!IsRunning)
                throw new InvalidOperationException();

            IsRunning = false;
            _cancellationTokenSource?.Cancel();
        }

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

        private async Task MonitorCpuUsage(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(_monitoringInterval, cancellationToken).ConfigureAwait(false);
                MonitorCpuUsageLegacy();
            }
        }

        private void MonitorCpuUsageLegacy()
        {
            // using process would work on all old and new frameworks
            // https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.process.getcurrentprocess?view=net-9.0#system-diagnostics-process-getcurrentprocess
            // Calling Refresh forces the Process object to update its cached information with current values from the OS.
            CurrentProcess.Refresh();
            CurrentProcessorTime = CurrentProcess.TotalProcessorTime.TotalMilliseconds;
            CpuUsage = CalculateCpuUsage();
            PreviousProcessorTime = CurrentProcessorTime;
        }

        private float CalculateCpuUsage()
        {
            // CPU Usage = (CPU Time Used / (Time Elapsed * Number of Cores)) * 100
            // Delta CPU Time Used = Current CPU Time - Previous CPU Time
            // Process.TotalProcessorTime.TotlMilliseconds returns the processing time across all processors
            // Environment.ProcessorCount returns then total number of cores (which includes physical cores plus hyper
            // threaded cores
            return (float)(CurrentProcessorTime - PreviousProcessorTime) / (float)(_monitoringInterval.TotalMilliseconds * CoreCount);
        }

        private async Task MonitorMemoryUsage(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(_monitoringInterval, cancellationToken).ConfigureAwait(false);
                // This is the memory that is shown in the task manager
                //long currentMemoryUsage = CurrentProcess.WorkingSet64;
                long currentMemoryUsage = CurrentProcess.PrivateMemorySize64;

#if NETSTANDARD2_0_OR_GREATER
                // This is wrong, but the workaround looks like it would be really long and difficult to implment....
                //long totalPhysicalMemory = CurrentProcess.WorkingSet64;
                long totalPhysicalMemory = (long)CalculateMemoryNETStandard();

#else
                long totalPhysicalMemory = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes;
                // Assumption: Probably not MAC
                // Use PInvoke here

#endif
                MemoryUsage = (double)currentMemoryUsage / (double)totalPhysicalMemory;
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

        private ulong CalculateMemoryNETStandard()
        {
            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX { dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX)) };
            if (GlobalMemoryStatusEx(ref memStatus))
            {
                return memStatus.ullTotalPhys;
                //Console.WriteLine($"Available RAM: {memStatus.ullAvailPhys / 1024 / 1024} MB");
            }
            return 0;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
        }
    }
}
