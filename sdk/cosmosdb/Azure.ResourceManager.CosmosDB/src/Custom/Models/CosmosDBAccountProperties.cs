// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    internal partial class CosmosDBAccountProperties
    {
        /// <summary> Flag to indicate enabling/disabling of hierarchical partition key ID last level enforcement on the account. </summary>
        [CodeGenMember("EnforceHierarchicalPartitionKeyIdLastLevel")]
        public bool? IsHierarchicalPartitionKeyIdLastLevelEnforced { get; set; }
    }
}
