// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

// Work in progress to to help track the flow of values through the computation
// graph so we can intelligently and automatically split expressions across
// module boundaries.

public class BicepValueReference(ProvisioningConstruct construct, string propertyName, params string[]? path)
{
    public ProvisioningConstruct Construct { get; } = construct;
    public string PropertyName { get; } = propertyName;
    public IReadOnlyList<string>? BicepPath { get; } = path;

    internal BicepExpression GetReference()
    {
        // We'll relax this soon
        if (Construct is not NamedProvisioningConstruct named)
        {
            throw new NotImplementedException("Cannot reference a construct without a name yet.");
        }

        BicepExpression target = BicepSyntax.Var(named.BicepIdentifier);
        if (BicepPath is not null)
        {
            foreach (string segment in BicepPath)
            {
                target = target.Get(segment);
            }
        }
        return target;
    }

    public override string ToString() =>
        $"<{GetReference()} from {Construct.GetType().Name}.{PropertyName}>";
}
