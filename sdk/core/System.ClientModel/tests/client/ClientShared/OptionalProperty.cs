// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace ClientModel.Tests.ClientShared;

internal static class OptionalProperty
{
    public static bool IsCollectionDefined<T>(IEnumerable<T> collection)
    {
        return !(collection is OptionalList<T> changeTrackingList && changeTrackingList.IsUndefined);
    }

    public static bool IsCollectionDefined<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> collection)
        where TKey : notnull
    {
        return !(collection is OptionalDictionary<TKey, TValue> changeTrackingList && changeTrackingList.IsUndefined);
    }

    public static bool IsCollectionDefined<TKey, TValue>(IDictionary<TKey, TValue>? collection)
        where TKey : notnull
    {
        if (collection is null)
            return false;

        return !(collection is OptionalDictionary<TKey, TValue> changeTrackingList && changeTrackingList.IsUndefined);
    }

    public static bool IsDefined<T>(T? value) where T : struct
    {
        return value.HasValue;
    }
    public static bool IsDefined(object value)
    {
        return value != null;
    }
    public static bool IsDefined(string? value)
    {
        return value != null;
    }

    public static bool IsDefined(JsonElement value)
    {
        return value.ValueKind != JsonValueKind.Undefined;
    }

    public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(OptionalProperty<IReadOnlyDictionary<TKey, TValue>> optional)
        where TKey : notnull
    {
        if (optional.HasValue)
        {
            return optional.Value!;
        }
        return new OptionalDictionary<TKey, TValue>(optional);
    }

    public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(OptionalProperty<IDictionary<TKey, TValue>> optional)
        where TKey : notnull
    {
        if (optional.HasValue)
        {
            return optional.Value!;
        }
        return new OptionalDictionary<TKey, TValue>(optional);
    }

    public static IReadOnlyList<T> ToList<T>(OptionalProperty<IReadOnlyList<T>> optional)
    {
        if (optional.HasValue)
        {
            return optional.Value!;
        }
        return new OptionalList<T>(optional);
    }

    public static IList<T> ToList<T>(OptionalProperty<IList<T>> optional)
    {
        if (optional.HasValue)
        {
            return optional.Value!;
        }
        return new OptionalList<T>(optional);
    }

    public static T? ToNullable<T>(OptionalProperty<T> optional) where T : struct
    {
        if (optional.HasValue)
        {
            return optional.Value;
        }
        return default;
    }

    public static T? ToNullable<T>(OptionalProperty<T?> optional) where T : struct
    {
        return optional.Value;
    }
}

#if !SOURCE_GENERATOR
public readonly struct OptionalProperty<T>
{
    public OptionalProperty(T? value) : this()
    {
        Value = value;
        HasValue = value is not null;
    }

    public T? Value { get; }
    public bool HasValue { get; }

    public static implicit operator OptionalProperty<T>(T? value) => new OptionalProperty<T>(value);
    public static implicit operator T?(OptionalProperty<T> optional) => optional.Value;
}
#endif
