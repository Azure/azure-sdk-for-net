// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure.Core;

#nullable disable

namespace Azure.Generator.Management.Tests.Common
{
    public class TestResponse : Response
    {
        private int _status;
        private string _reasonPhrase;
        private Stream _contentStream;

        private readonly ResponseHeaders _headers;

        private bool _disposed;

        public TestResponse(int status = 0, string reasonPhrase = "")
        {
            _status = status;
            _reasonPhrase = reasonPhrase;
            _headers = new ResponseHeaders();
        }

        public override int Status => _status;

        public void SetStatus(int value) => _status = value;

        public override string ReasonPhrase => _reasonPhrase;

        public void SetReasonPhrase(string value) => _reasonPhrase = value;

        public void SetContent(byte[] content)
        {
            ContentStream = new MemoryStream(content, 0, content.Length, false, true);
        }

        public Response SetContent(string content)
        {
            SetContent(Encoding.UTF8.GetBytes(content));
            return this;
        }

        public override Stream ContentStream
        {
            get => _contentStream;
            set => _contentStream = value;
        }

        public override string ClientRequestId { get; set; }

        public override BinaryData Content
        {
            get
            {
                if (_contentStream is null)
                {
                    return new BinaryData(Array.Empty<byte>());
                }

                if (ContentStream is not MemoryStream memoryContent)
                {
                    throw new InvalidOperationException($"The response is not buffered.");
                }

                if (memoryContent.TryGetBuffer(out ArraySegment<byte> segment))
                {
                    return new BinaryData(segment.AsMemory());
                }
                else
                {
                    return new BinaryData(memoryContent.ToArray());
                }
            }
        }

        public override ResponseHeaders Headers
            => _headers;

        public sealed override void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected override bool TryGetHeader(string name, out string value)
        {
            return _headers.TryGetValue(name, out value);
        }

        protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
        {
            return _headers.TryGetValues(name, out values);
        }

        protected override bool ContainsHeader(string name)
        {
            return _headers.Contains(name);
        }

        protected override IEnumerable<HttpHeader> EnumerateHeaders()
        {
            foreach (var header in _headers)
            {
                yield return header;
            }
        }

        protected void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                Stream content = _contentStream;
                if (content != null)
                {
                    _contentStream = null;
                    content.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
