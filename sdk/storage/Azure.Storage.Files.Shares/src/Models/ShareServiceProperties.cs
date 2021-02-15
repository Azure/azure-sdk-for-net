// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareServiceProperties.
    /// </summary>
    [CodeGenModel("StorageServiceProperties")]
    public partial class ShareServiceProperties
    {
        /// <summary>
        /// The set of CORS rules.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IList<ShareCorsRule> Cors { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
