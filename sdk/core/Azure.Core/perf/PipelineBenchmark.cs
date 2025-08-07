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

namespace Azure.Core.Perf
{
    [SimpleJob(RuntimeMoniker.Net80)]

    [MemoryDiagnoser]
    public class PipelineBenchmark
    {
        /// <summary>
        /// The HTTP pipeline used for sending requests in the benchmark scenario.
        /// </summary>
        public HttpPipeline _pipeline;
        private HttpMessage[] _messages;
        private int _messageIndex;

        [GlobalSetup]
        public void SetUp()
        {
            int messageCount = 1000;
            var options = new BenchmarkClientOptions
            {
                Transport = new HttpClientTransport(new HttpClient(new MockHttpMessageHandler()))
            };

            _pipeline = HttpPipelineBuilder.Build(options);

            // Pre-create messages

            _messages = new HttpMessage[messageCount];

            for (int i = 0; i < messageCount; i++)
            {
                var message = _pipeline.CreateMessage();

                message.Request.Uri.Reset(new Uri("https://www.example.com"));

                _messages[i] = message;
            }

            _messageIndex = 0;
        }
        [GlobalCleanup]
        public void CleanUp()
        {
            if (_messages != null)
            {
                foreach (var msg in _messages)
                {
                    msg?.Dispose();
                }
                _messages = Array.Empty<HttpMessage>();
            }
        }

        [Benchmark]
        public async Task<Response> SendMessageWithPipeline()
        {
            // Use round-robin to avoid always sending the same message

            var message = _messages[_messageIndex];

            _messageIndex = (_messageIndex + 1) % _messages.Length;

            await _pipeline.SendAsync(message, CancellationToken.None).ConfigureAwait(false);

            return message.Response;
        }
    }
}
