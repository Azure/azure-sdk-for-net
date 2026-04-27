// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis.Models
{
    // n1 review-comment workaround:
    // The baseline DLL exposed `[WirePath("AdditionalProperties")]` on this property because the
    // legacy OpenAPI declared an explicit JSON field literally named "AdditionalProperties".
    // The new TypeSpec models the same shape via `...Record<unknown>;` (additional-properties
    // spread), which the C# emitter materializes as the `_additionalBinaryDataProperties` bag.
    // Re-attaching `[WirePath]` here is purely for ApiCompat parity (so the baseline file can
    // stay empty) - the runtime serializer no longer emits a discrete `"AdditionalProperties"`
    // JSON field anyway.
    //
    // Applying [CodeGenMember("AdditionalProperties")] also exposes a generator bug in the
    // deserializer (https://github.com/Azure/azure-sdk-for-net/issues/58691); we work around it
    // by [CodeGenSuppress] + re-implementing DeserializeRedisCommonConfiguration in
    // Customization\Models\RedisCommonConfiguration.Serialization.cs.
    // TODO: remove this customization once the generator fix lands.
    public partial class RedisCommonConfiguration
    {
        /// <summary> Gets the AdditionalProperties. </summary>
        [CodeGenMember("AdditionalProperties")]
        [WirePath("AdditionalProperties")]
        public IDictionary<string, BinaryData> AdditionalProperties => _additionalBinaryDataProperties;
    }
}
