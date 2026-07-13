// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class FileServiceData : ResourceData
    {
        // this property was safe-flattened because FileServiceProtocolSettings previously only have one property
        // after one of these api-versions, new properties were added to FileServiceProtocolSettings
        // therefore this property is no longer flattened.
        // this customization code added it back to keep back compat.
        /// <summary> Setting for SMB protocol. </summary>
        [WirePath("properties.protocolSettings.smb")]
        public SmbSetting ProtocolSmbSetting
        {
            get => ProtocolSettings is null ? default : ProtocolSettings.SmbSetting;
            set
            {
                if (ProtocolSettings is null)
                    ProtocolSettings = new FileServiceProtocolSettings();
                ProtocolSettings.SmbSetting = value;
            }
        }
    }
}
