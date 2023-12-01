// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Represents a <see cref="HttpPipelinePolicy"/> that doesn't do any asynchronous or synchronously blocking operations.
    /// </summary>
#if !NET5_0 // DynamicallyAccessedMembers in net5.0 doesn't have AttributeTargets.Class as a target, but it was added in net6.0
    [DynamicallyAccessedMembers(System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicMethods)]
#endif
    public abstract class HttpPipelineSynchronousPolicy : HttpPipelinePolicy
    {
        private static Type[] _onReceivedResponseParameters = new[] { typeof(HttpMessage) };

        private readonly bool _hasOnReceivedResponse = true;

        /// <summary>
        /// Initializes a new instance of <see cref="HttpPipelineSynchronousPolicy"/>
        /// </summary>
        protected HttpPipelineSynchronousPolicy()
        {
            var onReceivedResponseMethod = GetType().GetMethod(nameof(OnReceivedResponse), BindingFlags.Instance | BindingFlags.Public, null, _onReceivedResponseParameters, null);
            if (onReceivedResponseMethod != null)
            {
                _hasOnReceivedResponse = onReceivedResponseMethod.GetBaseDefinition().DeclaringType != onReceivedResponseMethod.DeclaringType;
            }
        }

        /// <inheritdoc />
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            OnSendingRequest(message);
            ProcessNext(message, pipeline);
            OnReceivedResponse(message);
        }

        /// <inheritdoc />
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!_hasOnReceivedResponse)
            {
                // If OnReceivedResponse was not overridden we can avoid creating a state machine and return the task directly
                OnSendingRequest(message);
                return ProcessNextAsync(message, pipeline);
            }

            return InnerProcessAsync(message, pipeline);
        }

        private async ValueTask InnerProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            OnSendingRequest(message);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            OnReceivedResponse(message);
        }

        /// <summary>
        /// Method is invoked before the request is sent.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage" /> containing the request.</param>
        public virtual void OnSendingRequest(HttpMessage message) { }

        /// <summary>
        /// Method is invoked after the response is received.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage" /> containing the response.</param>
        public virtual void OnReceivedResponse(HttpMessage message) { }
    }
}
