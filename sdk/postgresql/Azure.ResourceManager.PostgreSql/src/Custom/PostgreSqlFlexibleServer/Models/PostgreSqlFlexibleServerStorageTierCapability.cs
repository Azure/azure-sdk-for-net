// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.PostgreSql.FlexibleServers;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Represents capability of a storage tier. </summary>
    public partial class PostgreSqlFlexibleServerStorageTierCapability : PostgreSqlBaseCapability
    {
        /// <summary> Storage tier name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("tierName")]
        public string TierName { get; }
        /// <summary> Indicates if this is a baseline storage tier or not. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("isBaseline")]
        public bool? IsBaseline { get; }
    }
}
