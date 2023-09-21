﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.IO;
using System.ServiceModel.Rest.Core;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Shared.Core.Serialization
{
    public class Utf8JsonRequestBody : RequestBody
    {
        private readonly MemoryStream _stream;
        private readonly RequestBody _content;

        public Utf8JsonWriter JsonWriter { get; }

        public Utf8JsonRequestBody()
        {
            _stream = new MemoryStream();
            _content = CreateFromStream(_stream);
            JsonWriter = new Utf8JsonWriter(_stream);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            await JsonWriter.FlushAsync(cancellation).ConfigureAwait(false);
            await _content.WriteToAsync(stream, cancellation).ConfigureAwait(false);
        }

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            JsonWriter.Flush();
            _content.WriteTo(stream, cancellation);
        }

        public override bool TryComputeLength(out long length)
        {
            length = JsonWriter.BytesCommitted + JsonWriter.BytesPending;
            return true;
        }

        public override void Dispose()
        {
            JsonWriter.Dispose();
            _content.Dispose();
            _stream.Dispose();
        }
    }
}
