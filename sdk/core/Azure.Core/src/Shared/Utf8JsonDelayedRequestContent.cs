// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Serialization;

namespace Azure.Core
{
    internal class Utf8JsonDelayedRequestContent : RequestContent
    {
        private readonly object _serializedLock = new object();

        private SequenceWriter? _sequenceWriter;
        private IModelJsonSerializable<object> _model;
        private ModelSerializerOptions _serializerOptions;
        private Utf8JsonWriter? _writer;
        private RequestContent? _content;

        public Utf8JsonDelayedRequestContent(IModelJsonSerializable<object> model, ModelSerializerOptions options)
        {
            _model = model;
            _serializerOptions = options;
        }

        private SequenceWriter SequenceWriter => _sequenceWriter ??= new SequenceWriter();

        private Utf8JsonWriter JsonWriter => _writer ??= new Utf8JsonWriter(SequenceWriter);

        private RequestContent Content => _content ??= Create(SequenceWriter);

        /// <inheritdoc/>
        public override void Dispose()
        {
            _writer?.Dispose();
            _sequenceWriter?.Dispose();
        }

        /// <inheritdoc/>
        public override bool TryComputeLength(out long length)
        {
            Serialize();
            return SequenceWriter.TryComputeLength(out length);
        }

        private void Serialize()
        {
            SequenceWriter.TryComputeLength(out var len);
            if (len == 0)
            {
                lock (_serializedLock)
                {
                    SequenceWriter.TryComputeLength(out len);
                    if (len == 0)
                    {
                        _model.Serialize(JsonWriter, _serializerOptions);
                        JsonWriter.Flush();
                    }
                }
            }
        }

        /// <inheritdoc/>
        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            Serialize();
            Content.WriteTo(stream, cancellation);
        }

        /// <inheritdoc/>
        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            Serialize();
            await Content.WriteToAsync(stream, cancellation).ConfigureAwait(false);
        }
    }
}
