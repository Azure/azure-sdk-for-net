// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

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
        public static bool IsNull(Variant value) => value.Type == null;
    }
}
