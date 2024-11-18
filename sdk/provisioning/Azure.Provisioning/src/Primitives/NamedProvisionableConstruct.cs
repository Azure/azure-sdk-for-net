// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Primitives;

/// <summary>
/// A named Bicep entity, like a resource or parameter.
/// </summary>
public abstract class NamedProvisionableConstruct : ProvisionableConstruct
{
    /// <summary>
    /// Gets or sets the the Bicep identifier name of the resource.  This can
    /// be used to refer to the resource in expressions, but is not the Azure
    /// name of the resource.  This value can contain letters, numbers, and
    /// underscores.
    /// </summary>
    public string BicepIdentifier
    {
        get => _bicepIdentifier;
        set
        {
            Infrastructure.ValidateBicepIdentifier(value, nameof(value));
            _bicepIdentifier = value;
        }
    }
    private string _bicepIdentifier;

    /// <summary>
    /// Creates a named Bicep entity, like a resource or parameter.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the resource.  This can be used to
    /// refer to the resource in expressions, but is not the Azure name of the
    /// resource.  This value can contain letters, numbers, and underscores.
    /// </param>
    protected NamedProvisionableConstruct(string bicepIdentifier)
    {
        Infrastructure.ValidateBicepIdentifier(bicepIdentifier, nameof(bicepIdentifier));
        _bicepIdentifier = bicepIdentifier;
    }
}
