// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Extension methods for <see cref="ContentSource"/> arrays.
    /// </summary>
    public static class ContentSourceExtensions
    {
        /// <summary>
        /// Reconstructs the wire-format source string by joining each element's
        /// <see cref="ContentSource.RawValue"/> with semicolons.
        /// </summary>
        /// <param name="sources"> The content source array. </param>
        /// <returns> A semicolon-delimited string of raw source values. </returns>
        public static string ToRawString(this ContentSource[] sources)
        {
            Argument.AssertNotNull(sources, nameof(sources));
            return string.Join(";", (object[])sources);
        }
    }
}
