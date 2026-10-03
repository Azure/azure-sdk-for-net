// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

internal sealed class RawExpression(string value) : BicepExpression
{
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(value);
}
