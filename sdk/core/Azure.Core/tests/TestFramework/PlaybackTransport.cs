// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Testing
{
    public class PlaybackTransport : MockTransport
    {
        private readonly RecordSession _session;

        private readonly RecordMatcher _matcher;

        private readonly Random _random;

        public PlaybackTransport(RecordSession session, RecordMatcher matcher, Random random)
        {
            _session = session;
            _matcher = matcher;
            _random = random;
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

            message.Response = GetResponse(_session.Lookup(message.Request, _matcher));
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

            message.Response = GetResponse(_session.Lookup(message.Request, _matcher));
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
            if (recordEntry.ResponseBody != null)
            {
                response.ContentStream = new MemoryStream(recordEntry.ResponseBody);
            }

            foreach (KeyValuePair<string, string[]> responseHeader in recordEntry.ResponseHeaders)
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
