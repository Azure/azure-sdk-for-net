// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.AppConfiguration
{
    public partial class AppConfigurationStore
    {
        /// <summary> Gets access keys for this App Configuration store. </summary>
        public BicepList<AppConfigurationStoreApiKey> GetKeys()
        {
            return BicepList<AppConfigurationStoreApiKey>.FromExpression(
                expression =>
                {
                    AppConfigurationStoreApiKey key = new();
                    ((IBicepValue)key).Expression = expression;
                    return key;
                },
                new MemberExpression(
                    new FunctionCallExpression(new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys")),
                    "keys"));
        }

        /// <summary> Supported API versions retained for compatibility. </summary>
        public static partial class ResourceVersions
        {
            /// <summary> API version "2024-06-01". </summary>
            public static readonly string V2024_06_01 = "2024-06-01";
            /// <summary> API version "2024-05-01". </summary>
            public static readonly string V2024_05_01 = "2024-05-01";
            /// <summary> API version "2023-03-01". </summary>
            public static readonly string V2023_03_01 = "2023-03-01";
            /// <summary> API version "2022-05-01". </summary>
            public static readonly string V2022_05_01 = "2022-05-01";
            /// <summary> API version "2020-06-01". </summary>
            public static readonly string V2020_06_01 = "2020-06-01";
            /// <summary> API version "2019-10-01". </summary>
            public static readonly string V2019_10_01 = "2019-10-01";
        }
    }
}
