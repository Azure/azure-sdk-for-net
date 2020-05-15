// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Azure.Core.TestFramework
{
    public class PlaybackTransport : MockTransport
    {
        private readonly RecordSession _session;

        private readonly RecordMatcher _matcher;

        private readonly RecordedTestSanitizer _sanitizer;

        private readonly Random _random;

        private readonly Func<RecordEntry, bool> _skipRequestBodyFilter;

        public PlaybackTransport(RecordSession session, RecordMatcher matcher, RecordedTestSanitizer sanitizer, Random random, Func<RecordEntry, bool> skipRequestBodyFilter)
        {
            _session = session;
            _matcher = matcher;
            _random = random;
            _sanitizer = sanitizer;
            _skipRequestBodyFilter = skipRequestBodyFilter;
        }

        public override void Process(HttpMessage message)
        {
            // Some tests will check if the Request Content is being read (to
            // verify their Progress handling) so we'll just copy it to a
            // MemoryStream
            if (message.Request.Content != null &&
                message.Request.Content.TryComputeLength(out long length) &&
                length > 0)
            {
                using (MemoryStream stream = new MemoryStream((int)length))
                {
                    message.Request.Content.WriteTo(stream, message.CancellationToken);
                }
            }

            var requestEntry = RecordTransport.CreateEntry(message.Request, null);

            if (_skipRequestBodyFilter(requestEntry))
            {
                requestEntry.Request.Body = null;
            }

            message.Response = GetResponse(_session.Lookup(requestEntry, _matcher, _sanitizer));

            // Copy the ClientRequestId like the HTTP transport.
            message.Response.ClientRequestId = message.Request.ClientRequestId;
        }

        public override async ValueTask ProcessAsync(HttpMessage message)
        {
            // Some tests will check if the Request Content is being read (to
            // verify their Progress handling) so we'll just copy it to a
            // MemoryStream asynchronously
            if (message.Request.Content != null &&
                message.Request.Content.TryComputeLength(out long length) &&
                length > 0)
            {
                using (MemoryStream stream = new MemoryStream((int)length))
                {
                    await message.Request.Content.WriteToAsync(stream, message.CancellationToken).ConfigureAwait(false);
                }
            }

            var requestEntry = RecordTransport.CreateEntry(message.Request, null);

            if (_skipRequestBodyFilter(requestEntry))
            {
                requestEntry.Request.Body = null;
            }

            message.Response = GetResponse(_session.Lookup(requestEntry, _matcher, _sanitizer));

            // Copy the ClientRequestId like the HTTP transport.
            message.Response.ClientRequestId = message.Request.ClientRequestId;
        }

        public override Request CreateRequest()
        {
            lock (_random)
            {
                // Force a call to random.NewGuid so we keep the random seed
                // unified between record/playback
                _random.NewGuid();

                // TODO: Pavel will think about ways to unify this
            }
            return base.CreateRequest();
        }

        public Response GetResponse(RecordEntry recordEntry)
        {
            var response = new MockResponse(recordEntry.StatusCode);
            // TODO: Use non-seekable stream
            if (recordEntry.Response.Body != null)
            {
                response.ContentStream = new MemoryStream(recordEntry.Response.Body);
            }

            foreach (KeyValuePair<string, string[]> responseHeader in recordEntry.Response.Headers)
            {
                foreach (string value in responseHeader.Value)
                {
                    response.AddHeader(new HttpHeader(responseHeader.Key, value));
                }
            }

            return response;
        }
    }
}
