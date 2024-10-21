﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

public abstract class ProvisionableConstruct : Provisionable
{
    /// <summary>
    /// Gets the parent infrastructure construct, if any.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Infrastructure? ParentInfrastructure { get; internal set; }

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override IEnumerable<Provisionable> GetProvisionableResources() => base.GetProvisionableResources();

    /// <summary>
    /// Gets the properties of the construct.
    /// </summary>
    internal IDictionary<string, BicepValue> ProvisioningProperties { get; } =
        new Dictionary<string, BicepValue>();

    /// <summary>
    /// Allow this resource to alias the result of an expression (i.e., we can
    /// have an instance of the `ResourceGroup` class effectively wrap the
    /// `resourceGroup()` function so people can use
    /// `BicepFunctions.GetResourceGroup().Location` just like `myRg.Location`).
    /// </summary>
    internal BicepExpression? ExpressionOverride { get; private set; }

    /// <summary>
    /// Set this construct to represent the result of an expression.  This is
    /// primarily meant to be called via `FromExpression` static methods on
    /// specific resources or constructs.
    /// </summary>
    /// <param name="reference">The expression.</param>
    protected internal void OverrideWithExpression(BicepExpression reference)
    {
        ExpressionOverride = reference;

        // Unlink from any group, if necessary, as expressions carry their
        // own context
        ParentInfrastructure?.Remove(this);

        // Reset all the properties as accessors off the current expr
        foreach (BicepValue property in ProvisioningProperties.Values)
        {
            property.Kind = BicepValueKind.Expression;
            property.Expression = property.Self?.BicepPath?.Aggregate(reference, (expr, segment) => expr.Get(segment));
            property.IsOutput = true; // TODO: We could consider evolving this depending on the type of expression
        }
    }

    /// <summary>
    /// Set a property on the construct.  This is primarily intended for
    /// resolvers to avoid reflection.
    /// </summary>
    /// <param name="property">The property to set.</param>
    /// <param name="value">The property value.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProvisioningProperty(BicepValue property, BicepValue value)
    {
        if (ProvisioningProperties.TryGetValue(property.Self!.PropertyName!, out BicepValue? existing) &&
            existing != property)
        {
            throw new ArgumentException($"Property {property.Self!.PropertyName} is not defined on construct {GetType().Name}.", nameof(property));
        }
        property.Assign(value);
    }

    /// <inheritdoc/>
    protected internal override void Resolve(ProvisioningBuildOptions? options = null)
    {
        options ??= new();
        base.Resolve(options);

        // Resolve any property values
        foreach (InfrastructureResolver resolver in options.InfrastructureResolvers)
        {
            resolver.ResolveProperties(this, options);
        }
    }

    /// <inheritdoc/>
    protected internal override void Validate(ProvisioningBuildOptions? options = null)
    {
        options ??= new();
        base.Validate(options);
    }

    private protected virtual void ValidateProperties()
    {
        foreach (BicepValue property in ProvisioningProperties.Values)
        {
            RequireProperty(property);
        }
    }

    private protected void RequireProperty(BicepValue value)
    {
        if (value.IsRequired && value.Kind == BicepValueKind.Unset)
        {
            throw new InvalidOperationException($"{GetType().Name} definition is missing required property {value.Self?.PropertyName}");
        }
    }

    /// <inheritdoc/>
    protected internal override IEnumerable<BicepStatement> Compile() =>
        [new ExpressionStatement(CompileProperties())];

    private protected BicepExpression CompileProperties()
    {
        if (ExpressionOverride is not null) { return ExpressionOverride; }

        // Aggregate all the properties into a single nested dictionary
        Dictionary<string, object> body = [];
        foreach (BicepValue property in ProvisioningProperties.Values.Where(p => !p.IsEmpty))
        {
            // Some of the properties are nested paths and need to be expanded
            // into multiple levels of hierarchy
            Dictionary<string, object> obj = body;
            for (int i = 0; i < property.Self!.BicepPath!.Count - 1; i++) // Properties always have Self/BicepPath defined
            {
                if (!obj.TryGetValue(property.Self.BicepPath[i], out object next) ||
                    next is not Dictionary<string, object> dict)
                {
                    dict = [];
                    obj[property.Self.BicepPath[i]] = dict;
                }
                obj = dict;
            }
            obj[property.Self.BicepPath[property.Self.BicepPath.Count - 1]] = property;
        }
        return CompileValues(body);

        // Collapse those nested dictionaries into nested ObjectExpressions,
        // compiling values along the way
        static ObjectExpression CompileValues(IDictionary<string, object> dict)
        {
            Dictionary<string, BicepExpression> bicep = [];
            foreach (KeyValuePair<string, object> pair in dict)
            {
                if (pair.Value is Dictionary<string, object> nested)
                {
                    bicep[pair.Key] = CompileValues(nested);
                }
                else if (pair.Value is BicepValue value)
                {
                    bicep[pair.Key] = value.Compile();
                }
                else if (pair.Value is ProvisionableConstruct construct)
                {
                    IList<BicepStatement> statements = [..construct.Compile()];
                    if (statements.Count != 1 || statements[0] is not ExpressionStatement expr)
                    {
                        throw new InvalidOperationException($"Expected a single expression statement for {pair.Key}.");
                    }
                    bicep[pair.Key] = expr.Expression;
                }
                else
                {
                    throw new InvalidOperationException($"Unexpected property value {pair.Value} for {pair.Key}.");
                }
            }
            return BicepSyntax.Object(bicep);
        }
    }
}
