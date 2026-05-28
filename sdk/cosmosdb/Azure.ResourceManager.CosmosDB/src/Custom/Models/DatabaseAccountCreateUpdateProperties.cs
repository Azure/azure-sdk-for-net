// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Spec marks databaseAccountOfferType as a constant ("Standard") so MPG emits it as `{ get; }`.
    // CosmosDBAccountCreateOrUpdateContent proxies it as { get; set; } for 1.4.0 GA back-compat —
    // the proxy setter requires a settable inner property. Suppress and re-emit with both accessors.
    [CodeGenSuppress("DatabaseAccountOfferType")]
    internal partial class DatabaseAccountCreateUpdateProperties
    {
        /// <summary> The offer type for the database. </summary>
        [WirePath("databaseAccountOfferType")]
        public CosmosDBAccountOfferType DatabaseAccountOfferType { get; set; }
    }
}
