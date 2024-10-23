// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace System.ClientModel.Internal;

internal class TrackingList<T> : List<T>, IList<T>
{
    public TrackingList(IEnumerable<T> collection) : base(collection)
    {
    }

    public bool HasChanged { get; private set; }

    public new T this[int index]
    {
        get => base[index];
        set
        {
            if (!EqualityComparer<T>.Default.Equals(base[index], value))
            {
                HasChanged = true;
            }
            base[index] = value;
        }
    }

    public new void Add(T item)
    {
        base.Add(item);
        HasChanged = true;
    }

    public new void Clear()
    {
        if (Count > 0)
        {
            HasChanged = true;
        }
        base.Clear();
    }

    public new bool Remove(T item)
    {
        if (base.Remove(item))
        {
            HasChanged = true;
            return true;
        }
        return false;
    }

    public new void RemoveAt(int index)
    {
        if (index >= 0 && index < Count)
        {
            HasChanged = true;
        }
        base.RemoveAt(index);
    }
}
