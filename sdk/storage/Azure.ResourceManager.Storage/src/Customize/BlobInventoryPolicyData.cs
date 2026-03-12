// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobInventoryPolicyData
    {
        /// <summary> Backward-compatible alias for Policy. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlobInventoryPolicySchema PolicySchema
        {
            get => Policy;
            set => Policy = value;
        }
    }
}
