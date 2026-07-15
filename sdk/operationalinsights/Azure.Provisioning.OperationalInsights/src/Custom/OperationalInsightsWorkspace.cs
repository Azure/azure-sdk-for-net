// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.OperationalInsights
{
    public partial class OperationalInsightsWorkspace
    {
        // Preserve previously shipped ResourceVersions values that are not emitted by the
        // TypeSpec-based provisioning generator for the current API version.
        public static partial class ResourceVersions
        {
            /// <summary> API version "2015-03-20". </summary>
            public static readonly string V2015_03_20 = "2015-03-20";
            /// <summary> API version "2020-08-01". </summary>
            public static readonly string V2020_08_01 = "2020-08-01";
            /// <summary> API version "2020-10-01". </summary>
            public static readonly string V2020_10_01 = "2020-10-01";
            /// <summary> API version "2021-06-01". </summary>
            public static readonly string V2021_06_01 = "2021-06-01";
            /// <summary> API version "2022-10-01". </summary>
            public static readonly string V2022_10_01 = "2022-10-01";
            /// <summary> API version "2023-09-01". </summary>
            public static readonly string V2023_09_01 = "2023-09-01";
            /// <summary> API version "2025-02-01". </summary>
            public static readonly string V2025_02_01 = "2025-02-01";
        }

        // Preserve the previously shipped listKeys helper because custom actions are not
        // emitted by the TypeSpec-based provisioning generator.
        /// <summary>
        /// Get access keys for this OperationalInsightsWorkspace resource.
        /// </summary>
        /// <returns>The keys for this OperationalInsightsWorkspace resource.</returns>
        public OperationalInsightsWorkspaceSharedKeys GetKeys()
        {
            OperationalInsightsWorkspaceSharedKeys key = new();
            ((IBicepValue)key).Expression = new FunctionCallExpression(new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys"));
            return key;
        }
    }
}
