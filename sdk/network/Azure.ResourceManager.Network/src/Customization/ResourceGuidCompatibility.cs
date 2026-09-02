// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    internal static class ResourceGuidCompatibility
    {
        /// <summary> Invokes the Parse compatibility operation. </summary>
        public static Guid? Parse(object value)
        {
            return Guid.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture), out Guid guid) ? guid : default;
        }
    }
}
