// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Compute
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceRoleData : ResourceData
    {
        /// <summary> Initializes a new instance of CloudServiceRoleData for deserialization. </summary>
        internal CloudServiceRoleData()
        {
        }

        /// <summary> The location. </summary>
        public AzureLocation? Location { get; }

        /// <summary> The SKU. </summary>
        public CloudServiceRoleSku Sku { get; }

        /// <summary> The unique identifier. </summary>
        public string UniqueId { get; }
    }
}
