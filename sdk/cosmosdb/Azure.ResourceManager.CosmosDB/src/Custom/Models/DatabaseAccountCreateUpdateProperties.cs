// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // DatabaseAccountCreateUpdateProperties is the inner properties model for the
    // CosmosDBAccountCreateOrUpdateContent wrapper. The spec marks
    // `databaseAccountOfferType` as a constant ("Standard") so MPG generates it as
    // `{ get; }` only. The legacy SDK exposed `DatabaseAccountOfferType` as
    // `{ get; set; }` (settable) on the back-compat surface — the property is
    // surfaced through the wrapper class' top-level proxy and callers historically
    // assigned to it. Suppress the get-only generated property and re-emit it with
    // a public setter so the wrapper's proxy assignment compiles and round-trips.
    [CodeGenSuppress("DatabaseAccountOfferType")]
    internal partial class DatabaseAccountCreateUpdateProperties
    {
        /// <summary> The offer type for the database. </summary>
        [WirePath("databaseAccountOfferType")]
        public CosmosDBAccountOfferType DatabaseAccountOfferType { get; set; }
    }
}
