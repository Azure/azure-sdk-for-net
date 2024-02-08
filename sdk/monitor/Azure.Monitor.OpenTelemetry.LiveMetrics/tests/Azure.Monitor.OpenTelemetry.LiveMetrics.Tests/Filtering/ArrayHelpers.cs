// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering.Tests
{
    using System;

    internal static class ArrayHelpers
    {
        public static void ForEach<T>(T[] array, Action<T> action)
        {
            foreach (T item in array)
            {
                action(item);
            }
        }
    }
}
