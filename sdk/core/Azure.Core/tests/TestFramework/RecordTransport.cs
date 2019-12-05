// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Testing
{
    public class RecordTransport : HttpPipelineTransport
    {
        private readonly HttpPipelineTransport _innerTransport;

        private readonly Func<RecordEntry, bool> _filter;

        private readonly Random _random;

        private readonly RecordSession _session;

        public RecordTransport(RecordSession session, HttpPipelineTransport innerTransport, Func<RecordEntry, bool> filter, Random random)
        {
            _innerTransport = innerTransport;
            _filter = filter;
            _random = random;
            _session = session;
        }

        public override void Process(HttpMessage message)
        {
            _innerTransport.Process(message);
            Record(message);
        }

        public override async ValueTask ProcessAsync(HttpMessage message)
        {
            await _innerTransport.ProcessAsync(message);
            Record(message);
        }

        private void Record(HttpMessage message)
        {
            RecordEntry recordEntry = CreateEntry(message.Request, message.Response);
            if (_filter(recordEntry))
            {
                _session.Record(recordEntry);
            }
        }

        public override Request CreateRequest()
        {
            Request request = _innerTransport.CreateRequest();

            lock (_random)
            {
                // Override ClientRequestId to avoid excessive diffs
                request.ClientRequestId = _random.NewGuid().ToString("N");
            }

            return request;
        }

        public RecordEntry CreateEntry(Request request, Response response)
        {
            var entry = new RecordEntry
            {
                RequestUri = request.Uri.ToString(),
                RequestMethod = request.Method,
                RequestHeaders = new SortedDictionary<string, string[]>(StringComparer.OrdinalIgnoreCase),
                ResponseHeaders = new SortedDictionary<string, string[]>(StringComparer.OrdinalIgnoreCase),
                RequestBody = ReadToEnd(request.Content),
                ResponseBody = ReadToEnd(response),
                StatusCode = response.Status
            };

            foreach (HttpHeader requestHeader in request.Headers)
            {
                var gotHeader = request.Headers.TryGetValues(requestHeader.Name, out IEnumerable<string> headerValues);
                Debug.Assert(gotHeader);
                entry.RequestHeaders.Add(requestHeader.Name, headerValues.ToArray());
            }

            // Make sure we record Content-Length even if it's not set explicitly
            if (!request.Headers.TryGetValue("Content-Length", out _) && request.Content != null && request.Content.TryComputeLength(out long computedLength))
            {
                entry.RequestHeaders.Add("Content-Length", new[] { computedLength.ToString(CultureInfo.InvariantCulture) });
            }

            foreach (HttpHeader responseHeader in response.Headers)
            {
                var gotHeader = response.Headers.TryGetValues(responseHeader.Name, out IEnumerable<string> headerValues);
                Debug.Assert(gotHeader);
                entry.ResponseHeaders.Add(responseHeader.Name, headerValues.ToArray());
            }

            return entry;
        }

        private byte[] ReadToEnd(Response response)
        {
            Stream responseContentStream = response.ContentStream;
            if (responseContentStream == null)
            {
                return null;
            }

            var memoryStream = new NonSeekableMemoryStream();
            responseContentStream.CopyTo(memoryStream);
            responseContentStream.Dispose();

            memoryStream.Reset();
            response.ContentStream = memoryStream;
            return memoryStream.ToArray();
        }

        private byte[] ReadToEnd(RequestContent requestContent)
        {
            if (requestContent == null)
            {
                return null;
            }

            using var memoryStream = new MemoryStream();
            requestContent.WriteTo(memoryStream, CancellationToken.None);
            return memoryStream.ToArray();
        }
    }
}
