// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

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

    // We're empty if unset or no literal values
    public override bool IsEmpty => base.IsEmpty || (_kind == BicepValueKind.Literal && _values.Count == 0);

    /// <summary>
    /// Creates a new BicepDictionary.
    /// </summary>
    public BicepDictionary() : this(self: null, values: null) { }

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
        _kind = BicepValueKind.Literal;
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
        base.Assign(source);
    }

    /// <summary>
    /// Convert a ProvisioningVariable or ProvisioningParameter to a BicepList.
    /// </summary>
    /// <param name="reference">The variable or parameter.</param>
    public static implicit operator BicepDictionary<T>(ProvisioningVariable reference) =>
        new(new BicepValueReference(reference, "{}"), BicepSyntax.Var(reference.BicepIdentifier)) { _isSecure = reference is ProvisioningParameter p && p.IsSecure };

    /// <summary>
    /// Gets or sets a value in a BicepDictionary.
    /// </summary>
    /// <param name="key">Key of the value.</param>
    /// <returns>The value.</returns>
    public BicepValue<T> this[string key]
    {
        get => _values[key];
        set => _values[key] = value;
    }

    public void Add(string key, BicepValue<T> value) => _values.Add(key, value);
    public void Add(KeyValuePair<string, BicepValue<T>> item) => _values.Add(item.Key, item.Value);

    // TODO: Decide whether it's important to "unlink" resources on removal
    public bool Remove(string key) => _values.Remove(key);
    public void Clear() => _values.Clear();

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

    private protected override BicepExpression CompileCore() => BicepTypeMapping.ToBicep(this, Format);
}
