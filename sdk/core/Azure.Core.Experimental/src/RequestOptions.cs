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
        private List<HttpMessageClassifier>? _classifiers;

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
        /// Initializes a new instance of the <see cref="RequestOptions"/> class.
        /// </summary>
        /// <param name="treatAsSuccess">The status codes to treat as successful.</param>
        public RequestOptions(params int[] treatAsSuccess) : this(treatAsSuccess, ResponseClassification.Success)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions"/> class.
        /// Applying provided classification to a set of status codes.
        /// </summary>
        /// <param name="statusCodes">The status codes to classify.</param>
        /// <param name="classification">The classification.</param>
        public RequestOptions(int[] statusCodes, ResponseClassification classification)
        {
            AddClassifier(statusCodes, classification);
        }

        /// <summary>
        /// Adds the classification for provided status codes.
        /// </summary>
        /// <param name="statusCodes">The status codes to classify.</param>
        /// <param name="classification">The classification.</param>
        public void AddClassifier(int[] statusCodes, ResponseClassification classification)
        {
            foreach (var statusCode in statusCodes)
            {
                AddClassifier(message => message.Response.Status == statusCode ? classification : null);
            }
        }

        /// <summary>
        /// Adds a function that allows to specify how response would be processed by the pipeline.
        /// </summary>
        /// <param name="classifier"></param>
        public void AddClassifier(Func<HttpMessage, ResponseClassification?> classifier)
        {
            _classifiers ??= new();
            _classifiers.Add(new FuncHttpMessageClassifier(classifier));
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
        /// Applies options from <see cref="RequestOptions"/> instance to a <see cref="HttpMessage"/>.
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <param name="message"></param>
        public static void Apply(RequestOptions requestOptions, HttpMessage message)
        {
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }

            if (requestOptions._classifiers != null)
            {
                message.ResponseClassifier = new PerCallResponseClassifier(message.ResponseClassifier, requestOptions._classifiers);
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

        private class PerCallResponseClassifier : ResponseClassifier
        {
            private readonly ResponseClassifier _inner;
            private readonly List<HttpMessageClassifier> _classifiers;

            public PerCallResponseClassifier(ResponseClassifier inner, List<HttpMessageClassifier> classifiers)
            {
                _inner = inner;
                _classifiers = classifiers;
            }

            public override bool IsRetriableResponse(HttpMessage message)
            {
                if (Applies(message, ResponseClassification.DontRetry)) return false;
                if (Applies(message, ResponseClassification.Retry)) return true;

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
                foreach (var classifier in _classifiers)
                {
                    if (classifier.TryClassify(message, null, out var c) &&
                        c == responseClassification)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private abstract class HttpMessageClassifier
        {
            public abstract bool TryClassify(HttpMessage message, Exception? exception, out ResponseClassification classification);
        }

        private class FuncHttpMessageClassifier : HttpMessageClassifier
        {
            private readonly Func<HttpMessage, ResponseClassification?> _func;

            public FuncHttpMessageClassifier(Func<HttpMessage, ResponseClassification?> func)
            {
                _func = func;
            }

            public override bool TryClassify(HttpMessage message, Exception? exception, out ResponseClassification classification)
            {
                if (_func(message) is ResponseClassification c)
                {
                    classification = c;
                    return true;
                }

                classification = default;
                return false;
            }
        }
    }

    /// <summary>
    /// Specifies how response would be processed by the pipeline and the client.
    /// </summary>
    public enum ResponseClassification
    {
        /// <summary>
        /// The response would be retried.
        /// </summary>
        Retry,

        /// <summary>
        /// The response would be retried.
        /// </summary>
        DontRetry,

        /// <summary>
        /// The client would throw an exception for the response.
        /// </summary>
        Throw,

        /// <summary>
        /// The client would tread the response a successful.
        /// </summary>
        Success,
    }
}