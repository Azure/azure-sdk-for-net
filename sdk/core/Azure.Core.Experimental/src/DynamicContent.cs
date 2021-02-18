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
    /// Represents the <see cref="JsonData"/> sent as part of the Azure.Core.Request.
    /// </summary>
    [DebuggerDisplay("Content: {_body}")]
    public class DynamicContent : RequestContent
    {
        private readonly JsonData _body;

        internal DynamicContent(JsonData body)
        {
            _body = body;
        }

        // TODO(matell): When this moves to Azure.Core, this static method should be exposed from the abstract RequestContent class.
        /// <summary>
        /// Creates a RequestConent for a given JSON object.
        /// </summary>
        /// <param name="body">The JSON object the request content represents</param>
        /// <returns>A RequestContent which is the UTF-8 encoding of the underlying DynamicJson</returns>
        public static RequestContent Create(JsonData body) => new DynamicContent(body);

        /// <inheritdoc />
        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            await _body.WriteToAsync(stream, cancellation).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            _body.WriteTo(stream);
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
