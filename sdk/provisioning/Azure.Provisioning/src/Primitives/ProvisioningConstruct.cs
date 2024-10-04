// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// A named Bicep entity, like a resource or parameter.
/// </summary>
public abstract class NamedProvisioningConstruct : ProvisioningConstruct
{
    /// <summary>
    /// Gets or sets the the Bicep identifier name of the resource.  This can
    /// be used to refer to the resource in expressions, but is not the Azure
    /// name of the resource.  This value can contain letters, numbers, and
    /// underscores.
    /// </summary>
    public string IdentifierName
    {
        get => _identifierName;
        set => _identifierName = ValidateIdentifierName(value, nameof(value));
    }
    private string _identifierName;
    // TODO: Listen for feedback, but discuss IdentifierName vs. ProvisioningName in the Arch Board

    /// <summary>
    /// Creates a named Bicep entity, like a resource or parameter.
    /// </summary>
    /// <param name="identifierName">
    /// The the Bicep identifier name of the resource.  This can be used to
    /// refer to the resource in expressions, but is not the Azure name of the
    /// resource.  This value can contain letters, numbers, and underscores.
    /// </param>
    protected NamedProvisioningConstruct(string identifierName) =>
        _identifierName = ValidateIdentifierName(identifierName, nameof(identifierName));

    // TODO: Relax this in the future when we make identifier names optional
    private static string ValidateIdentifierName(string identifierName, string paramName)
    {
        // TODO: Enable when Aspire is ready
        /*
        if (identifierName is null)
        {
            throw new ArgumentNullException(paramName, $"{nameof(IdentifierName)} cannot be null.");
        }
        else if (identifierName.Length == 0)
        {
            throw new ArgumentException($"{nameof(IdentifierName)} cannot be empty.", paramName);
        }

        foreach (var ch in identifierName)
        {
            if (!char.IsLetterOrDigit(ch) && ch != '_')
            {
                throw new ArgumentException($"{nameof(IdentifierName)} \"{identifierName}\" should only contain letters, numbers, and underscores.", paramName);
            }
        }
        /**/
        return identifierName;
    }
}

public abstract class ProvisioningConstruct : Provisionable
{
    /// <summary>
    /// Gets the parent infrastructure construct, if any.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Infrastructure? ParentInfrastructure { get; internal set; }

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override IEnumerable<Provisionable> GetResources() => base.GetResources();

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
    internal Expression? ExpressionOverride { get; private set; }

    /// <summary>
    /// Set this construct to represent the result of an expression.  This is
    /// primarily meant to be called via `FromExpression` static methods on
    /// specific resources or constructs.
    /// </summary>
    /// <param name="reference">The expression.</param>
    protected internal void OverrideWithExpression(Expression reference)
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
    protected internal override void Resolve(ProvisioningContext? context = null)
    {
        context ??= new();
        base.Resolve(context);

        // Resolve any property values
        foreach (PropertyResolver resolver in context.PropertyResolvers)
        {
            resolver.ResolveProperties(context, this);
        }
    }

    /// <inheritdoc/>
    protected internal override void Validate(ProvisioningContext? context = null)
    {
        context ??= new();
        base.Validate(context);
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
    protected internal override IEnumerable<Statement> Compile() =>
        [new ExprStatement(CompileProperties())];

    private protected Expression CompileProperties()
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
            Dictionary<string, Expression> bicep = [];
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
                else if (pair.Value is ProvisioningConstruct construct)
                {
                    IList<Statement> statements = [..construct.Compile()];
                    if (statements.Count != 1 || statements[0] is not ExprStatement expr)
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
