// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Base.Http;

namespace Azure.Base.Testing
{
    public class MockResponse : HttpPipelineResponse
    {
        private readonly List<HttpHeader> _headers = new List<HttpHeader>();

        private Stream _responseContentStream;

        public MockResponse(int status)
        {
            Status = status;
        }

        public override int Status { get; set; }

        public override Stream ResponseContentStream => _responseContentStream;

        public override string ToString() => $"{Status}";

        public void AddHeader(HttpHeader header)
        {
            _headers.Add(header);
        }

        public void SetContent(Stream contentStream)
        {
            _responseContentStream = contentStream;
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

        public override void Dispose()
        {
        }
    }
}