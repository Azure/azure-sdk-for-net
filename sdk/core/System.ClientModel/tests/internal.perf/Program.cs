// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Test.Perf;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;

namespace System.ClientModel.Tests.Internal.Perf;

public class Program
{
    public static async Task Main(string[] args)
    {
        if (!args.Contains("--bm"))
            // Allow the framework to execute the test scenarios.
            await PerfProgram.Main(Assembly.GetExecutingAssembly(), args);

        // To run Benchmark.NET benchmarks, use the --bm flag.

        // To see the list of benchmarks that can be run
        // dotnet run -c Release --framework net6.0 --bm --list flat

        // To run a specific benchmark class
        // dotnet run -c Release --framework net6.0 --bm --filter System.ClientModel.Tests.Internal.Perf.ResourceProviderDataModel*

        // To run a specific benchmark method
        // dotnet run -c Release --framework net6.0 --bm --filter *ResourceProviderDataModel.Read_PublicInterface
        // or
        // dotnet run -c Release --framework net6.0 --bm --filter System.ClientModel.Tests.Internal.Perf.ResourceProviderDataModel.Read_PublicInterface

        // To run a specific benchmark class and category
        // dotnet run -c Release --framework net6.0 --bm --anyCategories PublicInterface --filter System.ClientModel.Tests.Internal.Perf.ResourceProviderDataModel*

        var config = ManualConfig.Create(DefaultConfig.Instance);
        config.Options = ConfigOptions.JoinSummary | ConfigOptions.StopOnFirstError;
        config = config.AddDiagnoser(MemoryDiagnoser.Default);
        config.AddJob(Job.Default
            .WithWarmupCount(1)
            .WithIterationTime(TimeInterval.FromMilliseconds(250))
            .WithMinIterationCount(15)
            .WithMaxIterationCount(20)
            .AsDefault());
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args.Where(a => !a.Equals("--bm")).ToArray(), config);
    }
}