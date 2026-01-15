// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Qumulo.Models
{
    /// <summary> Storage Sku. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum StorageSku
    {
        /// <summary> Standard Storage Sku. </summary>
        Standard,
        /// <summary> Performance Storage Sku. </summary>
        Performance
    }
}
