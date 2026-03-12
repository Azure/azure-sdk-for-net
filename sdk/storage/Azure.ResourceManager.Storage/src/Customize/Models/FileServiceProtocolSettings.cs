// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class FileServiceProtocolSettings
    {
        /// <summary> Backward-compatible alias for Required. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("nfs.encryptionInTransit.required")]
        public bool? IsRequired
        {
            get => Required;
            set => Required = value;
        }
    }
}
