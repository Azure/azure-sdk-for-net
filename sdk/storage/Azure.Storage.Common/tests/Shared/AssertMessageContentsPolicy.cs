// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Test.Shared
{
    internal class AssertMessageContentsPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly Action<Request> _checkRequest;

        private readonly Action<Response> _checkResponse;

        private readonly HashSet<CheckMessageScope> _requestScopes = new();

        private readonly HashSet<CheckMessageScope> _responseScopes = new();

        public AssertMessageContentsPolicy(
            Action<Request> checkRequest = default,
            Action<Response> checkResponse = default)
        {
            _checkRequest = checkRequest;
            _checkResponse = checkResponse;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (_requestScopes.Count > 0)
            {
                _checkRequest?.Invoke(message.Request);
            }
        }

        public override void OnReceivedResponse(HttpMessage message)
        {
            if (_responseScopes.Count > 0)
            {
                _checkResponse?.Invoke(message.Response);
            }
        }

        public IDisposable CheckRequestScope() => CheckMessageScope.CheckRequestScope(this);

        public IDisposable CheckResponseScope() => CheckMessageScope.CheckResponseScope(this);

        private class CheckMessageScope : IDisposable
        {
            private bool _isRequestScope;
            private AssertMessageContentsPolicy _policy;

            public static CheckMessageScope CheckRequestScope(AssertMessageContentsPolicy policy)
            {
                CheckMessageScope result = new()
                {
                    _isRequestScope = true,
                    _policy = policy
                };
                result._policy._requestScopes.Add(result);
                return result;
            }

            public static CheckMessageScope CheckResponseScope(AssertMessageContentsPolicy policy)
            {
                CheckMessageScope result = new()
                {
                    _isRequestScope = false,
                    _policy = policy
                };
                result._policy._responseScopes.Add(result);
                return result;
            }

            public void Dispose()
            {
                (_isRequestScope ? _policy._requestScopes : _policy._responseScopes).Remove(this);
            }
        }
    }
}
