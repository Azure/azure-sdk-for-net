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
    /// Gets or sets whether this parameter uses a secure value.  It will default
    /// to secure if provided a <see cref="ProvisioningVariable.Value"/> that is known to be secure.
    /// </summary>
    public bool IsSecure
    {
        get => _isSecure || Value.IsSecure;
        set => _isSecure = value;
    }
    private bool _isSecure = false;

    /// <summary>
    /// Creates a new ProvisioningParameter.
    /// </summary>
    /// <param name="name">
    /// Name of the parameter.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="type">Type of the parameter.</param>
    public ProvisioningParameter(string name, Expression type)
        : base(name, type, value: null) { }

    /// <summary>
    /// Creates a new ProvisioningParameter.
    /// </summary>
    /// <param name="name">
    /// Name of the parameter.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="type">Type of the parameter.</param>
    public ProvisioningParameter(string name, Type type)
        : this(name, new TypeExpression(type)) { }

    /// <inheritdoc />
    protected internal override IEnumerable<Statement> Compile()
    {
        ParameterStatement stmt = BicepSyntax.Declare.Param(IdentifierName, BicepType, Value.Kind == BicepValueKind.Unset ? null : Value.Compile());
        if (IsSecure) { stmt = stmt.Decorate("secure"); }
        if (Description is not null) { stmt = stmt.Decorate("description", BicepSyntax.Value(Description)); }
        yield return stmt;
    }
}
