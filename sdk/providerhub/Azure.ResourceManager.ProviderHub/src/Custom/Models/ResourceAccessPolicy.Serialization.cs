// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// ResourceAccessPolicy is now generated as an extensible enum (a readonly struct), but the generated
// ResourceProviderManagement serialization still calls the ToSerialString/ToResourceAccessPolicy helpers that are
// only emitted for closed enums. Supply them here so the generated serialization compiles; for an extensible enum
// the round trip is a plain string pass-through, which also preserves values the client does not know about.

#nullable disable

namespace Azure.ResourceManager.ProviderHub.Models
{
    internal static partial class ResourceAccessPolicyExtensions
    {
        /// <param name="value"> The value to serialize. </param>
        public static string ToSerialString(this ResourceAccessPolicy value) => value.ToString();

        /// <param name="value"> The value to deserialize. </param>
        public static ResourceAccessPolicy ToResourceAccessPolicy(this string value) => new ResourceAccessPolicy(value);
    }
}
