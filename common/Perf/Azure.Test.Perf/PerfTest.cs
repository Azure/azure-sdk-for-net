// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public abstract class PerfTest<TOptions> : IPerfTest where TOptions : PerfOptions
    {
        private readonly HttpPipelineTransport _insecureTransport;

        private readonly HttpClient _recordPlaybackHttpClient;
        private readonly Uri _testProxy;
        private readonly TestProxyPolicy _testProxyPolicy;

        private string _recordingId;

        protected TOptions Options { get; private set; }

        private static int _globalParallelIndex;
        protected int ParallelIndex { get; }

        public PerfTest(TOptions options)
        {
            Options = options;
            ParallelIndex = Interlocked.Increment(ref _globalParallelIndex) - 1;

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
                    // Assume _transport is HttpWebRequestTransport (currently internal class)
                    ServicePointManager.ServerCertificateValidationCallback = (message, cert, chain, errors) => true;

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

        public virtual Task GlobalSetupAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task SetupAsync()
        {
            return Task.CompletedTask;
        }

        public async Task RecordAndStartPlayback()
        {
            // Make one call to Run() before starting recording, to avoid capturing one-time setup like authorization requests.
            if (Options.Sync)
            {
                Run(CancellationToken.None);
            }
            else
            {
                await RunAsync(CancellationToken.None);
            }

            await StartRecording();

            _testProxyPolicy.RecordingId = _recordingId;
            _testProxyPolicy.Mode = "record";

            // Record one call to Run()
            if (Options.Sync)
            {
                Run(CancellationToken.None);
            }
            else
            {
                await RunAsync(CancellationToken.None);
            }

            await StopRecording();

            await StartPlayback();

            _testProxyPolicy.Mode = "playback";
            _testProxyPolicy.RecordingId = _recordingId;
        }

        public abstract void Run(CancellationToken cancellationToken);

        public abstract Task RunAsync(CancellationToken cancellationToken);

        public async Task StopPlayback()
        {
            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(_testProxy, "/playback/stop"));
            message.Headers.Add("x-recording-id", _recordingId);
            message.Headers.Add("x-purge-inmemory-recording", bool.TrueString);

            await _recordPlaybackHttpClient.SendAsync(message);

            // Stop redirecting requests to test proxy
            _testProxyPolicy.Mode = null;
            _testProxyPolicy.RecordingId = null;
        }

        public virtual Task CleanupAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task GlobalCleanupAsync()
        {
            return Task.CompletedTask;
        }

        // https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync#implement-both-dispose-and-async-dispose-patterns
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();

            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
        }

        public virtual ValueTask DisposeAsyncCore()
        {
            return default;
        }

        protected static string GetEnvironmentVariable(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException($"Undefined environment variable {name}");
            }
            return value;
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
