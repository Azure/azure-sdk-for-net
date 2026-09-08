// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.AppContainers
{
    public partial class ContainerAppManagedEnvironment
    {
        private BicepList<ContainerAppPrivateEndpointConnection> _privateEndpointConnections;

        // The managed-environment and container-app private endpoint resources share the same model schema.
        // The generator currently selects ContainerAppContainerPrivateEndpointConnection for this property, but the
        // last stable library released it as ContainerAppPrivateEndpointConnection. Rename the newly selected property
        // so the released property name and type can be preserved below without a breaking change.
        // TODO: Remove this workaround when the generator reads the existing contract and preserves its resource selection.
        // https://github.com/Azure/azure-sdk-for-net/issues/60673
        /// <summary> Gets the container app private endpoint connection resources. </summary>
        [CodeGenMember("PrivateEndpointConnections")]
        public BicepList<ContainerAppContainerPrivateEndpointConnection> PrivateEndpointConnectionResources
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new ManagedEnvironmentProperties();
                }
                return Properties.PrivateEndpointConnections;
            }
        }

        // Preserve the property type from the last stable library.
        /// <summary> Gets the managed environment private endpoint connections. </summary>
        public BicepList<ContainerAppPrivateEndpointConnection> PrivateEndpointConnections
        {
            get
            {
                Initialize();
                return _privateEndpointConnections;
            }
        }

        /// <summary> Gets or sets whether peer traffic encryption is enabled. </summary>
        // The TypeSpec generator uses the improved PeerTrafficEncryptionIsEnabled name after https://github.com/Azure/azure-sdk-for-net/issues/60921.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use PeerTrafficEncryptionIsEnabled instead.")]
        public BicepValue<bool> IsEnabled
        {
            get => PeerTrafficEncryptionIsEnabled;
            set => PeerTrafficEncryptionIsEnabled = value;
        }

        /// <summary> Gets or sets whether mutual TLS authentication is enabled. </summary>
        // The TypeSpec generator uses the improved PeerAuthenticationIsMtlsEnabled name after https://github.com/Azure/azure-sdk-for-net/issues/60921.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use PeerAuthenticationIsMtlsEnabled instead.")]
        public BicepValue<bool> IsMtlsEnabled
        {
            get => PeerAuthenticationIsMtlsEnabled;
            set => PeerAuthenticationIsMtlsEnabled = value;
        }

        partial void DefineAdditionalProperties()
        {
            _privateEndpointConnections = DefineListProperty<ContainerAppPrivateEndpointConnection>(nameof(PrivateEndpointConnections), new string[] { "properties", "privateEndpointConnections" }, isOutput: true);
        }

        public static partial class ResourceVersions
        {
            // Preserve historical API versions that shipped from the reflection-based provisioning generator.
            /// <summary> API version "2022-03-01". </summary>
            public static readonly string V2022_03_01 = "2022-03-01";
            /// <summary> API version "2022-10-01". </summary>
            public static readonly string V2022_10_01 = "2022-10-01";
            /// <summary> API version "2023-05-01". </summary>
            public static readonly string V2023_05_01 = "2023-05-01";
            /// <summary> API version "2024-03-01". </summary>
            public static readonly string V2024_03_01 = "2024-03-01";
            /// <summary> API version "2025-01-01". </summary>
            public static readonly string V2025_01_01 = "2025-01-01";
            /// <summary> API version "2025-07-01". </summary>
            public static readonly string V2025_07_01 = "2025-07-01";
        }
    }
}
