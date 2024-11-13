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
    /// <param name="bicepIdentifier">
    /// Bicep identifier of the output.  This value can contain letters,
    /// numbers, and underscores.
    /// </param>
    /// <param name="type">Type of the output.</param>
    public ProvisioningOutput(string bicepIdentifier, BicepExpression type)
        : base(bicepIdentifier, type, value: null) { }

    /// <summary>
    /// Creates a new ProvisioningOutput.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// Bicep identifier of the output.  This value can contain letters,
    /// numbers, and underscores.
    /// </param>
    /// <param name="type">Type of the output.</param>
    public ProvisioningOutput(string bicepIdentifier, Type type)
        : this(bicepIdentifier, new TypeExpression(type)) { }

    /// <inheritdoc />
    protected internal override IEnumerable<BicepStatement> Compile()
    {
        OutputStatement statement = BicepSyntax.Declare.Output(BicepIdentifier, BicepType, Value.Compile());
        if (Description is not null) { statement = statement.Decorate("description", BicepSyntax.Value(Description)); }
        yield return statement;
    }
}
