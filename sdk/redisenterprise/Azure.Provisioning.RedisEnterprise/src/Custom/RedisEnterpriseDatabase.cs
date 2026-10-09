// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.RedisEnterprise
{
    // DatabaseCreateProperties redeclares accessKeysAuthentication to provide a create-time default.
    // Suppress the duplicate flattened member and preserve the released API with the forwarding property below.
    [CodeGenSuppress("AccessKeysAuthentication")]
    public partial class RedisEnterpriseDatabase
    {
        /// <summary> Gets or sets whether access-key authentication is enabled. </summary>
        public BicepValue<AccessKeysAuthentication> AccessKeysAuthentication
        {
            get
            {
                return Properties is null ? default! : Properties.AccessKeysAuthentication;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new DatabaseCreateProperties();
                }
                Properties.AccessKeysAuthentication = value;
            }
        }

        /// <summary> Gets access keys for this Redis Enterprise database. </summary>
        public RedisEnterpriseDataAccessKeys GetKeys()
        {
            RedisEnterpriseDataAccessKeys keys = new();
            ((IBicepValue)keys).Expression = new FunctionCallExpression(
                new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys"));
            return keys;
        }

        /// <summary> Supported API versions retained for compatibility. </summary>
        public static partial class ResourceVersions
        {
            /// <summary> API version "2025-07-01". </summary>
            public static readonly string V2025_07_01 = "2025-07-01";
            /// <summary> API version "2025-04-01". </summary>
            public static readonly string V2025_04_01 = "2025-04-01";
            /// <summary> API version "2024-10-01". </summary>
            public static readonly string V2024_10_01 = "2024-10-01";
            /// <summary> API version "2024-02-01". </summary>
            public static readonly string V2024_02_01 = "2024-02-01";
            /// <summary> API version "2023-11-01". </summary>
            public static readonly string V2023_11_01 = "2023-11-01";
            /// <summary> API version "2023-07-01". </summary>
            public static readonly string V2023_07_01 = "2023-07-01";
            /// <summary> API version "2022-01-01". </summary>
            public static readonly string V2022_01_01 = "2022-01-01";
            /// <summary> API version "2021-08-01". </summary>
            public static readonly string V2021_08_01 = "2021-08-01";
            /// <summary> API version "2021-03-01". </summary>
            public static readonly string V2021_03_01 = "2021-03-01";
        }
    }
}
