// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Blob query error.
    /// </summary>
    public class BlobQueryError
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// If the error is a fatal error.
        /// </summary>
        public bool IsFatal { get; internal set; }

        /// <summary>
        /// The position of the error.
        /// </summary>
        public long Position { get; internal set; }

        internal BlobQueryError() { }
    }
}
