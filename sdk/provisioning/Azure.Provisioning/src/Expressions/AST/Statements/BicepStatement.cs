// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure.Provisioning.Expressions;

[PersistableModelProxy(typeof(UnknownBicepStatement))]
public abstract partial class BicepStatement
{
    internal abstract BicepWriter Write(BicepWriter writer);
    public override string ToString() => new BicepWriter().Append(this).ToString();
}
