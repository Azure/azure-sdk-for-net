// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Taken from https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/test/OpenTelemetry.Tests.Stress
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Stress.Tests;

public partial class Program
{
    private static volatile bool bContinue = true;
    private static volatile string output = "Test results not available yet.";

    static Program()
    {
    }

    public static void Stress(int concurrency = 0, int prometheusPort = 0)
    {
#if DEBUG
        Console.WriteLine("***WARNING*** The current build is DEBUG which may affect timing!");
        Console.WriteLine();
#endif

        if (concurrency < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(concurrency), "concurrency level should be a non-negative number.");
        }

        if (concurrency == 0)
        {
            concurrency = Environment.ProcessorCount;
        }

        using var meter = new Meter("OpenTelemetry.Tests.Stress." + Guid.NewGuid().ToString("D"));
        var cntLoopsTotal = 0UL;
        meter.CreateObservableCounter(
            "OpenTelemetry.Tests.Stress.Loops",
            () => unchecked((long)cntLoopsTotal),
            description: "The total number of `Run()` invocations that are completed.");
        var dLoopsPerSecond = 0D;
        meter.CreateObservableGauge(
            "OpenTelemetry.Tests.Stress.LoopsPerSecond",
            () => dLoopsPerSecond,
            description: "The rate of `Run()` invocations based on a small sliding window of few hundreds of milliseconds.");
        var dCpuCyclesPerLoop = 0D;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            meter.CreateObservableGauge(
                "OpenTelemetry.Tests.Stress.CpuCyclesPerLoop",
                () => dCpuCyclesPerLoop,
                description: "The average CPU cycles for each `Run()` invocation, based on a small sliding window of few hundreds of milliseconds.");
        }

        using var meterProvider = prometheusPort != 0 ? Sdk.CreateMeterProviderBuilder()
            .AddMeter(meter.Name)
            .AddRuntimeInstrumentation()
            .AddPrometheusHttpListener(
                options => options.UriPrefixes = new string[] { $"http://localhost:{prometheusPort}/" })
            .Build() : null;

        var statistics = new long[concurrency];
        var watchForTotal = Stopwatch.StartNew();

        Parallel.Invoke(
            () =>
            {
                Console.Write($"Running (concurrency = {concurrency}");

                if (prometheusPort != 0)
                {
                    Console.Write($", prometheusEndpoint = http://localhost:{prometheusPort}/metrics/");
                }

                Console.WriteLine("), press <Esc> to stop...");

                var bOutput = false;
                var watch = new Stopwatch();
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true).Key;

                        switch (key)
                        {
                            case ConsoleKey.Enter:
                                Console.WriteLine(string.Format("{0} {1}", DateTime.UtcNow.ToString("O"), output));
                                break;
                            case ConsoleKey.Escape:
                                bContinue = false;
                                return;
                            case ConsoleKey.Spacebar:
                                bOutput = !bOutput;
                                break;
                        }

                        continue;
                    }

                    if (bOutput)
                    {
                        Console.WriteLine(string.Format("{0} {1}", DateTime.UtcNow.ToString("O"), output));
                    }

                    var cntLoopsOld = (ulong)statistics.Sum();
                    var cntCpuCyclesOld = GetCpuCycles();

                    watch.Restart();
                    Thread.Sleep(200);
                    watch.Stop();

                    cntLoopsTotal = (ulong)statistics.Sum();
                    var cntCpuCyclesNew = GetCpuCycles();

                    var nLoops = cntLoopsTotal - cntLoopsOld;
                    var nCpuCycles = cntCpuCyclesNew - cntCpuCyclesOld;

                    dLoopsPerSecond = (double)nLoops / ((double)watch.ElapsedMilliseconds / 1000.0);
                    dCpuCyclesPerLoop = nLoops == 0 ? 0 : nCpuCycles / nLoops;

                    output = $"Loops: {cntLoopsTotal:n0}, Loops/Second: {dLoopsPerSecond:n0}, CPU Cycles/Loop: {dCpuCyclesPerLoop:n0}, RunwayTime (Seconds): {watchForTotal.Elapsed.TotalSeconds:n0} ";
                    Console.Title = output;
                }
            },
            () =>
            {
                Parallel.For(0, concurrency, (i) =>
                {
                    statistics[i] = 0;
                    while (bContinue)
                    {
                        Run();
                        statistics[i]++;
                    }
                });
            });

        watchForTotal.Stop();
        cntLoopsTotal = (ulong)statistics.Sum();
        var totalLoopsPerSecond = (double)cntLoopsTotal / ((double)watchForTotal.ElapsedMilliseconds / 1000.0);
        var cntCpuCyclesTotal = GetCpuCycles();
        var cpuCyclesPerLoopTotal = cntLoopsTotal == 0 ? 0 : cntCpuCyclesTotal / cntLoopsTotal;
        Console.WriteLine("Stopping the stress test...");
        Console.WriteLine($"* Total Runaway Time (seconds) {watchForTotal.Elapsed.TotalSeconds:n0}");
        Console.WriteLine($"* Total Loops: {cntLoopsTotal:n0}");
        Console.WriteLine($"* Average Loops/Second: {totalLoopsPerSecond:n0}");
        Console.WriteLine($"* Average CPU Cycles/Loop: {cpuCyclesPerLoopTotal:n0}");
    }

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool QueryProcessCycleTime(IntPtr hProcess, out ulong cycles);

    private static ulong GetCpuCycles()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return 0;
        }

        if (!QueryProcessCycleTime((IntPtr)(-1), out var cycles))
        {
            return 0;
        }

        return cycles;
    }
}
