// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure
{
    /// <summary>
    /// Options that can be used to control the behavior of a request sent by a client.
    /// </summary>
    public class RequestContext : RequestOptions
    {
        internal List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)>? Policies { get; private set; }

        /// <summary>
        /// Controls under what conditions the operation raises an exception if the underlying response indicates a failure.
        /// </summary>
        public new ErrorOptions ErrorOptions
        {
            get => FromResponseErrorOptions(base.ErrorOptions);
            set => base.ErrorOptions = ToResponseErrorOptions(value);
        }

        private static ErrorOptions FromResponseErrorOptions(ClientErrorBehaviors options)
        {
            return options switch
            {
                ClientErrorBehaviors.Default => ErrorOptions.Default,
                ClientErrorBehaviors.NoThrow => ErrorOptions.NoThrow,
                _ => throw new NotSupportedException(),
            };
        }

        private static ClientErrorBehaviors ToResponseErrorOptions(ErrorOptions options)
        {
            return options switch
            {
                ErrorOptions.Default => ClientErrorBehaviors.Default,
                ErrorOptions.NoThrow => ClientErrorBehaviors.NoThrow,
                _ => throw new NotSupportedException(),
            };
        }

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
            => base.AddClassifier(classifier);

        internal ResponseClassifier Apply(ResponseClassifier classifier)
        {
            return classifier;

            // TODO: reimplement
            //if (_statusCodes == null && _handlers == null)
            //{
            //    return classifier;
            //}

            //if (classifier is StatusCodeClassifier statusCodeClassifier)
            //{
            //    StatusCodeClassifier clone = statusCodeClassifier.Clone();
            //    clone.Handlers = _handlers;

            //    if (_statusCodes != null)
            //    {
            //        foreach (var classification in _statusCodes)
            //        {
            //            clone.AddClassifier(classification.Status, classification.IsError);
            //        }
            //    }

            //    return clone;
            //}

            //return new ChainingClassifier(_statusCodes, _handlers, classifier);
        }
    }
}
