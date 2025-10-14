// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Test.Shared
{
    internal class CustomRequestHeadersAndQueryParametersPolicy : HttpPipelineSynchronousPolicy
    {
        private string _requestHeaderName;
        private string _requestHeaderValue;

        public CustomRequestHeadersAndQueryParametersPolicy(string requestHeaderName)
        {
            _requestHeaderName = requestHeaderName;
        }

        public void SetRequestHeaderValue(string value)
        {
            _requestHeaderValue = value;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            message.Request.Headers.Add(_requestHeaderName, _requestHeaderValue);
        }
    }
}
