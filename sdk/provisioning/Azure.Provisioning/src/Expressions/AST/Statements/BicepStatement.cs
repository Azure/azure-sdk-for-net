// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public abstract class BicepStatement
{
    internal abstract BicepWriter Write(BicepWriter writer);
    public override string ToString() => new BicepWriter().Append(this).ToString();
}
