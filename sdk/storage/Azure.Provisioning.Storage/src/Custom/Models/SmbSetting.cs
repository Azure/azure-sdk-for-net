// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class SmbSetting
{
    /// <summary> Gets or sets whether multichannel is enabled. </summary>
    [CodeGenMember("MultichannelIsMultiChannelEnabled")]
    public BicepValue<bool> IsMultiChannelEnabled
    {
        get
        {
            return Multichannel is null ? default : Multichannel.IsMultiChannelEnabled;
        }
        set
        {
            if (Multichannel is null)
            {
                Multichannel = new Multichannel();
            }
            Multichannel.IsMultiChannelEnabled = value;
        }
    }
}
