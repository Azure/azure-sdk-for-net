// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using BenchmarkDotNet.Attributes;

/*
Measures what a single request pays inside IngestionRedirectPolicy, which sits in the shared
pipeline and therefore runs for single-tenant callers too.

Multi-tenant export required two changes on this path, and both are now live for every caller
whether or not the feature is switched on:

  - CreateRequest builds a fresh RawRequestUriBuilder per request. It previously reused one
    instance, which is what let a learned redirect permanently retarget every later request.
  - Once any redirect has been learned, the policy materializes a Uri and a key string and takes
    a lock on every request. Before the first redirect it does none of that.

The three cases below separate those costs:

  NoRedirectLearned  - the cache is empty. One volatile read, then straight through. This is what
                       the overwhelming majority of callers pay, because most ingestion endpoints
                       never issue a redirect.
  RedirectLearned    - a redirect for this origin is cached. Pays the key materialization and the
                       lock on every request.
  RedirectLearnedOtherOrigin - a redirect is cached, but for a different origin. Worst case for the
                       common path: full key cost and lock, and the lookup misses.

BuildRequestUri isolates the per-request builder allocation on its own.

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9106/25H2/2025Update/HudsonValley2) (Hyper-V)
Intel Xeon Platinum 8370C CPU 2.80GHz (Max: 2.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.401
  [Host]    : .NET 8.0.31 (8.0.31, 8.0.3126.42015), X64 RyuJIT x86-64-v4
  MediumRun : .NET 8.0.31 (8.0.31, 8.0.3126.42015), X64 RyuJIT x86-64-v4

Job=MediumRun  IterationCount=15  LaunchCount=2  WarmupCount=10

| Method                     | Mean      | Error     | StdDev     | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------------------------- |----------:|----------:|-----------:|------:|-------:|----------:|------------:|
| NoRedirectLearned          | 465.50 ns | 44.309 ns |  66.320 ns |  1.02 | 0.0381 |     968 B |        1.00 |
| RedirectLearned            | 925.80 ns | 69.305 ns | 101.586 ns |  2.02 | 0.0477 |    1216 B |        1.26 |
| RedirectLearnedOtherOrigin | 615.15 ns | 30.883 ns |  45.268 ns |  1.34 | 0.0439 |    1112 B |        1.15 |
| BuildRequestUri            |  55.98 ns |  2.447 ns |   3.587 ns |  0.12 | 0.0067 |     168 B |        0.17 |

Reading these numbers: the transport is a no-op, so the whole of a real request is missing. An
ingestion POST costs milliseconds. The 460 ns and 248 B that a learned redirect adds is therefore
around 0.05% of a request that takes 1 ms, and the per-request builder that every caller pays
regardless is 56 ns. Both are too small to be worth optimizing, which is the useful result: the
correctness fixes did not cost the single-tenant path anything that matters.

One optimization was tried and rejected. The cache-hit path calls request.Uri.ToUri() twice, which
looks like two Uri allocations. Hoisting it into a local left the allocated bytes byte-for-byte
identical, because RequestUriBuilder already caches the Uri it builds and invalidates on mutation,
so the second call was nearly free. The change was reverted rather than kept on an unmeasurable gain.
*/

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class IngestionRedirectPolicyBenchmarks
    {
        private const string Origin = "https://westus2-1.in.applicationinsights.azure.com/v2.1/track";
        private const string OtherOrigin = "https://eastus-2.in.applicationinsights.azure.com/v2.1/track";
        private const string RedirectTarget = "https://westus2-1.in.applicationinsights.azure.com/v2.1/track/redirected";

        private static readonly Uri s_trackUri = new(Origin);

        private HttpPipeline _cold = null!;
        private HttpPipeline _warmSameOrigin = null!;
        private HttpPipeline _warmOtherOrigin = null!;

        [GlobalSetup]
        public void Setup()
        {
            _cold = BuildPipeline(out _);

            _warmSameOrigin = BuildPipeline(out var sameOriginTransport);
            WarmRedirectCache(_warmSameOrigin, sameOriginTransport, Origin);

            _warmOtherOrigin = BuildPipeline(out var otherOriginTransport);
            WarmRedirectCache(_warmOtherOrigin, otherOriginTransport, OtherOrigin);
        }

        [Benchmark(Baseline = true)]
        public void NoRedirectLearned() => Send(_cold);

        [Benchmark]
        public void RedirectLearned() => Send(_warmSameOrigin);

        [Benchmark]
        public void RedirectLearnedOtherOrigin() => Send(_warmOtherOrigin);

        /// <summary>
        /// The per-request builder on its own, with no policy around it.
        /// </summary>
        [Benchmark]
        public RequestUriBuilder BuildRequestUri()
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(s_trackUri);

            return uri;
        }

        private static void Send(HttpPipeline pipeline)
        {
            using var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Post;
            message.Request.Uri.Reset(s_trackUri);

            pipeline.Send(message, CancellationToken.None);
        }

        /// <summary>
        /// Drives one real 307 through the policy so the cache holds an entry for <paramref name="origin"/>,
        /// rather than reaching into the cache directly.
        /// </summary>
        private static void WarmRedirectCache(HttpPipeline pipeline, RedirectOnceTransport transport, string origin)
        {
            transport.RedirectNextRequest = true;

            using var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Post;
            message.Request.Uri.Reset(new Uri(origin));

            pipeline.Send(message, CancellationToken.None);

            transport.RedirectNextRequest = false;
        }

        private static HttpPipeline BuildPipeline(out RedirectOnceTransport transport)
        {
            transport = new RedirectOnceTransport();

            return new HttpPipeline(transport, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });
        }

        /// <summary>
        /// Answers 307 once when asked to, and 200 otherwise, so no socket is involved.
        /// </summary>
        private sealed class RedirectOnceTransport : HttpPipelineTransport
        {
            internal bool RedirectNextRequest;

            public override Request CreateRequest() => new MockRequest();

            public override void Process(HttpMessage message) => message.Response = BuildResponse();

            public override System.Threading.Tasks.ValueTask ProcessAsync(HttpMessage message)
            {
                message.Response = BuildResponse();

                return default;
            }

            private MockResponse BuildResponse()
            {
                if (!RedirectNextRequest)
                {
                    return new MockResponse(200);
                }

                RedirectNextRequest = false;

                var response = new MockResponse(307);
                response.AddHeader(new HttpHeader("Location", RedirectTarget));
                response.AddHeader(new HttpHeader("Cache-Control", "max-age=3600"));

                return response;
            }
        }
    }
}
