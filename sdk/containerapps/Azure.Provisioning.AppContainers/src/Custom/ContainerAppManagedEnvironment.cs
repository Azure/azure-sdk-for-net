// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.AppContainers
{
    public partial class ContainerAppManagedEnvironment
    {
        /// <summary> Gets or sets whether peer traffic encryption is enabled. </summary>
        // The TypeSpec generator uses the improved PeerTrafficEncryptionIsEnabled name after https://github.com/Azure/azure-sdk-for-net/issues/60921.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use PeerTrafficEncryptionIsEnabled instead.")]
        public BicepValue<bool> IsEnabled
        {
            get => PeerTrafficEncryptionIsEnabled;
            set => PeerTrafficEncryptionIsEnabled = value;
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
