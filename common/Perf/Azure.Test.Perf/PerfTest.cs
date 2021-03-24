// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public abstract class PerfTest<TOptions> : IPerfTest where TOptions : PerfOptions
    {
        protected TOptions Options { get; private set; }

        private HttpClient _httpClient;

        protected TestProxyTransport Transport { get; private set; }
        private string _playbackRecordingId;

        public PerfTest(TOptions options)
        {
            Options = options;

            if (Options.Insecure)
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

            Transport = new TestProxyTransport(httpClientTransport, Options.Host, Options.Port);
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
            var recordingFile = Guid.NewGuid().ToString();

            var recordRecordingId = await StartRecording(recordingFile);

            Transport.RecordingId = recordRecordingId;
            Transport.Mode = "record";

            // Record one call to Run()
            if (Options.Sync)
            {
                Run(CancellationToken.None);
            }
            else
            {
                await RunAsync(CancellationToken.None);
            }

            await StopRecording(recordRecordingId);

            _playbackRecordingId = await StartPlayback(recordingFile);

            Transport.Mode = "playback";
            Transport.RecordingId = _playbackRecordingId;
        }

        public abstract void Run(CancellationToken cancellationToken);

        public abstract Task RunAsync(CancellationToken cancellationToken);

        public async Task StopPlayback()
        {
            await StopPlayback(_playbackRecordingId);

            // Stop redirecting requests to test proxy
            Transport.RecordingId = null;
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

        private async Task<string> StartPlayback(string recordingFile)
        {
            Console.WriteLine("StartPlayback");

            var message = new HttpRequestMessage(HttpMethod.Post, $"https://{Options.Host}:{Options.Port}/playback/start");
            message.Headers.Add("x-recording-file", recordingFile);

            var response = await _httpClient.SendAsync(message);
            var recordingId = response.Headers.GetValues("x-recording-id").Single();
            Console.WriteLine($"  x-recording-id: {recordingId}");
            Console.WriteLine();

            return recordingId;
        }

        private async Task StopPlayback(string recordingId)
        {
            Console.WriteLine("StopPlayback");
            Console.WriteLine();

            var message = new HttpRequestMessage(HttpMethod.Post, $"https://{Options.Host}:{Options.Port}/playback/stop");
            message.Headers.Add("x-recording-id", recordingId);

            await _httpClient.SendAsync(message);
        }

        private async Task<string> StartRecording(string recordingFile)
        {
            Console.WriteLine("StartRecording");

            var message = new HttpRequestMessage(HttpMethod.Post, $"https://{Options.Host}:{Options.Port}/record/start");
            message.Headers.Add("x-recording-file", recordingFile);

            var response = await _httpClient.SendAsync(message);
            var recordingId = response.Headers.GetValues("x-recording-id").Single();

            Console.WriteLine($"  x-recording-id: {recordingId}");
            Console.WriteLine();

            return recordingId;
        }

        private async Task StopRecording(string recordingId)
        {
            Console.WriteLine("StopRecording");
            Console.WriteLine();

            var message = new HttpRequestMessage(HttpMethod.Post, $"https://{Options.Host}:{Options.Port}/record/stop");
            message.Headers.Add("x-recording-id", recordingId);
            message.Headers.Add("x-recording-save", bool.TrueString);

            await _httpClient.SendAsync(message);
        }
    }
}
