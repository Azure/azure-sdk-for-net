// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Proxy type used by ModelReaderWriter for abstract BicepExpression deserialization.
/// </summary>
internal partial class UnknownBicepExpression : BicepExpression
{
    internal override BicepWriter Write(BicepWriter writer) =>
        throw new InvalidOperationException("UnknownBicepExpression cannot be written.");
}
