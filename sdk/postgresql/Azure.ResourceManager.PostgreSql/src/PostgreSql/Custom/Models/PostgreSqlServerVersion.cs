// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.PostgreSql.Models
{
    /// <summary> The version of a server. </summary>
    public readonly partial struct PostgreSqlServerVersion : IEquatable<PostgreSqlServerVersion>
    {
#pragma warning disable CA1707
        /// <summary> 9.5. </summary>
        [CodeGenMember("NinePointFive")]
        public static PostgreSqlServerVersion Ver9_5 { get; } = new PostgreSqlServerVersion(Ver9_5Value);
        /// <summary> 9.6. </summary>
        [CodeGenMember("NinePointSix")]
        public static PostgreSqlServerVersion Ver9_6 { get; } = new PostgreSqlServerVersion(Ver9_6Value);
        /// <summary> 10. </summary>
        [CodeGenMember("Ten")]
        public static PostgreSqlServerVersion Ver10 { get; } = new PostgreSqlServerVersion(Ver10Value);
        /// <summary> 10.0. </summary>
        [CodeGenMember("TenPointZero")]
        public static PostgreSqlServerVersion Ver10_0 { get; } = new PostgreSqlServerVersion(Ver10_0Value);
        /// <summary> 10.2. </summary>
        [CodeGenMember("TenPointTwo")]
        public static PostgreSqlServerVersion Ver10_2 { get; } = new PostgreSqlServerVersion(Ver10_2Value);
        /// <summary> 11. </summary>
        [CodeGenMember("Eleven")]
        public static PostgreSqlServerVersion Ver11 { get; } = new PostgreSqlServerVersion(Ver11Value);
#pragma warning restore CA1707
    }
}
