// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private readonly RecordSession _session;

        public RecordTransport(RecordSession session, HttpPipelineTransport innerTransport)
        {
            _innerTransport = innerTransport;
            _session = session;
        }

        public override void Process(HttpPipelineMessage message)
        {
            _innerTransport.Process(message);
            _session.Record(CreateEntry(message.Request, message.Response));
        }

        public override async Task ProcessAsync(HttpPipelineMessage message)
        {
            await _innerTransport.ProcessAsync(message);
            _session.Record(CreateEntry(message.Request, message.Response));
        }

        public override Request CreateRequest(IServiceProvider services)
        {
            return _innerTransport.CreateRequest(services);
        }

        public RecordEntry CreateEntry(Request request, Response response)
        {
            var entry = new RecordEntry
            {
                RequestUri = request.UriBuilder.ToString(),
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
            if (response.ContentStream == null)
            {
                return null;
            }

            var memoryStream = new NonSeekableMemoryStream();
            response.ContentStream.CopyTo(memoryStream);
            memoryStream.Reset();
            response.ContentStream = memoryStream;
            return memoryStream.ToArray();
        }

        private byte[] ReadToEnd(HttpPipelineRequestContent requestContent)
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
