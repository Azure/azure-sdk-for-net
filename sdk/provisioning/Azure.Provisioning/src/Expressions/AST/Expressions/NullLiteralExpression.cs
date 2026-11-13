// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents the Bicep <c>null</c> literal expression.
/// </summary>
public class NullLiteralExpression() : LiteralExpression()
{
    internal override BicepWriter Write(BicepWriter writer) => writer.Append("null");
}
