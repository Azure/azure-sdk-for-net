// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Azure.Core.Serialization;

namespace Azure.Core
{
    internal class Utf8XmlDelayedRequestContent : RequestContent
    {
        private readonly object _serializedLock = new object();

        private IXmlModelSerializable<object> _model;
        private ModelSerializerOptions _serializerOptions;
        private XmlWriter? _writer;
        private RequestContent? _content;
        private MemoryStream? _stream;

        public Utf8XmlDelayedRequestContent(IXmlModelSerializable<object> model, ModelSerializerOptions options)
        {
            _model = model;
            _serializerOptions = options;
        }

        private MemoryStream Stream => _stream ??= new MemoryStream();

        private XmlWriter XmlWriter => _writer ??= XmlWriter.Create(Stream);

        private RequestContent Content => _content ??= Create(Stream);

        /// <inheritdoc/>
        public override void Dispose()
        {
            _writer?.Dispose();
            _stream?.Dispose();
        }

        /// <inheritdoc/>
        public override bool TryComputeLength(out long length)
        {
            Serialize();
            length = Stream.Length;
            return true;
        }

        private void Serialize()
        {
            if (Stream.Length == 0)
            {
                lock (_serializedLock)
                {
                    if (Stream.Length == 0)
                    {
                        _model.Serialize(XmlWriter, _serializerOptions);
                        XmlWriter.Flush();
                    }
                }
            }
        }

        /// <inheritdoc/>
        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            Serialize();
            Stream.Position = 0;
            Content.WriteTo(stream, cancellation);
        }

        /// <inheritdoc/>
        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            Serialize();
            Stream.Position = 0;
            await Content.WriteToAsync(stream, cancellation).ConfigureAwait(false);
        }
    }
}
