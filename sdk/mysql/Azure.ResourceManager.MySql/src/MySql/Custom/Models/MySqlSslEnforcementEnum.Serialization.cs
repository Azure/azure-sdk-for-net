// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.MySql.Models
{
    internal static partial class MySqlSslEnforcementEnumExtensions
    {
        public static string ToSerialString(this MySqlSslEnforcementEnum value) => value switch
        {
            MySqlSslEnforcementEnum.Enabled => "Enabled",
            MySqlSslEnforcementEnum.Disabled => "Disabled",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MySqlSslEnforcementEnum value.")
        };

        public static MySqlSslEnforcementEnum ToMySqlSslEnforcementEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Enabled")) return MySqlSslEnforcementEnum.Enabled;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Disabled")) return MySqlSslEnforcementEnum.Disabled;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MySqlSslEnforcementEnum value.");
        }
    }
}