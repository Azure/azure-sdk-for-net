// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// Represents the <see cref="DynamicJson"/> sent as part of the Azure.Core.Request.
    /// </summary>
    [DebuggerDisplay("Content: {_body}")]
    public class DynamicContent : RequestContent
    {
        private readonly DynamicJson _body;

        internal DynamicContent(DynamicJson body)
        {
            _body = body;
        }

        internal static RequestContent Create(DynamicJson body) => new DynamicContent(body);

        /// <inheritdoc />
        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            _body.WriteTo(writer);
            await writer.FlushAsync(cancellation).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            _body.WriteTo(writer);
            writer.Flush();
        }

        /// <inheritdoc />
        public override bool TryComputeLength(out long length)
        {
            using MemoryStream stream = new MemoryStream();
            WriteTo(stream, CancellationToken.None);
            length = Encoding.UTF8.GetString(stream.ToArray()).Length;
            return true;
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
