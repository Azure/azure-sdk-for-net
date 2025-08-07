// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public abstract class BatchPerfTest<TOptions> : PerfTestBase<TOptions> where TOptions : PerfOptions
    {
        private readonly HttpPipelineTransport _insecureTransport;

        private readonly HttpClient _recordPlaybackHttpClient;
        private readonly Uri _testProxy;
        private readonly TestProxyPolicy _testProxyPolicy;
        private string _recordingId;

        private long _completedOperations;
        public sealed override long CompletedOperations => _completedOperations;

        private List<TimeSpan> _latencies;
        public sealed override IList<TimeSpan> Latencies => _latencies;

        private List<TimeSpan> _correctedLatencies;
        public sealed override IList<TimeSpan> CorrectedLatencies => _correctedLatencies;

        public BatchPerfTest(TOptions options) : base(options)
        {
            if (Options.Insecure)
            {
                var transport = (new PerfClientOptions()).Transport;

                // Disable SSL validation
                if (transport is HttpClientTransport)
                {
                    _insecureTransport = new HttpClientTransport(new HttpClient(new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                    }));
                }
                else
                {
#if NETFRAMEWORK
                    // Assume _transport is HttpWebRequestTransport (currently internal class)
                    ServicePointManager.ServerCertificateValidationCallback = (message, cert, chain, errors) => true;
#endif
                    _insecureTransport = transport;
                }
            }

            if (Options.TestProxies != null && Options.TestProxies.Any())
            {
                if (Options.Insecure)
                {
                    _recordPlaybackHttpClient = new HttpClient(new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                    });
                }
                else
                {
                    _recordPlaybackHttpClient = new HttpClient();
                }

                _testProxy = Options.TestProxies.ElementAt(ParallelIndex % Options.TestProxies.Count());
                _testProxyPolicy = new TestProxyPolicy(_testProxy);
            }
        }

        protected TClientOptions ConfigureClientOptions<TClientOptions>(TClientOptions clientOptions) where TClientOptions : ClientOptions
        {
            if (_insecureTransport != null)
            {
                clientOptions.Transport = _insecureTransport;
            }

            if (_testProxyPolicy != null)
            {
                // TestProxyPolicy should be per-retry to run as late as possible in the pipeline.  For example, some
                // clients compute a request signature as a per-retry policy, and TestProxyPolicy should run after the
                // signature is computed to avoid altering the signature.
                clientOptions.AddPolicy(_testProxyPolicy, HttpPipelinePosition.PerRetry);
            }

            return clientOptions;
        }

        public sealed override async Task PostSetupAsync()
        {
            if (_testProxyPolicy != null)
            {
                // Make one call to Run() before starting recording, to avoid capturing one-time setup like authorization requests.
                if (Options.Sync)
                {
                    RunBatch(CancellationToken.None);
                }
                else
                {
                    await RunBatchAsync(CancellationToken.None);
                }

                await StartRecording();

                _testProxyPolicy.RecordingId = _recordingId;
                _testProxyPolicy.Mode = "record";

                // Record one call to RunMulti()
                if (Options.Sync)
                {
                    RunBatch(CancellationToken.None);
                }
                else
                {
                    await RunBatchAsync(CancellationToken.None);
                }

                await StopRecording();

                await StartPlayback();

                _testProxyPolicy.Mode = "playback";
                _testProxyPolicy.RecordingId = _recordingId;
            }
        }

        public sealed override void RunAll(CancellationToken cancellationToken)
        {
            _completedOperations = 0;
            LastCompletionTime = default;

            var sw = Stopwatch.StartNew();
            var latencySw = new Stopwatch();

            (TimeSpan Start, Stopwatch Stopwatch) operation = (default, default);

            if (Options.Latency)
            {
                _latencies = new List<TimeSpan>();

                if (PendingOperations != null)
                {
                    _correctedLatencies = new List<TimeSpan>();
                }
            }

            while (!cancellationToken.IsCancellationRequested)
            {
                if (PendingOperations != null)
                {
                    operation = PendingOperations.Reader.ReadAsync(cancellationToken).AsTask().Result;
                }

                if (Options.Latency)
                {
                    latencySw.Restart();
                }

                int completedOperations = RunBatch(cancellationToken);

                if (Options.Latency)
                {
                    for (var i = 0; i < completedOperations; i++)
                    {
                        _latencies.Add(latencySw.Elapsed);

                        if (PendingOperations != null)
                        {
                            _correctedLatencies.Add(operation.Stopwatch.Elapsed - operation.Start);
                        }
                    }
                }

                _completedOperations += completedOperations;
                LastCompletionTime = sw.Elapsed;
            }
        }

        public sealed override async Task RunAllAsync(CancellationToken cancellationToken)
        {
            _completedOperations = 0;
            LastCompletionTime = default;

            var sw = Stopwatch.StartNew();
            var latencySw = new Stopwatch();

            (TimeSpan Start, Stopwatch Stopwatch) operation = (default, default);

            if (Options.Latency)
            {
                _latencies = new List<TimeSpan>();

                if (PendingOperations != null)
                {
                    _correctedLatencies = new List<TimeSpan>();
                }
            }

            while (!cancellationToken.IsCancellationRequested)
            {
                if (PendingOperations != null)
                {
                    operation = await PendingOperations.Reader.ReadAsync(cancellationToken);
                }

                if (Options.Latency)
                {
                    latencySw.Restart();
                }

                var completedOperations = await RunBatchAsync(cancellationToken);

                if (Options.Latency)
                {
                    for (var i = 0; i < completedOperations; i++)
                    {
                        _latencies.Add(latencySw.Elapsed);

                        if (PendingOperations != null)
                        {
                            _correctedLatencies.Add(operation.Stopwatch.Elapsed - operation.Start);
                        }
                    }
                }

                _completedOperations += completedOperations;
                LastCompletionTime = sw.Elapsed;
            }
        }

        public abstract int RunBatch(CancellationToken cancellationToken);

        public abstract Task<int> RunBatchAsync(CancellationToken cancellationToken);

        public sealed override async Task PreCleanupAsync()
        {
            // Only stop playback if it was successfully started
            if (_testProxyPolicy != null && _testProxyPolicy.Mode == "playback")
            {
                var message = new HttpRequestMessage(HttpMethod.Post, new Uri(_testProxy, "/playback/stop"));
                message.Headers.Add("x-recording-id", _recordingId);
                message.Headers.Add("x-purge-inmemory-recording", bool.TrueString);

                await _recordPlaybackHttpClient.SendAsync(message);

                // Stop redirecting requests to test proxy
                _testProxyPolicy.Mode = null;
                _testProxyPolicy.RecordingId = null;
            }
        }

        private async Task StartRecording()
        {
            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(_testProxy, "/record/start"));

            var response = await _recordPlaybackHttpClient.SendAsync(message);
            _recordingId = response.Headers.GetValues("x-recording-id").Single();
        }

        private async Task StopRecording()
        {
            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(_testProxy, "/record/stop"));
            message.Headers.Add("x-recording-id", _recordingId);

            await _recordPlaybackHttpClient.SendAsync(message);
        }

        private async Task StartPlayback()
        {
            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(_testProxy, "/playback/start"));
            message.Headers.Add("x-recording-id", _recordingId);

            var response = await _recordPlaybackHttpClient.SendAsync(message);
            _recordingId = response.Headers.GetValues("x-recording-id").Single();
        }

        // Dummy class used to fetch default HttpPipelineTransport
        private class PerfClientOptions : ClientOptions { }
    }
}
