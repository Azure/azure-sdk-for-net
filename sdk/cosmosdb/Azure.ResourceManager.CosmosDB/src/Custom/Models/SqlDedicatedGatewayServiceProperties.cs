// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.CosmosDB.Models
{
    // See DataTransferServiceProperties.cs — same rationale: MPG emits a public ctor
    // that takes the CosmosDBServiceType discriminator, but the legacy SDK exposed a
    // parameterless ctor that initialized the discriminator and the read-only
    // Locations collection internally. Add the parameterless ctor back here.
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
