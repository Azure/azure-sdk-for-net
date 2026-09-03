// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Proxy type used by ModelReaderWriter for abstract BicepStatement deserialization.
/// </summary>
internal partial class UnknownBicepStatement : BicepStatement
{
    internal override BicepWriter Write(BicepWriter writer) =>
        throw new InvalidOperationException("UnknownBicepStatement cannot be written.");
}
