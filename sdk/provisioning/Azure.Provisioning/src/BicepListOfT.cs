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

        // handle self in all the items
        for (int i = 0; i < _values.Count; i++)
        {
            SetSelfForItem(_values[i], i);
        }
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
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index must be non-negative.");
                }
                // if we are referencing an actual value
                if (index < _values.Count)
                {
                    return _values[index];
                }
                // the index is out of range, we put a value factory as the literal value of this bicep value
                // this would blow up when we try to compile it later, but it would be fine if we convert it to an expression
                return new BicepValue<T>(GetItemSelf(index), () => _values[index].Value);
            }
        }
        set
        {
            if (_kind == BicepValueKind.Expression || _isOutput)
            {
                throw new InvalidOperationException($"Cannot assign to {_self?.PropertyName}");
            }
            _values[index] = value;
            // update the _self pointing the new item
            SetSelfForItem(value, index);
        }
    }

    private BicepValueReference? GetItemSelf(int index) =>
        _self is not null
            ? new BicepListValueReference(_self.Construct, _self.PropertyName, _self.BicepPath?.ToArray(), index)
            : null;

    private void SetSelfForItem(BicepValue<T> item, int index)
    {
        var itemSelf = GetItemSelf(index);
        item.SetSelf(itemSelf);
    }

    private void RemoveSelfForItem(BicepValue<T> item)
    {
        item.SetSelf(null);
    }

    public void Insert(int index, BicepValue<T> item)
    {
        if (_kind == BicepValueKind.Expression || _isOutput)
        {
            throw new InvalidOperationException($"Cannot Insert to {_self?.PropertyName}, the list is an expression or output only");
        }
        _values.Insert(index, item);
        // update the _self for the inserted item and all items after it
        for (int i = index; i < _values.Count; i++)
        {
            SetSelfForItem(_values[i], i);
        }
    }

    public void Add(BicepValue<T> item)
    {
        if (_kind == BicepValueKind.Expression || _isOutput)
        {
            throw new InvalidOperationException($"Cannot Add to {_self?.PropertyName}, the list is an expression or output only");
        }
        _values.Add(item);
        // update the _self pointing the new item
        SetSelfForItem(item, _values.Count - 1);
    }

    public void RemoveAt(int index)
    {
        if (_kind == BicepValueKind.Expression || _isOutput)
        {
            throw new InvalidOperationException($"Cannot Remove from {_self?.PropertyName}, the list is an expression or output only");
        }
        var removed = _values[index];
        _values.RemoveAt(index);
        // maintain the self reference for the removed item and remaining items
        RemoveSelfForItem(removed);
        for (int i = index; i < _values.Count; i++)
        {
            SetSelfForItem(_values[i], i);
        }
    }

    public void Clear()
    {
        if (_kind == BicepValueKind.Expression || _isOutput)
        {
            throw new InvalidOperationException($"Cannot Clear {_self?.PropertyName}, the list is an expression or output only");
        }
        for (int i = 0; i < _values.Count; i++)
        {
            RemoveSelfForItem(_values[i]);
        }
        _values.Clear();
    }

    public bool Remove(BicepValue<T> item)
    {
        if (_kind == BicepValueKind.Expression || _isOutput)
        {
            throw new InvalidOperationException($"Cannot Remove from {_self?.PropertyName}, the list is an expression or output only");
        }
        int index = _values.IndexOf(item);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }
        return false;
    }

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
