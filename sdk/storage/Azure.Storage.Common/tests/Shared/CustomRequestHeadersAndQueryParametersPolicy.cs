// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Test.Shared
{
    internal class CustomRequestHeadersAndQueryParametersPolicy : HttpPipelineSynchronousPolicy
    {
        private Dictionary<string, List<string>> _requestHeaders = new();
        private Dictionary<string, List<string>> _queryParameters = new();

        public CustomRequestHeadersAndQueryParametersPolicy() { }

        public void AddRequestHeader(string name, string value)
        {
            if (!_requestHeaders.TryGetValue(name, out var values))
            {
                values = new List<string>();
                _requestHeaders[name] = values;
            }
            values.Add(value);
        }

        public void AddQueryParameter(string name, string value)
        {
            if (!_queryParameters.TryGetValue(name, out var values))
            {
                values = new List<string>();
                _queryParameters[name] = values;
            }
            values.Add(value);
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            foreach (var header in _requestHeaders)
            {
                foreach (var value in header.Value)
                {
                    message.Request.Headers.Add(header.Key, value);
                }
            }
            foreach (var param in _queryParameters)
            {
                foreach (var value in param.Value)
                {
                    message.Request.Uri.AppendQuery(param.Key, value);
                }
            }
        }
    }
}
