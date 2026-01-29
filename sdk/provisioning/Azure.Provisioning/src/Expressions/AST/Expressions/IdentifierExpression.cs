// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class IdentifierExpression(string name) : BicepExpression
{
    public string Name { get; } = name;
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Name);
}
