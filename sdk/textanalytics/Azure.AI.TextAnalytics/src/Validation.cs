// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using static Azure.AI.TextAnalytics.TextAnalyticsClientOptions;

namespace Azure.AI.TextAnalytics
{
    internal static class Validation
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SupportsOperation(string name, ServiceVersion added, ServiceVersion current)
        {
            if (current < added)
            {
                throw NotSupported(name, added);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SupportsProperty<T>(T? value, string name, ServiceVersion added, ServiceVersion current)
            where T : struct
        {
            if (value.HasValue && current < added)
            {
                throw NotSupported(name, added);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SupportsProperty<T>(T value, string name, ServiceVersion added, ServiceVersion current)
            where T : class
        {
            if (value is not null && current < added)
            {
                throw NotSupported(name, added);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NotSupportedException NotSupported(string name, ServiceVersion added) => new($"{name} is only available for API version {GetVersionString(added)} and newer.");
    }
}
