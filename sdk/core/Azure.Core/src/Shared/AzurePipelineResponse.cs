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
        private readonly Response? _response;
        private readonly PipelineResponseHeaders _headers;
        private readonly int _status;
        private readonly string _reasonPhrase;
        private Stream? _contentStream;

        internal AzurePipelineResponse(Response response)
        {
            _response = response;
            _headers = new AzurePipelineResponseHeaders(response.Headers);
            _status = response.Status;
            _reasonPhrase = response.ReasonPhrase;
        }

        internal AzurePipelineResponse(Response response, HttpMessage message)
        {
            _headers = new AzurePipelineResponseHeaders(response.Headers, snapshot: true);
            _status = response.Status;
            _reasonPhrase = response.ReasonPhrase;
            _contentStream = message.ExtractResponseContent();
        }

        public override int Status => _status;

        public override string ReasonPhrase => _reasonPhrase;

        protected override PipelineResponseHeaders HeadersCore => _headers;

        public override Stream? ContentStream
        {
            get => _response?.ContentStream ?? _contentStream;
            set
            {
                if (_response is not null)
                {
                    _response.ContentStream = value;
                }
                else
                {
                    _contentStream = value;
                }
            }
        }

        public override BinaryData Content
            => _response?.Content ?? _contentStream switch
            {
                MemoryStream content => new BinaryData(content.ToArray()),
                null => BinaryData.Empty,
                _ => throw new InvalidOperationException("The response is not buffered.")
            };

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
            if (_response is not null)
            {
                _response.Dispose();
            }
            else
            {
                _contentStream?.Dispose();
                _contentStream = null;
            }
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
            private readonly ResponseHeaders? _headers;
            private readonly Dictionary<string, string>? _headerValues;
            private readonly Dictionary<string, IEnumerable<string>>? _headerValueCollections;
            private readonly List<KeyValuePair<string, string>>? _headerList;

            internal AzurePipelineResponseHeaders(ResponseHeaders headers, bool snapshot = false)
            {
                if (!snapshot)
                {
                    _headers = headers;
                    return;
                }

                _headerValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                _headerValueCollections = new Dictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);
                _headerList = new List<KeyValuePair<string, string>>();
                foreach (HttpHeader header in headers)
                {
                    _headerValues[header.Name] = header.Value;
                    if (headers.TryGetValues(header.Name, out IEnumerable<string>? values))
                    {
                        _headerValueCollections[header.Name] = new List<string>(values);
                    }
                    _headerList.Add(new KeyValuePair<string, string>(header.Name, header.Value));
                }
            }

            public override bool TryGetValue(string name, out string? value)
                => _headers is ResponseHeaders headers
                    ? headers.TryGetValue(name, out value)
                    : _headerValues!.TryGetValue(name, out value);

            public override bool TryGetValues(string name, out IEnumerable<string>? values)
                => _headers is ResponseHeaders headers
                    ? headers.TryGetValues(name, out values)
                    : _headerValueCollections!.TryGetValue(name, out values);

            public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
            {
                if (_headers is not null)
                {
                    foreach (HttpHeader header in _headers)
                    {
                        yield return new KeyValuePair<string, string>(header.Name, header.Value);
                    }
                }
                else
                {
                    foreach (KeyValuePair<string, string> header in _headerList!)
                    {
                        yield return header;
                    }
                }
            }
        }
    }
}
