// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden alias properties (IsDeleted, EnabledProtocol) for renamed
// generated properties. Could use @@clientName in spec but would lose improved names.

using System.ComponentModel;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class FileShareData
    {
        /// <summary> Backward-compatible alias for Deleted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.deleted")]
        public bool? IsDeleted => Deleted;

        /// <summary> Backward-compatible alias for EnabledProtocols. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.enabledProtocols")]
        public FileShareEnabledProtocol? EnabledProtocol
        {
            get => EnabledProtocols;
            set => EnabledProtocols = value;
        }
    }
}
