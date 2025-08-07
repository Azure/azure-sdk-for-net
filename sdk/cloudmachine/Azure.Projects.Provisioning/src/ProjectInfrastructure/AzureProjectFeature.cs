// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Projects.Core;

public abstract partial class AzureProjectFeature
{
    protected AzureProjectFeature(string id)
    {
        Id = id;
    }

    protected AzureProjectFeature()
    {
        Id = this.GetType().FullName!;
    }

    public string Id { get; }

    protected internal virtual void EmitFeatures(ProjectInfrastructure infrastructure) {
        infrastructure.Features.Append(this);
    }

    protected internal abstract void EmitConstructs(ProjectInfrastructure infrastructure);

    protected void EmitConnection(ProjectInfrastructure infrastructure, string connectionId, string endpoint)
    {
        infrastructure.Connections.EmitConnection(infrastructure, connectionId, endpoint);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => $"{this.GetType().Name} {this.Id}";
}
