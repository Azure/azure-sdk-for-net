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
    /// <para>
    /// Add the resource to the same <see cref="Infrastructure"/> as the lock, either as a new
    /// resource or as an existing one (for example, declared with <c>FromExisting</c>). When
    /// the resource is deployed by the same infrastructure, referencing it also establishes an
    /// implicit deployment dependency, so an explicit
    /// <see cref="ProvisionableResource.DependsOn"/> entry is unnecessary.
    /// </para>
    /// <para>
    /// When this property is null, the lock applies to the deployment scope (see
    /// <see cref="Infrastructure.TargetScope"/>); in a resource group deployment, that is the
    /// whole resource group. Assigning null clears a previously assigned resource.
    /// </para>
    /// <para>
    /// This property cannot move the lock to a different deployment scope. For example, a
    /// <see cref="ResourceGroup"/> declared in a subscription-scoped infrastructure cannot be
    /// used. To lock a resource group, deploy the lock at resource group scope and leave this
    /// property unset.
    /// </para>
    /// </remarks>
    public ProvisionableResource? Scope
    {
        get { Initialize(); return _scope!.Value; }
        set
        {
            Initialize();
            if (value is null)
            {
                // Bicep rejects an explicit null scope, so omit the property instead.
                _scope!.Clear();
            }
            else
            {
                _scope!.Value = value;
            }
        }
    }
    private ResourceReference<ProvisionableResource>? _scope;

    private partial void DefineAdditionalProperties()
    {
        _scope = DefineResource<ProvisionableResource>(nameof(Scope), ["scope"]);
    }
}
