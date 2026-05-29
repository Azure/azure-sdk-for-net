// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class NetworkFabricPatchContent
    {
        /// <summary> Network and credentials configuration already applied to terminal server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use TerminalServerSettings instead.")]
        public NetworkFabricPatchablePropertiesTerminalServerConfiguration TerminalServerConfiguration
        {
            get => Properties is null ? default : NetworkFabricPatchablePropertiesTerminalServerConfiguration.FromNetworkFabricTerminalServerPatchConfiguration(Properties.TerminalServerSettings);
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.TerminalServerSettings = value?.ToNetworkFabricTerminalServerPatchConfiguration();
            }
        }
    }
}
