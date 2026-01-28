// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Primitives;
using System;
using System.Collections.Generic;

namespace Azure.Generator.Management.Utilities
{
    /// <summary>
    /// Helper class for handling MatchConditions and RequestConditions types,
    /// as well as conditional request header parameters (If-Match, If-None-Match, etc.).
    /// </summary>
    internal static class MatchConditionsHelper
    {
        /// <summary>
        /// Set of header names that correspond to conditional request headers.
        /// These headers can be grouped into MatchConditions or RequestConditions types.
        /// </summary>
        public static readonly HashSet<string> ConditionalHeaders = new(StringComparer.OrdinalIgnoreCase)
        {
            "If-Match",
            "ifMatch",
            "If-None-Match",
            "ifNoneMatch",
            "If-Modified-Since",
            "ifModifiedSince",
            "If-Unmodified-Since",
            "ifUnmodifiedSince",
        };

        /// <summary>
        /// Checks if the given header name is a conditional request header.
        /// </summary>
        /// <param name="headerName">The header name to check.</param>
        /// <returns>True if the header is a conditional request header; otherwise, false.</returns>
        public static bool IsConditionalHeader(string? headerName)
        {
            return headerName != null && ConditionalHeaders.Contains(headerName);
        }

        /// <summary>
        /// Checks if the given type is a MatchConditions or RequestConditions type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>True if the type is MatchConditions or RequestConditions; otherwise, false.</returns>
        public static bool IsMatchConditionsType(CSharpType type)
        {
            var underlyingType = type.IsNullable ? type.WithNullable(false) : type;
            return underlyingType.Equals(typeof(MatchConditions)) || underlyingType.Equals(typeof(RequestConditions));
        }
    }
}
