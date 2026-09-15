// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.ContainerRegistry
{
    [CodeGenType("ContainerRegistry")]
    public partial class ContainerRegistryService
    {
#pragma warning disable CS0618 // ContainerRegistryPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
        private BicepList<ContainerRegistryPrivateEndpointConnectionData> _privateEndpointConnections;
#pragma warning restore CS0618

        /// <summary> Gets the private endpoint connection resources. </summary>
        [CodeGenMember("PrivateEndpointConnections")]
        public BicepList<ContainerRegistryPrivateEndpointConnection> PrivateEndpointConnectionResources
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RegistryProperties();
                }
                return Properties.PrivateEndpointConnections;
            }
        }

        /// <summary>
        /// Gets the private endpoint connection data models.
        /// This compatibility property preserves the previous generated model shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use PrivateEndpointConnectionResources instead.")]
#pragma warning disable CS0618 // ContainerRegistryPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
        public BicepList<ContainerRegistryPrivateEndpointConnectionData> PrivateEndpointConnections
#pragma warning restore CS0618
        {
            get
            {
                Initialize();
                return _privateEndpointConnections;
            }
        }

        partial void DefineAdditionalProperties()
        {
#pragma warning disable CS0618 // ContainerRegistryPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
            _privateEndpointConnections = DefineListProperty<ContainerRegistryPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), new string[] { "properties", "privateEndpointConnections" }, isOutput: true);
#pragma warning restore CS0618
        }

        /// <summary></summary>
        public static partial class ResourceVersions
        {
            /// <summary> API version "2017-03-01". </summary>
            public static readonly string V2017_03_01 = "2017-03-01";
            /// <summary> API version "2017-10-01". </summary>
            public static readonly string V2017_10_01 = "2017-10-01";
            /// <summary> API version "2019-05-01". </summary>
            public static readonly string V2019_05_01 = "2019-05-01";
            /// <summary> API version "2021-09-01". </summary>
            public static readonly string V2021_09_01 = "2021-09-01";
            /// <summary> API version "2022-12-01". </summary>
            public static readonly string V2022_12_01 = "2022-12-01";
            /// <summary> API version "2023-07-01". </summary>
            public static readonly string V2023_07_01 = "2023-07-01";
            /// <summary> API version "2025-04-01". </summary>
            public static readonly string V2025_04_01 = "2025-04-01";
        }
    }
}
