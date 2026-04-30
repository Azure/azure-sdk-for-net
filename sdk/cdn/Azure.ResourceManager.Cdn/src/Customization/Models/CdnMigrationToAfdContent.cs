// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Cdn;

namespace Azure.ResourceManager.Cdn.Models
{
    // Reason: Backward compatibility — the old SDK (v1.5.1) had a public
    // constructor taking CdnSku. The generator now makes the constructor
    // parameterless (CdnSku is set via the SkuName property instead).
    // This overload preserves the old public API surface for existing callers.
    //
    // Cannot rename type from CdnMigrationToAfd to CdnMigrationToFrontDoor —
    // the generated class implements IJsonModel<CdnMigrationToAfdContent> and
    // IPersistableModel<CdnMigrationToAfdContent>. A subclass approach cannot
    // satisfy these generic interface constraints.
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
