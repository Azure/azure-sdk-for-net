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
    /// <summary>
    /// Gets or sets the literal value.  You can also rely on implicit
    /// conversions most of the time.
    /// </summary>
    public T? Value
    {
        get
        {
            // If someone is referencing an output of a named resource, rather
            // than just return null, we'll return a reference expression
            if (IsOutput &&
                Kind == BicepValueKind.Unset &&
                typeof(ProvisioningConstruct).IsAssignableFrom(typeof(T)) &&
                Self?.Construct is NamedProvisioningConstruct)
            {
                // TODO: This is obviously a hack but we need to decide if we'd
                // rather have a separate type for outputs (kind of like we
                // do with ResourceReference<T>) or whether we want to merge
                // this concept into BicepValue<T>.
                T val = Activator.CreateInstance<T>();
                (val as ProvisioningConstruct)!.OverrideWithExpression(Self.GetReference());
                return val;
            }

            return _value;
        }
        private protected set => _value = value;
    }
    private T? _value;
    internal override object? GetLiteralValue() => Value;

    // Get the closest primitive to T
    private protected override Expression GetBicepType() =>
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
    public BicepValue(Expression expression) : this(self: null, expression) { }

    private protected BicepValue(BicepValueReference? self) : base(self) { }
    private protected BicepValue(BicepValueReference? self, T literal) : base(self, (object)literal!) { Value = literal; }
    private protected BicepValue(BicepValueReference? self, Expression expression) : base(self, expression) { }

    // Move strongly typed literal values when assigning
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Assign(BicepValue<T> source) => Assign((BicepValue)source);
    internal override void Assign(BicepValue source)
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
        if (value is BicepValue e)
        {
            if (e.Kind == BicepValueKind.Expression)
            {
                return new BicepValue<T>(e.Self, e.Expression!) { IsSecure = e.IsSecure };
            }
            else if (e.Kind == BicepValueKind.Unset && e.Self is not null)
            {
                return new BicepValue<T>(e.Self, e.Self.GetReference()) { IsSecure = e.IsSecure };
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
            BicepValue bicep = (value as BicepValue)!; // Cast will always succeed so !
            return new BicepValue<T>(bicep.Self, (T)bicep.GetLiteralValue()!) { IsSecure = bicep.IsSecure };
        }

        // Otherwise just wrap the literal
        return new(value);
    }
    public static implicit operator BicepValue<T>(Expression expression) => new(expression);
    public static implicit operator BicepValue<T>(BicepVariable reference) =>
        new(new BicepValueReference(reference, "<value>"), BicepSyntax.Var(reference.ResourceName)) { IsSecure = reference is BicepParameter p && p.IsSecure };

    // Special case conversions to string for things like Uri, AzureLocation, etc.
    public static implicit operator BicepValue<string>(BicepValue<T> value) =>
        value.Kind switch
        {
            BicepValueKind.Unset => new(value.Self),
            BicepValueKind.Expression => new(value.Self, value.Expression!),
            BicepValueKind.Literal => new(value.Self, BicepTypeMapping.ToLiteralString(value.Value!)),
            _ => throw new InvalidOperationException($"Unknown {nameof(BicepValueKind)}!")
        };

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static BicepValue<T> DefineProperty(
        ProvisioningConstruct construct,
        string propertyName,
        string[]? bicepPath,
        bool isOutput = false,
        bool isRequired = false,
        bool isSecure = false,
        BicepValue<T>? defaultValue = null)
    {
        BicepValue<T> val =
            new(new BicepValueReference(construct, propertyName, bicepPath))
            {
                IsOutput = isOutput,
                IsRequired = isRequired,
                IsSecure = isSecure
            };
        if (defaultValue is not null) { val.Assign(defaultValue); }
        construct.ProvisioningProperties[propertyName] = val;
        return val;
    }
}
