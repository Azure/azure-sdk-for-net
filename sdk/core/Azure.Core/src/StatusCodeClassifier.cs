// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using static Azure.RequestContext;

namespace Azure.Core
{
    /// <summary>
    /// This type inherits from ResponseClassifier and is designed to work
    /// efficiently with classifier customizations specified in <see cref="RequestContext"/>.
    /// </summary>
    public class StatusCodeClassifier : ResponseClassifier
    {
        private readonly ReadOnlySpan<ushort> _origCodes;
        private readonly PipelineMessageClassifier _statusCodeClassifier;

        internal ResponseClassificationHandler[]? Handlers { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="StatusCodeClassifier"/>.
        /// </summary>
        /// <param name="successStatusCodes">The status codes that this classifier will consider
        /// not to be errors.</param>
        public StatusCodeClassifier(ReadOnlySpan<ushort> successStatusCodes)
        {
            _statusCodeClassifier = Create(successStatusCodes);
        }

        private StatusCodeClassifier(PipelineMessageClassifier statusCodeClassifier, ResponseClassificationHandler[]? handlers)
        {
            _statusCodeClassifier = statusCodeClassifier;
            Handlers = handlers;
        }

        /// <inheritdoc/>
        public override bool IsErrorResponse(HttpMessage message)
        {
            if (Handlers != null)
            {
                foreach (var handler in Handlers)
                {
                    if (handler.TryClassify(message, out bool isError))
                    {
                        return isError;
                    }
                }
            }

            return base.IsErrorResponse(message);
        }

        internal virtual StatusCodeClassifier Clone(StatusCodeClassification[]? _statusCodes, ResponseClassificationHandler[]? _handlers)
        {
            if (_statusCodes != null)
            {
                foreach (StatusCodeClassification classification in _statusCodes)
                {
                    clone.AddClassifier(classification.Status, classification.IsError);
                }
            }

            // TODO: Update this logic
            return new StatusCodeClassifier(_statusCodeClassifier, Handlers);
        }
    }
}
