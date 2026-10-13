// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.SignalR;

// Preserve the shipped resource name for the generated SignalRSharedPrivateLinkResource type.
/// <summary> Describes a Shared Private Link Resource. </summary>
[CodeGenType("SignalRSharedPrivateLinkResource")]
public partial class SignalRSharedPrivateLink
{
    public static partial class ResourceVersions
    {
        /// <summary> API version "2018-10-01". </summary>
        public static readonly string V2018_10_01 = "2018-10-01";
        /// <summary> API version "2020-05-01". </summary>
        public static readonly string V2020_05_01 = "2020-05-01";
        /// <summary> API version "2021-10-01". </summary>
        public static readonly string V2021_10_01 = "2021-10-01";
        /// <summary> API version "2022-02-01". </summary>
        public static readonly string V2022_02_01 = "2022-02-01";
        /// <summary> API version "2023-02-01". </summary>
        public static readonly string V2023_02_01 = "2023-02-01";
        /// <summary> API version "2024-03-01". </summary>
        public static readonly string V2024_03_01 = "2024-03-01";
    }
}
