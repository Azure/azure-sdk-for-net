// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// A collection of <see cref="Provisionable"/> resources that supports
/// on-demand upgrading of deserialized resource wrappers to typed resources.
/// </summary>
internal class ProvisionableCollection : IEnumerable<Provisionable>
{
    private readonly List<Provisionable> _items = [];
    internal Infrastructure? Owner { get; set; }

    internal int Count => _items.Count;
    internal Provisionable this[int index]
    {
        get => _items[index];
        set => _items[index] = value;
    }

    internal void Add(Provisionable item) => _items.Add(item);
    internal bool Remove(Provisionable item) => _items.Remove(item);

    /// <summary>
    /// Returns all elements of the specified type. When <typeparamref name="T"/>
    /// derives from <see cref="ProvisionableResource"/>, any deserialized
    /// resource wrappers with a matching ARM type are automatically upgraded
    /// to real typed instances in-place. Subsequent calls (including via LINQ
    /// <c>OfType&lt;T&gt;</c>) will return the upgraded instances.
    /// </summary>
    /// <typeparam name="T">The type to filter for.</typeparam>
    public IEnumerable<T> OfType<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>() where T : Provisionable
    {
        if (!typeof(ProvisionableResource).IsAssignableFrom(typeof(T)))
        {
            return _items.OfType<T>();
        }

        return OfTypeWithUpgrade<T>();
    }

    private IEnumerable<T> OfTypeWithUpgrade<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>() where T : Provisionable
    {
        // Discover the ARM type by creating a probe via the public (id, version) ctor
        string? targetArmType = null;
        try
        {
            T probe = (T)Activator.CreateInstance(typeof(T), "__probe__", (string?)null)!;
            targetArmType = (probe as ProvisionableResource)?.ResourceType.ToString();
        }
        catch
        {
            // If ctor not found, fall back to standard OfType
        }

        if (targetArmType == null)
        {
            foreach (var item in _items.OfType<T>()) yield return item;
            yield break;
        }

        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i] is T existing)
            {
                yield return existing;
            }
            else if (_items[i] is DeserializedResource wrapper
                && wrapper.ArmType == targetArmType)
            {
                T typed = (T)Activator.CreateInstance(typeof(T), wrapper.BicepIdentifier, wrapper.ApiVersion)!;
                Infrastructure.HydrateResource(typed as ProvisionableResource, wrapper);
                if (typed is ProvisionableConstruct construct)
                {
                    construct.ParentInfrastructure = Owner;
                }
                _items[i] = typed;
                yield return typed;
            }
        }
    }

    /// <inheritdoc/>
    public IEnumerator<Provisionable> GetEnumerator() => _items.GetEnumerator();

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
