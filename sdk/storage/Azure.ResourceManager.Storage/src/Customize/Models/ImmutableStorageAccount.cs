// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ImmutableStorageAccount
    {
        /// <summary> Backward-compatible alias for Enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("enabled")]
        public bool? IsEnabled
        {
            get => Enabled;
            set => Enabled = value;
        }
    }
}
