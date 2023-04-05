// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.Shared
{
    /// <summary>
    /// Describes a stream that is a partition of another, larger stream.
    /// </summary>
    internal sealed class SlicedStream
    {
        public Stream Slice { get; }

        /// <summary>
        /// Position in the larger stream where <see cref="Slice"/> begins.
        /// </summary>
        public long AbsolutePosition { get; }

        public SlicedStream(Stream slice, long absolutePosition)
        {
            Slice = slice;
            AbsolutePosition = absolutePosition;
        }
    }
}
