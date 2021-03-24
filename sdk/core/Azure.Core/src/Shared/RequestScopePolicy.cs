// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class RequestScopePolicy : HttpPipelineSynchronousPolicy
    {
        private readonly AsyncLocal<RequestScopeAction?> _currentRequestScopeAction = new();

        protected RequestScopePolicy()
        {
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            _currentRequestScopeAction.Value?.Action?.Invoke(message);
        }

        public IDisposable StartScope(Action<HttpMessage>? action)
        {
            _currentRequestScopeAction.Value = new RequestScopeAction(action, _currentRequestScopeAction);

            return _currentRequestScopeAction.Value;
        }

        private class RequestScopeAction : IDisposable
        {
            private bool _disposed;
            private readonly RequestScopeAction? _parent;
            private readonly AsyncLocal<RequestScopeAction?> _currentRequestScopeAction;

            internal RequestScopeAction(Action<HttpMessage>? action, AsyncLocal<RequestScopeAction?> currentRequestScopeAction)
            {
                Action = action;
                _parent = currentRequestScopeAction.Value;
                _currentRequestScopeAction = currentRequestScopeAction;
            }

            public Action<HttpMessage>? Action { get; }

            public void Dispose()
            {
                if (_disposed)
                {
                    return;
                }

                _currentRequestScopeAction.Value = _parent;

                _disposed = true;
            }
        }
    }
}
