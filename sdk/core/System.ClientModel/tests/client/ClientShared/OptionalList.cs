// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace ClientModel.Tests.ClientShared;

internal class OptionalList<T> : IList<T>, IReadOnlyList<T>
{
    private IList<T>? _innerList;

    public OptionalList()
    {
    }

    public OptionalList(OptionalProperty<IList<T>> optionalList) : this(optionalList.Value)
    {
    }

    public OptionalList(OptionalProperty<IReadOnlyList<T>> optionalList) : this(optionalList.Value)
    {
    }

    private OptionalList(IEnumerable<T> innerList)
    {
        if (innerList == null)
        {
            return;
        }

        _innerList = innerList.ToList();
    }

    private OptionalList(IList<T> innerList)
    {
        if (innerList == null)
        {
            return;
        }

        _innerList = innerList;
    }

    public bool IsUndefined => _innerList == null;

    public void Reset()
    {
        _innerList = null;
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (IsUndefined)
        {
            IEnumerator<T> EnumerateEmpty()
            {
                yield break;
            }

            return EnumerateEmpty();
        }
        return EnsureList().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        EnsureList().Add(item);
    }

    public void Clear()
    {
        EnsureList().Clear();
    }

    public bool Contains(T item)
    {
        if (IsUndefined)
        {
            return false;
        }

        return EnsureList().Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (IsUndefined)
        {
            return;
        }

        EnsureList().CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
        if (IsUndefined)
        {
            return false;
        }

        return EnsureList().Remove(item);
    }

    public int Count
    {
        get
        {
            if (IsUndefined)
            {
                return 0;
            }
            return EnsureList().Count;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            if (IsUndefined)
            {
                return false;
            }

            return EnsureList().IsReadOnly;
        }
    }

    public int IndexOf(T item)
    {
        if (IsUndefined)
        {
            return -1;
        }

        return EnsureList().IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        EnsureList().Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        if (IsUndefined)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        EnsureList().RemoveAt(index);
    }

    public T this[int index]
    {
        get
        {
            if (IsUndefined)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return EnsureList()[index];
        }
        set
        {
            if (IsUndefined)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            EnsureList()[index] = value;
        }
    }

    private IList<T> EnsureList()
    {
        return _innerList ??= new List<T>();
    }
}
