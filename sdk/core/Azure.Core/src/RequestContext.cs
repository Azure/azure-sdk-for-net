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

        private (int Status, bool IsError)[]? _statusCodes;
        internal (int Status, bool IsError)[]? StatusCodes => _statusCodes;

        private ResponseClassificationHandler[]? _handlers;
        internal ResponseClassificationHandler[]? Handlers => _handlers;

        internal List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)>? Policies { get; private set; }

        /// <summary>
        /// Controls under what conditions the operation raises an exception if the underlying response indicates a failure.
        /// </summary>
        public ErrorOptions ErrorOptions { get; set; } = ErrorOptions.Default;

        /// <summary>
        /// The token to check for cancellation.
        /// </summary>
        public CancellationToken CancellationToken { get; set; } = CancellationToken.None;

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
        /// Customizes the <see cref="ResponseClassifier"/> for this operation to change
        /// the default <see cref="Response"/> classification behavior so that it considers
        /// the passed-in status code to be an error or not, as specified.
        /// Status code classifiers are applied after all <see cref="ResponseClassificationHandler"/> classifiers.
        /// This is useful for cases where you'd like to prevent specific response status codes from being treated as errors by
        /// logging and distributed tracing policies -- that is, if a response is not classified as an error, it will not appear as an error in
        /// logs or distributed traces.
        /// </summary>
        /// <param name="statusCode">The status code to customize classification for.</param>
        /// <param name="isError">Whether the passed-in status code should be classified as an error.</param>
        /// <exception cref="ArgumentOutOfRangeException">statusCode is not between 100 and 599 (inclusive).</exception>
        /// <exception cref="InvalidOperationException">If this method is called after the <see cref="RequestContext"/> has been
        /// used in a method call.</exception>
        public void AddClassifier(int statusCode, bool isError)
        {
            Argument.AssertInRange(statusCode, 100, 599, nameof(statusCode));

            if (_frozen)
            {
                throw new InvalidOperationException("Cannot modify classifiers after this type has been used in a method call.");
            }

            int length = _statusCodes == null ? 0 : _statusCodes.Length;
            Array.Resize(ref _statusCodes, length + 1);
            Array.Copy(_statusCodes, 0, _statusCodes, 1, length);
            _statusCodes[0] = (statusCode, isError);
        }

        /// <summary>
        /// Customizes the <see cref="ResponseClassifier"/> for this operation.
        /// Adding a <see cref="ResponseClassificationHandler"/> changes the classification
        /// behavior so that it first tries to classify a response via the handler, and if
        /// the handler doesn't have an opinion, it instead uses the default classifier.
        /// Handlers are applied in order so the most recently added takes precedence.
        /// This is useful for cases where you'd like to prevent specific response status codes from being treated as errors by
        /// logging and distributed tracing policies -- that is, if a response is not classified as an error, it will not appear as an error in
        /// logs or distributed traces.
        /// </summary>
        /// <param name="classifier">The custom classifier.</param>
        /// <exception cref="InvalidOperationException">If this method is called after the <see cref="RequestContext"/> has been
        /// used in a method call.</exception>
        public void AddClassifier(ResponseClassificationHandler classifier)
        {
            if (_frozen)
            {
                throw new InvalidOperationException("Cannot modify classifiers after this type has been used in a method call.");
            }

            int length = _handlers == null ? 0 : _handlers.Length;
            Array.Resize(ref _handlers, length + 1);
            Array.Copy(_handlers, 0, _handlers, 1, length);
            _handlers[0] = classifier;
        }

        internal void Freeze()
        {
            _frozen = true;
        }

        internal ResponseClassifier Apply(ResponseClassifier classifier)
        {
            if (_statusCodes == null && _handlers == null)
            {
                return classifier;
            }

            if (classifier is StatusCodeClassifier statusCodeClassifier)
            {
                StatusCodeClassifier clone = statusCodeClassifier.Clone();
                clone.Handlers = _handlers;

                if (_statusCodes != null)
                {
                    foreach (var classification in _statusCodes)
                    {
                        clone.AddClassifier(classification.Status, classification.IsError);
                    }
                }

                return clone;
            }

            return new ChainingClassifier(_statusCodes, _handlers, classifier);
        }
    }
}
