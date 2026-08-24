// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Storage;

public partial class SmbSetting
{
    // TypeSpec prefixes flattened nested properties with their model names. Preserve the
    // shorter shipped names by forwarding to the newly generated properties.
    /// <summary> Gets or sets whether SMB multichannel is enabled. </summary>
    public BicepValue<bool> IsMultiChannelEnabled
    {
        get { return MultichannelIsMultiChannelEnabled; }
        set { MultichannelIsMultiChannelEnabled = value; }
    }

    /// <summary> Gets or sets whether encryption in transit is required. </summary>
    public BicepValue<bool> IsRequired
    {
        get { return EncryptionInTransitIsRequired; }
        set { EncryptionInTransitIsRequired = value; }
    }
}
