// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

// TODO: See the comment on BicepValue about how this will be reshaped into
// more strongly typed models.

/// <summary>
/// Represents a value or expression.
/// </summary>
/// <typeparam name="T">The type of the value.</typeparam>
public class BicepValue<T> : BicepValue
{
    private T? _value;
    private Func<T?>? _valueFactory;
    /// <summary>
    /// Gets or sets the literal value.  You can also rely on implicit
    /// conversions most of the time.
    /// </summary>
    public T? Value => _valueFactory != null ? _valueFactory() : _value;
    private protected override object? GetLiteralValue() => Value;

    // Get the closest primitive to T
    private protected override BicepExpression GetBicepType() =>
        BicepSyntax.Types.Create<T>();

    /// <summary>
    /// Creates a new BicepValue.
    /// </summary>
    /// <param name="literal">The value.</param>
    public BicepValue(T literal) : this(self: null, literal) { }

    /// <summary>
    /// Creates a new BicepValue.
    /// </summary>
    /// <param name="expression">An expression that evaluates to the value.</param>
    public BicepValue(BicepExpression expression) : this(self: null, expression) { }

    /// <summary>
    /// Initialize a new instance without a literal value or expression (unset state).
    /// </summary>
    /// <param name="self"></param>
    internal BicepValue(BicepValueReference? self) : base(self)
    {
    }

    /// <summary>
    /// Initialize a new instance of a literal value, but the literal value will be lazily evaluated by the value factory.
    /// </summary>
    /// <param name="self"></param>
    /// <param name="valueFactory"></param>
    internal BicepValue(BicepValueReference? self, Func<T?> valueFactory) : base(self)
    {
        _kind = BicepValueKind.Literal;
        _valueFactory = valueFactory;
    }

    /// <summary>
    /// Initialize a new instance from a literal value.
    /// </summary>
    /// <param name="self"></param>
    /// <param name="literal"></param>
    private BicepValue(BicepValueReference? self, T literal) : base(self, literal!)
    {
        _value = literal;
    }

    /// <summary>
    /// Initialize a new instance from a bicep expression.
    /// </summary>
    /// <param name="self"></param>
    /// <param name="expression"></param>
    private BicepValue(BicepValueReference? self, BicepExpression expression) : base(self, expression)
    { }

    /// <summary>
    /// Clears a previously assigned literal or expression value.
    /// </summary>
    public void ClearValue()
    {
        _kind = BicepValueKind.Unset;
        _valueFactory = null;
        _value = default;
        _expression = null;
        _source = null;
    }

    // Move strongly typed literal values when assigning
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Assign(BicepValue<T> source) => Assign((BicepValue)source);
    internal override void Assign(IBicepValue source)
    {
        if (source is BicepValue<T> typed)
        {
            _value = typed.Value;
        }

        // Everything else is handled by the base Assign
        base.Assign(source);
    }

    // Convert literals, raw expressions, and vars/params/outputs
    public static implicit operator BicepValue<T>(T value)
    {
        if (value is IBicepValue e)
        {
            if (e.Kind == BicepValueKind.Expression)
            {
                return new BicepValue<T>(e.Self, e.Expression!) { _isSecure = e.IsSecure };
            }
            else if (e.Kind == BicepValueKind.Unset && e.Self is not null)
            {
                return new BicepValue<T>(e.Self, e.Self.GetReference()) { _isSecure = e.IsSecure };
            }
        }

        // If we're asking to convert BicepValue<Foo> to BicepValue<T> and Foo : T
        Type type = value?.GetType() ?? typeof(object);
        if (type.IsGenericType &&
            type.GetGenericTypeDefinition() == typeof(BicepValue<>) &&
            typeof(T).IsAssignableFrom(type.GetGenericArguments()[0]))
        {
            // We'll create a new BicepValue<T> but copy the Self reference so the
            // relationship is tracked.  This is likely to come up when we're assigning
            // something like BicepValue<string> to a property of type BicepValue<object>.
            IBicepValue bicep = (value as IBicepValue)!; // Cast will always succeed so !
            return new BicepValue<T>(bicep.Self, (T)bicep.LiteralValue!) { _isSecure = bicep.IsSecure };
        }

        // Otherwise just wrap the literal
        return new(value);
    }
    public static implicit operator BicepValue<T>(BicepExpression? expression) => new(expression ?? BicepSyntax.Null());
    public static implicit operator BicepValue<T>(ProvisioningVariable reference) =>
        new(new BicepValueReference(reference, "<value>"), BicepSyntax.Var(reference.BicepIdentifier)) { _isSecure = reference is ProvisioningParameter p && p.IsSecure };

    // Special case conversions to string for things like Uri, AzureLocation, etc.
    public static implicit operator BicepValue<string>(BicepValue<T> value) =>
        value._kind switch
        {
            BicepValueKind.Unset => new(value._self),
            BicepValueKind.Expression => new(value._self, value._expression!),
            BicepValueKind.Literal => new(value._self, BicepTypeMapping.ToLiteralString(value.Value!, value.Format)),
            _ => throw new InvalidOperationException($"Unknown {nameof(BicepValueKind)}!")
        };
}
