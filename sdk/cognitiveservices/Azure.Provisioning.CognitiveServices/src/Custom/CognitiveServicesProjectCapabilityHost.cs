// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.CognitiveServices
{
    /// <summary> Compatibility type for the project-scoped capability host resource name exposed by previous Azure.Provisioning.CognitiveServices releases. </summary>
    public partial class CognitiveServicesProjectCapabilityHost
    {
        /// <summary> Supported API versions for the CognitiveServicesProjectCapabilityHost resource. </summary>
        public static partial class ResourceVersions
        {
            /// <summary> API version "2025-06-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2025_06_01 = "2025-06-01";
            /// <summary> API version "2025-09-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2025_09_01 = "2025-09-01";
        }
    }
}
