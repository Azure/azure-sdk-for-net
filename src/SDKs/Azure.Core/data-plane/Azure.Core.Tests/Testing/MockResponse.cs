// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Azure.Core.Pipeline;

namespace Azure.Core.Testing
{
    public class MockResponse : Response
    {
        private readonly Dictionary<string, List<string>> _headers = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        public MockResponse(int status)
        {
            Status = status;
        }

        public override int Status { get; }

        public override Stream ContentStream { get; set; }

        public override string RequestId { get; set; }

        public override string ToString() => $"{Status}";

        public void SetContent(byte[] content)
        {
            ContentStream = new MemoryStream(content);
        }

        public void SetContent(string content)
        {
            SetContent(Encoding.UTF8.GetBytes(content));
        }

        public void AddHeader(HttpHeader header)
        {
            if (!_headers.TryGetValue(header.Name, out var values))
            {
                _headers[header.Name] = values = new List<string>();
            }

            values.Add(header.Value);
        }

        public override bool TryGetHeader(string name, out string value)
        {
            if (_headers.TryGetValue(name, out var values))
            {
                value = JoinHeaderValue(values);
                return true;
            }

            value = null;
            return false;
        }

        public override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
        {
            var result = _headers.TryGetValue(name, out var valuesList);
            values = valuesList;
            return result;
        }

        public override bool ContainsHeader(string name)
        {
            return TryGetHeaderValues(name, out _);
        }

        public override IEnumerable<HttpHeader> Headers => _headers.Select(h => new HttpHeader(h.Key, JoinHeaderValue(h.Value)));

        private static string JoinHeaderValue(IEnumerable<string> values)
        {
            return string.Join(",", values);
        }

        public override void Dispose()
        {
        }
    }
}
