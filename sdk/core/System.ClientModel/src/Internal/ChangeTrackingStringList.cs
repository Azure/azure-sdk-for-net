// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.ClientModel.Internal;

internal class ChangeTrackingStringList : IList<string>
{
    private IList<string> _list;
    private bool _frozen = false;
    private bool _tracking = true;

    public ChangeTrackingStringList()
    {
        _list = [];
    }

    public ChangeTrackingStringList(IEnumerable<string> collection)
    {
        _list = new List<string>(collection);
    }

    public bool HasChanged { get; private set; }

    public void Freeze()
    {
        _frozen = true;
    }

    public void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Cannot change any client pipeline options after the client pipeline has been created.");
        }
    }

    #region IList implementation

    public string this[int index]
    {
        get => _list[index];
        set
        {
            AssertNotFrozen();
            _list[index] = value;

            HasChanged |= _tracking;
        }
    }

    public int Count => _list.Count;

    public bool IsReadOnly => _list.IsReadOnly;

    public void Add(string item)
    {
        AssertNotFrozen();
        _list.Add(item);

        HasChanged |= _tracking;
    }

    public void Clear()
    {
        AssertNotFrozen();
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
        AssertNotFrozen();
        _list.Insert(index, item);

        HasChanged |= _tracking;
    }

    public bool Remove(string item)
    {
        AssertNotFrozen();
        bool removed = _list.Remove(item);

        HasChanged |= _tracking && removed;

        return removed;
    }

    public void RemoveAt(int index)
    {
        AssertNotFrozen();
        _list.RemoveAt(index);

        HasChanged |= _tracking;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion
}
