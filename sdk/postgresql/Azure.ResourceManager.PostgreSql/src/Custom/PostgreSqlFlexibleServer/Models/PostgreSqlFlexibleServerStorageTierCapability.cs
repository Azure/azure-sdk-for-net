// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves previous capability properties that were flattened from the service response.
    /// <summary> Represents capability of a storage tier. </summary>
    public partial class PostgreSqlFlexibleServerStorageTierCapability : PostgreSqlBaseCapability
    {
        /// <summary> Storage tier name. </summary>
        [WirePath("tierName")]
        public string TierName { get; }
        /// <summary> Indicates if this is a baseline storage tier or not. </summary>
        [WirePath("isBaseline")]
        public bool? IsBaseline { get; }
    }
}
