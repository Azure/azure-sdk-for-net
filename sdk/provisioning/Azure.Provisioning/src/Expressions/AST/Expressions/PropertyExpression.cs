// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Expressions;

public class PropertyExpression(string name, BicepExpression value) : BicepExpression
{
    public string Name { get; } = name;
    public BicepExpression Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) => throw new InvalidOperationException("Properties are only valid inside an object");
}
