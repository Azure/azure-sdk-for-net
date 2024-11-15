// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.CloudMachine;

namespace Azure.CloudMachine;

public class FeatureCollection
{
    private CloudMachineFeature[] _items = new CloudMachineFeature[4];
    private int _count;

    public bool TryFind<T>(out T? found) where T: CloudMachineFeature
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i] is T item)
            {
                found = item;
                return true;
            }
        }
        found = default;
        return false;
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

    internal void AddTo(CloudMachineInfrastructure infrastructure)
    {
        int index = 0;
        while (true)
        {
            if (index >= _count) break;
            CloudMachineFeature feature = _items[index++];
            feature.AddTo(infrastructure);
        }
    }
}
