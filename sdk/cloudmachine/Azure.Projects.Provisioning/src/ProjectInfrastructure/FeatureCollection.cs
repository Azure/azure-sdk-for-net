// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Projects.Core;

// This is a special collection that can be added to while it's being enumerated.
public class FeatureCollection : IEnumerable<AzureProjectFeature>
{
    private AzureProjectFeature[] _features = new AzureProjectFeature[4];
    private int _count;

    internal FeatureCollection() { }

    public IEnumerable<T> FindAll<T>() where T : AzureProjectFeature
    {
        for (int i = 0; i < _count; i++)
        {
            if (_features[i] is T item)
            {
                yield return item;
            }
        }
    }

    public bool TryGet<T>(out T? feature) where T : AzureProjectFeature
    {
        for (int i = 0; i < _count; i++)
        {
            if (_features[i] is T typed)
            {
                feature = typed;
                return true;
            }
        }
        feature = default;
        return false;
    }

    public void Append(AzureProjectFeature feature)
    {
        if (_count == _features.Length)
        {
            Resize();
        }
        _features[_count++] = feature;

        void Resize()
        {
            var newItems = new AzureProjectFeature[_features.Length * 2];
            Array.Copy(_features, newItems, _features.Length);
            _features = newItems;
        }
    }

    public IEnumerator<AzureProjectFeature> GetEnumerator()
    {
        for (int i=0; i < _count; i++)
        {
            yield return _features[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
