// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class SmbSetting
    {
        /// <summary> Backward-compatible alias for MultichannelEnabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsMultiChannelEnabled
        {
            get => MultichannelEnabled;
            set => MultichannelEnabled = value;
        }

        /// <summary> Backward-compatible alias for Required. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsRequired
        {
            get => Required;
            set => Required = value;
        }
    }
}
