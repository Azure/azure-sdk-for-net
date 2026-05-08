// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.KeyVault
{
    public partial class ManagedHsmPrivateEndpointConnection
    {
        // The generator only emits API versions that are declared in the current TypeSpec spec.
        // The KeyVault TypeSpec spec only contains the latest version (2025-05-01), but this
        // provisioning library previously shipped with a full history of API versions so that
        // customers can target specific deployments. We add the older versions here to preserve
        // backward compatibility and enable customers to provision with older API versions.
        //
        // ManagedHsmPrivateEndpointConnection shares the same version history as ManagedHsm
        // because it is a child resource of Microsoft.KeyVault/managedHSMs.
        public static partial class ResourceVersions
        {
            /// <summary> API version "2024-11-01". </summary>
            public static readonly string V2024_11_01 = "2024-11-01";
            /// <summary> API version "2023-07-01". </summary>
            public static readonly string V2023_07_01 = "2023-07-01";
            /// <summary> API version "2023-02-01". </summary>
            public static readonly string V2023_02_01 = "2023-02-01";
            /// <summary> API version "2022-11-01". </summary>
            public static readonly string V2022_11_01 = "2022-11-01";
            /// <summary> API version "2022-07-01". </summary>
            public static readonly string V2022_07_01 = "2022-07-01";
            /// <summary> API version "2021-10-01". </summary>
            public static readonly string V2021_10_01 = "2021-10-01";

            /// <summary> API version "2023-08-01-PREVIEW". </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly string V2023_08_01_PREVIEW = "2023-08-01-PREVIEW";
        }
    }
}
