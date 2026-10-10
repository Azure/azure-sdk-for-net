// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage
{
    /// <summary>
    /// Wraps a per-operation <see cref="ResponseClassifier"/> to preserve
    /// <see cref="StorageResponseClassifier"/> retry logic / error handling.
    /// </summary>
    internal class StorageRetriableClassifier : ResponseClassifier
    {
        private readonly ResponseClassifier _innerClassifier;
        private readonly StorageResponseClassifier _storageClassifier;

        public StorageRetriableClassifier(ResponseClassifier innerClassifier, StorageResponseClassifier storageClassifier)
        {
            _innerClassifier = innerClassifier;
            _storageClassifier = storageClassifier;
        }

        public override bool IsErrorResponse(HttpMessage message)
        {
            // Always let the inner classifier decide first. It carries any
            // ResponseClassificationHandlers added via RequestContext (e.g.
            // BlobBaseClientExistsClassifier for Exists calls). Those handlers
            // represent explicit per-call overrides and must take priority.
            if (!_innerClassifier.IsErrorResponse(message))
            {
                return false;
            }

            // The inner classifier considers this an error. For 409, let the
            // storage classifier decide.
            if (message.Response.Status == 409
                && !StorageResponseClassifier.IsConditionalAlreadyExistsConflict(message))
            {
                return _storageClassifier.IsErrorResponse(message);
            }

            return true;
        }

        public override bool IsRetriableResponse(HttpMessage message)
            => _storageClassifier.IsRetriableResponse(message);
    }
}
