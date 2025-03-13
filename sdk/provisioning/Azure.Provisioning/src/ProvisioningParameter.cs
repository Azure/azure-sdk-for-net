// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning;

/// <summary>
/// Represents a parameter in a Bicep template.
/// </summary>
public class ProvisioningParameter : ProvisioningVariable
{
    /// <summary>
    /// Gets or sets whether this parameter uses a secure value.  It will
    /// default to secure if provided a <see cref="ProvisioningVariable.Value"/>
    /// that is known to be secure.
    /// </summary>
    public bool IsSecure
    {
        get => _isSecure || ((IBicepValue)Value).IsSecure;
        set => _isSecure = value;
    }
    private bool _isSecure = false;

    /// <summary>
    /// Creates a new ProvisioningParameter.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// Bicep identifier of the parameter.  This value can contain letters,
    /// numbers, and underscores.
    /// </param>
    /// <param name="type">Type of the parameter.</param>
    public ProvisioningParameter(string bicepIdentifier, BicepExpression type)
        : base(bicepIdentifier, type, value: null) { }

    /// <summary>
    /// Creates a new ProvisioningParameter.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// Bicep identifier of the parameter.  This value can contain letters,
    /// numbers, and underscores.
    /// </param>
    /// <param name="type">Type of the parameter.</param>
    public ProvisioningParameter(string bicepIdentifier, Type type)
        : this(bicepIdentifier, new TypeExpression(type)) { }

    /// <inheritdoc />
    protected internal override IEnumerable<BicepStatement> Compile()
    {
        ParameterStatement statement =
            BicepSyntax.Declare.Param(
                BicepIdentifier,
                BicepType,
                ((IBicepValue)Value).Kind == BicepValueKind.Unset ? null : Value.Compile());
        if (IsSecure) { statement = statement.Decorate("secure"); }
        if (Description is not null) { statement = statement.Decorate("description", BicepSyntax.Value(Description)); }
        yield return statement;
    }
}
