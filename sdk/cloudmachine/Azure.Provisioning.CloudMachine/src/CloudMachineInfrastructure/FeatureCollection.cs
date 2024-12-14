// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Azure.Provisioning.Primitives;

namespace Azure.CloudMachine.Core;

public class FeatureCollection : IEnumerable<CloudMachineFeature>
{
    private CloudMachineFeature[] _items = new CloudMachineFeature[4];
    private int _count;

    internal Dictionary<Provisionable, (string RoleName, string RoleId)[]> RoleAnnotations =>
        _items.Take(_count)
        .Select(f => f.RequiredSystemRoles)
        .SelectMany(d => d)
        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

    internal FeatureCollection() { }

    public IEnumerable<T> FindAll<T>() where T : CloudMachineFeature
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i] is T item)
            {
                yield return item;
            }
        }
    }

    public void Add(CloudMachineFeature item)
    {
        if (_count == _items.Length)
        {
            Resize();
        }
        _items[_count++] = item;

        void Resize()
        {
            var newItems = new CloudMachineFeature[_items.Length * 2];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }
    }

    internal void Emit(CloudMachineInfrastructure infrastructure)
    {
        int index = 0;
        while (true)
        {
            if (index >= _count)
                break;
            CloudMachineFeature feature = _items[index++];
            feature.Emit(infrastructure);
        }
    }

    public IEnumerator<CloudMachineFeature> GetEnumerator()
    {
        for (int i=0; i < _count; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
