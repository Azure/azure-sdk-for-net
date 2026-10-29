// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.KeyVault.Models
{
    internal static partial class ManagedHsmSkuNameExtensions
    {
        public static string ToSerialString(this ManagedHsmSkuName value) => value switch
        {
            ManagedHsmSkuName.StandardB1 => "Standard_B1",
            ManagedHsmSkuName.CustomB32 => "Custom_B32",
            ManagedHsmSkuName.CustomB6 => "Custom_B6",
            ManagedHsmSkuName.CustomC42 => "Custom_C42",
            ManagedHsmSkuName.CustomC10 => "Custom_C10",
            ManagedHsmSkuName.StandardB1v2 => "Standard_B1v2",
            ManagedHsmSkuName.StandardB5v2 => "Standard_B5v2",
            ManagedHsmSkuName.StandardB10v2 => "Standard_B10v2",
            ManagedHsmSkuName.StandardB15v2 => "Standard_B15v2",
            ManagedHsmSkuName.StandardB20v2 => "Standard_B20v2",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ManagedHsmSkuName value.")
        };

        public static ManagedHsmSkuName ToManagedHsmSkuName(this string value)
        {
            if (string.Equals(value, "Standard_B1", StringComparison.InvariantCultureIgnoreCase))
                return ManagedHsmSkuName.StandardB1;
            if (string.Equals(value, "Custom_B32", StringComparison.InvariantCultureIgnoreCase))
                return ManagedHsmSkuName.CustomB32;
            if (string.Equals(value, "Custom_B6", StringComparison.InvariantCultureIgnoreCase))
                return ManagedHsmSkuName.CustomB6;
            if (string.Equals(value, "Custom_C42", StringComparison.InvariantCultureIgnoreCase))
                return ManagedHsmSkuName.CustomC42;
            if (string.Equals(value, "Custom_C10", StringComparison.InvariantCultureIgnoreCase))
                return ManagedHsmSkuName.CustomC10;
            if (string.Equals(value, "Standard_B1v2", StringComparison.InvariantCultureIgnoreCase))
                return ManagedHsmSkuName.StandardB1v2;
            if (string.Equals(value, "Standard_B5v2", StringComparison.InvariantCultureIgnoreCase))
                return ManagedHsmSkuName.StandardB5v2;
            if (string.Equals(value, "Standard_B10v2", StringComparison.InvariantCultureIgnoreCase))
                return ManagedHsmSkuName.StandardB10v2;
            if (string.Equals(value, "Standard_B15v2", StringComparison.InvariantCultureIgnoreCase))
                return ManagedHsmSkuName.StandardB15v2;
            if (string.Equals(value, "Standard_B20v2", StringComparison.InvariantCultureIgnoreCase))
                return ManagedHsmSkuName.StandardB20v2;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ManagedHsmSkuName value.");
        }
    }
}
