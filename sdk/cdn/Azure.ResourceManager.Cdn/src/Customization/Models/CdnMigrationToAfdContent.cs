// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Cdn;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class CdnMigrationToAfdContent
    {
        /// <summary> Initializes a new instance of <see cref="CdnMigrationToAfdContent"/>. </summary>
        /// <param name="sku"> Sku for the migration. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/> is null. </exception>
        public CdnMigrationToAfdContent(CdnSku sku)
        {
            Argument.AssertNotNull(sku, nameof(sku));

            Sku = sku;
            MigrationEndpointMappings = new ChangeTrackingList<MigrationEndpointMapping>();
        }
    }
}
