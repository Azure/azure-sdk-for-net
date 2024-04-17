// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Search.Models
{
    internal static partial class SearchServicePublicNetworkAccessExtensions
    {
        public static string ToSerialString(this SearchServicePublicNetworkAccess value) => value switch
        {
            SearchServicePublicNetworkAccess.Enabled => "enabled",
            SearchServicePublicNetworkAccess.Disabled => "disabled",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SearchServicePublicNetworkAccess value.")
        };

        public static SearchServicePublicNetworkAccess ToSearchServicePublicNetworkAccess(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "enabled")) return SearchServicePublicNetworkAccess.Enabled;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "disabled")) return SearchServicePublicNetworkAccess.Disabled;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SearchServicePublicNetworkAccess value.");
        }
    }
}
