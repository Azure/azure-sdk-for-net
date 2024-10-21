// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

// TODO: Currently everything's wrapped in BicepValue, but we're going to pull
// models and enums out (kind of like we do with ResourceReference already) so
// we get a better intellisense experience.  That'll also remove a lot of the
// clutter in this class hierarchy.

/// <summary>
/// Represents the value of a property that could be a literal .NET value, a
/// Bicep expression, or it could be unset.
/// </summary>
public abstract class BicepValue
{
    /// <summary>
    /// Gets the kind of this value (a literal value, an expression, or it's
    /// unset).
    /// </summary>
    public BicepValueKind Kind { get; set; } = BicepValueKind.Unset;

    public BicepExpression? Expression { get; set; } = null;
    // TODO: Lock down setter?  At a minimum we should force Kind to stay in
    // sync, but I'm hoping to change both at once.

    // Get the value when Kind == Literal
    internal abstract object? GetLiteralValue();

    // Tracks who defined this property
    internal BicepValueReference? Self { get; }

    // Tracks who set this property
    internal BicepValueReference? Source { get; private set; }

    // Tracks whether this is an output only property.
    internal bool IsOutput { get; set; } = false;

    // Tracks whether this property is required.
    internal bool IsRequired { get; set; } = false;

    // Tracks whether we currently wrap a secure value.  Bicep doesn't really
    // make use of this directly, but it will be important for module splitting
    // and test sanitization.
    internal bool IsSecure { get; set; } = false;

    // Indicate whether this value is empty or should be included in output
    internal virtual bool IsEmpty => Kind == BicepValueKind.Unset;

    // Naive Bicep type of the value.  We don't support complex object types so
    // this is mostly to help map primitives.
    private protected virtual BicepExpression GetBicepType() => BicepSyntax.Types.Object;

    // TODO: Clean these up when pulling richer objects out of BicepValue<T>
    private protected BicepValue(BicepValueReference? self) => Self = self;
    private protected BicepValue(BicepValueReference? self, /* unused but forces literal */ object literal)
        : this(self) { Kind = BicepValueKind.Literal; }
    private protected BicepValue(BicepValueReference? self, BicepExpression expression)
        : this(self) { Kind = BicepValueKind.Expression; Expression = expression; }

    // Assign a value to this property.
    internal virtual void Assign(BicepValue source)
    {
        // TODO: Do we want to add a more explicit notion of readonly
        // (especially for expr ref resources)?
        if (IsOutput) { throw new InvalidOperationException($"Cannot assign to output value {Self?.PropertyName}"); }

        // Track the source so we can correctly link references across modules
        Source = source?.Self;

        // Copy over the common values (but rely on derived classes for other values)
        Kind = source?.Kind ?? BicepValueKind.Unset;
        Expression = source?.Expression;
        IsSecure = source?.IsSecure ?? false;

        // If we're being assigned an Unset value that references a specific
        // resource, we'll consider this an expression referencing that property
        // (i.e., this is like referencing the unset Id property of a resource
        // you created moments ago).
        if (Kind == BicepValueKind.Unset && Source is not null)
        {
            Kind = BicepValueKind.Expression;
            Expression = Source.GetReference();
        }
    }

    /// <inheritdoc />
    public override string ToString() =>
        Kind switch
        {
            BicepValueKind.Unset =>   $"<{nameof(BicepValue)}: Unset>",
            BicepValueKind.Literal => $"<{nameof(BicepValue)}: {GetLiteralValue()}>",
            _ =>                      $"<{nameof(BicepValue)}: {Compile()}>",
        };

    public BicepExpression Compile() => BicepTypeMapping.ToBicep(this);
}

/// <summary>
/// Gets the kind of a <see cref="BicepValue"/>.
/// </summary>
public enum BicepValueKind { Unset, Literal, Expression }

// TODO: Replace this with helper properties like HasLiteral
