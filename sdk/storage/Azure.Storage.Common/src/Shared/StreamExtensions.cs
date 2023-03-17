// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    /// <summary>
    /// Extension methods for working with Streams.
    /// </summary>
    internal static class StreamExtensions
    {
        public static async Task<int> ReadInternal(
            this Stream stream,
            byte[] buffer,
            int offset,
            int count,
            bool async,
            CancellationToken cancellationToken)
        {
            if (async)
            {
                return await stream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return stream.Read(buffer, offset, count);
            }
        }

        public static async Task WriteInternal(
            this Stream stream,
            byte[] buffer,
            int offset,
            int count,
            bool async,
            CancellationToken cancellationToken)
        {
            if (async)
            {
                await stream.WriteAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                stream.Write(buffer, offset, count);
            }
        }

        public static async Task CopyToInternal(
            this Stream src,
            Stream dest,
            int bufferSize,
            bool async,
            CancellationToken cancellationToken)
        {
            if (async)
            {
                await src.CopyToAsync(dest, bufferSize, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                src.CopyTo(dest, bufferSize);
            }
        }
    }
}
