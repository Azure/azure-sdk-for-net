// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Internal;

namespace Azure.Core
{
    /// <summary>
    /// This type inherits from ResponseClassifier and is designed to work
    /// efficiently with classifier customizations specified in <see cref="RequestContext"/>.
    /// </summary>
    public class StatusCodeClassifier : ResponseClassifier
    {
        private BitVector640 _successCodes;

        internal ResponseClassificationHandler[]? Handlers { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="StatusCodeClassifier"/>.
        /// </summary>
        /// <param name="successStatusCodes">The status codes that this classifier
        /// will consider not to be errors.</param>
        public StatusCodeClassifier(ReadOnlySpan<ushort> successStatusCodes)
        {
            _successCodes = new();

            foreach (int statusCode in successStatusCodes)
            {
                AddClassifier(statusCode, isError: false);
            }
        }

        private StatusCodeClassifier(BitVector640 successCodes, ResponseClassificationHandler[]? handlers)
        {
            _successCodes = successCodes;
            Handlers = handlers;
        }

        /// <inheritdoc/>
        public override bool IsErrorResponse(HttpMessage message)
        {
            if (Handlers != null)
            {
                foreach (ResponseClassificationHandler handler in Handlers)
                {
                    if (handler.TryClassify(message, out bool isError))
                    {
                        return isError;
                    }
                }
            }

            return !_successCodes[message.Response.Status];
        }

        internal virtual StatusCodeClassifier Clone()
            => new(_successCodes, Handlers);

        internal void AddClassifier(int statusCode, bool isError)
        {
            Argument.AssertInRange(statusCode, 0, 639, nameof(statusCode));

            _successCodes[statusCode] = !isError;
        }
    }
}
