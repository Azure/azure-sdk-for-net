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
        private List<MessageClassifier> _classifiers = new();

        internal List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)>? Policies { get; private set; }

        private MessageClassifier? _classifier;

        internal MessageClassifier? Classifier
        {
            get
            {
                if (_classifier == null)
                {
                    _classifier = new AggregateClassifier(_classifiers);
                }

                return _classifier;
            }
            private set
            {
                _classifier = value;
            }
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
        /// TODO: Update this.
        /// Adds a custom classifier to the <see cref="ResponseClassifier"/> used in this call to the service method.
        /// The custom classifier is applied before the default classifier.
        /// This is useful in cases where you'd like to prevent specific response status codes from appearing as errors in
        /// logging and distributed tracing.  It will also prevent the call from throwing an exception when a response with
        /// this status code is received.
        /// </summary>
        /// <param name="statusCode">The status codes to classify differently in this call.</param>
        /// <param name="isError">Whether or not the passed-in status codes will be considered errors.</param>
        public void AddClassifier(int statusCode, bool isError)
        {
            _classifiers.Add(new StatusCodeClassifier(statusCode, isError));
        }

        /// <summary>
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="classify"></param>
        public void AddClassifier(int statusCode, Func<HttpMessage, bool> classify)
        {
            _classifiers.Add(new FuncClassifier(statusCode, classify));
        }

        private class StatusCodeClassifier : MessageClassifier
        {
            private readonly int _statusCode;
            private readonly bool _isError;

            public StatusCodeClassifier(int statusCode, bool isError)
            {
                _statusCode = statusCode;
                _isError = isError;
            }

            public override bool TryClassify(HttpMessage message, out bool isError)
            {
                if (message.Response.Status == _statusCode)
                {
                    isError = _isError;
                    return true;
                }

                isError = false;
                return false;
            }
        }

        private class FuncClassifier : MessageClassifier
        {
            private readonly int _statusCode;
            private readonly Func<HttpMessage, bool> _classify;

            internal FuncClassifier(int statusCode, Func<HttpMessage, bool> classify)
            {
                _statusCode = statusCode;
                _classify = classify;
            }

            /// <summary>
            /// </summary>
            /// <param name="message"></param>
            /// <param name="isError"></param>
            /// <returns></returns>
            public override bool TryClassify(HttpMessage message, out bool isError)
            {
                if (message.Response.Status == _statusCode)
                {
                    isError = _classify(message);
                    return true;
                }

                isError = false;
                return false;
            }
        }

        private class AggregateClassifier : MessageClassifier
        {
            // TODO: I'll come back and implement this as an array to optimize a bit
            private readonly List<MessageClassifier> _classifiers;

            /// <summary>
            /// MessageClassifier composted of multiple classifiers
            /// </summary>
            /// <param name="classifiers"></param>
            public AggregateClassifier(List<MessageClassifier> classifiers)
            {
                _classifiers = classifiers;
            }

            public override bool TryClassify(HttpMessage message, out bool isError)
            {
                for (int i = _classifiers.Count - 1; i >= 0; i--)
                {
                    if (_classifiers[i].TryClassify(message, out isError))
                    {
                        return true;
                    }
                }

                isError = false;
                return false;
            }
        }
    }
}
