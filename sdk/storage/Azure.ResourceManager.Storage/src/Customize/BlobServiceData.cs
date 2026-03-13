// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden alias for renamed automatic snapshot policy property.

using System.ComponentModel;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobServiceData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.automaticSnapshotPolicyEnabled")]
        public bool? IsAutomaticSnapshotPolicyEnabled
        {
            get => BlobServiceProperties is null ? default : BlobServiceProperties.IsAutomaticSnapshotPolicyEnabled;
            set
            {
                if (BlobServiceProperties is null)
                {
                    BlobServiceProperties = new BlobServicePropertiesProperties();
                }
                BlobServiceProperties.IsAutomaticSnapshotPolicyEnabled = value;
            }
        }
    }
}
