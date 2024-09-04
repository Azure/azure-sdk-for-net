// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

/// <summary>
/// Represents a variable in a Bicep template.
/// </summary>
public class BicepVariable : NamedProvisioningConstruct
{
    /// <summary>
    /// An optional description for the valuee.
    /// </summary>
    public string? Description { get; set; } = null;

    /// <summary>
    /// Gets the Bicep type of the value.
    /// </summary>
    protected Expression BicepType { get; }

    /// <summary>
    /// Gets or sets the value of the variable.
    /// </summary>
    public BicepValue<object> Value { get => _value; set => _value.Assign(value); }
    private readonly BicepValue<object> _value;

    protected BicepVariable(string name, Expression type, BicepValue<object>? value, ProvisioningContext? context = default)
        : base(name, context)
    {
        BicepType = type;
        _value = BicepValue<object>.DefineProperty(this, nameof(Value), bicepPath: null, defaultValue: value);
    }

    public BicepVariable(string name, Type type, ProvisioningContext? context = default)
        : this(name, new TypeExpression(type), value: null, context) { }

    public BicepVariable(string name, Expression type, ProvisioningContext? context = default)
        : this(name, type, value: null, context) { }

    public static BicepVariable Create<T>(string name, BicepValue<object>? value = null, ProvisioningContext? context = default)
    {
        BicepVariable variable = new(name, BicepSyntax.Types.Create<T>(), context);
        if (value is not null) { variable.Value = value; }
        return variable;
    }

    /// <inheritdoc />
    protected internal override IEnumerable<Statement> Compile(ProvisioningContext? context = default)
    {
        // TODO: add the rest of https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/parameters#use-decorators?
        VariableStatement stmt = BicepSyntax.Declare.Var(ResourceName, Value.Compile());
        if (Description is not null) { stmt = stmt.Decorate("description", BicepSyntax.Value(Description)); }
        yield return stmt;
    }
}
