// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Utilities;

namespace Azure.Provisioning;

/// <summary>
/// Represents a list of Bicep values.
/// </summary>
/// <typeparam name="T">The type of element represented by the values.</typeparam>
public class BicepList<T> :
    BicepValue,
    IList<BicepValue<T>>,
    IReadOnlyList<BicepValue<T>>
{
    // Literal values
    private IList<BicepValue<T>> _values;
    private protected override object? GetLiteralValue() => _values;

    // We're empty if unset or no literal values
    public override bool IsEmpty =>
        base.IsEmpty || (_kind == BicepValueKind.Literal && _values.Count == 0);

    /// <summary>
    /// Creates a new BicepList.
    /// </summary>
    public BicepList() : this(self: null, values: null) { }

    /// <summary>
    /// Creates a new BicepList with literal values.
    /// </summary>
    public BicepList(IList<BicepValue<T>>? values) : this(self: null, values) { }

    private BicepList(BicepExpression expression) : base(self: null, expression) { _values = []; }
    private protected BicepList(BicepValueReference? self, BicepExpression expression) : base(self, expression) { _values = []; }
    internal BicepList(BicepValueReference? self, IList<BicepValue<T>>? values = null)
        : base(self)
    {
        _kind = BicepValueKind.Literal;
        // Shallow clone their list
        _values = values != null ? [.. values] : [];
    }

    // Move literal elements when assigning values to a list
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Assign(BicepList<T> source) => Assign((BicepValue)source);
    internal override void Assign(IBicepValue source)
    {
        if (source is BicepList<T> typed)
        {
            _values = typed._values;
        }

        // Everything else is handled by the base Assign
        base.Assign(source);
    }

    /// <summary>
    /// Convert a ProvisioningVariable or ProvisioningParameter to a BicepList.
    /// </summary>
    /// <param name="reference">The variable or parameter.</param>
    public static implicit operator BicepList<T>(ProvisioningVariable reference) =>
        new(
            new BicepValueReference(reference, "[]"),
            BicepSyntax.Var(reference.BicepIdentifier))
        {
            _isSecure = reference is ProvisioningParameter p && p.IsSecure
        };

    /// <summary>
    /// Gets or sets a value at a given index.
    /// </summary>
    /// <param name="index">Index of the value.</param>
    /// <returns>The value at the index.</returns>
    public BicepValue<T> this[int index]
    {
        get
        {
            if (_kind == BicepValueKind.Expression)
            {
                // If we're being overridden by an expression, then turn any
                // reads into expressions as well, but of type T so people
                // can reference their members.
                return _referenceFactory!(BicepSyntax.Index(_expression!, BicepSyntax.Value(index)));
            }
            else
            {
                return _values[index];
            }
        }
        set
        {
            if (_kind == BicepValueKind.Expression || _isOutput)
            {
                throw new InvalidOperationException($"Cannot assign to {_self?.PropertyName}");
            }
            _values[index] = value;
        }
    }

    public void Insert(int index, BicepValue<T> item) => _values.Insert(index, item);
    public void Add(BicepValue<T> item)
    {
        _values.Add(item);
        // update the _self pointing the new item
        if (_self is not null)
        {
            int index = _values.Count - 1;
            var itemSelf = new BicepListValueReference(_self.Construct, _self.PropertyName, _self.BicepPath?.ToArray(), index);
            // assign this into the item - and recurse if its value is also a IBicepValue
            item.SetSelf(itemSelf);
        }
    }

    // TODO: Decide whether it's important to "unlink" resources on removal
    public void RemoveAt(int index) => _values.RemoveAt(index);
    public void Clear() => _values.Clear();
    public bool Remove(BicepValue<T> item) => _values.Remove(item);

    public int Count => _values.Count;
    public bool IsReadOnly => _values.IsReadOnly;
    public int IndexOf(BicepValue<T> item) => _values.IndexOf(item);
    public bool Contains(BicepValue<T> item) => _values.Contains(item);
    public void CopyTo(BicepValue<T>[] array, int arrayIndex) => _values.CopyTo(array, arrayIndex);
    public IEnumerator<BicepValue<T>> GetEnumerator() => _values.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_values).GetEnumerator();

    /// <summary>
    /// Creates a new BicepList resource from a Bicep expression that evaluates
    /// to a BicepList.
    /// </summary>
    /// <param name="referenceFactory">
    /// Factory used to construct new references to models.
    /// </param>
    /// <param name="expression">
    /// A Bicep expression that evaluates to a BicepList.
    /// </param>
    /// <returns>A BicepList.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static BicepList<T> FromExpression(Func<BicepExpression, T> referenceFactory, BicepExpression expression) =>
        new(expression) { _referenceFactory = referenceFactory };
    private Func<BicepExpression, T>? _referenceFactory = null;
}
