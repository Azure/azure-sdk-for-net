// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden aliases (IsMultiChannelEnabled, IsRequired) for renamed
// SMB setting properties. Could use @@clientName in spec but would lose improved names.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class SmbSetting
    {
        /// <summary> Backward-compatible alias for MultichannelEnabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("multichannel.enabled")]
        public bool? IsMultiChannelEnabled
        {
            get => MultichannelEnabled;
            set => MultichannelEnabled = value;
        }

        /// <summary> Backward-compatible alias for Required. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("encryptionInTransit.required")]
        public bool? IsRequired
        {
            get => Required;
            set => Required = value;
        }
    }
}
