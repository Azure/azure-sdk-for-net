// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Cryptography;

internal static class ContentRangeExtensions
{
    public static long? GetContentRangeLengthOrDefault(this string contentRange)
        => string.IsNullOrWhiteSpace(contentRange)
            ? default : ContentRange.Parse(contentRange).GetRangeLength();

    public static long GetRangeLength(this ContentRange contentRange)
        => contentRange.End.Value - contentRange.Start.Value + 1;
}
