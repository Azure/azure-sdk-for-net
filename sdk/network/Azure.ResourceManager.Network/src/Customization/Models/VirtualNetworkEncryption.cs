// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class VirtualNetworkEncryption
    {
        /// <summary> Gets or sets whether encryption is enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use IsEnabled instead.")]
        public bool Enabled
        {
            get => IsEnabled;
            set => IsEnabled = value;
        }
    }
}
