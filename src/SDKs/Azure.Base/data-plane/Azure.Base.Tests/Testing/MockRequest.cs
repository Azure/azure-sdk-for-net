// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Base.Http;

namespace Azure.Base.Testing
{
    public class MockRequest : HttpPipelineRequest
    {
        public MockRequest()
        {
            RequestId = new Guid().ToString();
        }

        private readonly List<HttpHeader> _headers = new List<HttpHeader>();

        public override void AddHeader(HttpHeader header)
        {
            _headers.Add(header);
        }

        public override bool TryGetHeader(string name, out string value)
        {
            foreach (var httpHeader in _headers)
            {
                if (httpHeader.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    value = httpHeader.Value;
                    return true;
                }
            }

            value = null;
            return false;
        }

        public override IEnumerable<HttpHeader> Headers => _headers;

        public override string RequestId { get; set; }

        public override string ToString() => $"{Method} {UriBuilder}";

        public override void Dispose()
        {
        }
    }
}