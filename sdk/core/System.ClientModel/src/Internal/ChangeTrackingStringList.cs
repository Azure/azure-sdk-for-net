// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel.Internal;

internal class ChangeTrackingStringList : IList<string>
{
    private readonly IList<string> _list;

    private bool _tracking;

    public ChangeTrackingStringList()
    {
        _list = new List<string>();

        _tracking = false;
    }

    public void StartTracking() => _tracking = true;
    public void StopTracking() => _tracking = false;

    public bool HasChanged { get; private set; }

    #region IList implementation

    public string this[int index]
    {
        get => _list[index];
        set
        {
            _list[index] = value;

            HasChanged |= _tracking;
        }
    }

    public int Count => _list.Count;

    public bool IsReadOnly => _list.IsReadOnly;

    public void Add(string item)
    {
        _list.Add(item);

        HasChanged |= _tracking;
    }

    public void Clear()
    {
        int count = _list.Count;

        _list.Clear();

        HasChanged |= _tracking && (count != 0);
    }

    public bool Contains(string item) => _list.Contains(item);

    public void CopyTo(string[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

    public IEnumerator<string> GetEnumerator() => _list.GetEnumerator();

    public int IndexOf(string item) => _list.IndexOf(item);

    public void Insert(int index, string item)
    {
        _list.Insert(index, item);

        HasChanged |= _tracking;
    }

    public bool Remove(string item)
    {
        bool removed = _list.Remove(item);

        HasChanged |= _tracking && removed;

        return removed;
    }

    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);

        HasChanged |= _tracking;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion
}
