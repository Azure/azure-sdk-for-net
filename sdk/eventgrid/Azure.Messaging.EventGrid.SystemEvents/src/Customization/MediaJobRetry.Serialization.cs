// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    internal static partial class MediaJobRetryExtensions
    {
        public static string ToSerialString(this MediaJobRetry value) => value switch
        {
            MediaJobRetry.DoNotRetry => "DoNotRetry",
            MediaJobRetry.MayRetry => "MayRetry",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MediaJobRetry value.")
        };

        public static MediaJobRetry ToMediaJobRetry(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "DoNotRetry")) return MediaJobRetry.DoNotRetry;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "MayRetry")) return MediaJobRetry.MayRetry;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MediaJobRetry value.");
        }
    }
}
