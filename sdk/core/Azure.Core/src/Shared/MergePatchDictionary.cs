// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    //internal partial class MergePatchDictionary<T> //: IDictionary<string, T?>
    //{
    //    public static MergePatchDictionary<string> GetStringDictionary()
    //        => new(e => e.GetString(), (w, s) => w.WriteStringValue(s), default);

    //    private readonly MergePatchChanges _changes;
    //    private readonly Dictionary<string, int> _indexes;
    //    private readonly T?[] _values;

    //    private readonly Func<JsonElement, T?> _deserializeItem;
    //    private readonly Action<Utf8JsonWriter, T?> _serializeItem;
    //    private readonly Func<T?, bool>? _itemHasChanges;

    //    private bool _checkChanges;
    //    private bool _hasChanges;

    //    public MergePatchDictionary(
    //        Func<JsonElement, T?> deserializeItem,
    //        Action<Utf8JsonWriter, T?> serializeItem,
    //        Func<T?, bool>? hasChanges = default)
    //    {
    //        // TODO: How to size it?
    //        _changes = new(100);
    //        _indexes = new Dictionary<string, int>();
    //        _values = new T?[100];

    //        _deserializeItem = deserializeItem;
    //        _serializeItem = serializeItem;
    //        _itemHasChanges = hasChanges;
    //    }

    //    /// <summary>
    //    /// Deserialization constructor
    //    /// </summary>
    //    internal MergePatchDictionary(
    //        JsonElement element,
    //        Func<JsonElement, T?> deserializeItem,
    //        Action<Utf8JsonWriter, T?> serializeItem,
    //        Func<T?, bool>? hasChanges = default)
    //    {
    //        // TODO: How to size it?
    //        _changes = new(100);
    //        _indexes = new Dictionary<string, int>();
    //        _values = new T?[100];

    //        _deserializeItem = deserializeItem;
    //        _serializeItem = serializeItem;
    //        _itemHasChanges = hasChanges;

    //        // Deserialize the values from the JsonElement
    //        foreach (JsonProperty property in element.EnumerateObject())
    //        {
    //            Add(property.Name, deserializeItem(property.Value));
    //        }
    //    }

    //    public bool HasChanges => _hasChanges || ItemsChanged();

    //    private bool ItemsChanged()
    //    {
    //        if (!_checkChanges)
    //        {
    //            return false;
    //        }

    //        foreach (KeyValuePair<string, int> item in _indexes)
    //        {
    //            bool mightHaveChanged = _changes.HasChanged(item.Value);
    //            if (mightHaveChanged)
    //            {
    //                T? value = _values[item.Value];
    //                if (_itemHasChanges != null && _itemHasChanges(value))
    //                {
    //                    return true;
    //                }
    //            }
    //        }

    //        return false;
    //    }

    //    public T? this[string key]
    //    {
    //        get
    //        {
    //            // If the value is read and a reference value, it might get changed
    //            _checkChanges = _itemHasChanges != null;
    //            if (_itemHasChanges != null)
    //            {
    //                _changes.SetChanged(_indexes[key]);
    //            }
    //            return _values[_indexes[key]];
    //        }

    //        set
    //        {
    //            _hasChanges = true;
    //            if (_indexes.TryGetValue(key, out int index))
    //            {
    //                _changes.SetChanged(index);
    //                _values[index] = value;
    //            }
    //            else
    //            {
    //                Add(key, value);
    //            }
    //        }
    //    }

    //    ICollection<string> IDictionary<string, T?>.Keys => _indexes.Keys;

    //    //ICollection<T?> IDictionary<string, T?>.Values => _dictionary.Values;

    //    //int ICollection<KeyValuePair<string, T?>>.Count => _indexes.Count;

    //    //bool ICollection<KeyValuePair<string, T?>>.IsReadOnly => false;

    //    //public void Add(string key, T? value)
    //    //{
    //    //    int index = GetNextIndex();
    //    //    _indexes[key] = index;
    //    //    _values[index] = value;
    //    //    _hasChanges = true;
    //    //    _changes.SetChanged(index);
    //    //}

    //    //private int GetNextIndex()
    //    //{
    //    //    // This will handle Resize() as well.
    //    //    // See example here: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Collections/Generic/Dictionary.cs#L848
    //    //    throw new NotImplementedException();
    //    //}

    //    //void ICollection<KeyValuePair<string, T?>>.Add(KeyValuePair<string, T?> item)
    //    //{
    //    //    int index = GetNextIndex();
    //    //    _indexes[item.Key] = index;
    //    //    _values[index] = item.Value;
    //    //    _hasChanges = true;
    //    //    _changes.SetChanged(index);
    //    //}

    //    //void ICollection<KeyValuePair<string, T?>>.Clear()
    //    //{
    //    //    // TODO: this raises the question of how we track changes for deleted elements.
    //    //    // Solve it here.

    //    //    _hasChanges = true;
    //    //    foreach (int index in _indexes.Values)
    //    //    {
    //    //        _changes.SetChanged(index);
    //    //    }

    //    //    (_dictionary as ICollection<KeyValuePair<string, T?>>).Clear();
    //    //}

    //    //bool ICollection<KeyValuePair<string, T?>>.Contains(KeyValuePair<string, T?> item) =>
    //    //    (_dictionary as ICollection<KeyValuePair<string, T?>>).Contains(item);

    //    //bool IDictionary<string, T?>.ContainsKey(string key)
    //    //    => _dictionary.ContainsKey(key);

    //    //void ICollection<KeyValuePair<string, T?>>.CopyTo(KeyValuePair<string, T?>[] array, int arrayIndex)
    //    //    => (_dictionary as ICollection<KeyValuePair<string, T?>>).CopyTo(array, arrayIndex);

    //    //IEnumerator<KeyValuePair<string, T?>> IEnumerable<KeyValuePair<string, T?>>.GetEnumerator()
    //    //{
    //    //    // TODO: handle item changes
    //    //    return _dictionary.GetEnumerator();
    //    //}

    //    //IEnumerator IEnumerable.GetEnumerator()
    //    //{
    //    //    // TODO: handle item changes
    //    //    return (_dictionary as IEnumerable).GetEnumerator();
    //    //}

    //    //bool IDictionary<string, T?>.Remove(string key)
    //    //{
    //    //    _hasChanges = true;
    //    //    _changed[key] = true;
    //    //    return _dictionary.Remove(key);
    //    //}

    //    //bool ICollection<KeyValuePair<string, T?>>.Remove(KeyValuePair<string, T?> item)
    //    //{
    //    //    _hasChanges = true;
    //    //    _changed[item.Key] = true;
    //    //    return (_dictionary as ICollection<KeyValuePair<string, T?>>).Remove(item);
    //    //}

    //    //public bool TryGetValue(string key, out T? value)
    //    //{
    //    //    if (_indexes.TryGetValue(key, out int index))
    //    //    {
    //    //        _checkChanges = _itemHasChanges != null;
    //    //        _changed[key] = _itemHasChanges != null;
    //    //        return true;
    //    //    }

    //    //    return false;
    //    //}
    //}
}
