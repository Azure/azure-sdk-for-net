// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.CosmosDB.Models
{
    public partial class SqlDedicatedGatewayServiceProperties
    {
        /// <summary> Initializes a new instance of <see cref="SqlDedicatedGatewayServiceProperties"/>. </summary>
        public SqlDedicatedGatewayServiceProperties()
        {
            Locations = new ChangeTrackingList<SqlDedicatedGatewayRegionalService>();
            ServiceType = CosmosDBServiceType.SqlDedicatedGateway;
        }
    }
}
