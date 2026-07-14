// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Expressions;

public class PropertyExpression : BicepExpression
{
    public string Name { get; }
    public BicepExpression Value { get; }
    internal bool AllowRawName { get; }

    public PropertyExpression(string name, BicepExpression value)
        : this(name, value, allowRawName: true)
    {
    }

    internal PropertyExpression(string name, BicepExpression value, bool allowRawName)
    {
        Name = name;
        Value = value;
        AllowRawName = allowRawName;
    }

    internal override BicepWriter Write(BicepWriter writer) => throw new InvalidOperationException("Properties are only valid inside an object");
}
