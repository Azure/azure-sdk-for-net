// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure
{
    /// <summary>
    /// Options which can be used to control the behavior of a request sent by a client.
    /// </summary>
    internal class RequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions"/> class.
        /// </summary>
        public RequestOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions"/> class using the given <see cref="RequestOptions"/>.
        /// </summary>
        /// <param name="statusOption"></param>
        public RequestOptions(ResponseStatusOption statusOption) => StatusOption = statusOption;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions"/> class.
        /// </summary>
        /// <param name="perCall"></param>
        public RequestOptions(Action<HttpMessage> perCall) => PerCallPolicy = new ActionPolicy(perCall);

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions"/> class using the given <see cref="ResponseStatusOption"/>.
        /// </summary>
        /// <param name="option"></param>
        public static implicit operator RequestOptions(ResponseStatusOption option) => new RequestOptions(option);

        /// <summary>
        /// The token to check for cancellation.
        /// </summary>
        public CancellationToken CancellationToken { get; set; } = CancellationToken.None;

        /// <summary>
        /// Controls under what conditions the operation raises an exception if the underlying response indicates a failure.
        /// </summary>
        public ResponseStatusOption StatusOption { get; set; } = ResponseStatusOption.Default;

        /// <summary>
        /// A <see cref="HttpPipelinePolicy"/> to use as part of this operation. This policy will be applied at the start
        /// of the underlying <see cref="HttpPipeline"/>.
        /// </summary>
        public HttpPipelinePolicy? PerCallPolicy { get; set; }

        /// <summary>
        /// Applies options from <see cref="RequestOptions"/> instance to a <see cref="HttpMessage"/>.
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <param name="message"></param>
        public static void Apply(RequestOptions requestOptions, HttpMessage message)
        {
            if (requestOptions == null)
            {
                return;
            }

            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
        }

        /// <summary>
        /// An <see cref="HttpPipelineSynchronousPolicy"/> which invokes an action when a request is being sent.
        /// </summary>
        internal class ActionPolicy : HttpPipelineSynchronousPolicy
        {
            private Action<HttpMessage> Action { get; }

            public ActionPolicy(Action<HttpMessage> action) => Action = action;

            public override void OnSendingRequest(HttpMessage message) => Action.Invoke(message);
        }
    }
}
