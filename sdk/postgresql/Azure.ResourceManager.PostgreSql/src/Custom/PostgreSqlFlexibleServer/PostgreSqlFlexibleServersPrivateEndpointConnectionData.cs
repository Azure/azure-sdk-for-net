// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    [CodeGenSuppress("PrivateLinkServiceConnectionState")]
    public partial class PostgreSqlFlexibleServersPrivateEndpointConnectionData
    {
        /// <summary> A collection of information about the state of the connection between service consumer and provider. </summary>
        [WirePath("properties.privateLinkServiceConnectionState")]
        public PostgreSqlFlexibleServersPrivateLinkServiceConnectionState ConnectionState
        {
            get
            {
                return Properties is null ? default : Properties.PrivateLinkServiceConnectionState;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new PrivateEndpointConnectionProperties();
                }
                Properties.PrivateLinkServiceConnectionState = value;
            }
        }
    }
}
