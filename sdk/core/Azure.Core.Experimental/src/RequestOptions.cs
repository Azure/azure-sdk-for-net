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
    public class RequestOptions
    {
        private List<(int StatusCode, ResponseClassification Classification)> _classifiers = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions"/> class.
        /// </summary>
        public RequestOptions() { }

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
        ///
        /// </summary>
        /// <param name="treatAsSuccess"></param>
        public RequestOptions(params int[] treatAsSuccess): this(treatAsSuccess, ResponseClassification.Success)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="statusCodes"></param>
        /// <param name="classification"></param>
        public RequestOptions(int[] statusCodes, ResponseClassification classification) {
            AddStatusClassifier(statusCodes, classification);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="statusCodes"></param>
        /// <param name="classification"></param>
        public void AddStatusClassifier(int[] statusCodes, ResponseClassification classification = ResponseClassification.Success)
        {
            foreach (var statusCode in statusCodes)
            {
                _classifiers.Add((statusCode, classification));
            }
        }

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
        ///
        /// </summary>
        /// <param name="message"></param>
        public void Apply(HttpMessage message)
        {
            if (PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", PerCallPolicy);
            }
            message.ResponseClassifier = new PerCallResponseClassifier(message.ResponseClassifier, this);
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

        internal class PerCallResponseClassifier : ResponseClassifier
        {
            private readonly ResponseClassifier _inner;
            private readonly RequestOptions _options;

            public PerCallResponseClassifier(ResponseClassifier inner, RequestOptions options)
            {
                _inner = inner;
                _options = options;
            }

            public override bool IsRetriableResponse(HttpMessage message)
            {
                if (Applies(message, ResponseClassification.DontRetry)) return false;

                return _inner.IsRetriableResponse(message);
            }

            public override bool IsRetriableException(Exception exception)
            {
                return _inner.IsRetriableException(exception);
            }

            public override bool IsRetriable(HttpMessage message, Exception exception)
            {
                if (Applies(message, ResponseClassification.DontRetry)) return false;

                return _inner.IsRetriable(message, exception);
            }

            public override bool IsErrorResponse(HttpMessage message)
            {
                if (Applies(message, ResponseClassification.Throw)) return true;
                if (Applies(message, ResponseClassification.Success)) return false;

                return _inner.IsErrorResponse(message);
            }

            private bool Applies(HttpMessage message, ResponseClassification responseClassification)
            {
                foreach (var classifier in _options._classifiers)
                {
                    if (classifier.StatusCode == message.Response.Status &&
                        classifier.Classification == responseClassification)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }

    /// <summary>
    ///
    /// </summary>
    public enum ResponseClassification
    {
        /// <summary>
        ///
        /// </summary>
        Retry,
        /// <summary>
        ///
        /// </summary>
        DontRetry,
        /// <summary>
        ///
        /// </summary>
        Throw,
        /// <summary>
        ///
        /// </summary>
        Success,
    }
}
