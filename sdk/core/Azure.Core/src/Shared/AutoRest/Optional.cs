// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core
{
    internal static class Optional
    {
        public static bool IsDefined<T>(IEnumerable<T> collection)
        {
            return !(collection is ChangeTrackingList<T> changeTrackingList && changeTrackingList.IsUndefined);
        }

        public static bool IsDefined<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> collection)
        {
            return !(collection is ChangeTrackingDictionary<TKey, TValue> changeTrackingList && changeTrackingList.IsUndefined);
        }

        public static bool IsDefined<TKey, TValue>(IDictionary<TKey, TValue> collection)
        {
            return !(collection is ChangeTrackingDictionary<TKey, TValue> changeTrackingList && changeTrackingList.IsUndefined);
        }

        public static bool IsDefined<T>(T? value) where T: struct
        {
            return value.HasValue;
        }
        public static bool IsDefined(object value)
        {
            return value != null;
        }
        public static bool IsDefined(string value)
        {
            return value != null;
        }
    }

    internal readonly partial struct Optional<T>
    {
        public Optional(T value) : this()
        {
            Value = value;
            HasValue = true;
        }

        public T Value { get; }
        public bool HasValue { get; }

        public static implicit operator Optional<T>(T value) => new Optional<T>(value);
        public static implicit operator T(Optional<T> optional) => optional.Value;
    }
}
