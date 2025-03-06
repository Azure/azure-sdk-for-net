// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Projects.AppConfiguration;
using Azure.Provisioning.Primitives;

namespace Azure.Projects.Core;

public abstract partial class AzureProjectFeature
{
    private ProvisionableResource? _resource;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProvisionableResource Resource
    {
        get
        {
            if (_resource == null)
            {
                throw new InvalidOperationException("Feature has not been emitted yet.");
            }
            return _resource;
        }
    }

    protected abstract ProvisionableResource EmitResources(ProjectInfrastructure infrastructure);

    protected void EmitConnection(ProjectInfrastructure infrastructure, string connectionId, string endpoint)
    {
        AppConfigurationSettingFeature connection = new(connectionId, endpoint, "cm_connection");
        infrastructure.AddFeature(connection);
    }

    protected internal virtual void AddImplicitFeatures(FeatureCollection features, string projectId) { }

    internal ProvisionableResource Emit(ProjectInfrastructure infrastructure)
    {
        if (_resource == null)
        {
            ProvisionableResource namedResource = EmitResources(infrastructure);
            _resource = namedResource;
        }
        return Resource;
    }

    protected static T EnsureEmits<T>(AzureProjectFeature feature)
    {
        if (feature.Resource is T typed)
            return typed;
        throw new ArgumentException($"Expected resource of type {typeof(T).Name}, but got {feature.GetType().Name}");
    }
}
