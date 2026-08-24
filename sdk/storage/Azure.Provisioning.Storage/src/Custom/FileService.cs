// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Storage;

public partial class FileService
{
    // TypeSpec exposes SMB settings through ProtocolSettings. Preserve the shipped flattened
    // ProtocolSmbSetting property while forwarding to the same nested Bicep path.
    /// <summary> Gets or sets the SMB protocol settings. </summary>
    public SmbSetting ProtocolSmbSetting
    {
        get
        {
            if (ProtocolSettings is null)
            {
                ProtocolSettings = new FileServiceProtocolSettings();
            }
            return ProtocolSettings.SmbSetting;
        }
        set
        {
            if (ProtocolSettings is null)
            {
                ProtocolSettings = new FileServiceProtocolSettings();
            }
            ProtocolSettings.SmbSetting = value;
        }
    }
}
