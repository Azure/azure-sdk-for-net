// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

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
                throw NotSupported(name, added, current);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SupportsProperty<T>(IModelValidator model, T? value, string name, ServiceVersion added, ServiceVersion current)
            where T : struct
        {
            if (value.HasValue && current < added)
            {
                throw NotSupported($"{model.GetType().Name}.{name}", added, current);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SupportsProperty<T>(IModelValidator model, T value, string name, ServiceVersion added, ServiceVersion current)
            where T : class
        {
            if (value is not null && current < added)
            {
                throw NotSupported($"{model.GetType().Name}.{name}", added, current);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NotSupportedException NotSupported(string name, ServiceVersion added, ServiceVersion current) => new($"{name} is not available in API version {GetVersionString(current)}. Use service API version {GetVersionString(added)} or newer.");
    }
}
