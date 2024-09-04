// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning;

/// <summary>
/// Represents an output in a Bicep template.
/// </summary>
/// <param name="name">Name of the output.</param>
/// <param name="type">Type of the output.</param>
/// <param name="context">Optional provisioning context.</param>
public class BicepOutput(string name, Expression type, ProvisioningContext? context = default)
    : BicepVariable(name, type, value: null, context)
{
    public BicepOutput(string name, Type type, ProvisioningContext? context = default)
        : this(name, new TypeExpression(type), context) { }

    public static new BicepOutput Create<T>(string name, BicepValue<object>? value = null, ProvisioningContext? context = default)
    {
        BicepOutput output = new(name, BicepSyntax.Types.Create<T>(), context);
        if (value is not null) { output.Value = value; }
        return output;
    }

    /// <inheritdoc />
    protected internal override IEnumerable<Statement> Compile(ProvisioningContext? context = default)
    {
        OutputStatement stmt = BicepSyntax.Declare.Output(ResourceName, BicepType, Value.Compile());
        if (Description is not null) { stmt = stmt.Decorate("description", BicepSyntax.Value(Description)); }
        yield return stmt;
    }
}
