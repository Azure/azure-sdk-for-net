// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Benchmarks.Nuget
{
    /// <summary>
    /// Scenario for benchmarking only the send operation of the Azure Core pipeline.
    /// </summary>
    public class PipelineScenario : IDisposable
    {
        /// <summary>
        /// The HTTP pipeline used for sending requests in the benchmark scenario.
        /// </summary>
        public readonly HttpPipeline _pipeline;
        private HttpMessage[] _messages;
        private int _messageIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="PipelineScenario"/> class with a specified number of pre-created messages.
        /// </summary>
        /// <param name="messageCount">The number of HTTP messages to pre-create for the benchmark scenario.</param>
        public PipelineScenario(int messageCount = 1000)
        {
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

        /// <summary>
        /// Sends a pre-created HTTP message asynchronously using the pipeline and returns the response.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous send operation. The task result contains the <see cref="Azure.Response"/> from the pipeline.
        /// </returns>
        public async Task<Azure.Response> SendPreCreatedAsync()
        {
            // Use round-robin to avoid always sending the same message

            var message = _messages[_messageIndex];

            _messageIndex = (_messageIndex + 1) % _messages.Length;

            await _pipeline.SendAsync(message, CancellationToken.None).ConfigureAwait(false);

            return message.Response;
        }

        /// <summary>
        /// Releases the resources used by the <see cref="PipelineScenario"/> instance.
        /// </summary>
        public void Dispose()
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
    }
}
