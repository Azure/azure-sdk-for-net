// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        if (Emited != null) return;
        ProvisionableResource provisionable = EmitCore(cm);
        Emited = provisionable;
    }

    protected abstract ProvisionableResource EmitCore(CloudMachineInfrastructure cm);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProvisionableResource Emited { get; protected set; } = default!;
}
