// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Utilities;

namespace Azure.Provisioning;

/// <summary>
/// Represents the value of a property that could be a literal .NET value, a
/// Bicep expression, or it could be unset.
/// </summary>
public abstract class BicepValue : IBicepValue
{
    /// <inheritdoc />
    BicepValueKind IBicepValue.Kind => _kind;
    private protected BicepValueKind _kind = BicepValueKind.Unset;

    /// <inheritdoc />
    BicepExpression? IBicepValue.Expression
    {
        get => _kind == BicepValueKind.Expression ? _expression : null;
        set
        {
            _kind = BicepValueKind.Expression;
            _expression = value;
        }
    }
    private protected BicepExpression? _expression;

    /// <inheritdoc />
    object? IBicepValue.LiteralValue => GetLiteralValue();
    private protected abstract object? GetLiteralValue();

    /// <inheritdoc />
    BicepValueReference? IBicepValue.Self { get => _self; set => _self = value; }
    private protected BicepValueReference? _self;

    /// <inheritdoc />
    BicepValueReference? IBicepValue.Source => _source;
    private protected BicepValueReference? _source;

    /// <inheritdoc />
    bool IBicepValue.IsOutput => _isOutput;
    internal bool _isOutput;

    /// <inheritdoc />
    bool IBicepValue.IsRequired => _isRequired;
    internal bool _isRequired;

    /// <inheritdoc />
    bool IBicepValue.IsSecure => _isSecure;
    internal bool _isSecure;

    // Optional format defining how values should be serialized
    internal string? Format { get; set; } = null;

    // Indicate whether this value is empty or should be included in output
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual bool IsEmpty => _kind == BicepValueKind.Unset;

    // Naive Bicep type of the value.  We don't support complex object types so
    // this is mostly to help map primitives.
    private protected virtual BicepExpression GetBicepType() => BicepSyntax.Types.Object;

    // TODO: Clean these up when pulling richer objects out of BicepValue<T>
    private protected BicepValue(BicepValueReference? self)
    {
        _kind = BicepValueKind.Unset;
        _self = self;
    }
    private protected BicepValue(BicepValueReference? self, /* unused but forces literal */ object literal)
        : this(self)
    {
        _kind = BicepValueKind.Literal;
    }
    private protected BicepValue(BicepValueReference? self, BicepExpression expression)
        : this(self)
    {
        _kind = BicepValueKind.Expression;
        _expression = expression;
    }

    /// <inheritdoc />
    void IBicepValue.SetReadOnly() => _isOutput = true;

    /// <inheritdoc />
    public override string ToString() => Compile().ToString();

    /// <inheritdoc />
    public BicepExpression Compile() => CompileCore();

    private protected virtual BicepExpression CompileCore()
        => BicepTypeMapping.ToBicep(this, Format);

    /// <inheritdoc />
    void IBicepValue.Assign(IBicepValue source) => Assign(source);

    // Assign a value to this property.
    internal virtual void Assign(IBicepValue source)
    {
        // TODO: Do we want to add a more explicit notion of readonly
        // (especially for expr ref resources)?
        if (_isOutput) { throw new InvalidOperationException($"Cannot assign to output value {_self?.PropertyName}"); }

        // Track the source so we can correctly link references across modules
        _source = source?.Self;

        // Copy over the common values (but rely on derived classes for other values)
        _kind = source?.Kind ?? BicepValueKind.Unset;
        _expression = source?.Expression;
        _isSecure = source?.IsSecure ?? false;

        // If we're being assigned an Unset value that references a specific
        // resource, we'll consider this an expression referencing that property
        // (i.e., this is like referencing the unset Id property of a resource
        // you created moments ago).
        if (_kind == BicepValueKind.Unset && _source is not null)
        {
            _kind = BicepValueKind.Expression;
            _expression = _source.GetReference();
        }
    }

    /// <summary>
    /// Gets a bicep expression corresponding to this instance.
    /// </summary>
    /// <param name="value"></param>
    public static explicit operator BicepExpression?(BicepValue value) =>
        value._kind == BicepValueKind.Expression ?
            value._expression :
            value._self?.GetReference();
}
