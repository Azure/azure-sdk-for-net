// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static partial class AppServiceDomainTypeExtensions
    {
        public static string ToSerialString(this AppServiceDomainType value) => value switch
        {
            AppServiceDomainType.Regular => "Regular",
            AppServiceDomainType.SoftDeleted => "SoftDeleted",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AppServiceDomainType value.")
        };

        public static AppServiceDomainType ToAppServiceDomainType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Regular")) return AppServiceDomainType.Regular;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "SoftDeleted")) return AppServiceDomainType.SoftDeleted;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AppServiceDomainType value.");
        }
    }
}
