// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    internal static partial class NotificationHubNamespaceTypeExtensions
    {
        public static string ToSerialString(this NotificationHubNamespaceType value) => value switch
        {
            NotificationHubNamespaceType.Messaging => "Messaging",
            NotificationHubNamespaceType.NotificationHub => "NotificationHub",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NotificationHubNamespaceType value.")
        };

        public static NotificationHubNamespaceType ToNotificationHubNamespaceType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Messaging")) return NotificationHubNamespaceType.Messaging;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "NotificationHub")) return NotificationHubNamespaceType.NotificationHub;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NotificationHubNamespaceType value.");
        }
    }
}
