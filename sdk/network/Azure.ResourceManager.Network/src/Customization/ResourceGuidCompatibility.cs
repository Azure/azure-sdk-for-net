// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using System;
using System.Globalization;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    internal static class ResourceGuidCompatibility
    {
        public static Guid? Parse(object value)
        {
            return Guid.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture), out Guid guid) ? guid : default;
        }
    }
}

#pragma warning restore CS1591
