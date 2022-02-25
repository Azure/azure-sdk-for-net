// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    internal class ChainingClassifier : ResponseClassifier
    {
        private ResponseClassificationHandler[]? _handlers;

        private ResponseClassifier _endOfChain;

        public ChainingClassifier(ResponseClassificationHandler[]? handlers,
            (int Status, bool IsError)[]? statusCodes,
            ResponseClassifier endOfChain)
        {
            if (handlers != null)
            {
                AddClassifiers(handlers);
            }

            if (statusCodes != null)
            {
                StatusCodeHandler handler = new StatusCodeHandler(statusCodes);
                AddClassifiers(new StatusCodeHandler[] { handler });
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

        private void AddClassifiers(ResponseClassificationHandler[] handlers)
        {
            int length = _handlers == null ? 0 : _handlers.Length;
            Array.Resize(ref _handlers, length + handlers.Length);
            Array.Copy(handlers, 0, _handlers, length, handlers.Length);
        }

        private class StatusCodeHandler : ResponseClassificationHandler
        {
            private int[] _statusCodes;
            private bool[] _isErrorValues;

            public StatusCodeHandler((int Status, bool IsError)[] statusCodes)
            {
                _statusCodes = new int[statusCodes.Length];
                _isErrorValues = new bool[statusCodes.Length];

                for (int i = 0; i < statusCodes.Length; i++)
                {
                    _statusCodes[i] = statusCodes[i].Status;
                    _isErrorValues[i] = statusCodes[i].IsError;
                }
            }

            public override bool TryClassify(HttpMessage message, out bool isError)
            {
                int index = _statusCodes.AsSpan().IndexOf(message.Response.Status);
                if (index >= 0)
                {
                    isError = _isErrorValues[index];
                    return true;
                }

                isError = false;
                return false;
            }
        }
    }
}
