// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

public class BicepValueReference(ProvisionableConstruct construct, string propertyName, params string[]? path)
{
    public BicepValueReference? Parent { get; private set; } = ((IBicepValue)construct).Self;
    public ProvisionableConstruct Construct { get; } = construct;
    public string PropertyName { get; } = propertyName;
    public IReadOnlyList<string>? BicepPath { get; } = path;

    internal BicepExpression GetReference()
    {
        // Get the root
        BicepExpression? target = Parent?.GetReference();
        if (target is null)
        {
            if (Construct is not NamedProvisionableConstruct named)
            {
                throw new NotImplementedException("Cannot reference a construct without a name.");
            }
            target = BicepSyntax.Var(named.BicepIdentifier);
        }

        // Finish getting to this resource
        if (BicepPath is not null)
        {
            foreach (string segment in BicepPath)
            {
                target = target.Get(segment);
            }
        }
        return target;
    }

    public override string ToString() => GetReference().ToString();
}
