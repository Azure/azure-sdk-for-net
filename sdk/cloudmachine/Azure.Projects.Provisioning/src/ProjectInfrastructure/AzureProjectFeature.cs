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
    // TODO: this should not be a guid. It should be a nice human readable name
    public string Id { get; } = Guid.NewGuid().ToString();

    protected internal virtual void EmitFeatures(FeatureCollection features, string projectId) { }

    protected internal abstract void EmitConstructs(ProjectInfrastructure infrastructure);

    protected void EmitConnections(ProjectInfrastructure infrastructure, string connectionId, string endpoint)
    {
        AppConfigurationSettingFeature connection = new(connectionId, endpoint, "cm_connection");
        infrastructure.AddFeature(connection);
    }
}
