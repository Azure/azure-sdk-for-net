// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The result of a GetLayout operation, containing the blob's layout
    /// information.
    /// </summary>
    internal class BlobLayoutSegment
    {
        internal BlobLayoutSegment() { }

        /// <summary> The start byte offset of the range. </summary>
        public long Start { get; internal set; }
        /// <summary> The end byte offset of the range. </summary>
        public long End { get; internal set; }
        /// <summary> The host:port of the endpoint. </summary>
        public string Endpoint { get; internal set; }
    }
}
