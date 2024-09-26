// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning;

/// <summary>
/// Represents an output in a Bicep template.
/// </summary>
public class BicepOutput : BicepVariable
{
    /// <summary>
    /// Creates a new BicepOutput.
    /// </summary>
    /// <param name="name">Name of the output.</param>
    /// <param name="type">Type of the output.</param>
    public BicepOutput(string name, Expression type)
        : base(name, type, value: null) { }

    /// <summary>
    /// Creates a new BicepOutput.
    /// </summary>
    /// <param name="name">Name of the output.</param>
    /// <param name="type">Type of the output.</param>
    public BicepOutput(string name, Type type)
        : this(name, new TypeExpression(type)) { }

    /// <inheritdoc />
    protected internal override IEnumerable<Statement> Compile(ProvisioningContext? context = default)
    {
        OutputStatement stmt = BicepSyntax.Declare.Output(ResourceName, BicepType, Value.Compile());
        if (Description is not null) { stmt = stmt.Decorate("description", BicepSyntax.Value(Description)); }
        yield return stmt;
    }
}
