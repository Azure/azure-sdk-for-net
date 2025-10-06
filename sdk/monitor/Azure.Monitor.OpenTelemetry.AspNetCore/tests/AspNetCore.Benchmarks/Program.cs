// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Running;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Benchmarks
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            // DebugInProcessConfig helps debug Benchmark within the same process.
            // Comment line 13 and remove comment from line 16 to launch Benchmarks in debug mode.
            // BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
        }
    }
}
