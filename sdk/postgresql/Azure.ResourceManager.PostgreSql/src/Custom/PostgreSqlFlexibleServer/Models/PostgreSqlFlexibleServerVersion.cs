// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> The version of a server. </summary>
    public readonly partial struct PostgreSqlFlexibleServerVersion : IEquatable<PostgreSqlFlexibleServerVersion>
    {
        /// <summary> 15. </summary>
        [CodeGenMember("_15")]
        public static PostgreSqlFlexibleServerVersion Ver15 { get; } = new PostgreSqlFlexibleServerVersion(_15Value);
        /// <summary> 14. </summary>
        [CodeGenMember("_14")]
        public static PostgreSqlFlexibleServerVersion Ver14 { get; } = new PostgreSqlFlexibleServerVersion(_14Value);
        /// <summary> 13. </summary>
        [CodeGenMember("_13")]
        public static PostgreSqlFlexibleServerVersion Ver13 { get; } = new PostgreSqlFlexibleServerVersion(_13Value);
        /// <summary> 12. </summary>
        [CodeGenMember("_12")]
        public static PostgreSqlFlexibleServerVersion Ver12 { get; } = new PostgreSqlFlexibleServerVersion(_12Value);
        /// <summary> 11. </summary>
        [CodeGenMember("_11")]
        public static PostgreSqlFlexibleServerVersion Ver11 { get; } = new PostgreSqlFlexibleServerVersion(_11Value);
    }
}
