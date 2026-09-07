// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.AppService;

public partial class KubeEnvironment
{
    public static partial class ResourceVersions
    {
        // Preserve historical API versions that shipped from the reflection-based provisioning generator.
        /// <summary> API version "2024-11-01". </summary>
        public static readonly string V2024_11_01 = "2024-11-01";
        /// <summary> API version "2024-04-01". </summary>
        public static readonly string V2024_04_01 = "2024-04-01";
        /// <summary> API version "2021-03-01". </summary>
        public static readonly string V2021_03_01 = "2021-03-01";
    }
}
