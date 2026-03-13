// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Structural fix: Provides missing additionalBinaryDataProperties0 field that the generated
// serialization code references but the generated model doesn't define.
// TODO: Generator bug - generated serialization references nonexistent field.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ListContainerItem
    {
        // Workaround for generator serialization bug: generated code references 'additionalBinaryDataProperties0'
        // as a local variable but never declares it. This static field provides a sink so the code compiles.
        // Unknown properties will not be preserved per-instance (minor runtime impact).
        [ThreadStatic]
        private static IDictionary<string, BinaryData> s_additionalBinaryDataProperties0;
        private static IDictionary<string, BinaryData> additionalBinaryDataProperties0
            => s_additionalBinaryDataProperties0 ??= new Dictionary<string, BinaryData>();
    }
}
