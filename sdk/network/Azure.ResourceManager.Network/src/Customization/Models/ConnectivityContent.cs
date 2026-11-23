// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ConnectivityContent
    {
        // The generated flattened name orders the words differently from the 1.15 API.
        // CodeGenMember binds that member to the original name without changing nested wire storage.
        /// <summary> HTTP configuration of the connectivity check. </summary>
        [CodeGenMember("ProtocolHttpConfiguration")]
        [WirePath("protocolConfiguration.HTTPConfiguration")]
        public NetworkHttpConfiguration HttpProtocolConfiguration
        {
            get => ProtocolConfiguration?.HttpConfiguration;
            set
            {
                if (ProtocolConfiguration is null)
                {
                    ProtocolConfiguration = new ProtocolConfiguration();
                }
                ProtocolConfiguration.HttpConfiguration = value;
            }
        }
    }
}
