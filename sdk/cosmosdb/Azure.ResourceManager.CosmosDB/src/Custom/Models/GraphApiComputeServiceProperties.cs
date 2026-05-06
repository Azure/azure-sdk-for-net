// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // See DataTransferServiceProperties.cs — same rationale.
    [CodeGenSuppress("GraphApiComputeServiceProperties")]
    public partial class GraphApiComputeServiceProperties
    {
        /// <summary> Initializes a new instance of <see cref="GraphApiComputeServiceProperties"/>. </summary>
        public GraphApiComputeServiceProperties()
        {
            Locations = new ChangeTrackingList<GraphApiComputeRegionalService>();
            ServiceType = CosmosDBServiceType.GraphApiCompute;
        }
    }
}
