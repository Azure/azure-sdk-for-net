// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CognitiveServices
{
    public partial class CognitiveServicesAccount
    {
        /// <summary>
        /// Get access keys for this CognitiveServicesAccount resource.
        /// </summary>
        /// <returns>The keys for this CognitiveServicesAccount resource.</returns>
        public ServiceAccountApiKeys GetKeys()
        {
            // TODO: Generate provisioning custom action methods instead of maintaining this shim manually. See https://github.com/Azure/azure-sdk-for-net/issues/56753.
            ServiceAccountApiKeys key = new ServiceAccountApiKeys();
            ((IBicepValue)key).Expression = new FunctionCallExpression(new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys"));
            return key;
        }

        public static partial class ResourceVersions
        {
            /// <summary> API version "2017-04-18". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2017_04_18 = "2017-04-18";
            /// <summary> API version "2021-04-30". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2021_04_30 = "2021-04-30";
            /// <summary> API version "2021-10-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2021_10_01 = "2021-10-01";
            /// <summary> API version "2022-03-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2022_03_01 = "2022-03-01";
            /// <summary> API version "2022-10-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2022_10_01 = "2022-10-01";
            /// <summary> API version "2022-12-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2022_12_01 = "2022-12-01";
            /// <summary> API version "2023-05-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2023_05_01 = "2023-05-01";
            /// <summary> API version "2024-10-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2024_10_01 = "2024-10-01";
            /// <summary> API version "2025-06-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2025_06_01 = "2025-06-01";
            /// <summary> API version "2025-09-01". Retained for compatibility with previous Azure.Provisioning.CognitiveServices releases. </summary>
            public static readonly string V2025_09_01 = "2025-09-01";
        }
    }
}
