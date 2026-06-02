// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // The auto-generated public default ctor passes the CosmosDBServiceType
    // discriminator up to the now-suppressed base ctor (see CosmosDBServiceProperties
    // customization). Suppress it and reintroduce a parameterless ctor that matches
    // the historical public surface and sets ServiceType internally.
    [CodeGenSuppress("DataTransferServiceProperties")]
    public partial class DataTransferServiceProperties
    {
        /// <summary> Initializes a new instance of <see cref="DataTransferServiceProperties"/>. </summary>
        public DataTransferServiceProperties()
        {
            Locations = new ChangeTrackingList<DataTransferRegionalService>();
            ServiceType = CosmosDBServiceType.DataTransfer;
        }
    }
}
