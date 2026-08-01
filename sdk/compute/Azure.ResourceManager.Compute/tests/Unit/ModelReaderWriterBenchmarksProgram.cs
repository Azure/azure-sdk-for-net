// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace Azure.ResourceManager.Compute.Tests.Unit
{
    public static class ModelReaderWriterBenchmarksProgram
    {
        public static void Main(string[] args)
        {
            var config = ManualConfig.Create(DefaultConfig.Instance)
                .WithOptions(ConfigOptions.DisableOptimizationsValidator);
            BenchmarkRunner.Run<ModelReaderWriterBenchmarks>(config, args);
        }
    }
}
