// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.ServiceBus;

// Customize the generated MigrationConfiguration resource
public partial class MigrationConfiguration
{
    // Preserve the singleton name default emitted by the reflection-based provisioning generator.
    partial void DefineAdditionalProperties()
    {
        _name.Assign("$default");
    }

    public static partial class ResourceVersions
    {
        // Preserve historical API versions that shipped from the reflection-based provisioning generator.
        /// <summary> API version "2017-04-01". </summary>
        public static readonly string V2017_04_01 = "2017-04-01";
        /// <summary> API version "2021-11-01". </summary>
        public static readonly string V2021_11_01 = "2021-11-01";
        /// <summary> API version "2024-01-01". </summary>
        public static readonly string V2024_01_01 = "2024-01-01";
    }
}

// CI experiment: include this package in the 20-package timing workload.
