// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.Core
{
    internal static class Optional
    {
        public static bool IsCollectionDefined<T>(IEnumerable<T> collection)
        {
            return !(collection is ChangeTrackingList<T> changeTrackingList && changeTrackingList.IsUndefined);
        }

        public static bool IsCollectionDefined<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> collection)
        {
            return !(collection is ChangeTrackingDictionary<TKey, TValue> changeTrackingList && changeTrackingList.IsUndefined);
        }

        public static bool IsCollectionDefined<TKey, TValue>(IDictionary<TKey, TValue> collection)
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

        public static bool IsDefined(JsonElement value)
        {
            return value.ValueKind != JsonValueKind.Undefined;
        }

        public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(Optional<IReadOnlyDictionary<TKey, TValue>> optional)
        {
            if (optional.HasValue)
            {
                return optional.Value;
            }
            return new ChangeTrackingDictionary<TKey, TValue>(optional);
        }

        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(Optional<IDictionary<TKey, TValue>> optional)
        {
            if (optional.HasValue)
            {
                return optional.Value;
            }
            return new ChangeTrackingDictionary<TKey, TValue>(optional);
        }
        public static IReadOnlyList<T> ToList<T>(Optional<IReadOnlyList<T>> optional)
        {
            if (optional.HasValue)
            {
                return optional.Value;
            }
            return new ChangeTrackingList<T>(optional);
        }

        public static IList<T> ToList<T>(Optional<IList<T>> optional)
        {
            if (optional.HasValue)
            {
                return optional.Value;
            }
            return new ChangeTrackingList<T>(optional);
        }

        public static T? ToNullable<T>(Optional<T> optional) where T: struct
        {
            if (optional.HasValue)
            {
                return optional.Value;
            }
            return default;
        }

        public static T? ToNullable<T>(Optional<T?> optional) where T: struct
        {
            return optional.Value;
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
