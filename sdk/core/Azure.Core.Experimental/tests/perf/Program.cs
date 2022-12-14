// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Experimental.Perf.Benchmarks;
using BenchmarkDotNet.Running;

namespace Azure.Core.Experimental.Performance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

            //DebugBenchmark();
        }

        private static void DebugBenchmark()
        {
            ReadLargePayloadBenchmark b = new();

            string value = b.ReadJsonElement();

            value = b.ReadJsonData();
        }
    }
}
