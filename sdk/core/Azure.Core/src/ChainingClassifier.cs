// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core
{
    internal class ChainingClassifier : ResponseClassifier
    {
        private ResponseClassificationHandler[]? _handlers;
        internal ResponseClassificationHandler[]? Handlers => _handlers;

        private ResponseClassifier _endOfChain;

        public ChainingClassifier(ResponseClassifier endOfChain)
        {
            _endOfChain = endOfChain;
        }

        internal void AddHandler(ResponseClassificationHandler handler)
        {
            int length = _handlers == null ? 0 : _handlers.Length;
            Array.Resize(ref _handlers, length + 1);
            Array.Copy(_handlers, 0, _handlers, 1, length);
            _handlers[0] = handler;
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

        private class StatusCodeHandler : ResponseClassificationHandler
        {

        }
    }
}
