// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Testing
{
    public class PlaybackTransport : MockTransport
    {
        private readonly RecordSession _session;

        private readonly RecordedTestSanitizer _sanitizer;

        public PlaybackTransport(RecordSession session, RecordedTestSanitizer sanitizer)
        {
            _session = session;
            _sanitizer = sanitizer;
        }

        public override void Process(HttpPipelineMessage message)
        {
            message.Response = GetResponse(_session.Lookup(message.Request, _sanitizer));
        }

        public override Task ProcessAsync(HttpPipelineMessage message)
        {
            message.Response = GetResponse(_session.Lookup(message.Request, _sanitizer));
            return Task.CompletedTask;
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
