// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Represent an extension point for the <see cref="HttpPipeline"/> that can mutate the <see cref="Request"/> and react to received <see cref="Response"/>.
    /// </summary>
    public abstract class HttpPipelinePolicy : PipelinePolicy
    {
        /// <summary>
        /// Applies the policy to the <paramref name="message"/>. Implementers are expected to mutate <see cref="HttpMessage.Request"/> before calling <see cref="ProcessNextAsync(HttpMessage, ReadOnlyMemory{HttpPipelinePolicy})"/> and observe the <see cref="HttpMessage.Response"/> changes after.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        /// <returns>The <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public abstract ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline);

        /// <summary>
        /// Applies the policy to the <paramref name="message"/>. Implementers are expected to mutate <see cref="ProcessNextAsync(HttpMessage, ReadOnlyMemory{HttpPipelinePolicy})"/> and observe the <see cref="HttpMessage.Response"/> changes after.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        public abstract void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline);

        /// <summary>
        /// Invokes the next <see cref="HttpPipelinePolicy"/> in the <paramref name="pipeline"/>.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> next policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after next one.</param>
        /// <returns>The <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        protected static ValueTask ProcessNextAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return pipeline.Span[0].ProcessAsync(message, pipeline.Slice(1));
        }

        /// <summary>
        /// Invokes the next <see cref="HttpPipelinePolicy"/> in the <paramref name="pipeline"/>.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> next policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after next one.</param>
        protected static void ProcessNext(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            pipeline.Span[0].Process(message, pipeline.Slice(1));
        }

        /// <inheritdoc/>
        public sealed override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            if (message is not HttpMessage httpMessage)
            {
                throw new InvalidOperationException($"Invalid type for message: '{message?.GetType()}'");
            }

            if (pipeline is not HttpPipelineAdapter processor)
            {
                throw new InvalidOperationException($"Invalid type for pipeline: '{pipeline?.GetType()}'");
            }

            // If this method is called, it means this method is being called
            // from a System.ClientModel PipelinePolicy instance. Since the
            // contract for the pipeline parameter for Azure.Core and
            // ClientModel Process methods is different, we need to pop some
            // policies off the stack before calling Process on the Azure.Core policy.
            await ProcessAsync(httpMessage, processor.Policies.Slice(currentIndex + 1)).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public sealed override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            if (message is not HttpMessage httpMessage)
            {
                throw new InvalidOperationException($"Invalid type for message: '{message?.GetType()}'");
            }

            if (pipeline is not HttpPipelineAdapter processor)
            {
                throw new InvalidOperationException($"Invalid type for pipeline: '{pipeline?.GetType()}'");
            }

            // If this method is called, it means this method is being called
            // from a System.ClientModel PipelinePolicy instance. Since the
            // contract for the pipeline parameter for Azure.Core and
            // ClientModel Process methods is different, we need to pop some
            // policies off the stack before calling Process on the Azure.Core policy.
            Process(httpMessage, processor.Policies.Slice(currentIndex + 1));
        }

        /// <summary>
        /// This type adapts the policy collection in Azure.Core's
        /// <see cref="HttpPipeline"/>, which is of type
        /// <see cref="ReadOnlyMemory{HttpPipelinePolicy}"/>, to the
        /// System.ClientModel policy collection, which is of type
        /// <see cref="IReadOnlyList{PipelinePolicy}"/>.
        ///
        /// This allows Azure.Core <see cref="HttpPipelinePolicy"/> instances
        /// to be called from the System.ClientModel <see cref="ClientPipeline"/>.
        /// This is because System.ClientModel policies of type
        /// <see cref="PipelinePolicy"/> will pass the policy collection as an
        /// instance of <see cref="IReadOnlyList{PipelinePolicy}"/>.  In order for
        /// Azure.Core policies to pass control to the next policy in the
        /// collection, they must be able to pass the collection as a
        /// <see cref="ReadOnlyMemory{HttpPipelinePolicy}"/>.  The underlying
        /// <see cref="ReadOnlyMemory{HttpPipelinePolicy}"/> used to implement the
        /// <see cref="IReadOnlyList{PipelinePolicy}"/> is exposed on this type as
        /// <see cref="Policies"/> property.
        ///
        /// In addition, this type also allows Azure.Core policies such as
        /// <see cref="RetryPolicy"/> to hold System.ClientModel policies as
        /// private members and call their
        /// <see cref="PipelinePolicy.Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
        /// methods to use the ClientModel functionality and also continue passing
        /// control down the chain of policies, across both
        /// <see cref="HttpPipelinePolicy"/> and <see cref="PipelinePolicy"/> types.
        /// </summary>
        internal struct HttpPipelineAdapter : IReadOnlyList<PipelinePolicy>
        {
            private readonly ReadOnlyMemory<HttpPipelinePolicy> _policies;
            private PolicyEnumerator? _enumerator;

            public HttpPipelineAdapter(ReadOnlyMemory<HttpPipelinePolicy> policies)
            {
                _policies = policies;
            }

            public ReadOnlyMemory<HttpPipelinePolicy> Policies
                => _policies;

            public PipelinePolicy this[int index] => _policies.Span[index];

            public int Count => _policies.Length;

            public IEnumerator<PipelinePolicy> GetEnumerator()
                => _enumerator ??= new(this);

            IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();

            private class PolicyEnumerator : IEnumerator<PipelinePolicy>
            {
                private readonly IReadOnlyList<PipelinePolicy> _policies;
                private int _current;

                public PolicyEnumerator(IReadOnlyList<PipelinePolicy> policies)
                {
                    _policies = policies;
                    _current = -1;
                }

                public PipelinePolicy Current
                {
                    get
                    {
                        if (_current >= 0 && _current < _policies.Count)
                        {
                            return _policies[_current];
                        }

                        return null!;
                    }
                }

                object IEnumerator.Current => Current;

                public bool MoveNext() => ++_current < _policies.Count;

                public void Reset() => _current = -1;

                public void Dispose() { }
            }
        }
    }
}
