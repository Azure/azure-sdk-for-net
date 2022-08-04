// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Core
{
    /// <summary>
    /// Implements chaining of classifiers for the general case where the end-of-chain
    /// <see cref="ResponseClassifier"/> is not a <see cref="StatusCodeClassifier"/>.
    /// <see cref="StatusCodeClassifier"/> is preferred due to its enhanced performance
    /// characteristics.
    /// The classifier chain is a series of <see cref="ResponseClassificationHandler"/> classifiers
    /// followed by the "end-of-chain" <see cref="ResponseClassifier"/>.  The handlers are
    /// added to the chain via <see cref="RequestContext"/>,
    /// and all of them are applied starting with the most recently added handler and
    /// iterating over the list to the least-recently added handler, then applying status code
    /// classification, and finally by applying the "end-of-chain" classifier.
    /// </summary>
    internal class ChainingClassifier : ResponseClassifier
    {
        private ResponseClassificationHandler[]? _handlers;
        private ResponseClassifier _endOfChain;

        public ChainingClassifier((int Status, bool IsError)[]? statusCodes,
            ResponseClassificationHandler[]? handlers,
            ResponseClassifier endOfChain)
        {
            if (handlers != null)
            {
                AddClassifiers(handlers);
            }

            if (statusCodes != null)
            {
                StatusCodeHandler[] handler = { new StatusCodeHandler(statusCodes) };
                AddClassifiers(new ReadOnlySpan<ResponseClassificationHandler>(handler));
            }

            _endOfChain = endOfChain;
        }

        public override bool IsErrorResponse(HttpMessage message)
        {
            if (_handlers != null)
            {
                foreach (var handler in _handlers)
                {
                    if (handler.TryClassify(message, out bool isError))
                    {
                        return isError;
                    }
                }
            }

            return _endOfChain.IsErrorResponse(message);
        }

        private void AddClassifiers(ReadOnlySpan<ResponseClassificationHandler> handlers)
        {
            int length = _handlers == null ? 0 : _handlers.Length;
            Array.Resize(ref _handlers, length + handlers.Length);
            Span<ResponseClassificationHandler> target = new Span<ResponseClassificationHandler>(_handlers, length, handlers.Length);
            handlers.CopyTo(target);
        }

        private class StatusCodeHandler : ResponseClassificationHandler
        {
            private (int Status, bool IsError)[] _statusCodes;

            public StatusCodeHandler((int Status, bool IsError)[] statusCodes)
            {
                _statusCodes = statusCodes;
            }

            public override bool TryClassify(HttpMessage message, out bool isError)
            {
                foreach (var classification in _statusCodes)
                {
                    if (classification.Status == message.Response.Status)
                    {
                        isError = classification.IsError;
                        return true;
                    }
                }

                isError = false;
                return false;
            }
        }
    }
}
