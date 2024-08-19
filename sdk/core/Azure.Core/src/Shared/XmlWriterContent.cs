// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Azure.Core
{
    internal class XmlWriterContent : RequestContent
    {
        private readonly MemoryStream _stream;
        private readonly RequestContent _content;

        public XmlWriterContent()
        {
            _stream = new MemoryStream();
            _content = Create(_stream);
            XmlWriter = new XmlTextWriter(_stream, Encoding.UTF8);
        }

        public XmlWriter XmlWriter { get; }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            XmlWriter.Flush();
            await _content.WriteToAsync(stream, cancellation).ConfigureAwait(false);
        }

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            XmlWriter.Flush();
            _content.WriteTo(stream, cancellation);
        }

        public override bool TryComputeLength(out long length)
        {
            XmlWriter.Flush();
            length = _stream.Length;
            return true;
        }

        public override void Dispose()
        {
            XmlWriter.Dispose();
            _content.Dispose();
            _stream.Dispose();
        }
    }
}
