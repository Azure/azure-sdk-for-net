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
    private ProvisionableResource? _resource;

    protected abstract ProvisionableResource EmitConstructs(CloudMachineInfrastructure cm);
    protected internal virtual void EmitConnections(ConnectionCollection connections, string cmId) { }
    protected internal virtual void EmitFeatures(FeatureCollection features, string cmId)
        => features.Add(this);

    internal ProvisionableResource Emit(CloudMachineInfrastructure cm)
    {
        if (_resource == null)
        {
            ProvisionableResource provisionable = EmitConstructs(cm);
            _resource = provisionable;
        }
        return Emitted;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProvisionableResource Emitted {
        get
        {
            if (_resource == null)
            {
                throw new InvalidOperationException("Feature has not been emitted yet.");
            }
            return _resource;
        }
    }

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
