// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

public class BicepValueReference(ProvisionableConstruct construct, string propertyName, params string[]? path)
{
    public ProvisionableConstruct Construct { get; } = construct;
    public string PropertyName { get; } = propertyName;
    public IReadOnlyList<string>? BicepPath { get; } = path;

    internal BicepExpression GetReference(bool throwIfNoRoot = true)
    {
        // Get the root
        BicepExpression? target = ((IBicepValue)Construct).Self?.GetReference();
        if (target is null)
        {
            if (Construct is NamedProvisionableConstruct named)
            {
                target = BicepSyntax.Var(named.BicepIdentifier);
            }
            else if (throwIfNoRoot)
            {
                throw new NotImplementedException("Cannot reference a construct without a name.");
            }
            else
            {
                // This will render unrooted ToStrings as MISSING_RESOURCE.foo.bar
                // which is obviously invalid, but potentially helpful for debugging.
                target = BicepSyntax.Var("MISSING_RESOURCE");
            }
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

    public override string ToString() => GetReference(throwIfNoRoot: false).ToString();
}
