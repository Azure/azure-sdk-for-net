// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.MySql.FlexibleServers.Models
{
    /// <summary> The version of a server. </summary>
    public readonly partial struct MySqlFlexibleServerVersion : IEquatable<MySqlFlexibleServerVersion>
    {
        /// <summary> 5.7. </summary>
        [CodeGenMember("Five7")]
        public static MySqlFlexibleServerVersion Ver5_7 { get; } = new MySqlFlexibleServerVersion(Ver5_7Value);
        /// <summary> 8.0.21. </summary>
        [CodeGenMember("Eight021")]
        public static MySqlFlexibleServerVersion Ver8_0_21 { get; } = new MySqlFlexibleServerVersion(Ver8_0_21Value);
    }
}
