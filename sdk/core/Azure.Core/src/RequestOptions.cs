// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure
{
    /// <summary>
    /// Options which can be used to control the behavior of a request sent by a client.
    /// </summary>
    public class RequestOptions
    {
        private bool _frozen;

        private (int Status, bool IsError)[]? _statusCodes;
        internal (int Status, bool IsError)[]? StatusCodes => _statusCodes;

        private ResponseClassificationHandler[]? _handlers;
        internal ResponseClassificationHandler[]? Handlers => _handlers;

        internal List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)>? Policies { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions"/> class.
        /// </summary>
        public RequestOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions"/> class
        /// that is a copy of the passed-in options.
        /// <paramref name="options">The RequestOptions to copy.</paramref>
        /// </summary>
        public RequestOptions(RequestOptions options)
        {
            _frozen = options._frozen;
            _statusCodes = options._statusCodes;
            _handlers = options._handlers;
            Policies = options.Policies;
            ErrorOptions = options.ErrorOptions;
        }

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
        /// Customizes the <see cref="ResponseClassifier"/> for this operation.
        /// Adding a classifier changes the default classification behavior so that it considers
        /// the passed-in status code to be an error or not, as specified.
        /// This is useful for cases where you'd like to prevent specific response status codes from being treated as errors by
        /// logging and distributed tracing policies -- that is, if a response is not classified as an error, it will not appear as an error in
        /// logs or distributed traces.
        /// </summary>
        /// <param name="statusCode">The status code to customize classification for.</param>
        /// <param name="isError">Whether the passed-in status code should be classified as an error.</param>
        public void AddClassifier(int statusCode, bool isError)
        {
            Argument.AssertInRange(statusCode, 100, 599, nameof(statusCode));

            if (_frozen)
            {
                throw new InvalidOperationException("Cannot modify this RequestContext after it has been used in a method call.");
            }

            int length = _statusCodes == null ? 0 : _statusCodes.Length;
            Array.Resize(ref _statusCodes, length + 1);
            _statusCodes[length] = (statusCode, isError);
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
        public void AddClassifier(ResponseClassificationHandler classifier)
        {
            if (_frozen)
            {
                throw new InvalidOperationException("Cannot modify this RequestContext after it has been used in a method call.");
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

        /// <summary>
        /// </summary>
        /// <param name="classifier"></param>
        internal CoreResponseClassifier Apply(CoreResponseClassifier classifier)
        {
            if (_statusCodes == null && _handlers == null)
            {
                return classifier;
            }

            CoreResponseClassifier clone = classifier.Clone();

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
    }
}
