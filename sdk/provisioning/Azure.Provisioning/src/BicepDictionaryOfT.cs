// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

// TODO: Dictionaries are less commonly used in Azure APIs so I haven't
// implemented all the more experimental parts of BicepList here yet while we
// iterate on the design.

/// <summary>
/// Represents a dictionary with string keys and bicep values.
/// </summary>
/// <typeparam name="T">The type of element represented by the values.</typeparam>
public class BicepDictionary<T> : BicepValue, IDictionary<string, BicepValue<T>>, IDictionary<string, BicepValue>
{
    // Literal values
    private IDictionary<string, BicepValue<T>> _values;
    internal override object? GetLiteralValue() => _values;

    // We're empty if unset or no literal values
    internal override bool IsEmpty => base.IsEmpty || (Kind == BicepValueKind.Literal && _values.Count == 0);

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

    private BicepDictionary(BicepValueReference? self, IDictionary<string, BicepValue<T>>? values = null)
        : base(self)
    {
        Kind = BicepValueKind.Literal;
        _values = values != null ? new Dictionary<string, BicepValue<T>>(values) : [];
        // Shallow clone their values
    }

    // Move literal elements when assigning values to a dictionary
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Assign(BicepDictionary<T> source) => Assign((BicepValue)source);
    internal override void Assign(BicepValue source)
    {
        if (source is BicepDictionary<T> typed)
        {
            // TODO: Decide if we'd rather shallow copy or steal their reference.
            _values = typed._values;
        }

        // Everything else is handled by the base Assign
        base.Assign(source);
    }

    /// <summary>
    /// Convert a ProvisioningVariable or ProvisioningParameter to a BicepList.
    /// </summary>
    /// <param name="reference">The variable or parameter.</param>
    public static implicit operator BicepDictionary<T>(ProvisioningVariable reference) =>
        new(new BicepValueReference(reference, "<value>"), BicepSyntax.Var(reference.BicepIdentifier)) { IsSecure = reference is ProvisioningParameter p && p.IsSecure };

    // TODO: Make it possible to correctly reference these values (especially
    // across module boundaries)?  Currently we only allow pulling values into
    // collections.
    private BicepValue<T> WrapValue(string key, BicepValue<T> value) => value;

    /// <summary>
    /// Gets or sets a value in a BicepDictionary.
    /// </summary>
    /// <param name="key">Key of the value.</param>
    /// <returns>The value.</returns>
    public BicepValue<T> this[string key]
    {
        // TODO: Decide if we want to support expression overrides (though
        // we'd also neeed a FromExpression + factory)
        get => _values[key];
        set => _values[key] = WrapValue(key, value);
    }

    public void Add(string key, BicepValue<T> value) => _values.Add(key, WrapValue(key, value));
    public void Add(KeyValuePair<string, BicepValue<T>> item) => _values.Add(item.Key, WrapValue(item.Key, item.Value));

    // TODO: Decide whether it's important to "unlink" resources on removal
    public bool Remove(string key) => _values.Remove(key);
    public void Clear() => _values.Clear();

    public ICollection<string> Keys => _values.Keys;
    public ICollection<BicepValue<T>> Values => _values.Values;
    public int Count => _values.Count;
    public bool IsReadOnly => false;

    public bool ContainsKey(string key) => _values.ContainsKey(key);
    public bool TryGetValue(string key, /*[MaybeNullWhen(false)]*/ out BicepValue<T> value) => _values.TryGetValue(key, out value);
    public bool Contains(KeyValuePair<string, BicepValue<T>> item) => _values.Contains(item);
    public void CopyTo(KeyValuePair<string, BicepValue<T>>[] array, int arrayIndex) => _values.CopyTo(array, arrayIndex);
    public bool Remove(KeyValuePair<string, BicepValue<T>> item) => Remove(item.Key);
    public IEnumerator<KeyValuePair<string, BicepValue<T>>> GetEnumerator() => _values.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();

    ICollection<BicepValue> IDictionary<string, BicepValue>.Values => _values.Values.OfType<BicepValue>().ToList();
    BicepValue IDictionary<string, BicepValue>.this[string key]
    {
        get => this[key];
        set => this[key] = (BicepValue<T>)value;
    }
    void IDictionary<string, BicepValue>.Add(string key, BicepValue value) => Add(key, (BicepValue<T>)value);
    bool IDictionary<string, BicepValue>.TryGetValue(string key, out BicepValue value)
    {
        if (TryGetValue(key, out BicepValue<T> val))
        {
            value = val;
            return true;
        }
        value = new BicepValue<object>(BicepSyntax.Null());
        return false;
    }
    void ICollection<KeyValuePair<string, BicepValue>>.Add(KeyValuePair<string, BicepValue> item) => Add(item.Key, (BicepValue<T>)item.Value);
    bool ICollection<KeyValuePair<string, BicepValue>>.Contains(KeyValuePair<string, BicepValue> item) => ContainsKey(item.Key);
    void ICollection<KeyValuePair<string, BicepValue>>.CopyTo(KeyValuePair<string, BicepValue>[] array, int arrayIndex) =>
        _values.Select(p => new KeyValuePair<string, BicepValue>(p.Key, p.Value)).ToList().CopyTo(array, arrayIndex);
    bool ICollection<KeyValuePair<string, BicepValue>>.Remove(KeyValuePair<string, BicepValue> item) => Remove(item.Key);
    IEnumerator<KeyValuePair<string, BicepValue>> IEnumerable<KeyValuePair<string, BicepValue>>.GetEnumerator() =>
        _values.Select(p => new KeyValuePair<string, BicepValue>(p.Key, p.Value)).GetEnumerator();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static BicepDictionary<T> DefineProperty(
        ProvisioningConstruct construct,
        string propertyName,
        string[]? bicepPath,
        bool isOutput = false,
        bool isRequired = false)
    {
        BicepDictionary<T> values =
            new(new BicepValueReference(construct, propertyName, bicepPath))
            {
                IsOutput = isOutput,
                IsRequired = isRequired
            };
        construct.ProvisioningProperties[propertyName] = values;
        return values;
    }
}
