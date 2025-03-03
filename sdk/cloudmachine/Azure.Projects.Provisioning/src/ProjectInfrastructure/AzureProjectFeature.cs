// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;

namespace Azure.Projects.Core;

public abstract class AzureProjectFeature
{
    private ProvisionableResource? _resource;

    protected abstract ProvisionableResource EmitResources(ProjectInfrastructure cm);
    protected internal virtual void EmitConnections(ICollection<ClientConnection> connections, string cmId) { }
    protected internal virtual void EmitFeatures(FeatureCollection features, string cmId)
        => features.Add(this);

    internal ProvisionableResource Emit(ProjectInfrastructure cm)
    {
        if (_resource == null)
        {
            ProvisionableResource namedResource = EmitResources(cm);
            _resource = namedResource;
        }
        return Resource;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProvisionableResource Resource {
        get
        {
            if (_resource == null)
            {
                throw new InvalidOperationException("Feature has not been emitted yet.");
            }
            return _resource;
        }
    }

    protected internal Dictionary<Provisionable, FeatureRole[]> RequiredSystemRoles { get; } = [];

    protected static T EnsureEmits<T>(AzureProjectFeature feature)
    {
        if (feature.Resource is T typed)
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
