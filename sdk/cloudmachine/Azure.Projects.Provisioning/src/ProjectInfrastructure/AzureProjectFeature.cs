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
    protected AzureProjectFeature(string id)
    {
        Id = id;
    }

    protected AzureProjectFeature()
    {
        Id = this.GetType().Name;
    }

    public string Id { get; }

    protected internal virtual void EmitFeatures(ProjectInfrastructure infrastructure) { }

    protected internal abstract void EmitConstructs(ProjectInfrastructure infrastructure);

    protected void EmitConnections(ProjectInfrastructure infrastructure, string connectionId, string endpoint)
    {
        AppConfigurationSettingFeature connection = new(connectionId, endpoint);
        infrastructure.AddFeature(connection);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => $"{this.GetType().Name} {this.Id}";
}
