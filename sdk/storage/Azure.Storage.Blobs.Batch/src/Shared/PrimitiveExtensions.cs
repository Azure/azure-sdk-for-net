// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copied from https://github.com/aspnet/Extensions/tree/master/src/Primitives/src/Extensions.cs

using System;
using System.Security.Cryptography;
using System.Text;

namespace Azure.Core.Http.Multipart
{
    internal static class PrimitiveExtensions
    {
        /// <summary>
        /// Add the given <see cref="StringSegment"/> to the <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="StringBuilder"/> to add to.</param>
        /// <param name="segment">The <see cref="StringSegment"/> to add.</param>
        /// <returns>The original <see cref="StringBuilder"/>.</returns>
        public static StringBuilder Append(this StringBuilder builder, StringSegment segment)
        {
            return builder.Append(segment.Buffer, segment.Offset, segment.Length);
        }

#if !NET6_0_OR_GREATER
        public static StringBuilder Append(this StringBuilder builder, ReadOnlySpan<char> span)
        {
            // Quick and dirty hack to work around missing extension
            return builder.Append(span.ToString());
        }
#endif
    }
}
