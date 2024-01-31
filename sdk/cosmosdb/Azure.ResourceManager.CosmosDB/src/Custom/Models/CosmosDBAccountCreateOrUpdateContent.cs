// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.CosmosDB.Models
{
    public partial class CosmosDBAccountCreateOrUpdateContent : TrackedResourceData
    {
        /// <summary> The offer type for the database. </summary>
        public CosmosDBAccountOfferType DatabaseAccountOfferType { get; [EditorBrowsable(EditorBrowsableState.Never)] set; }
    }
}
