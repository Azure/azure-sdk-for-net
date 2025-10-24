// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Expressions;

public class TypeExpression(Type type) : BicepExpression
{
    public Type Type { get; } = type;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(
            BicepTypeMapping.GetBicepTypeName(Type) ??
            throw new NotSupportedException($"Failed to automatically map {Type.FullName} into a {nameof(TypeExpression)}.  Please explicitly choose a primitive type like bool, int, string, object, array, etc.");
}
