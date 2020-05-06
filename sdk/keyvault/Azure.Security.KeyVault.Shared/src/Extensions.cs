﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Security.KeyVault
{
    internal static partial class Extensions
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> source) => source is null || source.Count == 0;
    }
}
