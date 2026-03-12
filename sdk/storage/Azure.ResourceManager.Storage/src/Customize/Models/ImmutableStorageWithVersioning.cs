// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ImmutableStorageWithVersioning
    {
        /// <summary> Backward-compatible alias for Enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsEnabled
        {
            get => Enabled;
            set => Enabled = value;
        }
    }
}
