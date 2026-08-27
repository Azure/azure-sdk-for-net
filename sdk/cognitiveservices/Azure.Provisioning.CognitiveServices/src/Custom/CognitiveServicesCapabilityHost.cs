// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.CognitiveServices
{
    public partial class CognitiveServicesCapabilityHost
    {
        // TypeSpec generation only emits the configured service versions. Restore the constants
        // that were public in 1.2.0 so existing source continues to compile.
        public static partial class ResourceVersions
        {
            /// <summary> API version "2025-06-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2025_06_01 = "2025-06-01";
            /// <summary> API version "2025-09-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2025_09_01 = "2025-09-01";
        }
    }
}
