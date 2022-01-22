// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        private List<int>? _nonErrorStatusCodes;

        internal List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)>? Policies { get; private set; }

        internal bool HasResponseClassifier { get; private set; }

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
        /// Adds an <see cref="HttpPipelinePolicy"/> into the pipeline for the duration of this request.
        /// The position of policy in the pipeline is controlled by <paramref name="position"/> parameter.
        /// If you want the policy to execute once per client request use <see cref="HttpPipelinePosition.PerCall"/>
        /// otherwise use <see cref="HttpPipelinePosition.PerRetry"/> to run the policy for every retry.
        /// </summary>
        /// <param name="policy">The <see cref="HttpPipelinePolicy"/> instance to be added to the pipeline.</param>
        /// <param name="position">The position of the policy in the pipeline.</param>
        public void AddPolicy(HttpPipelinePolicy policy, HttpPipelinePosition position)
        {
            Policies ??= new();
            Policies.Add((position, policy));
        }

        /// <summary>
        /// </summary>
        /// <param name="statusCodes">Status codes that will not be considered to be error status codes for the scope of the service method call.</param>
        public void NotError(IEnumerable<int> statusCodes)
        {
            _nonErrorStatusCodes ??= new();
            _nonErrorStatusCodes.AddRange(statusCodes);
            HasResponseClassifier = true;
        }

        internal ResponseClassifier GetResponseClassifier(ResponseClassifier inner)
        {
            // TODO: come up with something cleaner here
            return new PerCallResponseClassifier(inner, _nonErrorStatusCodes);
        }

        private class PerCallResponseClassifier : ResponseClassifier
        {
            private readonly ResponseClassifier _inner;
            private readonly IEnumerable<int> _nonErrorStatusCodes;

            public PerCallResponseClassifier(ResponseClassifier inner, IEnumerable<int> statusCodes)
            {
                _inner = inner;
                _nonErrorStatusCodes = statusCodes;
            }

            public override bool IsRetriableResponse(HttpMessage message)
            {
                return _inner.IsRetriableResponse(message);
            }

            public override bool IsRetriableException(Exception exception)
            {
                return _inner.IsRetriableException(exception);
            }

            public override bool IsRetriable(HttpMessage message, Exception exception)
            {
                return _inner.IsRetriable(message, exception);
            }

            public override bool IsErrorResponse(HttpMessage message)
            {
                if (_nonErrorStatusCodes.Contains(message.Response.Status))
                    return false;

                return _inner.IsErrorResponse(message);
            }
        }
    }
}
