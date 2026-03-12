// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageSkuRestriction
    {
        /// <summary> Backward-compatible alias for Type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public string RestrictionType => Type;
    }
}
