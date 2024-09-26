// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

/// <summary>
/// Represents a variable in a Bicep template.
/// </summary>
public class ProvisioningVariable : NamedProvisioningConstruct
{
    /// <summary>
    /// Gets or sets the value of the variable.
    /// </summary>
    public BicepValue<object> Value { get => _value; set => _value.Assign(value); }
    private readonly BicepValue<object> _value;

    /// <summary>
    /// An optional description for the value.
    /// </summary>
    public string? Description { get; set; } = null;

    /// <summary>
    /// Gets the Bicep type of the value.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Expression BicepType { get; }

    /// <summary>
    /// Creates a new ProvisioningVariable.
    /// </summary>
    /// <param name="name">Name of the variable.</param>
    /// <param name="type">Type of the variable.</param>
    /// <param name="value">Default value of the variable.</param>
    protected ProvisioningVariable(string name, Expression type, BicepValue<object>? value)
        : base(name)
    {
        BicepType = type;
        _value = BicepValue<object>.DefineProperty(this, nameof(Value), bicepPath: null, defaultValue: value);
    }

    /// <summary>
    /// Creates a new ProvisioningVariable.
    /// </summary>
    /// <param name="name">Name of the variable.</param>
    /// <param name="type">Type of the variable.</param>
    public ProvisioningVariable(string name, Type type)
        : this(name, new TypeExpression(type), value: null) { }

    /// <inheritdoc />
    protected internal override IEnumerable<Statement> Compile(ProvisioningContext? context = default)
    {
        // TODO: add the rest of https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/parameters#use-decorators?
        VariableStatement stmt = BicepSyntax.Declare.Var(ResourceName, Value.Compile());
        if (Description is not null) { stmt = stmt.Decorate("description", BicepSyntax.Value(Description)); }
        yield return stmt;
    }
}
