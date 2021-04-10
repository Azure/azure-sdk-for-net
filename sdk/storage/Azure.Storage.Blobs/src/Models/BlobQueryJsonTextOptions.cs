// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// JSON text configuration.
    /// </summary>
    public class BlobQueryJsonTextOptions : BlobQueryTextOptions
    {
        /// <summary>
        /// Record Separator.
        /// </summary>
        public string RecordSeparator { get; set; }
    }
}
