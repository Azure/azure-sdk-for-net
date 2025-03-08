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
    public string Id { get; } = Guid.NewGuid().ToString();

    protected internal abstract void EmitResources(ProjectInfrastructure infrastructure);

    protected internal virtual void AddImplicitFeatures(FeatureCollection features, string projectId) { }

    protected void EmitConnection(ProjectInfrastructure infrastructure, string connectionId, string endpoint)
    {
        AppConfigurationSettingFeature connection = new(connectionId, endpoint, "cm_connection");
        infrastructure.AddFeature(connection);
    }
}
