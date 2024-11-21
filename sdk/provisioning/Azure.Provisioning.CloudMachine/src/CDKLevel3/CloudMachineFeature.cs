// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.CloudMachine;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CloudMachine;

public abstract class CloudMachineFeature
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void AddTo(CloudMachineInfrastructure cm) => cm.Features.Add(this);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Emit(CloudMachineInfrastructure cm)
    {
        if (Emitted != null)
            return;
        ProvisionableResource provisionable = EmitCore(cm);
        Emitted = provisionable;
    }

    protected abstract ProvisionableResource EmitCore(CloudMachineInfrastructure cm);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProvisionableResource Emitted { get; protected set; } = default!;

    protected internal Dictionary<Provisionable, (string RoleName, string RoleId)[]> RequiredSystemRoles { get; } = [];

    /// <summary>
    /// A collection of dependency mappings.
    /// The key is the dependent resource and the value is the resource it depends on.
    /// </summary>
    protected internal Dictionary<Provisionable, Provisionable> DependencyMapping { get; } = [];
}
