// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    // Preserve the previous GA property name over properties.privateLinkServiceConnectionState.
    // This can be removed if the spec applies a C# @@clientName customization to the common
    // privateLinkServiceConnectionState property and the SDK is regenerated from that spec commit.
    public partial class PostgreSqlFlexibleServersPrivateEndpointConnectionData
    {
        /// <summary> A collection of information about the state of the connection between service consumer and provider. </summary>
        [CodeGenMember("PrivateLinkServiceConnectionState")]
        public PostgreSqlFlexibleServersPrivateLinkServiceConnectionState ConnectionState { get; set; }
    }
}
