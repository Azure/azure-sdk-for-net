// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class VpnConfigurationPatchableProperties
    {
        /// <summary> option A properties. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use OptionASettings instead.")]
        public VpnConfigurationPatchableOptionAProperties OptionAProperties
        {
            get => VpnConfigurationPatchableOptionAProperties.FromGeneratedOptionAPatchProperties(OptionASettings);
            set => OptionASettings = value?.ToVpnOptionAPatchProperties();
        }
    }
}
