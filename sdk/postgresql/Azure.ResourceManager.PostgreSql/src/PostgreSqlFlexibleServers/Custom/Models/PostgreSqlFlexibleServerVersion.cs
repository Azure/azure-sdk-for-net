// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> The version of a server. </summary>
    public readonly partial struct PostgreSqlFlexibleServerVersion : IEquatable<PostgreSqlFlexibleServerVersion>
    {
        /// <summary> 15. </summary>
        [CodeGenMember("Fifteen")]
        public static PostgreSqlFlexibleServerVersion Ver15 { get; } = new PostgreSqlFlexibleServerVersion(Ver15Value);
        /// <summary> 14. </summary>
        [CodeGenMember("Fourteen")]
        public static PostgreSqlFlexibleServerVersion Ver14 { get; } = new PostgreSqlFlexibleServerVersion(Ver14Value);
        /// <summary> 13. </summary>
        [CodeGenMember("Thirteen")]
        public static PostgreSqlFlexibleServerVersion Ver13 { get; } = new PostgreSqlFlexibleServerVersion(Ver13Value);
        /// <summary> 12. </summary>
        [CodeGenMember("Twelve")]
        public static PostgreSqlFlexibleServerVersion Ver12 { get; } = new PostgreSqlFlexibleServerVersion(Ver12Value);
        /// <summary> 11. </summary>
        [CodeGenMember("Eleven")]
        public static PostgreSqlFlexibleServerVersion Ver11 { get; } = new PostgreSqlFlexibleServerVersion(Ver11Value);
    }
}
