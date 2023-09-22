// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline
{
    /// <summary>
    /// TBD.
    /// </summary>
    public abstract class PipelineSynchronousPolicy : PipelinePolicy
    {
        private static Type[] _onReceivedResponseParameters = new[] { typeof(RestMessage) };

        private readonly bool _hasOnReceivedResponse = true;

        /// <summary>
        /// Initializes a new instance of <see cref="PipelineSynchronousPolicy"/>
        /// </summary>
        protected PipelineSynchronousPolicy()
        {
            var onReceivedResponseMethod = GetType().GetMethod(nameof(OnReceivedResponse), BindingFlags.Instance | BindingFlags.Public, null, _onReceivedResponseParameters, null);
            if (onReceivedResponseMethod != null)
            {
                _hasOnReceivedResponse = onReceivedResponseMethod.GetBaseDefinition().DeclaringType != onReceivedResponseMethod.DeclaringType;
            }
        }

        protected override void Process(RestMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
        {
            OnSendingRequest(message);
            ProcessNext(message, pipeline);
            OnReceivedResponse(message);
        }

        protected override ValueTask ProcessAsync(RestMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
        {
            if (!_hasOnReceivedResponse)
            {
                // If OnReceivedResponse was not overridden we can avoid creating a state machine and return the task directly
                OnSendingRequest(message);
                return ProcessNextAsync(message, pipeline);
            }

            return InnerProcessAsync(message, pipeline);
        }

        private async ValueTask InnerProcessAsync(RestMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
        {
            OnSendingRequest(message);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            OnReceivedResponse(message);
        }

        /// <summary>
        /// Method is invoked before the request is sent.
        /// </summary>
        /// <param name="message">The <see cref="RestMessage" /> containing the request.</param>
        public virtual void OnSendingRequest(RestMessage message) { }

        /// <summary>
        /// Method is invoked after the response is received.
        /// </summary>
        /// <param name="message">The <see cref="RestMessage" /> containing the response.</param>
        public virtual void OnReceivedResponse(RestMessage message) { }
    }
}