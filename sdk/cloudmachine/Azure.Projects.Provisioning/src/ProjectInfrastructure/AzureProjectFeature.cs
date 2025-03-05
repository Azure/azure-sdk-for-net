// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Projects.AppConfiguration;
using Azure.Provisioning.Primitives;

namespace Azure.Projects.Core;

public abstract class AzureProjectFeature
{
    private ProvisionableResource? _resource;

    protected abstract ProvisionableResource EmitResources(ProjectInfrastructure infrastructure);

    protected internal virtual void EmitImplicitFeatures(FeatureCollection features, string projectId) { }

    internal ProvisionableResource Emit(ProjectInfrastructure infrastructure)
    {
        if (_resource == null)
        {
            ProvisionableResource namedResource = EmitResources(infrastructure);
            _resource = namedResource;
        }
        return Resource;
    }

    protected void AddConnectionToAppConfig(ProjectInfrastructure infrastructure, string connectionId, string endpoint)
    {
        AppConfigurationSettingFeature connection = new(connectionId, endpoint);
        connection.BicepIdentifier = "cm_connection";
        infrastructure.AddFeature(connection);
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
