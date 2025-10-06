// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using Azure.Test.Perf;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;

if (!args.Contains("--bm"))
    await PerfProgram.Main(Assembly.GetExecutingAssembly(), args);
// To run Benchmark.NET benchmarks, use the --bm flag.

// To see the list of benchmarks that can be run
// dotnet run -c Release --framework net8.0 --bm --list flat

// To run a specific benchmark class
// dotnet run -c Release --framework net8.0 --bm --filter Azure.Core.Perf.SerializationBenchmark*

// To run a specific benchmark method
// dotnet run -c Release --framework net8.0 --bm --filter *SerializationBenchmark.Deserialize_PublicInterface
// or
// dotnet run -c Release --framework net8.0 --bm --filter Azure.Core.Perf.SerializationBenchmark.Deserialize_PublicInterface

// To run a specific benchmark class and category
// dotnet run -c Release --framework net8.0 --bm --anyCategories PublicInterface --filter Azure.Core.Perf.SerializationBenchmark*

#if AZURE_CORE_VERSION_nuget
    string artifactsPath = "BenchmarkDotNet.Artifacts/results/nuget";
#else
    string artifactsPath = "BenchmarkDotNet.Artifacts/results/local";
#endif

var config = ManualConfig.Create(DefaultConfig.Instance);
config.ArtifactsPath = artifactsPath;
config.Options = ConfigOptions.JoinSummary | ConfigOptions.StopOnFirstError;
config = config.AddDiagnoser(MemoryDiagnoser.Default);
config.AddExporter(JsonExporter.Full);
config.AddJob(Job.Default
    .WithWarmupCount(1)
    .WithIterationTime(TimeInterval.FromMilliseconds(250))
    .WithMinIterationCount(15)
    .WithMaxIterationCount(20)
    .AsDefault());
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args.Where(a => !a.Equals("--bm")).ToArray(), config);
