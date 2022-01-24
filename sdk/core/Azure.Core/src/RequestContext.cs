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
        private List<int>? _customErrorCodes;
        private List<int>? _customNonErrorCodes;

        internal List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)>? Policies { get; private set; }

        internal bool HasCustomClassifier => _customErrorCodes != null || _customNonErrorCodes != null;

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
        /// <param name="isError">Whether the passed-in status codes will be considered to be error codes for the duration of this request.</param>
        public void ConfigureResponse(int[] statusCodes, bool isError)
        {
            if (isError)
            {
                _customErrorCodes ??= new();
                _customErrorCodes.AddRange(statusCodes);
            }
            else
            {
                _customNonErrorCodes ??= new();
                _customNonErrorCodes.AddRange(statusCodes);
            }
        }

        internal ResponseClassifier GetResponseClassifier(ResponseClassifier inner)
        {
            return new PerCallResponseClassifier(inner, _customErrorCodes, _customNonErrorCodes);
        }

        private class PerCallResponseClassifier : ResponseClassifier
        {
            private readonly ResponseClassifier _inner;
            private readonly IList<int>? _customErrorCodes;
            private readonly IList<int>? _customNonErrorCodes;

            public PerCallResponseClassifier(ResponseClassifier inner, IList<int>? errorCodes, IList<int>? nonErrorCodes)
            {
                _inner = inner;
                _customErrorCodes = errorCodes;
                _customNonErrorCodes = nonErrorCodes;
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
                if (_customErrorCodes != null &&
                    _customErrorCodes.Contains(message.Response.Status))
                {
                    return true;
                }

                if (_customNonErrorCodes != null &&
                    _customNonErrorCodes.Contains(message.Response.Status))
                {
                    return false;
                }

                return _inner.IsErrorResponse(message);
            }
        }
    }
}
