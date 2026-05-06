// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    [CodeGenSuppress("DatabaseAccountOfferType")]
    internal partial class DatabaseAccountCreateUpdateProperties
    {
        /// <summary> The offer type for the database. </summary>
        [WirePath("databaseAccountOfferType")]
        public CosmosDBAccountOfferType DatabaseAccountOfferType { get; set; }
    }
}
