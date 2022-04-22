// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Running;
using Azure.ResourceManager.Perf;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<MgmtTelemetryPolicyBenchmark>();
    }
}
