// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    internal static partial class AuthorizationRuleAccessRightExtensions
    {
        public static string ToSerialString(this AuthorizationRuleAccessRight value) => value switch
        {
            AuthorizationRuleAccessRight.Manage => "Manage",
            AuthorizationRuleAccessRight.Send => "Send",
            AuthorizationRuleAccessRight.Listen => "Listen",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AuthorizationRuleAccessRight value.")
        };

        public static AuthorizationRuleAccessRight ToAuthorizationRuleAccessRight(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Manage")) return AuthorizationRuleAccessRight.Manage;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Send")) return AuthorizationRuleAccessRight.Send;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Listen")) return AuthorizationRuleAccessRight.Listen;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AuthorizationRuleAccessRight value.");
        }
    }
}
