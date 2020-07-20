// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Shared
{
    /// <summary>
    /// Describes a stream that is a partition of another, larger stream.
    /// </summary>
    internal abstract class SlicedStream : System.IO.Stream
    {
        /// <summary>
        /// Absolute position of the start of this stream in the larger stream it was chunked from.
        /// </summary>
        public abstract long AbsolutePosition { get; }
    }
}
