// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MobileNetwork.Models
{
    /// <summary>
    /// The platform type where packet core is deployed. The contents of this enum can change.
    /// Serialized Name: PlatformType
    /// </summary>
    public readonly partial struct MobileNetworkPlatformType : IEquatable<MobileNetworkPlatformType>
    {
        /// <summary>
        /// If this option is chosen, you must set one of "azureStackEdgeDevice", "connectedCluster" or "customLocation". If multiple are set, they must be consistent with each other.
        /// Serialized Name: PlatformType.AKS-HCI
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MobileNetworkPlatformType AKSHCI { get => AksHci; }
        /// <summary>
        /// If this option is chosen, you must set one of "azureStackHciCluster", "connectedCluster" or "customLocation". If multiple are set, they must be consistent with each other.
        /// Serialized Name: PlatformType.3P-AZURE-STACK-HCI
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MobileNetworkPlatformType ThreePAzureStackHCI { get => ThreePAzureStackHci; }
    }
}
