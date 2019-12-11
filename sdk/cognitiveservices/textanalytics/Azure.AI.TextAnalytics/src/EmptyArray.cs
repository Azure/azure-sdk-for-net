// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.TextAnalytics
{
    internal class EmptyArray<T>
    {
        public static readonly T[] Instance = Array.Empty<T>();
    }
}
