// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Batch.Models
{
    // Batch API version 2026-10-01 removed TaskAuthenticationToken, so the generated converters no longer map it.
    // Preserve the original wire value in both directions for callers using older API versions such as 2025-06-01.
    internal static partial class BatchAuthenticationModeExtensions
    {
        public static string ToSerialString(this BatchAuthenticationMode value) => value switch
        {
            BatchAuthenticationMode.SharedKey => "SharedKey",
            BatchAuthenticationMode.Aad => "AAD",
            BatchAuthenticationMode.TaskAuthenticationToken => "TaskAuthenticationToken",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown BatchAuthenticationMode value.")
        };

        public static BatchAuthenticationMode ToBatchAuthenticationMode(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "SharedKey"))
            {
                return BatchAuthenticationMode.SharedKey;
            }
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AAD"))
            {
                return BatchAuthenticationMode.Aad;
            }
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "TaskAuthenticationToken"))
            {
                return BatchAuthenticationMode.TaskAuthenticationToken;
            }
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown BatchAuthenticationMode value.");
        }
    }
}
