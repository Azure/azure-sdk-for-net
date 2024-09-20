﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning;

/// <summary>
/// Represents a parameter in a Bicep template.
/// </summary>
public class BicepParameter : BicepVariable
{
    /// <summary>
    /// Gets or sets whether this parameter uses a secure value.  It will default
    /// to secure if provided a <see cref="BicepVariable.Value"/> that is known to be secure.
    /// </summary>
    public bool IsSecure
    {
        get => _isSecure || Value.IsSecure;
        set => _isSecure = value;
    }
    private bool _isSecure = false;

    /// <summary>
    /// Creates a new BicepParameter.
    /// </summary>
    /// <param name="name">Name of the parameter.</param>
    /// <param name="type">Type of the parameter.</param>
    /// <param name="context">Optional provisioning context.</param>
    public BicepParameter(string name, Expression type, ProvisioningContext? context = default)
        : base(name, type, value: null, context) { }

    /// <summary>
    /// Creates a new BicepParameter.
    /// </summary>
    /// <param name="name">Name of the parameter.</param>
    /// <param name="type">Type of the parameter.</param>
    /// <param name="context">Optional provisioning context.</param>
    public BicepParameter(string name, Type type, ProvisioningContext? context = default)
        : this(name, new TypeExpression(type), context) { }

    /// <inheritdoc />
    protected internal override IEnumerable<Statement> Compile(ProvisioningContext? context = default)
    {
        ParameterStatement stmt = BicepSyntax.Declare.Param(ResourceName, BicepType, Value.Kind == BicepValueKind.Unset ? null : Value.Compile());
        if (IsSecure) { stmt = stmt.Decorate("secure"); }
        if (Description is not null) { stmt = stmt.Decorate("description", BicepSyntax.Value(Description)); }
        yield return stmt;
    }
}
