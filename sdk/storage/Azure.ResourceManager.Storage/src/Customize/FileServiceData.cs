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
    /// <summary>
    /// A class representing the FileService data model.
    /// The properties of File services in storage account.
    /// </summary>
    public partial class FileServiceData : ResourceData
    {
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
