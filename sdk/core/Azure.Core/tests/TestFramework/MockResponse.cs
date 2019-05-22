// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Testing
{
    public class TestPipelineFactory
    {
        public static HttpPipeline Create(HttpPipelineTransport transport, params HttpPipelinePolicy[] policies)
        {
            var allPolicies = new HttpPipelinePolicy[policies.Length + 1];
            policies.AsMemory().CopyTo(allPolicies);
            allPolicies[policies.Length] = new HttpPipelineTransportPolicy(transport);
            return new HttpPipeline(transport, allPolicies);
        }
        public static HttpPipeline Create(HttpPipelineTransport transport, ResponseClassifier responseClassifier, params HttpPipelinePolicy[] policies)
        {
            var allPolicies = new HttpPipelinePolicy[policies.Length + 1];
            policies.AsMemory().CopyTo(allPolicies);
            allPolicies[policies.Length] = new HttpPipelineTransportPolicy(transport);
            return new HttpPipeline(transport, allPolicies, responseClassifier);
        }

        private class HttpPipelineTransportPolicy : HttpPipelinePolicy
        {
            private readonly HttpPipelineTransport _transport;

            public HttpPipelineTransportPolicy(HttpPipelineTransport transport)
            {
                _transport = transport;
            }

            public override Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                Debug.Assert(pipeline.IsEmpty);

                return _transport.ProcessAsync(message);
            }

            public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                Debug.Assert(pipeline.IsEmpty);

                _transport.Process(message);
            }
        }
    }
    public class MockResponse : Response
    {
        private readonly Dictionary<string, List<string>> _headers = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        public MockResponse(int status, string reasonPhrase = null)
        {
            Status = status;
            ReasonPhrase = reasonPhrase;
        }

        public override int Status { get; }

        public override string ReasonPhrase { get; }

        public override Stream ContentStream { get; set; }

        public override string ClientRequestId { get; set; }

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

#if HAS_INTERNALS_VISIBLE_CORE
internal
#endif
        protected override bool TryGetHeader(string name, out string value)
        {
            if (_headers.TryGetValue(name, out var values))
            {
                value = JoinHeaderValue(values);
                return true;
            }

            value = null;
            return false;
        }

#if HAS_INTERNALS_VISIBLE_CORE
internal
#endif
        protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
        {
            var result = _headers.TryGetValue(name, out var valuesList);
            values = valuesList;
            return result;
        }

#if HAS_INTERNALS_VISIBLE_CORE
internal
#endif
        protected override bool ContainsHeader(string name)
        {
            return TryGetHeaderValues(name, out _);
        }

#if HAS_INTERNALS_VISIBLE_CORE
internal
#endif
        protected override IEnumerable<HttpHeader> EnumerateHeaders() => _headers.Select(h => new HttpHeader(h.Key, JoinHeaderValue(h.Value)));

        private static string JoinHeaderValue(IEnumerable<string> values)
        {
            return string.Join(",", values);
        }

        public override void Dispose()
        {
        }
    }
}
