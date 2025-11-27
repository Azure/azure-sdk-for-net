// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public abstract class LiteralExpression(object? value = null) : BicepExpression
{
    public object? Value { get; } = value;
}
