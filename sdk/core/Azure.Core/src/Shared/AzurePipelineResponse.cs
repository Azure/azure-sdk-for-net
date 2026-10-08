// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

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
        private readonly PipelineResponseHeaders _headers;
        private readonly int _status;
        private readonly string _reasonPhrase;
        private Stream? _contentStream;

        internal AzurePipelineResponse(HttpMessage message)
        {
            Response response = message.Response;
            _headers = new AzurePipelineResponseHeaders(response.Headers);
            _status = response.Status;
            _reasonPhrase = response.ReasonPhrase;
            _contentStream = message.ExtractResponseContent();
        }

        public override int Status => _status;

        public override string ReasonPhrase => _reasonPhrase;

        protected override PipelineResponseHeaders HeadersCore => _headers;

        public override Stream? ContentStream
        {
            get => _contentStream;
            set => _contentStream = value;
        }

        public override BinaryData Content
        {
            get
            {
                if (_contentStream is null)
                {
                    return BinaryData.Empty;
                }

                if (_contentStream is not MemoryStream content)
                {
                    throw new InvalidOperationException("The response is not buffered.");
                }

                return content.TryGetBuffer(out ArraySegment<byte> segment)
                    ? new BinaryData(segment.AsMemory())
                    : new BinaryData(content.ToArray());
            }
        }

        public override BinaryData BufferContent(CancellationToken cancellationToken = default)
        {
            Stream? responseContentStream = ContentStream;
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
                    ContentStream = content;
                }
                catch
                {
                    content.Dispose();
                    throw;
                }
            }

            return Content;
        }

        public override async ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
        {
            Stream? responseContentStream = ContentStream;
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
                    ContentStream = content;
                }
                catch
                {
                    content.Dispose();
                    throw;
                }
            }

            return Content;
        }

        public override void Dispose()
        {
            _contentStream?.Dispose();
            _contentStream = null;
        }

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
            private readonly Dictionary<string, string> _headerValues;
            private readonly Dictionary<string, IEnumerable<string>> _headerValueCollections;
            private readonly List<KeyValuePair<string, string>> _headerList;

            internal AzurePipelineResponseHeaders(ResponseHeaders headers)
            {
                _headerValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                _headerValueCollections = new Dictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);
                _headerList = new List<KeyValuePair<string, string>>();
                foreach (HttpHeader header in headers)
                {
                    if (!_headerValues.ContainsKey(header.Name))
                    {
                        _headerValues.Add(header.Name, header.Value);
                    }
                    if (!_headerValueCollections.ContainsKey(header.Name)
                        && headers.TryGetValues(header.Name, out IEnumerable<string>? values))
                    {
                        _headerValueCollections.Add(header.Name, new List<string>(values));
                    }
                    _headerList.Add(new KeyValuePair<string, string>(header.Name, header.Value));
                }
            }

            public override bool TryGetValue(string name, out string? value)
                => _headerValues.TryGetValue(name, out value);

            public override bool TryGetValues(string name, out IEnumerable<string>? values)
                => _headerValueCollections.TryGetValue(name, out values);

            public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
            {
                foreach (KeyValuePair<string, string> header in _headerList)
                {
                    yield return header;
                }
            }
        }
    }
}
