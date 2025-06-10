// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Benchmarks.Nuget;
using Benchmarks.Local;

namespace Azure.Core.Perf;

[SimpleJob(RuntimeMoniker.Net80)]

[MemoryDiagnoser]
public class PipelineBenchmark
{
    private Benchmarks.Local.PipelineScenario _localScenario;
    private Benchmarks.Nuget.PipelineScenario _nugetScenario;
    private HttpMessage _localMessage;
    private HttpMessage _nugetMessage;

    [GlobalSetup]
    public void SetUp()
    {
        // Set up local scenario
        _localScenario = new Benchmarks.Local.PipelineScenario();
        _localMessage = _localScenario._pipeline.CreateMessage();
        _localMessage.Request.Uri.Reset(new Uri("https://www.example.com"));

        // Set up NuGet scenario
        _nugetScenario = new Benchmarks.Nuget.PipelineScenario();
        _nugetMessage = _nugetScenario._pipeline.CreateMessage();
        _nugetMessage.Request.Uri.Reset(new Uri("https://www.example.com"));
    }

    [Benchmark]
    public async Task<Response> LocalPipeline()
    {
        return await _localScenario.SendAsync();
    }

    [Benchmark(Baseline = true)]
    public async Task<Response> NugetPipeline()
    {
        return await _nugetScenario.SendAsync();
    }
}
