// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Resources;

public partial class ManagementLock
{
    /// <summary>
    /// Gets or sets the resource to which this lock applies.
    /// </summary>
    /// <remarks>
    /// The resource must be declared in the same Bicep module as the lock.
    /// When this property is null, the lock applies to the deployment scope.
    /// Referencing a resource establishes an implicit deployment dependency;
    /// an explicit <see cref="ProvisionableResource.DependsOn"/> is unnecessary.
    /// </remarks>
    public ProvisionableResource? Scope
    {
        get { Initialize(); return _scope!.Value; }
        set
        {
            Initialize();
            _scope!.Value = value;
            if (value is null)
            {
                // Omit an unset scope instead of emitting an explicit Bicep null.
                _scopeValue!.ClearValue();
            }
        }
    }
    private ResourceReference<ProvisionableResource>? _scope;
    private BicepValue<string>? _scopeValue;

    private partial void DefineAdditionalProperties()
    {
        _scopeValue = DefineProperty<string>(nameof(Scope), ["scope"]);
        _scope = new ResourceReference<ProvisionableResource>(_scopeValue);
    }
}
