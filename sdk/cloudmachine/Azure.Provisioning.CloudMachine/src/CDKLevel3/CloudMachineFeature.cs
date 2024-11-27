// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.CloudMachine;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CloudMachine;

public abstract class CloudMachineFeature
{
    protected abstract ProvisionableResource EmitInfrastructure(CloudMachineInfrastructure cm);
    protected internal virtual void EmitConnections(ConnectionCollection connections, string cmId) { }
    protected internal virtual void EmitFeatures(FeatureCollection features, string cmId)
        => features.Add(this);

    internal void Emit(CloudMachineInfrastructure cm)
    {
        if (Emitted != null) return;
        ProvisionableResource provisionable = EmitInfrastructure(cm);
        Emitted = provisionable;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProvisionableResource Emitted { get; protected set; } = default!;

    protected internal Dictionary<Provisionable, (string RoleName, string RoleId)[]> RequiredSystemRoles { get; } = [];

    protected static T EnsureEmits<T>(CloudMachineFeature feature)
    {
        if (feature.Emitted is T typed)
            return typed;
        throw new ArgumentException($"Expected resource of type {typeof(T).Name}, but got {feature.GetType().Name}");
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => base.ToString()!;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => base.Equals(obj);
}
