// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class GalleryData
    {
        /// <summary> Specifies whether soft deletion is enabled for the gallery. </summary>
        [Obsolete("Use SoftDeletePolicy instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSoftDeleteEnabled
        {
            get => SoftDeletePolicy?.IsSoftDeleteEnabled;
            set
            {
                SoftDeletePolicy ??= new SoftDeletePolicy();
                SoftDeletePolicy.IsSoftDeleteEnabled = value;
            }
        }
    }
}
