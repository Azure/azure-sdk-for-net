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
    /// Options that can be used to control the behavior of a request sent by a client.
    /// </summary>
    public class RequestContext
    {
        private bool _frozen;

        internal List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)>? Policies { get; private set; }

        private (int Status, bool IsError)[]? _statusCodes;
        internal (int Status, bool IsError)[]? StatusCodes => _statusCodes;

        private HttpMessageClassifier[]? _classifiers;
        internal HttpMessageClassifier[]? MessageClassifiers => _classifiers;

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
        /// Adds a custom classifier to the <see cref="ResponseClassifier"/> that decides if the response
        /// received from the service should be considered an error response, for this service call.
        /// The custom classifier is applied before the default classifier.
        /// This is useful for cases where you'd like to prevent specific response status codes from being treated as errors by
        /// logging and distributed tracing policies -- that is, if a response is not classified as an error, it will not appear as an error in
        /// logs or distributed traces.
        /// </summary>
        /// <param name="statusCode">The status code to customize classification for.</param>
        /// <param name="isError">Whether the passed-in status code should be classified as an error.</param>
        public void AddClassifier(int statusCode, bool isError)
        {
            if (_frozen)
            {
                throw new InvalidOperationException("Cannot modify this RequestContext after it has been used in a method call.");
            }

            int length = _statusCodes == null ? 0 : _statusCodes.Length;
            Array.Resize(ref _statusCodes, length + 1);
            _statusCodes[length] = (statusCode, isError);
        }

        /// <summary>
        /// Adds a custom <see cref="HttpMessageClassifier"/> to the <see cref="ResponseClassifier"/> that decides if the response
        /// received from the service should be considered an error response, for this service call.
        /// The custom classifier is applied before the default classifier.
        /// This is useful for cases where you'd like to prevent specific response status codes from being treated as errors by
        /// logging and distributed tracing policies -- that is, if a response is not classified as an error, it will not appear as an error in
        /// logs or distributed traces.
        /// </summary>
        /// <param name="classifier">The custom classifier.</param>
        public void AddClassifier(HttpMessageClassifier classifier)
        {
            if (_frozen)
            {
                throw new InvalidOperationException("Cannot modify this RequestContext after it has been used in a method call.");
            }

            int length = _classifiers == null ? 0 : _classifiers.Length;
            Array.Resize(ref _classifiers, length + 1);
            _classifiers[length] = classifier;
        }

        internal void Freeze()
        {
            _frozen = true;
        }
    }
}
