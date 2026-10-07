// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Redis
{
    [CodeGenType("Redis")]
    public partial class RedisResource
    {
        // The TypeSpec model is named RedisResource, but the provisioning generator emits Redis by default.
        // Preserve the shipped RedisResource type name with CodeGenType and keep compatibility members here.
        public static partial class ResourceVersions
        {
            // Preserve historical GA API versions that shipped from the reflection-based provisioning generator.
            /// <summary> API version "2014-04-01". </summary>
            public static readonly string V2014_04_01 = "2014-04-01";
            /// <summary> API version "2015-03-01". </summary>
            public static readonly string V2015_03_01 = "2015-03-01";
            /// <summary> API version "2015-08-01". </summary>
            public static readonly string V2015_08_01 = "2015-08-01";
            /// <summary> API version "2016-04-01". </summary>
            public static readonly string V2016_04_01 = "2016-04-01";
            /// <summary> API version "2017-02-01". </summary>
            public static readonly string V2017_02_01 = "2017-02-01";
            /// <summary> API version "2017-10-01". </summary>
            public static readonly string V2017_10_01 = "2017-10-01";
            /// <summary> API version "2018-03-01". </summary>
            public static readonly string V2018_03_01 = "2018-03-01";
            /// <summary> API version "2019-07-01". </summary>
            public static readonly string V2019_07_01 = "2019-07-01";
            /// <summary> API version "2020-06-01". </summary>
            public static readonly string V2020_06_01 = "2020-06-01";
            /// <summary> API version "2020-12-01". </summary>
            public static readonly string V2020_12_01 = "2020-12-01";
            /// <summary> API version "2021-06-01". </summary>
            public static readonly string V2021_06_01 = "2021-06-01";
            /// <summary> API version "2022-05-01". </summary>
            public static readonly string V2022_05_01 = "2022-05-01";
            /// <summary> API version "2022-06-01". </summary>
            public static readonly string V2022_06_01 = "2022-06-01";
            /// <summary> API version "2023-04-01". </summary>
            public static readonly string V2023_04_01 = "2023-04-01";
            /// <summary> API version "2023-08-01". </summary>
            public static readonly string V2023_08_01 = "2023-08-01";
            /// <summary> API version "2024-03-01". </summary>
            public static readonly string V2024_03_01 = "2024-03-01";
        }

        // The TypeSpec provisioning generator does not emit custom action helpers yet.
        // Preserve the shipped Redis GetKeys() convenience API until action generation is supported.
        /// <summary>
        /// Get access keys for this RedisResource resource.
        /// </summary>
        /// <returns>The keys for this RedisResource resource.</returns>
        public RedisAccessKeys GetKeys()
        {
            RedisAccessKeys keys = new();
            ((IBicepValue)keys).Expression = new FunctionCallExpression(new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys"));
            return keys;
        }

        /// <summary> Gets the private endpoint connection resources. </summary>
        [CodeGenMember("PrivateEndpointConnections")]
        public BicepList<RedisPrivateEndpointConnection> PrivateEndpointConnectionResources
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RedisProperties();
                }
                return Properties.PrivateEndpointConnectionResources;
            }
        }

        /// <summary>
        /// Gets the private endpoint connection data models.
        /// This compatibility property is preserved for the previous generated model shape. Use <see cref="PrivateEndpointConnectionResources"/> instead.
        /// </summary>
        // The new generator models private endpoint connections as child resources. Keep the old flattened
        // data-model list as an obsolete compatibility API for callers compiled against Azure.Provisioning.Redis 1.1.0.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use PrivateEndpointConnectionResources instead.")]
        public BicepList<RedisPrivateEndpointConnectionData> PrivateEndpointConnections
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RedisProperties();
                }
                return Properties.PrivateEndpointConnections;
            }
        }
    }
}
