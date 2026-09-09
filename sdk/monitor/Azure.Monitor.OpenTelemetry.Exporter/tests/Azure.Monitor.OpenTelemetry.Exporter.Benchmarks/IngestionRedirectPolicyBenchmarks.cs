// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

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
  RedirectLearned    - a redirect for this origin is cached, so the request pays the key
                       materialization, the lock, the trust check against the cached target, and the
                       rewrite.
  RedirectLearnedOtherOrigin - a redirect is cached, but for a different origin. Pays the key
                       materialization and the lock, then misses and does no trust check. The gap
                       between these two rows is therefore what the trust check and rewrite cost,
                       and the gap from the baseline is what the key and lock cost.

BuildRequestUri isolates the per-request builder allocation on its own.

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9106/25H2/2025Update/HudsonValley2) (Hyper-V)
Intel Xeon Platinum 8370C CPU 2.80GHz (Max: 2.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.401
  [Host]    : .NET 8.0.31 (8.0.31, 8.0.3126.42015), X64 RyuJIT x86-64-v4
  MediumRun : .NET 8.0.31 (8.0.31, 8.0.3126.42015), X64 RyuJIT x86-64-v4

Job=MediumRun  IterationCount=15  LaunchCount=2  WarmupCount=10

| Method                     | Mean        | Error      | StdDev     | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------------------------- |------------:|-----------:|-----------:|------:|-------:|----------:|------------:|
| NoRedirectLearned          |   586.05 ns |  37.084 ns |  55.506 ns |  1.01 | 0.0467 |    1192 B |        1.00 |
| RedirectLearned            | 1,145.17 ns | 114.137 ns | 170.835 ns |  1.97 | 0.0572 |    1440 B |        1.21 |
| RedirectLearnedOtherOrigin |   759.45 ns |  77.354 ns | 115.780 ns |  1.31 | 0.0525 |    1336 B |        1.12 |
| BuildRequestUri            |    64.72 ns |   5.728 ns |   8.395 ns |  0.11 | 0.0067 |     168 B |        0.14 |

Reading these numbers: the transport is a no-op, so the whole of a real request is missing. An
ingestion POST costs milliseconds. The 559 ns and 248 B that a learned redirect adds is therefore
around 0.06% of a request that takes 1 ms, and the per-request builder that every caller pays
regardless is 65 ns. Both are too small to be worth optimizing, which is the useful result: the
correctness fixes did not cost the single-tenant path anything that matters.

Where that 559 ns goes is not where it first appears. RedirectLearnedOtherOrigin pays the key
materialization and the lock in full and lands only 173 ns above the baseline, so the remaining
386 ns belongs to IsTrustedIngestionRedirect and the rewrite, not to the lock. The trust check
lower-cases two IdnHost values, which is also most of the 248 B. Anyone optimizing this should start
there and not at the cache.

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
        /// rather than reaching into the cache directly. Whether the entry is written depends on
        /// production trust and header-parsing rules, and when it is not the policy simply carries on,
        /// so the result is verified instead of assumed: an unwarmed pipeline would silently turn two
        /// of the rows below into duplicates of the baseline.
        /// </summary>
        private static void WarmRedirectCache(HttpPipeline pipeline, RedirectOnceTransport transport, string origin)
        {
            transport.ArmRedirect();

            using (var message = pipeline.CreateMessage())
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri(origin));

                pipeline.Send(message, CancellationToken.None);
            }

            using var probe = pipeline.CreateMessage();
            probe.Request.Method = RequestMethod.Post;
            probe.Request.Uri.Reset(new Uri(origin));

            pipeline.Send(probe, CancellationToken.None);

            if (probe.Request.Uri.ToUri().AbsoluteUri != RedirectTarget)
            {
                throw new InvalidOperationException(
                    $"Redirect cache was not warmed for {origin}: the probe was sent to {probe.Request.Uri} instead of {RedirectTarget}.");
            }
        }

        private static HttpPipeline BuildPipeline(out RedirectOnceTransport transport)
        {
            transport = new RedirectOnceTransport();

            return new HttpPipeline(transport, new HttpPipelinePolicy[] { new IngestionRedirectPolicy() });
        }

        /// <summary>
        /// Answers 307 once when armed, and 200 otherwise, so no socket is involved.
        /// </summary>
        private sealed class RedirectOnceTransport : HttpPipelineTransport
        {
            private int _redirectsRemaining;

            internal void ArmRedirect() => _redirectsRemaining = 1;

            public override Request CreateRequest() => new MockRequest();

            public override void Process(HttpMessage message) => message.Response = BuildResponse();

            public override ValueTask ProcessAsync(HttpMessage message)
            {
                message.Response = BuildResponse();

                return default;
            }

            private MockResponse BuildResponse()
            {
                if (_redirectsRemaining == 0)
                {
                    // Carries the cache directive because the policy reads it from the response that
                    // completes the redirect, not from the 307 itself.
                    var ok = new MockResponse(200);
                    ok.AddHeader(new HttpHeader("Cache-Control", "max-age=3600"));

                    return ok;
                }

                _redirectsRemaining--;

                var response = new MockResponse(307);
                response.AddHeader(new HttpHeader("Location", RedirectTarget));

                return response;
            }
        }
    }
}
