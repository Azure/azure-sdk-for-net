// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Perf.Benchmark.Tests;
using BenchmarkDotNet.Running;

public class Program
{
    public static void Main() => BenchmarkRunner.Run<BenchmarkTests>();
}
