// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Extension methods for <see cref="IEnumerable{T}"/> of <see cref="Provisionable"/>
/// that delegate to <see cref="ProvisionableCollection.OfType{T}"/> when the
/// underlying sequence is a <see cref="ProvisionableCollection"/>, enabling
/// automatic upgrading of deserialized resource wrappers.
/// </summary>
public static class ProvisionableEnumerableExtensions
{
    /// <summary>
    /// Returns all elements of the specified type. When the source is a
    /// <see cref="ProvisionableCollection"/> and <typeparamref name="T"/>
    /// derives from <see cref="ProvisionableResource"/>, deserialized resource
    /// wrappers with a matching ARM type are automatically upgraded to real
    /// typed instances in-place.
    /// </summary>
    /// <typeparam name="T">The type to filter for.</typeparam>
    /// <param name="source">The sequence to filter.</param>
    public static IEnumerable<T> OfType<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(
        this IEnumerable<Provisionable> source) where T : Provisionable
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source is ProvisionableCollection collection)
        {
            return collection.OfType<T>();
        }

        return System.Linq.Enumerable.OfType<T>(source);
    }
}
