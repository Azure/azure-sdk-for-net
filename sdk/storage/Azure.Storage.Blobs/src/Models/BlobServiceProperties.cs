// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Storage Service Properties.
    /// </summary>
    [CodeGenModel("StorageServiceProperties")]
    public partial class BlobServiceProperties
    {
        /// <summary>
        /// The set of CORS rules.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public IList<BlobCorsRule> Cors { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly
    }
}
