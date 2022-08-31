// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.MixedReality.Models
{
    internal static partial class SerialExtensions
    {
        public static string ToSerialString(this Serial value) => value switch
        {
            Serial.Primary => "1",
            Serial.Secondary => "2",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Serial value.")
        };
    }
}
