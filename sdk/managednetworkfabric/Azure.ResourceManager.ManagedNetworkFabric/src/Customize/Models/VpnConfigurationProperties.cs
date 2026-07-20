// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class VpnConfigurationProperties
    {
        /// <summary> option A properties. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use OptionASettings instead.")]
        public VpnConfigurationOptionAProperties OptionAProperties
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use OptionASettings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use OptionASettings instead.");
        }
    }
}
