// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Azure.Provisioning.Primitives;

namespace Azure.Projects.Core;

public class FeatureCollection : IEnumerable<AzureProjectFeature>
{
    private AzureProjectFeature[] _items = new AzureProjectFeature[4];
    private int _count;

    internal Dictionary<Provisionable, (string RoleName, string RoleId)[]> RoleAnnotations =>
        _items.Take(_count)
        .Select(f => f.RequiredSystemRoles)
        .SelectMany(d => d)
        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

    internal FeatureCollection() { }

    public IEnumerable<T> FindAll<T>() where T : AzureProjectFeature
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i] is T item)
            {
                yield return item;
            }
        }
    }

    public void Add(AzureProjectFeature item)
    {
        if (_count == _items.Length)
        {
            Resize();
        }
        _items[_count++] = item;

        void Resize()
        {
            var newItems = new AzureProjectFeature[_items.Length * 2];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }
    }

    internal void Emit(ProjectInfrastructure infrastructure)
    {
        int index = 0;
        while (true)
        {
            if (index >= _count)
                break;
            AzureProjectFeature feature = _items[index++];
            feature.Emit(infrastructure);
        }
    }

    public IEnumerator<AzureProjectFeature> GetEnumerator()
    {
        for (int i=0; i < _count; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
