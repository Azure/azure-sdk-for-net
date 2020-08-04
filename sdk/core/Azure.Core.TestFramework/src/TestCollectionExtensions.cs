// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core.TestFramework
{
    public static class TestCollectionExtensions
    {
        public static void InitializeFrom<T>(this ICollection<T> target, IEnumerable<T> source)
        {
            if (source == null)
            {
                return;
            }

            target.Clear();
            foreach (var s in source)
            {
                target.Add(s);
            }
        }
    }
}