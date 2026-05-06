// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // See DataTransferServiceProperties.cs — same rationale.
    [CodeGenSuppress("MaterializedViewsBuilderServiceProperties")]
    public partial class MaterializedViewsBuilderServiceProperties
    {
        /// <summary> Initializes a new instance of <see cref="MaterializedViewsBuilderServiceProperties"/>. </summary>
        public MaterializedViewsBuilderServiceProperties()
        {
            Locations = new ChangeTrackingList<MaterializedViewsBuilderRegionalService>();
            ServiceType = CosmosDBServiceType.MaterializedViewsBuilder;
        }
    }
}
