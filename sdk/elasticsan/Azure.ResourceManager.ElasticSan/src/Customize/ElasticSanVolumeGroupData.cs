// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.ElasticSan.Models;

namespace Azure.ResourceManager.ElasticSan
{
    // Manually added back for completed compatibility
    public partial class ElasticSanVolumeGroupData
    {
        /// <summary> The retention policy for the soft deleted volume group and its associated resources. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ElasticSanDeleteRetentionPolicy DeleteRetentionPolicy { get; set; }
    }
}
