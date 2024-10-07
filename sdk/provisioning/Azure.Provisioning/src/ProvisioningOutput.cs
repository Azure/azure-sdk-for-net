// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning;

/// <summary>
/// Represents an output in a Bicep template.
/// </summary>
public class ProvisioningOutput : ProvisioningVariable
{
    /// <summary>
    /// Creates a new ProvisioningOutput.
    /// </summary>
    /// <param name="name">
    /// Name of the output.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="type">Type of the output.</param>
    public ProvisioningOutput(string name, Expression type)
        : base(name, type, value: null) { }

    /// <summary>
    /// Creates a new ProvisioningOutput.
    /// </summary>
    /// <param name="name">
    /// Name of the output.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="type">Type of the output.</param>
    public ProvisioningOutput(string name, Type type)
        : this(name, new TypeExpression(type)) { }

    /// <inheritdoc />
    protected internal override IEnumerable<Statement> Compile()
    {
        OutputStatement stmt = BicepSyntax.Declare.Output(IdentifierName, BicepType, Value.Compile());
        if (Description is not null) { stmt = stmt.Decorate("description", BicepSyntax.Value(Description)); }
        yield return stmt;
    }
}
