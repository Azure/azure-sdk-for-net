// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.MySql.Models
{
    internal static partial class MySqlServerSecurityAlertPolicyStateExtensions
    {
        public static string ToSerialString(this MySqlServerSecurityAlertPolicyState value) => value switch
        {
            MySqlServerSecurityAlertPolicyState.Enabled => "Enabled",
            MySqlServerSecurityAlertPolicyState.Disabled => "Disabled",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MySqlServerSecurityAlertPolicyState value.")
        };

        public static MySqlServerSecurityAlertPolicyState ToMySqlServerSecurityAlertPolicyState(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Enabled")) return MySqlServerSecurityAlertPolicyState.Enabled;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Disabled")) return MySqlServerSecurityAlertPolicyState.Disabled;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MySqlServerSecurityAlertPolicyState value.");
        }
    }
}