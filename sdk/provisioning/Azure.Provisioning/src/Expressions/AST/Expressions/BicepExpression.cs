// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public abstract class BicepExpression
{
    internal abstract BicepWriter Write(BicepWriter writer);
    public override string ToString() => new BicepWriter().Append(this).ToString();

    public static implicit operator BicepExpression(string value) => new StringLiteralExpression(value);
    public static implicit operator BicepExpression(int value) => new IntLiteralExpression(value);
    public static implicit operator BicepExpression(bool value) => new BoolLiteralExpression(value);
}
