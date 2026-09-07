// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.OperationalInsights
{
    // Preserve previously shipped ResourceVersions values that are not emitted by the
    // TypeSpec-based provisioning generator for the current API version.
    public partial class LogAnalyticsQuery
    {
        public static partial class ResourceVersions
        {
            /// <summary> API version "2019-09-01". </summary>
            public static readonly string V2019_09_01 = "2019-09-01";
            /// <summary> API version "2023-09-01". </summary>
            public static readonly string V2023_09_01 = "2023-09-01";
            /// <summary> API version "2025-02-01". </summary>
            public static readonly string V2025_02_01 = "2025-02-01";
        }
    }
}
