// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core.Http;

namespace Azure.Core.Pipeline
{
    public class HttpPipelineMessage
    {
        private Dictionary<string, object>? _properties;

        private Response? _response;

        public CancellationToken CancellationToken { get; }

        public HttpPipelineMessage(Request request, ResponseClassifier responseClassifier, CancellationToken cancellationToken)
        {
            Request = request;
            ResponseClassifier = responseClassifier;
            CancellationToken = cancellationToken;
        }

        public Request Request { get; set; }

        public Response Response
        {
            get
            {
                if (_response == null)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException("Response was not set, make sure SendAsync was called");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return _response;
            }
            set => _response = value;
        }

        public bool HasResponse => _response != null;

        public ResponseClassifier ResponseClassifier { get; set; }

        public bool TryGetProperty(string name, out object? value)
        {
            value = null;
            return _properties?.TryGetValue(name, out value) == true;
        }

        public void SetProperty(string name, object value)
        {
            _properties ??= new Dictionary<string, object>();

            _properties[name] = value;
        }
    }
}
