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

namespace Azure.Core.TestFramework
{
    public class RecordTransport : HttpPipelineTransport
    {
        private readonly HttpPipelineTransport _innerTransport;

        private readonly Func<RecordEntry, EntryRecordModel> _filter;

        private readonly Random _random;

        private readonly RecordSession _session;

        public RecordTransport(RecordSession session, HttpPipelineTransport innerTransport, Func<RecordEntry, EntryRecordModel> filter, Random random)
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

            switch (_filter(recordEntry))
            {
                case EntryRecordModel.Record:
                    _session.Record(recordEntry);
                    break;
                case EntryRecordModel.RecordWithoutRequestBody:
                    recordEntry.Request.Body = null;
                    _session.Record(recordEntry);
                    break;
                default:
                    break;
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

        public static RecordEntry CreateEntry(Request request, Response response)
        {
            var entry = new RecordEntry
            {
                RequestUri = request.Uri.ToString(),
                RequestMethod = request.Method,
                Request =
                {
                    Body = ReadToEnd(request.Content),
                },
            };

            foreach (HttpHeader requestHeader in request.Headers)
            {
                var gotHeader = request.Headers.TryGetValues(requestHeader.Name, out IEnumerable<string> headerValues);
                Debug.Assert(gotHeader);
                entry.Request.Headers.Add(requestHeader.Name, headerValues.ToArray());
            }

            // Make sure we record Content-Length even if it's not set explicitly
            if (!request.Headers.TryGetValue("Content-Length", out _) && request.Content != null && request.Content.TryComputeLength(out long computedLength))
            {
                entry.Request.Headers.Add("Content-Length", new[] { computedLength.ToString(CultureInfo.InvariantCulture) });
            }

            if (response != null)
            {
                entry.Response.Body = ReadToEnd(response);
                entry.StatusCode = response.Status;
                foreach (HttpHeader responseHeader in response.Headers)
                {
                    var gotHeader = response.Headers.TryGetValues(responseHeader.Name, out IEnumerable<string> headerValues);
                    Debug.Assert(gotHeader);
                    entry.Response.Headers.Add(responseHeader.Name, headerValues.ToArray());
                }
            }

            return entry;
        }

        private static byte[] ReadToEnd(Response response)
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

        private static byte[] ReadToEnd(RequestContent requestContent)
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
