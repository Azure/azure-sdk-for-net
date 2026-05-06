// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    public readonly partial struct CosmosDBServerVersion
    {
#pragma warning disable CA1707
        /// <summary> 3.2. </summary>
        [CodeGenMember("Three2")]
        public static CosmosDBServerVersion V3_2 { get; } = new CosmosDBServerVersion(Three2Value);
        /// <summary> 3.6. </summary>
        [CodeGenMember("Three6")]
        public static CosmosDBServerVersion V3_6 { get; } = new CosmosDBServerVersion(Three6Value);
        /// <summary> 4.0. </summary>
        [CodeGenMember("Four0")]
        public static CosmosDBServerVersion V4_0 { get; } = new CosmosDBServerVersion(Four0Value);
        /// <summary> 4.2. </summary>
        [CodeGenMember("Four2")]
        public static CosmosDBServerVersion V4_2 { get; } = new CosmosDBServerVersion(Four2Value);
#pragma warning restore CA1707
    }
}
