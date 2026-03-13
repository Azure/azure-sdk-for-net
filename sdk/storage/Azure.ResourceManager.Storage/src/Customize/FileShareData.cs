// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden alias properties for renamed generated properties.

using System.ComponentModel;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class FileShareData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.deleted")]
        public bool? IsDeleted => FileShareProperties is null ? default : FileShareProperties.IsDeleted;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.enabledProtocols")]
        public FileShareEnabledProtocol? EnabledProtocol
        {
            get => FileShareProperties is null ? default : FileShareProperties.EnabledProtocol;
            set
            {
                if (FileShareProperties is null)
                {
                    FileShareProperties = new FileShareProperties();
                }
                FileShareProperties.EnabledProtocol = value;
            }
        }
    }
}
