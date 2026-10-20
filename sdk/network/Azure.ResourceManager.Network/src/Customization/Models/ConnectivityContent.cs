// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
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

        // Retain the name shipped in 1.16.1/1.17 as an alias, not independent serialized storage.
        /// <summary> HTTP configuration of the connectivity check. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `HttpProtocolConfiguration` instead", false)]
        public NetworkHttpConfiguration ProtocolHTTPConfiguration
        {
            get => HttpProtocolConfiguration;
            set => HttpProtocolConfiguration = value;
        }
    }
}
