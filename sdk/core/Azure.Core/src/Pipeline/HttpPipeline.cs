// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
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

        /// <summary>
        /// Indicates whether or not the pipeline was created using its internal constructor.
        /// If it was, we know the indices where we can add per-request policies at positions
        /// <see cref="HttpPipelinePosition.PerCall"/> and <see cref="HttpPipelinePosition.PerRetry"/>.
        /// </summary>
        private readonly bool _internallyConstructed;

        /// <summary>
        /// The pipeline index where <see cref="HttpPipelinePosition.PerCall"/> policies will be added,
        /// if any are specified using <see cref="RequestContext.AddPolicy(HttpPipelinePolicy, HttpPipelinePosition)"/>.
        /// </summary>
        private readonly int _perCallIndex;

        /// <summary>
        /// The pipeline index where <see cref="HttpPipelinePosition.PerRetry"/> policies will be added,
        /// if any are specified using <see cref="RequestContext.AddPolicy(HttpPipelinePolicy, HttpPipelinePosition)"/>.
        /// </summary>
        private readonly int _perRetryIndex;

        /// <summary>
        /// Creates a new instance of <see cref="HttpPipeline"/> with the provided transport, policies and response classifier.
        /// </summary>
        /// <param name="transport">The <see cref="HttpPipelineTransport"/> to use for sending the requests.</param>
        /// <param name="policies">Policies to be invoked as part of the pipeline in order.</param>
        /// <param name="responseClassifier">The response classifier to be used in invocations.</param>
        public HttpPipeline(HttpPipelineTransport transport, HttpPipelinePolicy[]? policies = null, ResponseClassifier? responseClassifier = null)
        {
            _transport = transport ?? throw new ArgumentNullException(nameof(transport));
            ResponseClassifier = responseClassifier ?? ResponseClassifier.Shared;

            policies ??= Array.Empty<HttpPipelinePolicy>();

            HttpPipelinePolicy[] all = new HttpPipelinePolicy[policies.Length + 1];
            all[policies.Length] = new HttpPipelineTransportPolicy(_transport,
                ClientDiagnostics.CreateMessageSanitizer(new DiagnosticsOptions()));
            policies.CopyTo(all, 0);

            _pipeline = all;
        }

        internal HttpPipeline(
            HttpPipelineTransport transport,
            int perCallIndex,
            int perRetryIndex,
            HttpPipelinePolicy[] pipeline,
            ResponseClassifier responseClassifier)
        {
            ResponseClassifier = responseClassifier ?? throw new ArgumentNullException(nameof(responseClassifier));

            _transport = transport ?? throw new ArgumentNullException(nameof(transport));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));

            Debug.Assert(pipeline[pipeline.Length - 1] is HttpPipelineTransportPolicy);

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
            => new HttpMessage(CreateRequest(), ResponseClassifier);

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public HttpMessage CreateMessage(RequestContext? context)
            => CreateMessage(context, default);

        /// <summary>
        /// Creates a new <see cref="HttpMessage"/> instance.
        /// </summary>
        /// <param name="context">Context specifying the message options.</param>
        /// <param name="classifier"></param>
        /// <returns>The message.</returns>
        public HttpMessage CreateMessage(RequestContext? context, ResponseClassifier? classifier = default)
        {
            HttpMessage message = CreateMessage();
            if (classifier != null)
            {
                message.ResponseClassifier = classifier;
            }
            message.ApplyRequestContext(context, classifier);
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
        public ValueTask SendAsync(HttpMessage message, CancellationToken cancellationToken)
        {
            message.CancellationToken = cancellationToken;
            message.ProcessingStartTime = DateTimeOffset.UtcNow;
            AddHttpMessageProperties(message);

            if (message.Policies == null || message.Policies.Count == 0)
            {
                return _pipeline.Span[0].ProcessAsync(message, _pipeline.Slice(1));
            }

            return SendAsync(message);
        }

        private async ValueTask SendAsync(HttpMessage message)
        {
            int length = _pipeline.Length + message.Policies!.Count;
            HttpPipelinePolicy[] policies = ArrayPool<HttpPipelinePolicy>.Shared.Rent(length);
            try
            {
                ReadOnlyMemory<HttpPipelinePolicy> pipeline = CreateRequestPipeline(policies, message.Policies);
                await pipeline.Span[0].ProcessAsync(message, pipeline.Slice(1)).ConfigureAwait(false);
            }
            finally
            {
                ArrayPool<HttpPipelinePolicy>.Shared.Return(policies);
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
            message.ProcessingStartTime = DateTimeOffset.UtcNow;
            AddHttpMessageProperties(message);

            if (message.Policies == null || message.Policies.Count == 0)
            {
                _pipeline.Span[0].Process(message, _pipeline.Slice(1));
            }
            else
            {
                int length = _pipeline.Length + message.Policies.Count;
                HttpPipelinePolicy[] policies = ArrayPool<HttpPipelinePolicy>.Shared.Rent(length);
                try
                {
                    ReadOnlyMemory<HttpPipelinePolicy> pipeline = CreateRequestPipeline(policies, message.Policies);
                    pipeline.Span[0].Process(message, pipeline.Slice(1));
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

            // Copy over client policies and splice in custom policies at designated indices
            ReadOnlySpan<HttpPipelinePolicy> pipeline = _pipeline.Span;
            int transportIndex = pipeline.Length - 1;

            pipeline.Slice(0, _perCallIndex).CopyTo(policies);

            int index = _perCallIndex;
            int count = AddCustomPolicies(customPolicies, policies, HttpPipelinePosition.PerCall, index);

            index += count;
            count = _perRetryIndex - _perCallIndex;
            pipeline.Slice(_perCallIndex, count).CopyTo(policies.AsSpan(index, count));

            index += count;
            count = AddCustomPolicies(customPolicies, policies, HttpPipelinePosition.PerRetry, index);

            index += count;
            count = transportIndex - _perRetryIndex;
            pipeline.Slice(_perRetryIndex, count).CopyTo(policies.AsSpan(index, count));

            index += count;
            count = AddCustomPolicies(customPolicies, policies, HttpPipelinePosition.BeforeTransport, index);

            index += count;
            policies[index] = pipeline[transportIndex];

            return new ReadOnlyMemory<HttpPipelinePolicy>(policies, 0, index + 1);
        }

        private static int AddCustomPolicies(List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)> source, HttpPipelinePolicy[] target, HttpPipelinePosition position, int start)
        {
            int count = 0;
            if (source != null)
            {
                foreach ((HttpPipelinePosition Position, HttpPipelinePolicy Policy) policy in source)
                {
                    if (policy.Position == position)
                    {
                        target[start + count] = policy.Policy;
                        count++;
                    }
                }
            }

            return count;
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
                    foreach (KeyValuePair<string, object?> kvp in messageProperties)
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
