// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies blob tag access conditions for a container or blob.
    /// </summary>
    public class BlobTagRequestConditions : RequestConditions
    {
        /// <summary>
        /// Optional SQL statement to apply to the Tags of the Blob.
        /// </summary>
        public string TagConditions { get; set; }
    }
}
