// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Base class for all Bicep statement AST nodes.
/// </summary>
[PersistableModelProxy(typeof(UnknownBicepStatement))]
public abstract partial class BicepStatement
{
    internal abstract BicepWriter Write(BicepWriter writer);
    /// <inheritdoc />
    public override string ToString() => new BicepWriter().Append(this).ToString();
}
