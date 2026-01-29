// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.ProviderHub.Models
{
    internal static partial class ProviderHubExtendedLocationTypeExtensions
    {
        public static string ToSerialString(this ProviderHubExtendedLocationType value) => value switch
        {
            ProviderHubExtendedLocationType.NotSpecified => "NotSpecified",
            ProviderHubExtendedLocationType.EdgeZone => "EdgeZone",
            ProviderHubExtendedLocationType.ArcZone => "ArcZone",
            ProviderHubExtendedLocationType.CustomLocation => "CustomLocation",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ProviderHubExtendedLocationType value.")
        };

        public static ProviderHubExtendedLocationType ToProviderHubExtendedLocationType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "NotSpecified")) return ProviderHubExtendedLocationType.NotSpecified;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "EdgeZone")) return ProviderHubExtendedLocationType.EdgeZone;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ArcZone")) return ProviderHubExtendedLocationType.ArcZone;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "CustomLocation")) return ProviderHubExtendedLocationType.CustomLocation;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ProviderHubExtendedLocationType value.");
        }
    }
}
