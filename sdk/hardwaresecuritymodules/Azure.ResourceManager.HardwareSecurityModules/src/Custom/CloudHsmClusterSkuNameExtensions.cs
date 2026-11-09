// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.HardwareSecurityModules.Models
{
    internal static partial class CloudHsmClusterSkuNameExtensions
    {
        public static string ToSerialString(this CloudHsmClusterSkuName value) => value switch
        {
            CloudHsmClusterSkuName.StandardB1 => "Standard_B1",
            CloudHsmClusterSkuName.StandardB10 => "Standard B10",
            CloudHsmClusterSkuName.StandardB1v2 => "Standard_B1v2",
            CloudHsmClusterSkuName.StandardB5v2 => "Standard_B5v2",
            CloudHsmClusterSkuName.StandardB10v2 => "Standard_B10v2",
            CloudHsmClusterSkuName.StandardB15v2 => "Standard_B15v2",
            CloudHsmClusterSkuName.StandardB20v2 => "Standard_B20v2",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CloudHsmClusterSkuName value.")
        };

        public static CloudHsmClusterSkuName ToCloudHsmClusterSkuName(this string value)
        {
            if (string.Equals(value, "Standard_B1", StringComparison.InvariantCultureIgnoreCase))
                return CloudHsmClusterSkuName.StandardB1;
            if (string.Equals(value, "Standard B10", StringComparison.InvariantCultureIgnoreCase))
                return CloudHsmClusterSkuName.StandardB10;
            if (string.Equals(value, "Standard_B1v2", StringComparison.InvariantCultureIgnoreCase))
                return CloudHsmClusterSkuName.StandardB1v2;
            if (string.Equals(value, "Standard_B5v2", StringComparison.InvariantCultureIgnoreCase))
                return CloudHsmClusterSkuName.StandardB5v2;
            if (string.Equals(value, "Standard_B10v2", StringComparison.InvariantCultureIgnoreCase))
                return CloudHsmClusterSkuName.StandardB10v2;
            if (string.Equals(value, "Standard_B15v2", StringComparison.InvariantCultureIgnoreCase))
                return CloudHsmClusterSkuName.StandardB15v2;
            if (string.Equals(value, "Standard_B20v2", StringComparison.InvariantCultureIgnoreCase))
                return CloudHsmClusterSkuName.StandardB20v2;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CloudHsmClusterSkuName value.");
        }
    }
}
