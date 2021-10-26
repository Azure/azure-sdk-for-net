// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure
{
    /// <summary>
    /// Options which can be used to control the behavior of a request sent by a client.
    /// </summary>
    public class RequestContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext"/> class.
        /// </summary>
        public RequestContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext"/> class using the given <see cref="ErrorOptions"/>.
        /// </summary>
        /// <param name="options"></param>
        public static implicit operator RequestContext(ErrorOptions options) => new RequestContext { ErrorOptions = options };

        /// <summary>
        /// The token to check for cancellation.
        /// </summary>
        public CancellationToken CancellationToken { get; set; } = CancellationToken.None;

        /// <summary>
        /// Controls under what conditions the operation raises an exception if the underlying response indicates a failure.
        /// </summary>
        public ErrorOptions ErrorOptions { get; set; } = ErrorOptions.Default;

        /// <summary>
        /// A <see cref="HttpPipelinePolicy"/> to use as part of this operation. This policy will be applied at the start
        /// of the underlying <see cref="HttpPipeline"/>.
        /// </summary>
        internal HttpPipelinePolicy? PerCallPolicy { get; set; }

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
