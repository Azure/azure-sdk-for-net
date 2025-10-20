// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Utilities;

namespace Azure.Provisioning;

/// <summary>
/// Represents a dictionary with string keys and bicep values.
/// </summary>
/// <typeparam name="T">The type of element represented by the values.</typeparam>
public class BicepDictionary<T> :
    BicepValue, IDictionary<string, BicepValue<T>>,
    IDictionary<string, IBicepValue>,
    IReadOnlyDictionary<string, BicepValue<T>>
{
    // Literal values
    private IDictionary<string, BicepValue<T>> _values;
    private protected override object? GetLiteralValue() => _values;

    /// <summary>
    /// Creates a new BicepDictionary.
    /// </summary>
    public BicepDictionary() : this(self: null, values: new Dictionary<string, BicepValue<T>>()) { }

    /// <summary>
    /// Creates a new BicepDictionary with literal values.
    /// </summary>
    public BicepDictionary(IDictionary<string, BicepValue<T>>? values) : this(self: null, values) { }

    private protected BicepDictionary(BicepValueReference? self, BicepExpression expression)
        : base(self, expression)
        => _values = new Dictionary<string, BicepValue<T>>();

    internal BicepDictionary(BicepValueReference? self, IDictionary<string, BicepValue<T>>? values = null)
        : base(self)
    {
        _kind = values != null ? BicepValueKind.Literal : BicepValueKind.Unset;
        // Shallow clone their values
        _values = values != null ? new Dictionary<string, BicepValue<T>>(values) : [];
    }

    // Move literal elements when assigning values to a dictionary
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Assign(BicepDictionary<T> source) => Assign((BicepValue)source);
    internal override void Assign(IBicepValue source)
    {
        if (source is BicepDictionary<T> typed)
        {
            _values = typed._values;
        }

        // Everything else is handled by the base Assign
        base.Assign(source);

        // handle self in all the items
        foreach (var kv in _values)
        {
            SetSelfForItem(kv.Value, kv.Key);
        }
    }

    /// <summary>
    /// Convert a ProvisioningVariable or ProvisioningParameter to a BicepList.
    /// </summary>
    /// <param name="reference">The variable or parameter.</param>
    public static implicit operator BicepDictionary<T>(ProvisioningVariable reference) =>
        new(new BicepValueReference(reference, "{}"), BicepSyntax.Var(reference.BicepIdentifier)) { _isSecure = reference is ProvisioningParameter p && p.IsSecure };

    private BicepValueReference? GetItemSelf(string key) =>
        _self is not null
            ? new BicepDictionaryValueReference(_self.Construct, _self.PropertyName, _self.BicepPath?.ToArray(), key)
            : null;

    private void SetSelfForItem(BicepValue<T> item, string key)
    {
        var itemSelf = GetItemSelf(key);
        item.SetSelf(itemSelf);
    }

    private void RemoveSelfForItem(BicepValue<T> item)
    {
        item.SetSelf(null);
    }

    /// <summary>
    /// Gets or sets a value in a BicepDictionary.
    /// </summary>
    /// <param name="key">Key of the value.</param>
    /// <returns>The value.</returns>
    public BicepValue<T> this[string key]
    {
        get
        {
            if (_values.TryGetValue(key, out var value))
            {
                return value;
            }
            // The key does not exist; we put a value factory as the literal value of this Bicep value.
            // If the value factory is evaluated before the key is added, it will throw a KeyNotFoundException.
            // This is valid for generating a reference expression, but will fail if the value is accessed before being added.
            return new BicepValue<T>(GetItemSelf(key), () => _values[key].Value);
        }
        set
        {
            if (_kind == BicepValueKind.Expression || _isOutput)
            {
                throw new InvalidOperationException($"Cannot assign to {_self?.PropertyName}, the dictionary is an expression or output only");
            }
            if (_kind == BicepValueKind.Unset)
            {
                _kind = BicepValueKind.Literal;
            }
            _values[key] = value;
            // update the _self pointing the new item
            SetSelfForItem(value, key);
        }
    }

    public void Add(string key, BicepValue<T> value)
    {
        if (_kind == BicepValueKind.Expression || _isOutput)
        {
            throw new InvalidOperationException($"Cannot Add to {_self?.PropertyName}, the dictionary is an expression or output only");
        }
        if (_kind == BicepValueKind.Unset)
        {
            _kind = BicepValueKind.Literal;
        }
        _values.Add(key, value);
        // update the _self pointing the new item
        SetSelfForItem(value, key);
    }

    public void Add(KeyValuePair<string, BicepValue<T>> item) => Add(item.Key, item.Value);

    public bool Remove(string key)
    {
        if (_kind == BicepValueKind.Expression || _isOutput)
        {
            throw new InvalidOperationException($"Cannot Remove from {_self?.PropertyName}, the dictionary is an expression or output only");
        }
        if (_kind == BicepValueKind.Unset)
        {
            _kind = BicepValueKind.Literal;
        }
        if (_values.TryGetValue(key, out var removedItem))
        {
            // maintain the self reference for the removed item if the item exists
            RemoveSelfForItem(removedItem);
        }
        return _values.Remove(key);
    }

    public void Clear()
    {
        if (_kind == BicepValueKind.Expression || _isOutput)
        {
            throw new InvalidOperationException($"Cannot Clear {_self?.PropertyName}, the dictionary is an expression or output only");
        }
        if (_kind == BicepValueKind.Unset)
        {
            _kind = BicepValueKind.Literal;
        }
        foreach (var kv in _values)
        {
            RemoveSelfForItem(kv.Value);
        }
        _values.Clear();
    }

    public ICollection<string> Keys => _values.Keys;
    public ICollection<BicepValue<T>> Values => _values.Values;
    public int Count => _values.Count;
    public bool IsReadOnly => false;

    public bool ContainsKey(string key) => _values.ContainsKey(key);
#if NET6_0_OR_GREATER
    public bool TryGetValue(string key, [MaybeNullWhen(false)] out BicepValue<T> value) => _values.TryGetValue(key, out value);
#else
    public bool TryGetValue(string key, out BicepValue<T> value) => _values.TryGetValue(key, out value);
#endif
    public bool Contains(KeyValuePair<string, BicepValue<T>> item) => _values.Contains(item);
    public void CopyTo(KeyValuePair<string, BicepValue<T>>[] array, int arrayIndex) => _values.CopyTo(array, arrayIndex);
    public bool Remove(KeyValuePair<string, BicepValue<T>> item) => Remove(item.Key);
    public IEnumerator<KeyValuePair<string, BicepValue<T>>> GetEnumerator() => _values.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();
    IEnumerable<string> IReadOnlyDictionary<string, BicepValue<T>>.Keys => _values.Keys;
    ICollection<IBicepValue> IDictionary<string, IBicepValue>.Values => _values.Values.OfType<IBicepValue>().ToList();
    IEnumerable<BicepValue<T>> IReadOnlyDictionary<string, BicepValue<T>>.Values => _values.Values;

    IBicepValue IDictionary<string, IBicepValue>.this[string key]
    {
        get => this[key];
        set => this[key] = (BicepValue<T>)value;
    }
    void IDictionary<string, IBicepValue>.Add(string key, IBicepValue value) => Add(key, (BicepValue<T>)value);
    bool IDictionary<string, IBicepValue>.TryGetValue(string key, out IBicepValue value)
    {
        if (TryGetValue(key, out BicepValue<T>? val))
        {
            value = val;
            return true;
        }
        value = new BicepValue<object>(BicepSyntax.Null());
        return false;
    }
    void ICollection<KeyValuePair<string, IBicepValue>>.Add(KeyValuePair<string, IBicepValue> item) => Add(item.Key, (BicepValue<T>)item.Value);
    bool ICollection<KeyValuePair<string, IBicepValue>>.Contains(KeyValuePair<string, IBicepValue> item) => ContainsKey(item.Key);
    void ICollection<KeyValuePair<string, IBicepValue>>.CopyTo(KeyValuePair<string, IBicepValue>[] array, int arrayIndex) =>
        _values.Select(p => new KeyValuePair<string, IBicepValue>(p.Key, p.Value)).ToList().CopyTo(array, arrayIndex);
    bool ICollection<KeyValuePair<string, IBicepValue>>.Remove(KeyValuePair<string, IBicepValue> item) => Remove(item.Key);
    IEnumerator<KeyValuePair<string, IBicepValue>> IEnumerable<KeyValuePair<string, IBicepValue>>.GetEnumerator() =>
        _values.Select(p => new KeyValuePair<string, IBicepValue>(p.Key, p.Value)).GetEnumerator();

    private protected override BicepExpression CompileCore()
    {
        if (_kind == BicepValueKind.Expression)
        {
            return _expression!;
        }
        if (_source is not null)
        {
            return _source.GetReference();
        }
        if (_kind == BicepValueKind.Literal)
        {
            Dictionary<string, BicepExpression> compiledValues = [];
            foreach (var kv in _values)
            {
                compiledValues[kv.Key] = kv.Value.Compile();
            }
            return BicepSyntax.Object(compiledValues);
        }
        if (_self is not null)
        {
            return _self.GetReference();
        }
        if (_kind is BicepValueKind.Unset)
        {
            return BicepSyntax.Null();
        }

        throw new InvalidOperationException($"Cannot convert {this} to a Bicep expression.");
    }
}
