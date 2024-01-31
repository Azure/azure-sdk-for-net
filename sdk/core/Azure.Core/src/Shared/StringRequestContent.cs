// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal class StringRequestContent : RequestContent
    {
        private readonly byte[] _bytes;

        public StringRequestContent(string value)
        {
            _bytes = Encoding.UTF8.GetBytes(value);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
#if NET6_0_OR_GREATER
            await stream.WriteAsync(_bytes.AsMemory(), cancellation).ConfigureAwait(false);
#else
            await stream.WriteAsync(_bytes, 0, _bytes.Length, cancellation).ConfigureAwait(false);
#endif
        }

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
#if NET6_0_OR_GREATER
            stream.Write(_bytes.AsSpan());
#else
            stream.Write(_bytes, 0, _bytes.Length);
#endif
        }

        public override bool TryComputeLength(out long length)
        {
            length = _bytes.Length;
            return true;
        }

        public override void Dispose()
        {
        }
    }
}
