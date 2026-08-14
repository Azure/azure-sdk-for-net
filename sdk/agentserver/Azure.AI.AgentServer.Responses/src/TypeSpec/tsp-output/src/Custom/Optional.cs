// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Custom overrides for Optional collection-defined checks that add null safety.
/// Placing these methods here prevents the TypeSpec emitter from generating them.
/// The generated serializers call IsCollectionDefined before iterating collections,
/// but null collections are not ChangeTrackingList/Dictionary instances, so the
/// generated check incorrectly returns true for null, causing NullReferenceException.
/// </summary>
internal static partial class Optional
{
    public static bool IsCollectionDefined<T>(IEnumerable<T> collection)
    {
        if (collection == null)
        {
            return false;
        }

        return !(collection is ChangeTrackingList<T> changeTrackingList && changeTrackingList.IsUndefined);
    }

    public static bool IsCollectionDefined<TKey, TValue>(IDictionary<TKey, TValue> collection)
    {
        if (collection == null)
        {
            return false;
        }

        return !(collection is ChangeTrackingDictionary<TKey, TValue> changeTrackingDictionary && changeTrackingDictionary.IsUndefined);
    }

    public static bool IsCollectionDefined<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> collection)
    {
        if (collection == null)
        {
            return false;
        }

        return !(collection is ChangeTrackingDictionary<TKey, TValue> changeTrackingDictionary && changeTrackingDictionary.IsUndefined);
    }
}
