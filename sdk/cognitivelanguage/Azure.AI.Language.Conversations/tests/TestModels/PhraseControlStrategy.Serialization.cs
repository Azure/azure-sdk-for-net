// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.Language.Conversations
{
    internal static partial class PhraseControlStrategyExtensions
    {
        public static string ToSerialString(this PhraseControlStrategy value) => value switch
        {
            PhraseControlStrategy.Encourage => "encourage",
            PhraseControlStrategy.Discourage => "discourage",
            PhraseControlStrategy.Disallow => "disallow",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PhraseControlStrategy value.")
        };

        public static PhraseControlStrategy ToPhraseControlStrategy(this string value)
        {
            if (string.Equals(value, "encourage", StringComparison.InvariantCultureIgnoreCase)) return PhraseControlStrategy.Encourage;
            if (string.Equals(value, "discourage", StringComparison.InvariantCultureIgnoreCase)) return PhraseControlStrategy.Discourage;
            if (string.Equals(value, "disallow", StringComparison.InvariantCultureIgnoreCase)) return PhraseControlStrategy.Disallow;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PhraseControlStrategy value.");
        }
    }
}
