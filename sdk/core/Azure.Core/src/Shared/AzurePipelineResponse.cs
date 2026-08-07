// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal sealed class AzurePipelineResponse : PipelineResponse
    {
        private readonly Response _response;
        private readonly PipelineResponseHeaders _headers;

        internal AzurePipelineResponse(Response response)
        {
            _response = response;
            _headers = new AzurePipelineResponseHeaders(response.Headers);
        }

        public override int Status => _response.Status;

        public override string ReasonPhrase => _response.ReasonPhrase;

        protected override PipelineResponseHeaders HeadersCore => _headers;

        public override Stream? ContentStream
        {
            get => _response.ContentStream;
            set => _response.ContentStream = value;
        }

        public override BinaryData Content => _response.Content;

        public override BinaryData BufferContent(CancellationToken cancellationToken = default)
        {
            Stream? responseContentStream = _response.ContentStream;
            if (responseContentStream is not MemoryStream)
            {
                var content = new MemoryStream();
                try
                {
                    if (responseContentStream is not null)
                    {
                        CopyTo(responseContentStream, content, cancellationToken);
                    }
                    content.Position = 0;
                    responseContentStream?.Dispose();
                    _response.ContentStream = content;
                }
                catch
                {
                    content.Dispose();
                    throw;
                }
            }

            return _response.Content;
        }

        public override async ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
        {
            Stream? responseContentStream = _response.ContentStream;
            if (responseContentStream is not MemoryStream)
            {
                var content = new MemoryStream();
                try
                {
                    if (responseContentStream is not null)
                    {
                        await responseContentStream.CopyToAsync(content, 81920, cancellationToken).ConfigureAwait(false);
                    }
                    content.Position = 0;
                    responseContentStream?.Dispose();
                    _response.ContentStream = content;
                }
                catch
                {
                    content.Dispose();
                    throw;
                }
            }

            return _response.Content;
        }

        public override void Dispose() => _response.Dispose();

        private static void CopyTo(Stream source, Stream destination, CancellationToken cancellationToken)
        {
            byte[] buffer = new byte[81920];
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                int bytesRead = source.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                {
                    return;
                }

                destination.Write(buffer, 0, bytesRead);
            }
        }

        private sealed class AzurePipelineResponseHeaders : PipelineResponseHeaders
        {
            private readonly ResponseHeaders _headers;

            internal AzurePipelineResponseHeaders(ResponseHeaders headers)
            {
                _headers = headers;
            }

            public override bool TryGetValue(string name, out string? value)
                => _headers.TryGetValue(name, out value);

            public override bool TryGetValues(string name, out IEnumerable<string>? values)
                => _headers.TryGetValues(name, out values);

            public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
            {
                foreach (HttpHeader header in _headers)
                {
                    yield return new KeyValuePair<string, string>(header.Name, header.Value);
                }
            }
        }
    }
}
