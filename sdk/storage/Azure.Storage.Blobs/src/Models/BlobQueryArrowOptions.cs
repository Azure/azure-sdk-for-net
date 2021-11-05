// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Arrow configuration.  Only valid for <see cref="BlobQueryOptions.OutputTextConfiguration"/>.
    /// </summary>
    public class BlobQueryArrowOptions : BlobQueryTextOptions
    {
        /// <summary>
        /// List of <see cref="BlobQueryArrowField"/> describing the schema of the data.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IList<BlobQueryArrowField> Schema { get; set; } = new List<BlobQueryArrowField>();
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
