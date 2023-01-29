// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.Test.Perf;

await PerfProgram.Main(Assembly.GetExecutingAssembly(), args);
// To run Benchmark.NET benchmarks, comment the line above and uncomment the benchmark test below.
// BenchmarkDotNet.Running.BenchmarkRunner.Run<Azure.Core.Perf.FastPropertyBagBenchmark>();
