// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.Template.Models
{
    internal static class LengthUnitExtensions
    {
        public static string ToSerialString(this LengthUnit value) => value switch
        {
            LengthUnit.Pixel => "pixel",
            LengthUnit.Inch => "inch",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown LengthUnit value.")
        };

        public static LengthUnit ToLengthUnit(this string value) => value switch
        {
            "pixel" => LengthUnit.Pixel,
            "inch" => LengthUnit.Inch,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown LengthUnit value.")
        };
    }
}
