// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public abstract class PerfTest<TOptions> : IPerfTest where TOptions : PerfOptions
    {
        private readonly HttpClient _httpClient;
        private readonly TestProxyTransport _transport;
        private string _recordingId;

        protected TOptions Options { get; private set; }
        protected HttpPipelineTransport Transport => _transport;

        public PerfTest(TOptions options)
        {
            Options = options;

            if (Options.Insecure || Options.TestProxy != null)
            {
                _httpClient = new HttpClient(new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                });
            }
            else
            {
                _httpClient = new HttpClient();
            }

            var httpClientTransport = new HttpClientTransport(_httpClient);

            _transport = new TestProxyTransport(httpClientTransport, Options.TestProxy);
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
            await StartRecording();

            _transport.RecordingId = _recordingId;
            _transport.Mode = "record";

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

            _transport.Mode = "playback";
            _transport.RecordingId = _recordingId;
        }

        public abstract void Run(CancellationToken cancellationToken);

        public abstract Task RunAsync(CancellationToken cancellationToken);

        public async Task StopPlayback()
        {
            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(Options.TestProxy, "/playback/stop"));
            message.Headers.Add("x-recording-id", _recordingId);
            message.Headers.Add("x-purge-inmemory-recording", bool.TrueString);

            await _httpClient.SendAsync(message);

            // Stop redirecting requests to test proxy
            _transport.Mode = null;
            _transport.RecordingId = null;
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
            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(Options.TestProxy, "/record/start"));

            var response = await _httpClient.SendAsync(message);
            _recordingId = response.Headers.GetValues("x-recording-id").Single();
        }

        private async Task StopRecording()
        {
            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(Options.TestProxy, "/record/stop"));
            message.Headers.Add("x-recording-id", _recordingId);

            await _httpClient.SendAsync(message);
        }

        private async Task StartPlayback()
        {
            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(Options.TestProxy, "/playback/start"));
            message.Headers.Add("x-recording-id", _recordingId);

            var response = await _httpClient.SendAsync(message);
            _recordingId = response.Headers.GetValues("x-recording-id").Single();
        }
    }
}
