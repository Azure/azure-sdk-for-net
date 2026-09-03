// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep type expression that maps a .NET <see cref="System.Type"/> to a Bicep primitive type name.
/// </summary>
/// <param name="type">The .NET type to map.</param>
public partial class TypeExpression(Type type) : BicepExpression
{
    /// <summary>
    /// Gets the .NET type being mapped to a Bicep type name.
    /// </summary>
    public Type Type { get; } = type;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(
            BicepTypeMapping.GetBicepTypeName(Type) ??
            throw new NotSupportedException($"Failed to automatically map {Type.FullName} into a {nameof(TypeExpression)}.  Please explicitly choose a primitive type like bool, int, string, object, array, etc."));
}
