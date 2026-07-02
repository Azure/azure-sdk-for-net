// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using Perfolizer.Horology;

namespace System.ClientModel.Tests.Internal.Perf;

public class Program
{
    public static void Main(string[] args)
    {
        // To see the list of benchmarks that can be run
        // dotnet run -c Release --framework net6.0 --list flat

        // To run a specific benchmark class
        // dotnet run -c Release --framework net6.0 --filter System.ClientModel.Tests.Internal.Perf.ResourceProviderDataModel*

        // To run a specific benchmark method
        // dotnet run -c Release --framework net6.0 --filter *ResourceProviderDataModel.Read_PublicInterface
        // or
        // dotnet run -c Release --framework net6.0 --filter System.ClientModel.Tests.Internal.Perf.ResourceProviderDataModel.Read_PublicInterface

        // To run a specific benchmark class and category
        // dotnet run -c Release --framework net6.0 --anyCategories PublicInterface --filter System.ClientModel.Tests.Internal.Perf.ResourceProviderDataModel*

        var config = ManualConfig.Create(DefaultConfig.Instance);
        config.Options = ConfigOptions.JoinSummary | ConfigOptions.StopOnFirstError;
        config = config.AddDiagnoser(MemoryDiagnoser.Default);

        // The proxy resolution benchmarks (ProxyResolution*) measure sub-microsecond operations where
        // the in-process toolchain produces noisy, sometimes physically impossible results (for example
        // a proxy "miss" appearing faster than the no-proxy baseline). When the run targets those
        // benchmarks - i.e. it is launched by Run-ProxyBenchmarks.ps1, which passes --filter
        // *ProxyResolution* - use the default out-of-process toolchain for accurate, isolated
        // measurements. Every other run keeps the fast in-process toolchain unchanged.
        bool proxyRun = args.Any(arg => arg.IndexOf("ProxyResolution", StringComparison.OrdinalIgnoreCase) >= 0);

        if (proxyRun)
        {
            // The sub-microsecond proxy paths have a fat right tail (rare multi-microsecond GC and
            // scheduling spikes on a non-isolated machine) that distorts the mean, so surface the Median
            // as well - it is the robust reference value for these benchmarks.
            config.AddColumn(StatisticColumn.Median);

            // Multiple process launches plus generous warmup/iteration counts drive down the run-to-run
            // variance so the small miss-path overhead does not invert the ordering relative to the
            // no-proxy baseline. Three launches average out per-process layout bias (keeping the ratios
            // stable); the warmup/iteration counts give the medians enough samples to be meaningful.
            // Absolute timings of these sub-microsecond paths still carry run-to-run variance on a
            // non-isolated machine - the deterministic Allocated column is the most reliable signal.
            config.AddJob(Job.Default
                .WithLaunchCount(3)
                .WithWarmupCount(10)
                .WithIterationCount(15)
                .AsDefault());
        }
        else
        {
            config.AddJob(Job.Default
                .WithToolchain(InProcessEmitToolchain.Instance)
                .WithWarmupCount(1)
                .WithIterationTime(TimeInterval.FromMilliseconds(250))
                .WithMinIterationCount(15)
                .WithMaxIterationCount(20)
                .AsDefault());
        }

        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
    }
}
