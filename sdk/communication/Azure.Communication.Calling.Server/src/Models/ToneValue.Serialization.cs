// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Calling.Server
{
    internal static partial class ToneValueExtensions
    {
        public static ToneValue ToToneValue(this string value)
        {
            if (string.Equals(value, "tone0", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.Tone0;
            if (string.Equals(value, "tone1", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.Tone1;
            if (string.Equals(value, "tone2", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.Tone2;
            if (string.Equals(value, "tone3", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.Tone3;
            if (string.Equals(value, "tone4", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.Tone4;
            if (string.Equals(value, "tone5", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.Tone5;
            if (string.Equals(value, "tone6", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.Tone6;
            if (string.Equals(value, "tone7", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.Tone7;
            if (string.Equals(value, "tone8", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.Tone8;
            if (string.Equals(value, "tone9", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.Tone9;
            if (string.Equals(value, "star", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.Star;
            if (string.Equals(value, "pound", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.Pound;
            if (string.Equals(value, "a", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.A;
            if (string.Equals(value, "b", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.B;
            if (string.Equals(value, "c", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.C;
            if (string.Equals(value, "d", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.D;
            if (string.Equals(value, "flash", StringComparison.InvariantCultureIgnoreCase))
                return ToneValue.Flash;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ToneValue value.");
        }
    }
}
