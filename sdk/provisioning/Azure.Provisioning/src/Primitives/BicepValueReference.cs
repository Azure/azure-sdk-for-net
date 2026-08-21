// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Tracks a reference to a specific property on a provisioning construct, including the Bicep path needed to resolve it.
/// </summary>
/// <param name="construct">The construct that owns the referenced property.</param>
/// <param name="propertyName">The property name.</param>
/// <param name="path">The Bicep path segments used to resolve the reference.</param>
public class BicepValueReference(ProvisionableConstruct construct, string propertyName, params string[]? path)
{
    /// <summary>
    /// Gets the construct that owns the referenced property.
    /// </summary>
    public ProvisionableConstruct Construct { get; } = construct;
    /// <summary>
    /// Gets the property name.
    /// </summary>
    public string PropertyName { get; } = propertyName;
    /// <summary>
    /// Gets the Bicep path segments used to resolve the reference.
    /// </summary>
    public IReadOnlyList<string>? BicepPath { get; } = path;

    internal virtual BicepExpression GetReference(bool throwIfNoRoot = true)
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
                throw new InvalidOperationException("Cannot reference a construct without a name.");
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

    /// <inheritdoc />
    public override string ToString() => GetReference(throwIfNoRoot: false).ToString();
}

internal class BicepListValueReference(ProvisionableConstruct construct, string propertyName, string[]? path, int index)
    : BicepValueReference(construct, propertyName, path)
{
    public int Index { get; set; } = index;

    internal override BicepExpression GetReference(bool throwIfNoRoot = true)
    {
        return base.GetReference(throwIfNoRoot).Index(new IntLiteralExpression(Index));
    }
}

internal class BicepDictionaryValueReference(ProvisionableConstruct construct, string propertyName, string[]? path, string key)
    : BicepValueReference(construct, propertyName, path)
{
    public string Key { get; } = key;
    internal override BicepExpression GetReference(bool throwIfNoRoot = true)
    {
        return base.GetReference(throwIfNoRoot).Index(Key);
    }
}
