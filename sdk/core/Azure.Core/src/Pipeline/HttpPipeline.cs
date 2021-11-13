// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Represents a primitive for sending HTTP requests and receiving responses extensible by adding <see cref="HttpPipelinePolicy"/> processing steps.
    /// </summary>
    public class HttpPipeline
    {
        private static readonly AsyncLocal<HttpMessagePropertiesScope?> CurrentHttpMessagePropertiesScope = new AsyncLocal<HttpMessagePropertiesScope?>();

        private protected readonly HttpPipelineTransport _transport;

        private readonly ReadOnlyMemory<HttpPipelinePolicy> _pipeline;

        private readonly bool _internallyConstructed;
        private readonly int _perCallIndex;
        private readonly int _perRetryIndex;
        private readonly int _transportIndex;

        /// <summary>
        /// Creates a new instance of <see cref="HttpPipeline"/> with the provided transport, policies and response classifier.
        /// </summary>
        /// <param name="transport">The <see cref="HttpPipelineTransport"/> to use for sending the requests.</param>
        /// <param name="policies">Policies to be invoked as part of the pipeline in order.</param>
        /// <param name="responseClassifier">The response classifier to be used in invocations.</param>
        public HttpPipeline(HttpPipelineTransport transport, HttpPipelinePolicy[]? policies = null, ResponseClassifier? responseClassifier = null)
        {
            _transport = transport ?? throw new ArgumentNullException(nameof(transport));
            ResponseClassifier = responseClassifier ?? new ResponseClassifier();

            policies = policies ?? Array.Empty<HttpPipelinePolicy>();

            var all = new HttpPipelinePolicy[policies.Length + 1];
            all[policies.Length] = new HttpPipelineTransportPolicy(_transport);
            policies.CopyTo(all, 0);

            _transportIndex = policies.Length;

            _pipeline = all;
        }

        internal HttpPipeline(HttpPipelineTransport transport, int perCallIndex, int perRetryIndex, HttpPipelinePolicy[]? policies = null, ResponseClassifier? responseClassifier = null) : this(transport, policies, responseClassifier)
        {
            _perCallIndex = perCallIndex;
            _perRetryIndex = perRetryIndex;
            _internallyConstructed = true;
        }

        /// <summary>
        /// Creates a new <see cref="Request"/> instance.
        /// </summary>
        /// <returns>The request.</returns>
        public Request CreateRequest()
            => _transport.CreateRequest();

        /// <summary>
        /// Creates a new <see cref="HttpMessage"/> instance.
        /// </summary>
        /// <returns>The message.</returns>
        public HttpMessage CreateMessage()
        {
            return new HttpMessage(CreateRequest(), ResponseClassifier);
        }

        /// <summary>
        /// Creates a new <see cref="HttpMessage"/> instance.
        /// </summary>
        /// <param name="context">Context specifying the message options.</param>
        /// <returns>The message.</returns>
        public HttpMessage CreateMessage(RequestContext context)
        {
            var message = CreateMessage();
            if (context != null)
            {
                message.CancellationToken = context.CancellationToken;
                message.Policies = context.Policies;
            }
            return message;
        }

        /// <summary>
        /// The <see cref="ResponseClassifier"/> instance used in this pipeline invocations.
        /// </summary>
        public ResponseClassifier ResponseClassifier { get; }

        /// <summary>
        /// Invokes the pipeline asynchronously. After the task completes response would be set to the <see cref="HttpMessage.Response"/> property.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public async ValueTask SendAsync(HttpMessage message, CancellationToken cancellationToken)
        {
            message.CancellationToken = cancellationToken;
            AddHttpMessageProperties(message);

            if (message.Policies == null)
            {
                await _pipeline.Span[0].ProcessAsync(message, _pipeline.Slice(1)).ConfigureAwait(false);
            }
            else
            {
                var length = _pipeline.Length + message.Policies.Count;
                var policies = ArrayPool<HttpPipelinePolicy>.Shared.Rent(length);
                try
                {
                    var pipeline = CreateRequestPipeline(policies, message.Policies);
                    await pipeline.Span[0].ProcessAsync(message, pipeline.Slice(1)).ConfigureAwait(false);
                }
                finally
                {
                    ArrayPool<HttpPipelinePolicy>.Shared.Return(policies);
                }
            }
        }

        /// <summary>
        /// Invokes the pipeline synchronously. After the task completes response would be set to the <see cref="HttpMessage.Response"/> property.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        public void Send(HttpMessage message, CancellationToken cancellationToken)
        {
            message.CancellationToken = cancellationToken;
            AddHttpMessageProperties(message);

            if (message.Policies == null)
            {
                _pipeline.Span[0].Process(message, _pipeline.Slice(1));
            }
            else
            {
                var length = _pipeline.Length + message.Policies.Count;
                var policies = ArrayPool<HttpPipelinePolicy>.Shared.Rent(length);
                try
                {
                    var pipeline = CreateRequestPipeline(policies, message.Policies);
                    pipeline.Span[0].ProcessAsync(message, pipeline.Slice(1));
                }
                finally
                {
                    ArrayPool<HttpPipelinePolicy>.Shared.Return(policies);
                }
            }
        }

        /// <summary>
        /// Invokes the pipeline asynchronously with the provided request.
        /// </summary>
        /// <param name="request">The <see cref="Request"/> to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="ValueTask{T}"/> representing the asynchronous operation.</returns>
        public async ValueTask<Response> SendRequestAsync(Request request, CancellationToken cancellationToken)
        {
            HttpMessage message = new HttpMessage(request, ResponseClassifier);
            await SendAsync(message, cancellationToken).ConfigureAwait(false);
            return message.Response;
        }

        /// <summary>
        /// Invokes the pipeline synchronously with the provided request.
        /// </summary>
        /// <param name="request">The <see cref="Request"/> to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        public Response SendRequest(Request request, CancellationToken cancellationToken)
        {
            HttpMessage message = new HttpMessage(request, ResponseClassifier);
            Send(message, cancellationToken);
            return message.Response;
        }

        /// <summary>
        /// Creates a scope in which all outgoing requests would use the provided
        /// </summary>
        /// <param name="clientRequestId">The client request id value to be sent with request.</param>
        /// <returns>The <see cref="IDisposable"/> instance that needs to be disposed when client request id shouldn't be sent anymore.</returns>
        /// <example>
        /// Sample usage:
        /// <code snippet="Snippet:ClientRequestId" language="csharp">
        /// var secretClient = new SecretClient(new Uri(&quot;http://example.com&quot;), new DefaultAzureCredential());
        ///
        /// using (HttpPipeline.CreateClientRequestIdScope(&quot;&lt;custom-client-request-id&gt;&quot;))
        /// {
        ///     // The HTTP request resulting from the client call would have x-ms-client-request-id value set to &lt;custom-client-request-id&gt;
        ///     secretClient.GetSecret(&quot;&lt;secret-name&gt;&quot;);
        /// }
        /// </code>
        /// </example>
        public static IDisposable CreateClientRequestIdScope(string? clientRequestId)
        {
            return CreateHttpMessagePropertiesScope(new Dictionary<string, object?>() { { ReadClientRequestIdPolicy.MessagePropertyKey, clientRequestId } });
        }

        /// <summary>
        /// Creates a scope in which all <see cref="HttpMessage"/>s would have provided properties.
        /// </summary>
        /// <param name="messageProperties">Properties to be added to <see cref="HttpMessage"/>s</param>
        /// <returns>The <see cref="IDisposable"/> instance that needs to be disposed when properties shouldn't be used anymore.</returns>
        public static IDisposable CreateHttpMessagePropertiesScope(IDictionary<string, object?> messageProperties)
        {
            Argument.AssertNotNull(messageProperties, nameof(messageProperties));
            CurrentHttpMessagePropertiesScope.Value = new HttpMessagePropertiesScope(messageProperties, CurrentHttpMessagePropertiesScope.Value);
            return CurrentHttpMessagePropertiesScope.Value;
        }

        private ReadOnlyMemory<HttpPipelinePolicy> CreateRequestPipeline(HttpPipelinePolicy[] policies, List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)> customPolicies)
        {
            if (!_internallyConstructed)
            {
                throw new InvalidOperationException("Cannot send messages with per-request policies if the pipeline wasn't constructed with HttpPipelineBuilder.");
            }

            int AddCustomPolicies(HttpPipelinePosition position, int start)
            {
                int i = 0;
                if (customPolicies != null)
                {
                    foreach (var policy in customPolicies)
                    {
                        if (policy.Position == position)
                        {
                            policies[start + i++] = policy.Policy;
                        }
                    }
                }

                return i;
            }

            // Copy over client policies and splice in custom policies at designated indices
            _pipeline.Slice(0, _perCallIndex).CopyTo(policies);

            int custom = AddCustomPolicies(HttpPipelinePosition.PerCall, _perCallIndex);

            int count = _perRetryIndex - _perCallIndex;
            _pipeline.Slice(_perCallIndex, count).CopyTo(new Memory<HttpPipelinePolicy>(policies, _perCallIndex + custom, count));

            custom += AddCustomPolicies(HttpPipelinePosition.PerRetry, _perRetryIndex + custom);

            count = _transportIndex - _perRetryIndex;
            _pipeline.Slice(_perRetryIndex, count).CopyTo(new Memory<HttpPipelinePolicy>(policies, _perRetryIndex + custom, count));

            custom += AddCustomPolicies(HttpPipelinePosition.BeforeTransport, _transportIndex + custom);

            count = _pipeline.Length - _transportIndex;
            _pipeline.Slice(_transportIndex, count).CopyTo(new Memory<HttpPipelinePolicy>(policies, _transportIndex + custom, count));

            return new ReadOnlyMemory<HttpPipelinePolicy>(policies, 0, _pipeline.Length + custom);
        }

        private static void AddHttpMessageProperties(HttpMessage message)
        {
            if (CurrentHttpMessagePropertiesScope.Value != null)
            {
                foreach (KeyValuePair<string, object?> kvp in CurrentHttpMessagePropertiesScope.Value.Properties)
                {
                    if (kvp.Value != null)
                    {
                        message.SetProperty(kvp.Key, kvp.Value);
                    }
                }
            }
        }

        private class HttpMessagePropertiesScope : IDisposable
        {
            private readonly HttpMessagePropertiesScope? _parent;
            private bool _disposed;

            internal HttpMessagePropertiesScope(IDictionary<string, object?> messageProperties, HttpMessagePropertiesScope? parent)
            {
                if (parent != null)
                {
                    Properties = new Dictionary<string, object?>(parent.Properties);
                    foreach (var kvp in messageProperties)
                    {
                        Properties[kvp.Key] = kvp.Value;
                    }
                }
                else
                {
                    Properties = new Dictionary<string, object?>(messageProperties);
                }
                _parent = parent;
            }

            public Dictionary<string, object?> Properties { get; }

            public void Dispose()
            {
                if (_disposed)
                {
                    return;
                }
                CurrentHttpMessagePropertiesScope.Value = _parent;
                _disposed = true;
            }
        }
    }
}
