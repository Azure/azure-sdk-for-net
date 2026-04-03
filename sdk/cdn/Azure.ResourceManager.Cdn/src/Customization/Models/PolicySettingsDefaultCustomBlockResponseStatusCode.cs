// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Backward compatibility: old API used spelled-out names instead of numeric prefixes
    public readonly partial struct PolicySettingsDefaultCustomBlockResponseStatusCode
    {
        [CodeGenMember("_200")]
        public static PolicySettingsDefaultCustomBlockResponseStatusCode TwoHundred { get; } = new PolicySettingsDefaultCustomBlockResponseStatusCode(_200Value);

        [CodeGenMember("_403")]
        public static PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredThree { get; } = new PolicySettingsDefaultCustomBlockResponseStatusCode(_403Value);

        [CodeGenMember("_405")]
        public static PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredFive { get; } = new PolicySettingsDefaultCustomBlockResponseStatusCode(_405Value);

        [CodeGenMember("_406")]
        public static PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredSix { get; } = new PolicySettingsDefaultCustomBlockResponseStatusCode(_406Value);

        [CodeGenMember("_429")]
        public static PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredTwentyNine { get; } = new PolicySettingsDefaultCustomBlockResponseStatusCode(_429Value);
    }
}
