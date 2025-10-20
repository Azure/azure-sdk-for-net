// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Net;
using Azure.Core;
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
    public T? Value
    {
        get => _valueFactory is not null ? _valueFactory() : _value;
        private set
        {
            if (_valueFactory is not null)
            {
                throw new InvalidOperationException($"Cannot assign value for {_self?.GetReference(false)} because its value may not be valid");
            }
            _value = value;
        }
    }

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
            Value = typed.Value;
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
            return CompileLiteralValue(Value, Format);
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

    private static BicepExpression CompileLiteralValue(object? value, string? format)
    {
        return value switch
        {
            null => BicepSyntax.Null(),
            IBicepValue v => v.Compile(),
            bool b => BicepSyntax.Value(b),
            int i => BicepSyntax.Value(i),
            long l => BicepSyntax.Value(l),
            float f => BicepSyntax.Value(f),
            double d => BicepSyntax.Value(d),
            string s => BicepSyntax.Value(s),
            Uri u => BicepSyntax.Value(BicepTypeMapping.ToLiteralString(u, format)),
            DateTimeOffset d => BicepSyntax.Value(BicepTypeMapping.ToLiteralString(d, format)),
            TimeSpan t => BicepSyntax.Value(BicepTypeMapping.ToLiteralString(t, format)),
            Guid g => BicepSyntax.Value(BicepTypeMapping.ToLiteralString(g, format)),
            IPAddress a => BicepSyntax.Value(BicepTypeMapping.ToLiteralString(a, format)),
            ETag e => BicepSyntax.Value(BicepTypeMapping.ToLiteralString(e, format)),
            ResourceIdentifier i => BicepSyntax.Value(BicepTypeMapping.ToLiteralString(i, format)),
            AzureLocation azureLocation => BicepSyntax.Value(BicepTypeMapping.ToLiteralString(azureLocation, format)),
            ResourceType rt => BicepSyntax.Value(BicepTypeMapping.ToLiteralString(rt, format)),
            Enum e => BicepSyntax.Value(BicepTypeMapping.ToLiteralString(e, format)),
            // Other extensible enums like AzureLocation (AzureLocation has been handled above)
            ValueType ee => BicepSyntax.Value(BicepTypeMapping.ToLiteralString(ee, format)),
            _ => throw new InvalidOperationException($"Cannot convert {value} to a Bicep expression.")
        };
    }
}
