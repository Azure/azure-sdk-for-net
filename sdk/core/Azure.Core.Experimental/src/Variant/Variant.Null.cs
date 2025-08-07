// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure
{
    public readonly partial struct Variant
    {
        /// <summary>
        /// Null Variant.
        /// </summary>
        public static readonly Variant Null = new((object?)null);

        /// <summary>
        /// Indicates whether the Variant is null or has a value.
        /// </summary>
        /// <returns><code>true</code> if the Variant is <code>null</code>; <code>false</code> otherwise.</returns>
        public bool IsNull => Type == null;
    }
}
