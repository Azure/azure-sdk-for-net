// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// The baseline SDK exposed members named Tls1_0 and Tls1_2.
// We cannot rename via `@@clientName(MinimumTLSVersion.`1.0`, "Tls1_0", "csharp")`
// at the spec side because the C# generator strips underscores from
// clientName values, producing `Tls10`/`Tls12` instead of the desired
// `Tls1_0`/`Tls1_2`. Using [CodeGenMember] here replaces the generated
// `_10`/`_12` members so only the friendly baseline names are public.

using Azure.ResourceManager.FrontDoor;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.FrontDoor.Models
{
    public readonly partial struct FrontDoorRequiredMinimumTlsVersion
    {
        /// <summary> TLS 1.0 minimum version. </summary>
        [CodeGenMember("_10")]
        public static FrontDoorRequiredMinimumTlsVersion Tls1_0 { get; } = new FrontDoorRequiredMinimumTlsVersion("1.0");

        /// <summary> TLS 1.2 minimum version. </summary>
        [CodeGenMember("_12")]
        public static FrontDoorRequiredMinimumTlsVersion Tls1_2 { get; } = new FrontDoorRequiredMinimumTlsVersion("1.2");
    }
}
