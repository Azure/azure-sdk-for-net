// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: the baseline SDK had members named Tls1_0 and Tls1_2.
// The TypeSpec generator strips underscores from clientName values, producing Tls10 and
// Tls12. These properties are aliases pointing to the generated members.

namespace Azure.ResourceManager.FrontDoor.Models
{
    public readonly partial struct FrontDoorRequiredMinimumTlsVersion
    {
        /// <summary> TLS 1.0 minimum version. </summary>
        public static FrontDoorRequiredMinimumTlsVersion Tls1_0 => _10;

        /// <summary> TLS 1.2 minimum version. </summary>
        public static FrontDoorRequiredMinimumTlsVersion Tls1_2 => _12;
    }
}
