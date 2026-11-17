// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel.Primitives;

// Registration list exposed by options types. It becomes read-only when its owner freezes and
// notifies the owner of changes so derived lookup structures can be rebuilt.
internal sealed class ModelProxyCollection : IList<ModelProxy>
{
    private readonly List<ModelProxy> _items;
    private readonly string _frozenMessage;
    private readonly Action? _changed;
    private bool _frozen;

    internal ModelProxyCollection(string frozenMessage, Action? changed = null, IEnumerable<ModelProxy>? items = null, bool frozen = false)
    {
        _items = items is null ? [] : new List<ModelProxy>(items);
        _frozenMessage = frozenMessage;
        _changed = changed;
        _frozen = frozen;
    }

    internal void Freeze() => _frozen = true;

    public ModelProxy this[int index]
    {
        get => _items[index];
        set
        {
            AssertNotFrozen();
            Argument.AssertNotNull(value, nameof(value));
            _items[index] = value;
            _changed?.Invoke();
        }
    }

    public int Count => _items.Count;

    public bool IsReadOnly => _frozen;

    public void Add(ModelProxy item)
    {
        AssertNotFrozen();
        Argument.AssertNotNull(item, nameof(item));
        _items.Add(item);
        _changed?.Invoke();
    }

    public void Clear()
    {
        AssertNotFrozen();
        _items.Clear();
        _changed?.Invoke();
    }

    public bool Contains(ModelProxy item) => _items.Contains(item);

    public void CopyTo(ModelProxy[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

    public IEnumerator<ModelProxy> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int IndexOf(ModelProxy item) => _items.IndexOf(item);

    public void Insert(int index, ModelProxy item)
    {
        AssertNotFrozen();
        Argument.AssertNotNull(item, nameof(item));
        _items.Insert(index, item);
        _changed?.Invoke();
    }

    public bool Remove(ModelProxy item)
    {
        AssertNotFrozen();
        bool removed = _items.Remove(item);
        if (removed)
        {
            _changed?.Invoke();
        }
        return removed;
    }

    public void RemoveAt(int index)
    {
        AssertNotFrozen();
        _items.RemoveAt(index);
        _changed?.Invoke();
    }

    private void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException(_frozenMessage);
        }
    }
}
