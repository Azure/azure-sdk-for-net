// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    /// <summary> Describes the ServerVersion of an a MongoDB account. </summary>
    public readonly partial struct CosmosDBServerVersion : IEquatable<CosmosDBServerVersion>
    {
#pragma warning disable CA1707
        /// <summary> 3.2. </summary>
        [CodeGenMember("Three2")]
        public static CosmosDBServerVersion V3_2 { get; } = new CosmosDBServerVersion(V3_2Value);
        /// <summary> 3.6. </summary>
        [CodeGenMember("Three6")]
        public static CosmosDBServerVersion V3_6 { get; } = new CosmosDBServerVersion(V3_6Value);
        /// <summary> 4.0. </summary>
        [CodeGenMember("Four0")]
        public static CosmosDBServerVersion V4_0 { get; } = new CosmosDBServerVersion(V4_0Value);
        /// <summary> 4.2. </summary>
        [CodeGenMember("Four2")]
        public static CosmosDBServerVersion V4_2 { get; } = new CosmosDBServerVersion(V4_2Value);
#pragma warning restore CA1707
    }
}
