// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Base class for all Bicep statement AST nodes.
/// </summary>
public abstract class BicepStatement
{
    internal abstract BicepWriter Write(BicepWriter writer);
    /// <inheritdoc />
    public override string ToString() => new BicepWriter().Append(this).ToString();
}
