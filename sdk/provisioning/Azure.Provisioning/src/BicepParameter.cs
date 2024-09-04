// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning;

/// <summary>
/// Represents a parameter in a Bicep template.
/// </summary>
/// <param name="name">Name of the output.</param>
/// <param name="type">Type of the output.</param>
/// <param name="context">Optional provisioning context.</param>
public class BicepParameter(string name, Expression type, ProvisioningContext? context = default)
    : BicepVariable(name, type, value: null, context)
{
    private bool _isSecure = false;
    public bool IsSecure
    {
        get => _isSecure || Value.IsSecure;
        set => _isSecure = value;
    }

    public BicepParameter(string name, Type type, ProvisioningContext? context = default)
        : this(name, new TypeExpression(type), context) { }

    public static new BicepParameter Create<T>(string name, BicepValue<object>? value = null, ProvisioningContext? context = default)
    {
        BicepParameter variable = new(name, BicepSyntax.Types.Create<T>(), context);
        if (value is not null) { variable.Value = value; }
        return variable;
    }

    /// <inheritdoc />
    protected internal override IEnumerable<Statement> Compile(ProvisioningContext? context = default)
    {
        ParameterStatement stmt = BicepSyntax.Declare.Param(ResourceName, BicepType, Value.Kind == BicepValueKind.Unset ? null : Value.Compile());
        if (IsSecure) { stmt = stmt.Decorate("secure"); }
        if (Description is not null) { stmt = stmt.Decorate("description", BicepSyntax.Value(Description)); }
        yield return stmt;
    }
}
