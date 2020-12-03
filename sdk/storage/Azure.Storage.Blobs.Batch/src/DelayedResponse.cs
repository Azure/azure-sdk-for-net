// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core;

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// A Response that can be returned before a request is actually sent and
    /// will throw until a live response is provided to wrap.
    /// </summary>
    internal class DelayedResponse : Response
    {
        /// <summary>
        /// The live Response to wrap.
        /// </summary>
        private Response _live;

        /// <summary>
        /// An optional function that can be used to process the response.  It
        /// is responsible for parsing response bodies and throwing exceptions.
        /// (This would be more meaningful if we add a DelayedResponse{T} down
        /// the road.)
        ///
        /// This is intended to be one of the
        /// BlobRestClient.Group.OperationName_CreateResponse methods which
        /// correctly throw when necessary.
        /// </summary>
        private readonly Func<Response, Response> _processResponse;

        /// <summary>
        /// Gets the live Response or throws an InvalidOperationException if
        /// you attempt to use the Response before the batch operation has been
        /// submitted.
        /// </summary>
        private Response LiveResponse
        {
            get => _live ?? throw BatchErrors.UseDelayedResponseEarly();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DelayedResponse"/> class.
        /// </summary>
        /// <param name="message">The message this is a response for.</param>
        /// <param name="processResponse">
        /// An optional function that can be used to process the response.  It
        /// is responsible for parsing response bodies and throwing exceptions.
        /// </param>
        public DelayedResponse(HttpMessage message, Func<Response, Response> processResponse = null)
        {
            // Have the BatchPipelineTransport associate this response with the
            // message when it's sent.
            message.SetProperty(BatchConstants.DelayedResponsePropertyName, this);
            _processResponse = processResponse;
        }

        /// <summary>
        /// Set the live <see cref="Response"/>.
        /// </summary>
        /// <param name="live">The live <see cref="Response"/>.</param>
        /// <param name="throwOnFailure">
        /// A value indicating whether or not we should throw for Response
        /// failures.
        /// </param>
        public void SetLiveResponse(Response live, bool throwOnFailure)
        {
            _live = live;

            // Set the live response before possibly throwing in case someone
            // tries to catch the exception but then interrogate raw responses
            if (throwOnFailure && _processResponse != null)
            {
                _live = _processResponse(_live);
            }
        }

        public override string ToString()
        {
            return _live == null ? "Status: NotSent, the batch has not been submitted yet" : base.ToString();
        }

        // We directly forward the entire Response interface to LiveResponse
        #region forward Response members to Live
        /// <inheritdoc />
        public override int Status =>
            _live == null ?
                BatchConstants.NoStatusCode : // Give users a hint that this is an exploding Response
                LiveResponse.Status;

        /// <inheritdoc />
        public override string ReasonPhrase => LiveResponse.ReasonPhrase;

        /// <inheritdoc />
        public override Stream ContentStream
        {
            get => LiveResponse.ContentStream;
            set => LiveResponse.ContentStream = value;
        }

        /// <inheritdoc />
        public override string ClientRequestId
        {
            get => LiveResponse.ClientRequestId;
            set => LiveResponse.ClientRequestId = value;
        }

        /// <inheritdoc />
        public override void Dispose() =>
            _live?.Dispose(); // Don't want to throw so we just use _live

        /// <inheritdoc />
        protected override bool ContainsHeader(string name) =>
            LiveResponse.Headers.Contains(name);

        /// <inheritdoc />
        protected override IEnumerable<HttpHeader> EnumerateHeaders() =>
            LiveResponse.Headers;

        /// <inheritdoc />
        protected override bool TryGetHeader(string name, out string value) =>
            LiveResponse.Headers.TryGetValue(name, out value);

        /// <inheritdoc />
        protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values) =>
            LiveResponse.Headers.TryGetValues(name, out values);
        #endregion forward Response members to Live
    }
}
