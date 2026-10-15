// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a single property within a Bicep object expression.
/// </summary>
/// <param name="name">The property name.</param>
/// <param name="value">The property value expression.</param>
public partial class PropertyExpression(string name, BicepExpression value) : BicepExpression
{
    /// <summary>
    /// Gets the property name.
    /// </summary>
    public string Name { get; } = name;
    /// <summary>
    /// Gets the property value expression.
    /// </summary>
    public BicepExpression Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) => throw new InvalidOperationException("Properties are only valid inside an object");
}
