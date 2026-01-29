// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
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
        config.AddJob(Job.Default
            .WithWarmupCount(1)
            .WithIterationTime(TimeInterval.FromMilliseconds(250))
            .WithMinIterationCount(15)
            .WithMaxIterationCount(20)
            .AsDefault());
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
    }
}
