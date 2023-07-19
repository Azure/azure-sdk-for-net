// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Test.Shared
{
    internal class AssertMessageContentsPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly Action<Request> _checkRequest;

        private readonly Action<Response> _checkResponse;

        public bool CheckRequest { get; set; }
        public bool CheckResponse { get; set; }

        public AssertMessageContentsPolicy(
            Action<Request> checkRequest = default,
            Action<Response> checkResponse = default)
        {
            _checkRequest = checkRequest;
            _checkResponse = checkResponse;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (CheckRequest)
            {
                _checkRequest?.Invoke(message.Request);
            }
        }

        public override void OnReceivedResponse(HttpMessage message)
        {
            if (CheckResponse)
            {
                _checkResponse?.Invoke(message.Response);
            }
        }
    }
}
