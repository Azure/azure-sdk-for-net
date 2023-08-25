// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Security.KeyVault
{
    internal static partial class Extensions
    {
        public static T[] Clone<T>(this T[] source)
        {
            if (source is null)
            {
                return null;
            }

            T[] clone = new T[source.Length];
            Array.Copy(source, clone, source.Length);

            return clone;
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> source) => source is null || source.Count == 0;
    }
}
