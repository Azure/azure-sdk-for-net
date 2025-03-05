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
    protected internal virtual void EmitConnections(ICollection<ClientConnection> connections, string projectId) { }
    protected internal virtual void EmitImplicitFeatures(FeatureCollection features, string projectId)
        => features.Add(this);

    protected void AddConnectionToAppConfig(ProjectInfrastructure infrastructure, string connectionId, string endpoint)
    {
        AppConfigurationFeature appConfig = infrastructure.Features.FindAll<AppConfigurationFeature>().First();
        AppConfigurationSettingFeature connection = new(appConfig, connectionId, endpoint);
        connection.BicepIdentifier = "cm_connection";
        infrastructure.AddFeature(connection);
    }

    internal ProvisionableResource Emit(ProjectInfrastructure infrastructure)
    {
        if (_resource == null)
        {
            ProvisionableResource namedResource = EmitResources(infrastructure);
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
