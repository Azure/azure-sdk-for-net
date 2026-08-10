// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Projects.Core;

/// <summary>
/// Base class for all project provisioning features that emit Azure infrastructure constructs.
/// </summary>
public abstract partial class AzureProjectFeature
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AzureProjectFeature"/> class with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier for this feature.</param>
    protected AzureProjectFeature(string id)
    {
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AzureProjectFeature"/> class using the full type name as the identifier.
    /// </summary>
    protected AzureProjectFeature()
    {
        Id = this.GetType().FullName!;
    }

    /// <summary>
    /// Gets the unique identifier for this feature.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Emits this feature and any prerequisite features into the specified infrastructure.
    /// </summary>
    /// <param name="infrastructure">The project infrastructure to emit features into.</param>
    protected internal virtual void EmitFeatures(ProjectInfrastructure infrastructure)
    {
        infrastructure.Features.Append(this);
    }

    /// <summary>
    /// Emits the provisioning constructs for this feature into the specified infrastructure.
    /// </summary>
    /// <param name="infrastructure">The project infrastructure to emit constructs into.</param>
    protected internal abstract void EmitConstructs(ProjectInfrastructure infrastructure);

    /// <summary>
    /// Emits a connection entry for this feature into the project infrastructure.
    /// </summary>
    /// <param name="infrastructure">The project infrastructure to emit the connection into.</param>
    /// <param name="connectionId">The identifier for the connection.</param>
    /// <param name="endpoint">The endpoint URI for the connection.</param>
    protected void EmitConnection(ProjectInfrastructure infrastructure, string connectionId, string endpoint)
    {
        infrastructure.Connections.EmitConnection(infrastructure, connectionId, endpoint);
    }

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => $"{this.GetType().Name} {this.Id}";
}
